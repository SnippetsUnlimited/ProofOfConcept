using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Company.SpellChecker.Library;

namespace Company.SpellChecker
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                EnglishDictionary.Instance.Initialize(new string[] { txtDictionary.Text });
                MessageBox.Show("Dictionary successfully loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            fd.CheckFileExists = true;
            fd.Filter = "*.txt|*.txt";

            if (System.IO.File.Exists(fd.FileName))
            {
                txtDictionary.Text = fd.FileName;
            }
        }

        private DiagnosticsUtils.ExecutionStopwatch stopwatch = new DiagnosticsUtils.ExecutionStopwatch();


        private void txtSearchWord_KeyUp(object sender, KeyEventArgs e)
        {
            {

                stopwatch.Start();
                var result = EnglishDictionary.Instance.GetMatches(txtSearchWord.Text);
                stopwatch.Stop();
                
                lblAutoCompleteProcessingTime.Text = stopwatch.ElapsedTicks.ToString();

                lbAutoComplete.DataSource = result;
                lblAutoCompleteCount.Text = result.Count + " words";
            }
            {
                stopwatch.Start();
                var result = EnglishDictionary.Instance.GetSuggestions(txtSearchWord.Text, Convert.ToInt32(numTolerance.Value));
                stopwatch.Stop();

                lblSuggestionProcessingTime.Text = stopwatch.ElapsedTicks.ToString();

                lbSuggestions.DataSource = result;
                lblSuggestionCount.Text = result.Count + " words";
            }


        }

        private void frmConsole_Load(object sender, EventArgs e)
        {
        }

        private void numTolerance_ValueChanged(object sender, EventArgs e)
        {
            txtSearchWord_KeyUp(sender, new KeyEventArgs(Keys.Cancel));
        }
    }
}
