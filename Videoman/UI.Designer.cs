namespace Videoman
{
    partial class UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.label1 = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.selectFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.bufferSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.bufferType = new System.Windows.Forms.ComboBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.passBox = new System.Windows.Forms.TextBox();
            this.encFileCheck = new System.Windows.Forms.CheckBox();
            this.removeFileCheck = new System.Windows.Forms.CheckBox();
            this.showPassBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bufferSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current File:";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Enabled = false;
            this.fileNameBox.Location = new System.Drawing.Point(81, 78);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(370, 20);
            this.fileNameBox.TabIndex = 1;
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(15, 12);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(194, 49);
            this.selectFile.TabIndex = 2;
            this.selectFile.Text = "SELECT FILE";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Title = "Select a File";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 113);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(597, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 4;
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(12, 145);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(597, 326);
            this.mediaPlayer.TabIndex = 5;
            this.mediaPlayer.Tag = "";
            // 
            // bufferSize
            // 
            this.bufferSize.Location = new System.Drawing.Point(318, 12);
            this.bufferSize.Name = "bufferSize";
            this.bufferSize.Size = new System.Drawing.Size(57, 20);
            this.bufferSize.TabIndex = 6;
            this.bufferSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Buffer Size (MiB):";
            // 
            // bufferType
            // 
            this.bufferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bufferType.Items.AddRange(new object[] {
            "KiB",
            "MiB",
            "GiB"});
            this.bufferType.Location = new System.Drawing.Point(381, 11);
            this.bufferType.Name = "bufferType";
            this.bufferType.Size = new System.Drawing.Size(71, 21);
            this.bufferType.TabIndex = 8;
            // 
            // resetBtn
            // 
            this.resetBtn.Enabled = false;
            this.resetBtn.Location = new System.Drawing.Point(534, 11);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 21);
            this.resetBtn.TabIndex = 9;
            this.resetBtn.Text = "Cancel";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Enabled = false;
            this.runBtn.Location = new System.Drawing.Point(534, 38);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 23);
            this.runBtn.TabIndex = 10;
            this.runBtn.Text = "GO";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Pass:";
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(274, 40);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '•';
            this.passBox.Size = new System.Drawing.Size(146, 20);
            this.passBox.TabIndex = 12;
            // 
            // encFileCheck
            // 
            this.encFileCheck.AutoSize = true;
            this.encFileCheck.Location = new System.Drawing.Point(458, 67);
            this.encFileCheck.Name = "encFileCheck";
            this.encFileCheck.Size = new System.Drawing.Size(104, 17);
            this.encFileCheck.TabIndex = 13;
            this.encFileCheck.Text = "Cypher file name";
            this.encFileCheck.UseVisualStyleBackColor = true;
            // 
            // removeFileCheck
            // 
            this.removeFileCheck.AutoSize = true;
            this.removeFileCheck.Location = new System.Drawing.Point(458, 90);
            this.removeFileCheck.Name = "removeFileCheck";
            this.removeFileCheck.Size = new System.Drawing.Size(99, 17);
            this.removeFileCheck.TabIndex = 14;
            this.removeFileCheck.Text = "Remove old file";
            this.removeFileCheck.UseVisualStyleBackColor = true;
            // 
            // showPassBtn
            // 
            this.showPassBtn.Location = new System.Drawing.Point(426, 38);
            this.showPassBtn.Name = "showPassBtn";
            this.showPassBtn.Size = new System.Drawing.Size(25, 23);
            this.showPassBtn.TabIndex = 15;
            this.showPassBtn.Text = "S";
            this.showPassBtn.UseVisualStyleBackColor = true;
            this.showPassBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShowPassBtn_MouseDown);
            this.showPassBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShowPassBtn_MouseUp);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 483);
            this.Controls.Add(this.showPassBtn);
            this.Controls.Add(this.removeFileCheck);
            this.Controls.Add(this.encFileCheck);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.bufferType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bufferSize);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.label1);
            this.Name = "UI";
            this.Text = "VideoMan";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bufferSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.NumericUpDown bufferSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox bufferType;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.CheckBox encFileCheck;
        private System.Windows.Forms.CheckBox removeFileCheck;
        private System.Windows.Forms.Button showPassBtn;
    }
}

