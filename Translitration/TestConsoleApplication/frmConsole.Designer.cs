namespace TestConsoleApplication
{
    partial class frmConsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lstStrictComplete = new System.Windows.Forms.ListBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.txtUrduAutocomplete = new System.Windows.Forms.TextBox();
            this.lstUrduAutocomplete = new System.Windows.Forms.ListBox();
            this.lstEnglishAutocomplete = new System.Windows.Forms.ListBox();
            this.txtEnglishAutocomplete = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEncodingPreview = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Urdu Autocomplete:";
            // 
            // lstStrictComplete
            // 
            this.lstStrictComplete.DisplayMember = "Key";
            this.lstStrictComplete.FormattingEnabled = true;
            this.lstStrictComplete.Location = new System.Drawing.Point(12, 73);
            this.lstStrictComplete.Name = "lstStrictComplete";
            this.lstStrictComplete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstStrictComplete.Size = new System.Drawing.Size(185, 355);
            this.lstStrictComplete.TabIndex = 2;
            this.lstStrictComplete.ValueMember = "Value";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Strict Complete:";
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(12, 12);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(75, 23);
            this.btnInitialize.TabIndex = 6;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // txtUrduAutocomplete
            // 
            this.txtUrduAutocomplete.Location = new System.Drawing.Point(203, 73);
            this.txtUrduAutocomplete.Name = "txtUrduAutocomplete";
            this.txtUrduAutocomplete.Size = new System.Drawing.Size(185, 20);
            this.txtUrduAutocomplete.TabIndex = 7;
            this.txtUrduAutocomplete.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUrduAutocomplete_KeyUp);
            // 
            // lstUrduAutocomplete
            // 
            this.lstUrduAutocomplete.DisplayMember = "Key";
            this.lstUrduAutocomplete.FormattingEnabled = true;
            this.lstUrduAutocomplete.Location = new System.Drawing.Point(203, 99);
            this.lstUrduAutocomplete.Name = "lstUrduAutocomplete";
            this.lstUrduAutocomplete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstUrduAutocomplete.Size = new System.Drawing.Size(185, 329);
            this.lstUrduAutocomplete.TabIndex = 8;
            this.lstUrduAutocomplete.ValueMember = "Value";
            // 
            // lstEnglishAutocomplete
            // 
            this.lstEnglishAutocomplete.DisplayMember = "Key";
            this.lstEnglishAutocomplete.FormattingEnabled = true;
            this.lstEnglishAutocomplete.Location = new System.Drawing.Point(394, 125);
            this.lstEnglishAutocomplete.Name = "lstEnglishAutocomplete";
            this.lstEnglishAutocomplete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstEnglishAutocomplete.Size = new System.Drawing.Size(185, 303);
            this.lstEnglishAutocomplete.TabIndex = 11;
            this.lstEnglishAutocomplete.ValueMember = "Value";
            // 
            // txtEnglishAutocomplete
            // 
            this.txtEnglishAutocomplete.Location = new System.Drawing.Point(394, 73);
            this.txtEnglishAutocomplete.Name = "txtEnglishAutocomplete";
            this.txtEnglishAutocomplete.Size = new System.Drawing.Size(185, 20);
            this.txtEnglishAutocomplete.TabIndex = 10;
            this.txtEnglishAutocomplete.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEnglishAutocomplete_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "English Autocomplete:";
            // 
            // txtEncodingPreview
            // 
            this.txtEncodingPreview.Location = new System.Drawing.Point(394, 99);
            this.txtEncodingPreview.Name = "txtEncodingPreview";
            this.txtEncodingPreview.Size = new System.Drawing.Size(185, 20);
            this.txtEncodingPreview.TabIndex = 12;
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 438);
            this.Controls.Add(this.txtEncodingPreview);
            this.Controls.Add(this.lstEnglishAutocomplete);
            this.Controls.Add(this.txtEnglishAutocomplete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstUrduAutocomplete);
            this.Controls.Add(this.txtUrduAutocomplete);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstStrictComplete);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Console Application";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmConsole_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstStrictComplete;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.TextBox txtUrduAutocomplete;
        private System.Windows.Forms.ListBox lstUrduAutocomplete;
        private System.Windows.Forms.ListBox lstEnglishAutocomplete;
        private System.Windows.Forms.TextBox txtEnglishAutocomplete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEncodingPreview;
    }
}

