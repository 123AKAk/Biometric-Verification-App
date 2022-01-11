using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;   
using System.Net;
using Newtonsoft.Json;

namespace Image_Crop_GUI
{
    public partial class VerificationCapture : Form, DPFP.Capture.EventHandler
    {
        public int index = 0;

        public Bitmap export;

        //text to be displayed on the image
        //public string[] names = { "Right Thumb" };
        public string[] names = { "" };
        //public string[] names = { "Right Thumb", "Left Thumb", "Right Index", "Left Index", "Right Middle", "Left Middle", "Right Ring", "Left Ring", "Right Pinky", "Left Pinky", "Right Toe", "Left Toe" };

        public List<Bitmap> images = new List<Bitmap>();

        public bool current_image_saved = false;

        public Bitmap bmp;

        public bool fingerprocesed = false;

        string exportDir = @Directory.GetCurrentDirectory() + "\\exports\\";

        public VerificationCapture()
        {
            InitializeComponent();

            if (!Directory.Exists(exportDir))
            {
                Directory.CreateDirectory(exportDir);
            }
        }
        private void VerificationCapture_Load(object sender, EventArgs e)
        {
            Init();
            Start();
            save_btn.Visible = true;
        }

        protected virtual void Init()
        {
            bmp = new Bitmap(init_image.Image);
            try
            {
                Capturer = new DPFP.Capture.Capture();              // Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;                   // Subscribe for capturing events.
                else
                    SetPrompt("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void Process(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                }
                catch
                {
                    SetPrompt("Can't initiate capture!");
                }
                save_btn.Top = 360;
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("Can't terminate capture!");
                }
            }
        }

