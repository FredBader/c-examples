using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_Write_Time_Changer
{
  public partial class frmMain : Form
  {

    FileInfo omFile;

    public frmMain()
    {
      InitializeComponent();
      zzInitialize();
    }
    
    /// <summary>
    /// Initialize the form components and set the default values for this project
    /// </summary>
    private void zzInitialize()
    {
      try
      {
        dateTimePicker.Format = DateTimePickerFormat.Custom;
        dateTimePicker.CustomFormat = "MMMM dd, yyyy - dddd HH:mm:ss";

        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "All files (*.*)|*.*";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;
        openFileDialog.Multiselect = false;

        zzSetFileInfoEx("Please select a file.", DateTime.Now, "");
      }
      catch (Exception ex)
      {

        MessageBox.Show("Error: " + ex.Message);
        return;
      }

    }

    /// <summary>
    /// Prompts for a file and then displays the information for the file
    /// </summary>
    private void zzSelectFile()
    {

      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        try
        {
          omFile = new FileInfo(openFileDialog.FileName);
          zzSetFileInfoEx(omFile);
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        }
      }
    }

    /// <summary>
    /// Set the values for the form labels and DateTime picker
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="dateFile"></param>
    /// <param name="fileInfo"></param>
    private void zzSetFileInfoEx(String fileName, 
                                 DateTime dateFile, 
                                 String fileInfo)
    {
      try
      {
        labelFileName.Text = fileName;
        dateTimePicker.Value = dateFile;
        labelFileInfo.Text = fileInfo;
      }
      catch (Exception ex)
      {

        MessageBox.Show("Error: " + ex.Message);
        return;
      }

    }

    private void zzSetFileInfoEx(FileInfo fileInfo)
    {
      try
      {
        if (fileInfo.Equals(null))
          return;

        zzSetFileInfoEx(fileInfo.Name, fileInfo.LastWriteTime, fileInfo.FullName);
      }
      catch (Exception ex)
      {

        MessageBox.Show("Error: " + ex.Message);
        return;
      }

    }

    private void buttonSelectFile_Click(object sender, EventArgs e)
    {
      zzSelectFile();
    }

    private void buttonQuit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void dateTimePicker_ValueChanged(object sender, EventArgs e)
    {
      try
      {
        omFile.LastWriteTime = dateTimePicker.Value;
      }
      catch (Exception)
      {

        return;
      }
    }
  }
}
