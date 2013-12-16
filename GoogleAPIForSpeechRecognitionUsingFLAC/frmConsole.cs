using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoogleAPIForSpeechRecognitionUsingFLAC
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
        }

        private void btnBroseWAV_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            fd.CheckFileExists = true;
            fd.Filter = "*.wav|*.wav";

            if (System.IO.File.Exists(fd.FileName))
            {
                txtFlacPath.Text = fd.FileName;
            }
        }

        private void btnPostToGoogle_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txtFlacPath.Text))
            {
                GoogleSpeechAPI api = new GoogleSpeechAPI();
                api.URL = txtGoogleURL.Text;  /* https://www.google.com/speech-api/v1/recognize?lang=en */
                txtResult.Text += api.GetTranscript(txtFlacPath.Text);
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {

        }
    }
}