        #region Form Event Handlers:
        #endregion

        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            Process(Sample);
            fingerprocesed = true;
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //finger removed
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //finger touched
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            SetPrompt("Fingerprint device connected!");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            SetError("Fingerprint device disconnected!");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.LowContrast)
            {
                //quality poor
                MessageBox.Show("Low Constrast", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CaptureFeedback == DPFP.Capture.CaptureFeedback.NoFinger)
            {
                //quality poor
                MessageBox.Show("No Finger", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CaptureFeedback == DPFP.Capture.CaptureFeedback.TooFast)
            {
                //quality poor
                MessageBox.Show("Too Fast", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CaptureFeedback == DPFP.Capture.CaptureFeedback.TooLow)
            {
                //quality poor
                MessageBox.Show("Too Low", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CaptureFeedback == DPFP.Capture.CaptureFeedback.TooNoisy)
            {
                //quality poor
                MessageBox.Show("Too Noisy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CaptureFeedback == DPFP.Capture.CaptureFeedback.NoCentralRegion)
            {
                //quality poor
                MessageBox.Show("No Central Region", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CaptureFeedback == DPFP.Capture.CaptureFeedback.TooDark)
            {
                //quality poor
                MessageBox.Show("Too Dark", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CaptureFeedback == DPFP.Capture.CaptureFeedback.TooLight)
            {
                //quality poor
                MessageBox.Show("Too Light", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //quality good
                //if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                //{

                //}
            }
        }
        #endregion

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                MessageBox.Show("FingerPrint Quality is Badd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
        }

        protected void SetPrompt(string prompt)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(prompt, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        protected void SetError(string prompt)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(prompt, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke((MethodInvoker)delegate
            {
                bmp = new Bitmap(bitmap, new Size(Picture.Width + 20, Picture.Height + 20));
                Picture.Image = bmp;
            });
        }

        private DPFP.Capture.Capture Capturer;

      
        private void next_item_Click(object sender, EventArgs e)
        {
            if (current_image_saved == true)
            {
                if (index <= 0)
                {
                    index++;
                }
                try
                {
                    Picture.Image = images[index];
                    bmp = images[index];
                    current_image_saved = true;
                }
                catch (Exception)
                {
                    Picture.Image = init_image.Image;
                    bmp = new Bitmap(init_image.Image);
                    current_image_saved = false;
                }
                capture_title.Text = "Capture " + names[index];
            }
            else
            {
                MessageBox.Show("Fingerprint sample not saved yet!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void previous_item_Click(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                index--;
            }
            try
            {
                Picture.Image = images[index];
                bmp = images[index];
                current_image_saved = true;
            }
            catch (Exception)
            {
                Picture.Image = init_image.Image;
                bmp = new Bitmap(init_image.Image);
                current_image_saved = false;
            }
            capture_title.Text = "Capture " + names[index];
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                images[index] = bmp;
                if (fingerprocesed == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    runnextclick();
                }
            }
            catch (Exception)
            {
                images.Add(bmp);
                runnextclick();
            }
            current_image_saved = true;
        }

        string fingerprintbas64 = null;
        string passportbase64 = null;
        public void runnextclick()
        {
            //draws and saves the image
            if (regmaticno.Text.Equals(""))
            {
                MessageBox.Show("Reg/Matric No. Cannot be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fingerprocesed == true)
            {
                serverfingerprintpath = @Directory.GetCurrentDirectory() + "\\exports\\" + String.Format(regmaticno.Text.Replace('/', '-').ToLower()) + "-fingerprint-orignal.jpg";
                passportprintpath = @Directory.GetCurrentDirectory() + "\\exports\\" + String.Format(regmaticno.Text.Replace('/', '-').ToLower()) + "-passport-orignal.jpg";
                studregmatricno = regmaticno.Text;
                try
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ubs-v2.sourcecrafts.com/api/ubs/bifpdveqczboqowsfsfviwxjlspjeevh/biometric/identify");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("cache-control", "no-cache");

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {

                        string json = "{\"student_regno\":\"" + regmaticno.Text + "\"}";

                        streamWriter.Write(json);
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();

                        var json = JsonConvert.DeserializeObject<UGSSJsonResponse>(result);

                        if (json.status_code.Equals("200"))
                        {
                            //gets base64 string
                            fingerprintbas64 = json.payload.bio_fingerprint;
                            passportbase64 = json.payload.bio_passport;

                            byte[] finngerprintbytes = Convert.FromBase64String(fingerprintbas64);
                            Image finngerprintimage;
                            using (MemoryStream ms = new MemoryStream(finngerprintbytes))
                            {
                                finngerprintimage = Image.FromStream(ms);
                                finngerprintimage.Save(serverfingerprintpath, ImageFormat.Jpeg);
                            }

                            byte[] passportbytes = Convert.FromBase64String(passportbase64);
                            Image passportimage;
                            using (MemoryStream ms = new MemoryStream(passportbytes))
                            {
                                passportimage = Image.FromStream(ms);
                                passportimage.Save(passportprintpath, ImageFormat.Jpeg);
                            }

                            //if base64 img request is successful run the remaining requests
                            finish_Click();
                        }
                        else
                        {
                            MessageBox.Show("Verification failed. \n\nMore Information:\n" + json.status_message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Server connection error. \n\nMore information:\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public static string verificationpath = null;
        public static string serverfingerprintpath = null;
        public static string passportprintpath = null;
        public static string studregmatricno = null;
        public void finish_Click()
        {
            Bitmap bmp = new Bitmap(preview_img.Width, preview_img.Height);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, preview_img.Width, preview_img.Height);
                graph.FillRectangle(Brushes.White, ImageSize);
            }
            preview_img.Image = bmp;
            capture_title.Text = "Captured";
            preview_img.Visible = true;
            drawImg();
            Stop();

            //export the fingerprint file
            string filename = @exportDir + String.Format(regmaticno.Text.Replace('/', '-').ToLower()) + "-new.jpg";

            export.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            verificationpath = filename;
            
            playmatch form2 = new playmatch();
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Location = new Point(this.Location.X, this.Location.Y);
            this.Visible = false;
            form2.Show();
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        public void drawImg()
        {
            int start_y = 10;
            int start_x = 10;
            int cnt = 0;
            int stepper_x = (int)(preview_img.Width - 0) / 1;
            int stepper_y = (int)(preview_img.Height - 0) / 1;

            Bitmap screen = new Bitmap(preview_img.Image, preview_img.Size);

            Graphics g = Graphics.FromImage(screen);

            RectangleF rect_text = new RectangleF(200, 15, preview_img.Width, 50);
            //g.DrawString(String.Format("", mainregno), new Font("Segoe UI Symbol", 12, FontStyle.Bold), Brushes.Black, rect_text);

            foreach (Bitmap bitmap in images)
            {
                int w = stepper_x - 10;
                int h = stepper_y - 10;

                Bitmap small = new Bitmap(bitmap, w - 12, h - 12);

                g.DrawImage(small, new Point(start_x, start_y));

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                RectangleF rectf = new RectangleF(start_x + 10, (start_y + h) - 8, stepper_x, 20);

                g.DrawString(names[cnt], new Font("Segoe UI Symbol", 8, FontStyle.Bold), Brushes.Black, rectf);

                preview_img.Image = screen;

                export = screen;

                cnt++;
                start_x += stepper_x;
                if (cnt == 6)
                {
                    start_x = 45;
                    start_y += stepper_y;
                }
            }
            g.Flush();
        }

        private void Capture_FormClosed(object sender, FormClosedEventArgs e)
        {
            home form3 = new home();
            form3.Show();
            this.Hide();
        }

        
    }
}