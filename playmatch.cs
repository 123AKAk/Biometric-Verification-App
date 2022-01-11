using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Collections;
using System.Drawing.Drawing2D;

using PatternRecognition.FingerprintRecognition.Core;
using PatternRecognition.ROC;
using PatternRecognition.FingerprintRecognition.FeatureExtractors;
using PatternRecognition.FingerprintRecognition.Matchers;
using PatternRecognition.FingerprintRecognition.ResourceProviders;
using ImageProcessingTools;

using OpenCvSharp;
using Newtonsoft.Json;
using System.Net;

namespace Image_Crop_GUI
{
    public partial class playmatch : Form
    {
        //crop
        private List<Point> polygonPoints = new List<Point>(); //mouse click points to crop image
        Point temp_point;
        private int x = 0, y = 0, temp_count, undocount = 0;
        IplImage resim; // original image
        Bitmap resimi, temp_im, bmp, croplast, Source, temp; // original image bitmap format for using System.Drawing.Graphics Class
        Graphics G, temp_g;
        Rectangle rectcrop;
        Pen a = new Pen(Color.Red, 2);
        //


        //match variables
        public double score;
        public string qry;
        public string matchtemp;

        bool checkforcrop = false;
        public playmatch()
        {
            InitializeComponent();
        }

        //does the necessary after loaded
        private void playmatch_Load(object sender, EventArgs e)
        {
            studregno.Text = VerificationCapture.studregmatricno;

            //loads passport
            passport.ImageLocation = VerificationCapture.passportprintpath;

            //puts verification image to box automatically
            matchtemp = VerificationCapture.verificationpath;
            newverificationimage.ImageLocation = VerificationCapture.verificationpath;

            //puts server image to box
            resim = IplImage.FromFile(VerificationCapture.serverfingerprintpath);
            pictureBox1.Image = resim.ToBitmap();
            first_refresh_im();

            runpoints();
        }

        public void crop()
        {
            try
            {
                timer1.Stop();
                IplImage accc = Cv.CreateImage(new CvSize(bmp.Width, bmp.Height), BitDepth.U8, 3);

                Graphics Ga = Graphics.FromImage(bmp);
                //the black image
                Ga.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, bmp.Width, bmp.Height));
                //draw from the last point to first point  
                Ga.DrawLine(new Pen(Color.Red, 3), polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);

                //all of the rgb values are being set 1 inside the polygon 
                SolidBrush Brush = new SolidBrush(Color.FromArgb(1, 1, 1));
                //we have to prepare one mask of Multiplying operation for cropping region
                G.FillClosedCurve(Brush, polygonPoints.ToArray());
                Cv.Mul(BitmapToIplImage(Source), BitmapToIplImage(bmp), accc, 1);

