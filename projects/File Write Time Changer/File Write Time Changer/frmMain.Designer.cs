namespace File_Write_Time_Changer
{
  partial class frmMain
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
      this.labelFileInfo = new System.Windows.Forms.Label();
      this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.buttonSelectFile = new System.Windows.Forms.Button();
      this.buttonQuit = new System.Windows.Forms.Button();
      this.labelFileName = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(14, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "File Name";
      // 
      // labelFileInfo
      // 
      this.labelFileInfo.AutoSize = true;
      this.labelFileInfo.Location = new System.Drawing.Point(14, 70);
      this.labelFileInfo.Name = "labelFileInfo";
      this.labelFileInfo.Size = new System.Drawing.Size(23, 13);
      this.labelFileInfo.TabIndex = 1;
      this.labelFileInfo.Text = "File";
      // 
      // dateTimePicker
      // 
      this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dateTimePicker.Location = new System.Drawing.Point(17, 35);
      this.dateTimePicker.Name = "dateTimePicker";
      this.dateTimePicker.Size = new System.Drawing.Size(285, 20);
      this.dateTimePicker.TabIndex = 2;
      this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
      // 
      // openFileDialog
      // 
      this.openFileDialog.FileName = "openFileDialog";
      // 
      // buttonSelectFile
      // 
      this.buttonSelectFile.Location = new System.Drawing.Point(142, 135);
      this.buttonSelectFile.Name = "buttonSelectFile";
      this.buttonSelectFile.Size = new System.Drawing.Size(77, 23);
      this.buttonSelectFile.TabIndex = 3;
      this.buttonSelectFile.Text = "Select File";
      this.buttonSelectFile.UseVisualStyleBackColor = true;
      this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
      // 
      // buttonQuit
      // 
      this.buttonQuit.Location = new System.Drawing.Point(225, 135);
      this.buttonQuit.Name = "buttonQuit";
      this.buttonQuit.Size = new System.Drawing.Size(77, 23);
      this.buttonQuit.TabIndex = 4;
      this.buttonQuit.Text = "Exit";
      this.buttonQuit.UseVisualStyleBackColor = true;
      this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
      // 
      // labelFileName
      // 
      this.labelFileName.AutoSize = true;
      this.labelFileName.Location = new System.Drawing.Point(74, 11);
      this.labelFileName.Name = "labelFileName";
      this.labelFileName.Size = new System.Drawing.Size(23, 13);
      this.labelFileName.TabIndex = 5;
      this.labelFileName.Text = "File";
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(323, 169);
      this.Controls.Add(this.labelFileName);
      this.Controls.Add(this.buttonQuit);
      this.Controls.Add(this.buttonSelectFile);
      this.Controls.Add(this.dateTimePicker);
      this.Controls.Add(this.labelFileInfo);
      this.Controls.Add(this.label1);
      this.Name = "frmMain";
      this.Text = "File Write Time Modifier";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labelFileInfo;
    private System.Windows.Forms.DateTimePicker dateTimePicker;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button buttonSelectFile;
    private System.Windows.Forms.Button buttonQuit;
    private System.Windows.Forms.Label labelFileName;
  }
}

