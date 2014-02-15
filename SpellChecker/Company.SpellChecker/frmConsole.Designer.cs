namespace Company.SpellChecker
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
            this.label4 = new System.Windows.Forms.Label();
            this.numTolerance = new System.Windows.Forms.NumericUpDown();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDictionary = new System.Windows.Forms.TextBox();
            this.lblSuggestionProcessingTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSuggestionCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSuggestions = new System.Windows.Forms.ListBox();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.lblAutoCompleteProcessingTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAutoCompleteCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbAutoComplete = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Tolerance:";
            // 
            // numTolerance
            // 
            this.numTolerance.Location = new System.Drawing.Point(72, 37);
            this.numTolerance.Name = "numTolerance";
            this.numTolerance.Size = new System.Drawing.Size(91, 20);
            this.numTolerance.TabIndex = 45;
            this.numTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTolerance.ValueChanged += new System.EventHandler(this.numTolerance_ValueChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(381, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 23);
            this.btnLoad.TabIndex = 44;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Dictionary:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(293, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(82, 23);
            this.btnBrowse.TabIndex = 42;
            this.btnBrowse.Text = "Browse ...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDictionary
            // 
            this.txtDictionary.Location = new System.Drawing.Point(72, 7);
            this.txtDictionary.Name = "txtDictionary";
            this.txtDictionary.Size = new System.Drawing.Size(215, 20);
            this.txtDictionary.TabIndex = 41;
            // 
            // lblSuggestionProcessingTime
            // 
            this.lblSuggestionProcessingTime.AutoSize = true;
            this.lblSuggestionProcessingTime.Location = new System.Drawing.Point(342, 450);
            this.lblSuggestionProcessingTime.Name = "lblSuggestionProcessingTime";
            this.lblSuggestionProcessingTime.Size = new System.Drawing.Size(10, 13);
            this.lblSuggestionProcessingTime.TabIndex = 40;
            this.lblSuggestionProcessingTime.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Processing Time:";
            // 
            // lblSuggestionCount
            // 
            this.lblSuggestionCount.AutoSize = true;
            this.lblSuggestionCount.Location = new System.Drawing.Point(333, 104);
            this.lblSuggestionCount.Name = "lblSuggestionCount";
            this.lblSuggestionCount.Size = new System.Drawing.Size(10, 13);
            this.lblSuggestionCount.TabIndex = 38;
            this.lblSuggestionCount.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Suggestions:";
            // 
            // lbSuggestions
            // 
            this.lbSuggestions.FormattingEnabled = true;
            this.lbSuggestions.Location = new System.Drawing.Point(247, 124);
            this.lbSuggestions.Name = "lbSuggestions";
            this.lbSuggestions.Size = new System.Drawing.Size(216, 316);
            this.lbSuggestions.TabIndex = 36;
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Location = new System.Drawing.Point(12, 73);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(451, 20);
            this.txtSearchWord.TabIndex = 35;
            this.txtSearchWord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchWord_KeyUp);
            // 
            // lblAutoCompleteProcessingTime
            // 
            this.lblAutoCompleteProcessingTime.AutoSize = true;
            this.lblAutoCompleteProcessingTime.Location = new System.Drawing.Point(107, 450);
            this.lblAutoCompleteProcessingTime.Name = "lblAutoCompleteProcessingTime";
            this.lblAutoCompleteProcessingTime.Size = new System.Drawing.Size(10, 13);
            this.lblAutoCompleteProcessingTime.TabIndex = 51;
            this.lblAutoCompleteProcessingTime.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Processing Time:";
            // 
            // lblAutoCompleteCount
            // 
            this.lblAutoCompleteCount.AutoSize = true;
            this.lblAutoCompleteCount.Location = new System.Drawing.Point(98, 104);
            this.lblAutoCompleteCount.Name = "lblAutoCompleteCount";
            this.lblAutoCompleteCount.Size = new System.Drawing.Size(10, 13);
            this.lblAutoCompleteCount.TabIndex = 49;
            this.lblAutoCompleteCount.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Auto Complete:";
            // 
            // lbAutoComplete
            // 
            this.lbAutoComplete.FormattingEnabled = true;
            this.lbAutoComplete.Location = new System.Drawing.Point(12, 124);
            this.lbAutoComplete.Name = "lbAutoComplete";
            this.lbAutoComplete.Size = new System.Drawing.Size(216, 316);
            this.lbAutoComplete.TabIndex = 47;
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 483);
            this.Controls.Add(this.lblAutoCompleteProcessingTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAutoCompleteCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbAutoComplete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numTolerance);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDictionary);
            this.Controls.Add(this.lblSuggestionProcessingTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSuggestionCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSuggestions);
            this.Controls.Add(this.txtSearchWord);
            this.Name = "frmConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spell Checker";
            this.Load += new System.EventHandler(this.frmConsole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTolerance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numTolerance;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDictionary;
        private System.Windows.Forms.Label lblSuggestionProcessingTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSuggestionCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbSuggestions;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.Label lblAutoCompleteProcessingTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAutoCompleteCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbAutoComplete;
    }
}

