namespace DirectoryListenerTest
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
      this.titleFileName = new System.Windows.Forms.Label();
      this.lblFileName = new System.Windows.Forms.Label();
      this.titleAction = new System.Windows.Forms.Label();
      this.titleDirectory = new System.Windows.Forms.Label();
      this.textDirectory = new System.Windows.Forms.TextBox();
      this.lblAction = new System.Windows.Forms.Label();
      this.btnClose = new System.Windows.Forms.Button();
      this.btnFolderBrowserDialog = new System.Windows.Forms.Button();
      this.listFiles = new System.Windows.Forms.ListView();
      this.SuspendLayout();
      // 
      // titleFileName
      // 
      this.titleFileName.AutoSize = true;
      this.titleFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.titleFileName.Location = new System.Drawing.Point(12, 61);
      this.titleFileName.Name = "titleFileName";
      this.titleFileName.Size = new System.Drawing.Size(63, 13);
      this.titleFileName.TabIndex = 0;
      this.titleFileName.Text = "File Name";
      // 
      // lblFileName
      // 
      this.lblFileName.AutoSize = true;
      this.lblFileName.Location = new System.Drawing.Point(12, 81);
      this.lblFileName.Name = "lblFileName";
      this.lblFileName.Size = new System.Drawing.Size(54, 13);
      this.lblFileName.TabIndex = 1;
      this.lblFileName.Text = "File Name";
      // 
      // titleAction
      // 
      this.titleAction.AutoSize = true;
      this.titleAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.titleAction.Location = new System.Drawing.Point(12, 116);
      this.titleAction.Name = "titleAction";
      this.titleAction.Size = new System.Drawing.Size(43, 13);
      this.titleAction.TabIndex = 2;
      this.titleAction.Text = "Action";
      // 
      // titleDirectory
      // 
      this.titleDirectory.AutoSize = true;
      this.titleDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.titleDirectory.Location = new System.Drawing.Point(12, 9);
      this.titleDirectory.Name = "titleDirectory";
      this.titleDirectory.Size = new System.Drawing.Size(58, 13);
      this.titleDirectory.TabIndex = 3;
      this.titleDirectory.Text = "Directory";
      // 
      // textDirectory
      // 
      this.textDirectory.Location = new System.Drawing.Point(15, 30);
      this.textDirectory.Name = "textDirectory";
      this.textDirectory.Size = new System.Drawing.Size(313, 20);
      this.textDirectory.TabIndex = 6;
      // 
      // lblAction
      // 
      this.lblAction.Location = new System.Drawing.Point(12, 135);
      this.lblAction.Name = "lblAction";
      this.lblAction.Size = new System.Drawing.Size(340, 32);
      this.lblAction.TabIndex = 7;
      this.lblAction.Text = "Action";
      // 
      // btnClose
      // 
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(257, 506);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(95, 23);
      this.btnClose.TabIndex = 8;
      this.btnClose.Text = "Exit";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // btnFolderBrowserDialog
      // 
      this.btnFolderBrowserDialog.AutoEllipsis = true;
      this.btnFolderBrowserDialog.Location = new System.Drawing.Point(329, 30);
      this.btnFolderBrowserDialog.Name = "btnFolderBrowserDialog";
      this.btnFolderBrowserDialog.Size = new System.Drawing.Size(23, 20);
      this.btnFolderBrowserDialog.TabIndex = 9;
      this.btnFolderBrowserDialog.UseVisualStyleBackColor = true;
      // 
      // listFiles
      // 
      this.listFiles.Location = new System.Drawing.Point(10, 170);
      this.listFiles.MultiSelect = false;
      this.listFiles.Name = "listFiles";
      this.listFiles.Size = new System.Drawing.Size(341, 326);
      this.listFiles.TabIndex = 10;
      this.listFiles.UseCompatibleStateImageBehavior = false;
      this.listFiles.View = System.Windows.Forms.View.Details;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(372, 541);
      this.Controls.Add(this.listFiles);
      this.Controls.Add(this.btnFolderBrowserDialog);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.lblAction);
      this.Controls.Add(this.textDirectory);
      this.Controls.Add(this.titleDirectory);
      this.Controls.Add(this.titleAction);
      this.Controls.Add(this.lblFileName);
      this.Controls.Add(this.titleFileName);
      this.Name = "frmMain";
      this.Text = "Directory Listener Test";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label titleFileName;
    private System.Windows.Forms.Label lblFileName;
    private System.Windows.Forms.Label titleAction;
    private System.Windows.Forms.Label titleDirectory;
    private System.Windows.Forms.TextBox textDirectory;
    private System.Windows.Forms.Label lblAction;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnFolderBrowserDialog;
    private System.Windows.Forms.ListView listFiles;
  }
}