                computecrop();
                croplast = accc.ToBitmap().Clone(rectcrop, Source.PixelFormat);//just show cropped region part of image
                pictureBox2.Image = croplast; // crop region of image           
            }
            catch(Exception e)
            {
                MessageBox.Show("Error " + e);
            }

        }
        // we have to conversion from bitmap to IplImage to use OpenCvSharp methods
        public static IplImage BitmapToIplImage(Bitmap bitmap)
        {
            IplImage tmp, tmp2;

            Rectangle bRect = new Rectangle(new System.Drawing.Point(0, 0), new Size((int)bitmap.Width, (int)bitmap.Height));
            BitmapData bmData = bitmap.LockBits(bRect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            tmp = Cv.CreateImage(Cv.Size(bitmap.Width, bitmap.Height), BitDepth.U8, 3);
            tmp2 = Cv.CreateImage(Cv.Size(bitmap.Width, bitmap.Height), BitDepth.U8, 1);
            tmp.ImageData = bmData.Scan0; ;

            bitmap.UnlockBits(bmData);
           // Cv.CvtColor(tmp, tmp2, ColorConversion.RgbToGray);
            return tmp;
        }
        // this method computes rectangular start and end points of crop region
        private void computecrop()
        {
            int smallestX = resim.Width, biggestX = 0, biggestY = 0, smallestY = resim.Height;
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                biggestX = Math.Max(biggestX,polygonPoints[i].X);
                smallestX = Math.Min(smallestX,polygonPoints[i].X);

                biggestY = Math.Max(biggestY,polygonPoints[i].Y);
                smallestY = Math.Min(smallestY,polygonPoints[i].Y);
            }
                textBox1.Text = "biggestX=" + biggestX + " smallestX=" + smallestX + " biggestY=" + biggestY + " smallestY= " + smallestY;
            
            rectcrop = new Rectangle(smallestX, smallestY, biggestX - smallestX, biggestY - smallestY);
        }
        //when clicked crop button we stop timer and we have to start timer to crop new region
        private void refresh()
        {
            timer1.Start();
            first_refresh_im();
        }
        //if we slide the mouse unexpectedly and choose wrong points, we can undo mouse clicked points 
        private void undo()
        {
            undocount++;
            try{
                polygonPoints.RemoveRange(temp_count, 1);
                temp_count--;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            refresh_im(); // 
            G.Dispose(); // we have to dipose G object not to blow up ram
            DrawPolygon();

            G = Graphics.FromImage(bmp);
        }
        //draw polygon from coordinate values
        private void DrawPolygon()
        {
            temp = bmp;
            try
            {
                temp_g = Graphics.FromImage(temp);
            }
            catch
            {
                temp_g.Dispose();
            }
            textBox1.Text = "" + polygonPoints.Count;
            for (int i = 0; i < polygonPoints.Count - 1; i++)
            {
                this.DrawLinea(polygonPoints[i], polygonPoints[i + 1]);

            }
            bmp = temp;
           
        }
       //this method helps us to choose right points with drawing line between two points
        private void DrawLine(System.Drawing.Point p1, System.Drawing.Point p2)
        {
            
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            try
            {
                G.DrawLine(a, p1, p2);
            }
            catch(Exception ex)
            {
                this.Refresh();
                MessageBox.Show("Program has encountered an unexpected error and has to be reset." + ex);
            }

            pictureBox1.Image = bmp;
            

        }
        // when we undo point of region, we have to draw new polygon with ex-points of region
        //so in this point, we have to run re-draw lines with using called as Drawlinea method
        private void DrawLinea(System.Drawing.Point p1, System.Drawing.Point p2)
        {
            try
            {
                temp_g.SmoothingMode = SmoothingMode.AntiAlias;
                temp_g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                temp_g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                temp_g.DrawLine(a, p1.X, p1.Y, p2.X, p2.Y);
            }
            catch
            {
                temp_g.Dispose();
                MessageBox.Show("Program has encountered an unexpected error and has to be reset.");
            }
        }

        // we have refresh some assignments operators for new image or cropping new region
        private void first_refresh_im()
        {
            Rectangle rect = new Rectangle(0, 0, resim.Width, resim.Height);
            resimi = resim.ToBitmap() ;
            bmp = resimi.Clone(rect, resimi.PixelFormat);
            Source = resimi.Clone(rect, resimi.PixelFormat);
            pictureBox1.Image = bmp;
            G = Graphics.FromImage(bmp);
            polygonPoints.Clear();
        }
        // when we undo point of region, we have to create new rectangular object with using ex-points
        // and we have to need new bmp Source object
        private void refresh_im()
        {
            Rectangle rect = new Rectangle(0, 0, resim.Width, resim.Height);
            bmp = resimi.Clone(rect, resimi.PixelFormat);
            Source = resimi.Clone(rect, resimi.PixelFormat);
            pictureBox1.Image = bmp;

        }        

        //to choose points of crop region
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:

                    temp_point = new System.Drawing.Point(e.X, e.Y);
                    temp_count = polygonPoints.Count;

                    //MessageBox.Show(" temp_count|-" + temp_count+ " temp_point|-" + temp_point);

                    polygonPoints.Add(new System.Drawing.Point(e.X, e.Y));
                    if (polygonPoints.Count > 1)
                    {
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        temp_im = bmp.Clone(rect, PixelFormat.Format24bppRgb);
                        this.DrawLine(polygonPoints[polygonPoints.Count - 2], polygonPoints[polygonPoints.Count - 1]);

                        checkforcrop = true;
                    }
                    break;
                // in this point we can undo easily, with pushing mouse right click
                case MouseButtons.Right:

                    if (polygonPoints.Count > 0)
                    {
                        undo();
                    }
                    break;
            }
            pictureBox1.Image = bmp;
        }

        //in here, we take all of points mouse move 
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;

            this.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            textBox2.Text = "x=" + x + " y=" + y + " poly=" + polygonPoints.Count;
        }       

        private void Crop_page_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (uploadfingerprint.Enabled == false)
            {
                return;
            }

            a.Dispose();
            bmp.Dispose();
            this.Dispose();

            VerificationCapture form3 = new VerificationCapture();
            form3.Show();
            this.Hide();

        }

        private void undo_button_Click(object sender, EventArgs e)
        {
            undo();
        }
        private void refresh_button_Click(object sender, EventArgs e)
        {
            refresh();
            pictureBox2.ImageLocation = @Directory.GetCurrentDirectory() + "\\croplast.jpg";
        }
        private void cropimage(object sender, EventArgs e)
        {
            crop();
            try
            {
                if (checkforcrop == true)
                {
                    string mainfilename = "croplast.jpg";
                    croplast.Save(mainfilename, ImageFormat.Bmp);
                    qry = @Directory.GetCurrentDirectory() + "\\" + mainfilename;
                }
                else
                {
                    MessageBox.Show("Mark Point first before Cropping");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void runmatchagain(object sender, EventArgs e)
        {
            string amainfilename = "croplast.jpg";
            string aqry = @Directory.GetCurrentDirectory() + "\\" + amainfilename;
            match(aqry, matchtemp);
        }
        //run points
        public void runpoints()
        {
            //65 65
            //65 210
            //195 210
            //195 65
            //65 65

            bool checkerror = false;

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    temp_point = new System.Drawing.Point(39, 42);
                    //temp_count = polygonPoints.Count;
                    temp_count = i;

                    polygonPoints.Add(new System.Drawing.Point(39, 42));
                    if (polygonPoints.Count > 1)
                    {
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        temp_im = bmp.Clone(rect, PixelFormat.Format24bppRgb);
                        this.DrawLine(polygonPoints[polygonPoints.Count - 2], polygonPoints[polygonPoints.Count - 1]);
                    }
                }
                else if (i == 1)
                {
                    temp_point = new System.Drawing.Point(41, 209);
                    //temp_count = polygonPoints.Count;
                    temp_count = i;

                    polygonPoints.Add(new System.Drawing.Point(41, 209));
                    if (polygonPoints.Count > 1)
                    {
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        temp_im = bmp.Clone(rect, PixelFormat.Format24bppRgb);
                        this.DrawLine(polygonPoints[polygonPoints.Count - 2], polygonPoints[polygonPoints.Count - 1]);
                    }
                }
                else if (i == 2)
                {
                    temp_point = new System.Drawing.Point(190, 209);
                    //temp_count = polygonPoints.Count;
                    temp_count = i;

                    polygonPoints.Add(new System.Drawing.Point(190, 209));
                    if (polygonPoints.Count > 1)
                    {
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        temp_im = bmp.Clone(rect, PixelFormat.Format24bppRgb);
                        this.DrawLine(polygonPoints[polygonPoints.Count - 2], polygonPoints[polygonPoints.Count - 1]);
                    }
                }
                else if (i == 3)
                {
                    temp_point = new System.Drawing.Point(188, 44);
                    //temp_count = polygonPoints.Count;
                    temp_count = i;

                    polygonPoints.Add(new System.Drawing.Point(188, 44));
                    if (polygonPoints.Count > 1)
                    {
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        temp_im = bmp.Clone(rect, PixelFormat.Format24bppRgb);
                        this.DrawLine(polygonPoints[polygonPoints.Count - 2], polygonPoints[polygonPoints.Count - 1]);
                    }
                }
                else if (i == 4)
                {
                    temp_point = new System.Drawing.Point(38, 42);
                    //temp_count = polygonPoints.Count;
                    temp_count = i;

                    polygonPoints.Add(new System.Drawing.Point(38, 42));
                    if (polygonPoints.Count > 1)
                    {
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        temp_im = bmp.Clone(rect, PixelFormat.Format24bppRgb);
                        this.DrawLine(polygonPoints[polygonPoints.Count - 2], polygonPoints[polygonPoints.Count - 1]);
                    }
                }
                else
                {
                    MessageBox.Show("Error processing Image");
                    checkerror = true;
                }
                //MessageBox.Show("Last count: temp_count|-" + temp_count + " temp_point|-" + temp_point);
            }
            if (checkerror != true)
            {
                crop();
                string mainfilename = "croplast.jpg";
                croplast.Save(mainfilename, ImageFormat.Bmp);
                qry = @Directory.GetCurrentDirectory() + "\\" + mainfilename;
                first_refresh_im();
                match(qry, matchtemp);
            }
            else
            {
                return;
            }
        }

        //run fingerprint match here
        private Bitmap Change_Resolution(string file)
        {
            using (Bitmap bitmap = (Bitmap)Image.FromFile(file))
            {
                using (Bitmap newBitmap = new Bitmap(bitmap))
                {
                    newBitmap.SetResolution(500, 500);
                    return newBitmap;
                }
            }
        }

        private void match(string query, string template)
        {
            try
            {
                Change_Resolution(query);
                Change_Resolution(template);

                // Loading fingerprints
                var fingerprintImg1 = ImageLoader.LoadImage(query);
                var fingerprintImg2 = ImageLoader.LoadImage(template);
                //// Building feature extractor and extracting features
                var featExtractor = new PNFeatureExtractor() { MtiaExtractor = new Ratha1995MinutiaeExtractor() };
                var features1 = featExtractor.ExtractFeatures(fingerprintImg1);
                var features2 = featExtractor.ExtractFeatures(fingerprintImg2);

                // Building matcher and matching
                var matcher = new PN();
                double similarity = matcher.Match(features1, features2);
                //score = similarity.ToString("0.000");
                score = similarity;
                matchtxt.Text = score.ToString();
                if (score > 20)
                {
                    matchtxt.ForeColor = Color.Green;
                    matchstatus.Text = "Passed";
                    matchstatus.ForeColor = Color.Green;
                    uploadfingerprint.Enabled = true;
                }
                else if(score > 0)
                {
                    matchtxt.ForeColor = Color.Yellow;
                    matchstatus.Text = "Passed";
                    matchstatus.ForeColor = Color.Yellow;
                    uploadfingerprint.Enabled = true;
                }
                else
                {
                    matchtxt.ForeColor = Color.Red;
                    matchstatus.Text = "Failed";
                    matchstatus.ForeColor = Color.Red;
                    uploadfingerprint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //uploads new fingerprint to the server
        private void uploadfingerprint_Click(object sender, EventArgs e)
        {
            uploadfingerprint.Enabled = false;

            string uploadfingerprintbase64String = null;

            using (Image image = Image.FromFile(VerificationCapture.verificationpath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    uploadfingerprintbase64String = Convert.ToBase64String(imageBytes);
                }
            }

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ubs-v2.sourcecrafts.com/api/ubs/bifpdveqczboqowsfsfviwxjlspjeevh/biometric/update");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("cache-control", "no-cache");

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    string json = "{\"student_regno\":\"" + studregno.Text + "\"," +
                                    "\"bio_fingerprint\":\"" + uploadfingerprintbase64String + "\"}";

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    var json = JsonConvert.DeserializeObject<UGSSJsonResponse>(result);

                    if (json.status_code.Equals("200"))
                    {
                        MessageBox.Show("Saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loading.Text = "Saved successfully.";

                        a.Dispose();
                        bmp.Dispose();
                        this.Dispose();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Save failed. \n\nMore Information:\n" + json.status_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        loading.Text = "Save failed.";
                    }
                }

                loading.Visible = false;
                uploadfingerprint.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server connection error. \n\nMore information:\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loading.Visible = false;
                uploadfingerprint.Enabled = true;
            }
        }
    }
}
