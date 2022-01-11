using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Image_Crop_GUI
{
    public partial class home : Form
    {
        string storeDir = @Directory.GetCurrentDirectory() + "\\vendor.txt";

        public home()
        {
            InitializeComponent();

            checkinter();


            if (!File.Exists(storeDir))
            {
                TextWriter txt = new StreamWriter(storeDir);
                txt.Close();
            }

            string[] lines = File.ReadAllLines(storeDir);
            foreach (string ln in lines)
            {
                email.Text = ln;
                break;
            }
        }

        private void checkinter()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check internet connection and restart application.");
                loginbtn.Enabled = false;
            }
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            checkinter();
            if (email.Text.Equals("") || password.Text.Equals(""))
            {
                MessageBox.Show("Fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                passwrd = passwrd.Replace("*", "");

                loginbtn.Enabled = false;
                loading.Visible = true;

                try
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ubs-v2.sourcecrafts.com/api/ubs/bifpdveqczboqowsfsfviwxjlspjeevh/vendor/login");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    //httpWebRequest.Timeout = 1000;
                    httpWebRequest.Headers.Add("cache-control", "no-cache");

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {

                        string json = "{\"email\":\"" + email.Text + "\"," +
                                      "\"password\":\"" + passwrd + "\"}";

                        streamWriter.Write(json);
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();

                        var json = JsonConvert.DeserializeObject<UGSSJsonResponse>(result);

                        if (json.status_code.Equals("200"))
                        {
                            //User.name = json.payload.name;
                            //User.role = json.payload.role;
                            //User.token = json.payload.token;

                            File.WriteAllText(storeDir, String.Empty);
                            string[] textLines = { email.Text, passwrd };
                            File.WriteAllLines(storeDir, textLines);

                            VerificationCapture form2 = new VerificationCapture();
                            form2.StartPosition = FormStartPosition.CenterScreen;
                            form2.Location = new Point(this.Location.X, this.Location.Y);
                            this.Visible = false;
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect email or password. \n\nMore Information:\n" + json.status_message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    loading.Visible = false;
                    loginbtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Server connection error. \n\nMore information:\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    loading.Visible = false;
                    loginbtn.Enabled = true;
                }
            }
        }
        string passwrd;
        private void password_TextChanged(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                passwrd = "";
            }

            passwrd += password.Text;
            if (password.Text == "" && password.Text.Contains('*'))
            {
                password.Text.Remove('*');
            }
            else
            {
            }
            password.Text = new string('*', password.Text.Length);

            password.SelectionStart = password.Text.Length;
            password.SelectionLength = 0;
        }
    }
}
