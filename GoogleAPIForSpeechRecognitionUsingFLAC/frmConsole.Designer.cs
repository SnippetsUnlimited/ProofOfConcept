namespace GoogleAPIForSpeechRecognitionUsingFLAC
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtFlacPath = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnPostToGoogle = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnBroseWAV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGoogleURL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Output Path:";
            // 
            // txtFlacPath
            // 
            this.txtFlacPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFlacPath.Location = new System.Drawing.Point(91, 16);
            this.txtFlacPath.Name = "txtFlacPath";
            this.txtFlacPath.Size = new System.Drawing.Size(430, 20);
            this.txtFlacPath.TabIndex = 16;
            this.txtFlacPath.Text = "c:\\HelloWorld.flac";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(527, 251);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 15;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnPostToGoogle
            // 
            this.btnPostToGoogle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPostToGoogle.Location = new System.Drawing.Point(526, 40);
            this.btnPostToGoogle.Name = "btnPostToGoogle";
            this.btnPostToGoogle.Size = new System.Drawing.Size(75, 23);
            this.btnPostToGoogle.TabIndex = 14;
            this.btnPostToGoogle.Text = "Send";
            this.btnPostToGoogle.UseVisualStyleBackColor = true;
            this.btnPostToGoogle.Click += new System.EventHandler(this.btnPostToGoogle_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(90, 68);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(430, 207);
            this.txtResult.TabIndex = 13;
            // 
            // btnBroseWAV
            // 
            this.btnBroseWAV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBroseWAV.Location = new System.Drawing.Point(526, 13);
            this.btnBroseWAV.Name = "btnBroseWAV";
            this.btnBroseWAV.Size = new System.Drawing.Size(75, 23);
            this.btnBroseWAV.TabIndex = 12;
            this.btnBroseWAV.Text = "Browse ...";
            this.btnBroseWAV.UseVisualStyleBackColor = true;
            this.btnBroseWAV.Click += new System.EventHandler(this.btnBroseWAV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Post URL:";
            // 
            // txtGoogleURL
            // 
            this.txtGoogleURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoogleURL.Location = new System.Drawing.Point(90, 42);
            this.txtGoogleURL.Name = "txtGoogleURL";
            this.txtGoogleURL.Size = new System.Drawing.Size(430, 20);
            this.txtGoogleURL.TabIndex = 10;
            this.txtGoogleURL.Text = "https://www.google.com/speech-api/v1/recognize?lang=en";
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 289);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFlacPath);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnPostToGoogle);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnBroseWAV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGoogleURL);
            this.Name = "frmConsole";
            this.Text = "POC - Google API";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFlacPath;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnPostToGoogle;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnBroseWAV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGoogleURL;
    }
}

