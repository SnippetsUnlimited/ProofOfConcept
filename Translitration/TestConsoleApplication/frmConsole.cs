using Company.Text.Transliteration;
using Company.Text.Transliteration.StrictTranslitration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestConsoleApplication
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
        }

        InputManager inputmanager = new InputManager();
        WordDictionary dic = null;

        private void frmConsole_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                lstStrictComplete.SelectedIndex--;
            }
            else if (e.KeyCode == Keys.Down)
            {
                lstStrictComplete.SelectedIndex++;
            }
            else
            {
                char newChar = char.ToLower((char)e.KeyValue);
                
                inputmanager.ProcessInput(newChar, true, lstStrictComplete.SelectedIndex);

                lstStrictComplete.DataSource = new BindingSource(inputmanager.GetSuggestions(), null);
                lstStrictComplete.DisplayMember = "Value";
                lstStrictComplete.ValueMember = "Key";

                if (lstStrictComplete.Items.Count > 0)
                {
                    lstStrictComplete.SelectedIndex = 0;
                }
            }
        }

        private void txtUrduAutocomplete_KeyUp(object sender, KeyEventArgs e)
        {
            var x = dic.GetUrduMatches(txtUrduAutocomplete.Text);
            DateTime now = DateTime.Now;
            lstUrduAutocomplete.DataSource = x;
            //lblSearchCount.Text = x.Count + " words";
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            dic = WordDictionary.Instance;
        }

        private void txtEnglishAutocomplete_KeyUp(object sender, KeyEventArgs e)
        {
            dic = WordDictionary.Instance;
            var result = dic.GetEnglish2UrduMatches(txtEnglishAutocomplete.Text);
            lstEnglishAutocomplete.DataSource = result;
        }

    }
}
