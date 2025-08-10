using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace shrtndClient
{
    public partial class shtrndForm : Form
    {
        public shtrndForm()
        {
            InitializeComponent();
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            if (txtInput.Text == "Enter your URL here...")
            {
                txtInput.Text = "";
                txtInput.ForeColor = Color.Black;
            }
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                txtInput.Text = "Enter your URL here...";
                txtInput.ForeColor = Color.DimGray;
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound
                shortenURL();
            }
        }

        private void btnShorten_Click(object sender, EventArgs e)
        {
            shortenURL();
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            copyData();
        }

        private void lblData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string targetURL = e.Link.LinkData as string;
            if (!string.IsNullOrEmpty(targetURL))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = targetURL,
                        UseShellExecute = true // use default browser
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open the link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void shortenURL()
        {
            string longURL = txtInput.Text.Trim();

            // Auto fix: add https:// prefix if missing
            if (!longURL.StartsWith("http://") && !longURL.StartsWith("https://"))
            {
                longURL = "https://" + longURL;
            }

            if (longURL == "Enter your URL here..." || string.IsNullOrWhiteSpace(longURL))
            {
                MessageBox.Show("Please enter a valid URL.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Regex to validate URL 
            var urlPattern = new System.Text.RegularExpressions.Regex(@"^(https?:\/\/)[^\s$.?#].[^\s]*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (!urlPattern.IsMatch(longURL))
            {
                MessageBox.Show("Please enter a valid URL. e.g(google.com)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var payload = new { url = longURL };
                    string jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);

                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://shrturl-u17c.onrender.com/shorten", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Failed to shorten the URL. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var responseString = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseString);

                    string shortURL = data.short_url;

                    lblData.Text = shortURL;
                    lblData.Links.Clear();
                    lblData.Links.Add(0, shortURL.Length, shortURL);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while shortening the URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
           
        }
        
        private void copyData()
        {
            if (string.IsNullOrWhiteSpace(lblData.Text))
            {
                return;
            }
            Clipboard.SetText(lblData.Text);
            btnCopy.Text = "Copied!";
            Task.Delay(3000).ContinueWith(t =>
            {
                Invoke(new Action(() => btnCopy.Text = "Copy"));
            });
        }
    }
}
