using System;
using System.Windows.Forms;
using System.IO;


// This project has examples for the FileSystemWatcher (http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx) and
// making safe thread calls to form controls (http://msdn.microsoft.com/en-us/library/vstudio/ms171728(v=vs.100).aspx)

namespace DirectoryListenerTest
{
  public partial class frmMain : Form
  {

    // This delegate enables asynchronous calls 
    #region Thread Delegate
    // Delegate for setting the text property on a TextBox and Label control.
    delegate void SetTextCallback(string text);

    // Delegate for listing the files in the listFiles ListView.
    delegate void SetListFileCallback();
    #endregion

    #region Constructor and Destructor
    // Create a new FileSystemWatcher
    private FileSystemWatcher omFileSystemWatcher = new FileSystemWatcher();

    // Create a FolderBrowserDialog.  This will allow a user to select which
    // to watch
    FolderBrowserDialog omFolderBrowserDialog;

   
    public frmMain()
    {
      InitializeComponent();
      zzInitialize();
    }
    ~frmMain()
    {
      omFileSystemWatcher.EnableRaisingEvents = false;
      omFileSystemWatcher = null;
      omFolderBrowserDialog = null;
    }

    #endregion

    // Initializes the entire form and object properties and events
    #region Initializers

    /// <summary>
    /// Initialize the form properties, set defaults for TextBox and Labels
    /// and initialize watchers and events
    /// </summary>
    private void zzInitialize()
    {
      zzInitFormProperties();
      zzSetDirectoryText(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
      zzSetLabelText("", "");
      zzSetActionListeners();
      zzInitFolderBrowser();

      listFiles.Columns.Add("Files", 337);
      zzResetListFiles();
    }

    /// <summary>
    /// Set default properties of this form
    /// </summary>
    private void zzInitFormProperties()
    {
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Text = "File Watcher Test";
      
    }

    /// <summary>
    /// Initialize the FolderBrowserDialog
    /// </summary>
    private void zzInitFolderBrowser()
    {
      omFolderBrowserDialog = new FolderBrowserDialog();
      omFolderBrowserDialog.ShowNewFolderButton = false;
      omFolderBrowserDialog.Description = "Select the folder to watch.";
    }

    /// <summary>
    /// Initialize event handling for the FileSystemWatcher, textDirectory TextBox,
    /// the btnClose Button and the btnFolderBroswerDialog Button
    /// </summary>
    private void zzSetActionListeners()
    {
      // Set the directory to watch and start watching
      zzSetDirectoryListener(textDirectory.Text);

      // Watch for the textDirectory text to change and
      // then start watching that directory
      textDirectory.TextChanged += (sender, e) => 
      { 
        zzSetDirectoryListener(textDirectory.Text);
        zzResetListFiles();
      };

      // btnClose was clicked so close this application
      btnClose.Click += (sender, e) => { this.Close(); };

      // btnFolderBrowserDialog was clicked.  Run method to show dialog.
      btnFolderBrowserDialog.Click += (sender, e) => { zzFolderBrowserDialog(); };
    }

    
    #endregion

    // These methods demonstrates a pattern for making thread-safe
    // calls on a Windows Forms control. 
    //
    // If the calling thread is different from the thread that
    // created the TextBox control, these methods creates a
    // SetTextCallback and calls itself asynchronously using the
    // Invoke method.
    //
    // If the calling thread is the same as the thread that created
    // the TextBox control, the Text property is set directly. 
    #region Thread-safe methods

    /// <summary>
    /// Thread safe method to set the text of the lblFileName Label
    /// </summary>
    /// <param name="svFileName">The string value to display in the lblFileName Label</param>
    private void zzSetFileName(String svFileName)
    {

      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (lblFileName.InvokeRequired)
      {
        SetTextCallback d = new SetTextCallback(zzSetFileName);
        this.Invoke(d, new object[] { svFileName });
      } 
      else 
      {
        lblFileName.Text = svFileName;
      }

    }

    /// <summary>
    /// Thread safe method to set the text of the lblAction Label
    /// </summary>
    /// <param name="svAction">The string value to display in the lblAction Label</param>
    private void zzSetAction(String svAction)
    {

      if (lblAction.InvokeRequired)
      {
        SetTextCallback d = new SetTextCallback(zzSetAction);
        this.Invoke(d, new object[] { svAction });
      }
      else
      {
        lblAction.Text = svAction;
      }

    }

    /// <summary>
    /// Thread safe method to set the text of the textDirectory TextBox
    /// </summary>
    /// <param name="svPath">The text to display in the textDirectory TextBox</param>
    private void zzSetDirectoryText(String svPath)
    {
      if (textDirectory.InvokeRequired)
      {
        SetTextCallback d = new SetTextCallback(zzSetDirectoryText);
        this.Invoke(d, new object[] { svPath });
      }
      else
      {
        textDirectory.Text = svPath;
      }
    }

    private void zzResetListFiles()
    {
      if (listFiles.InvokeRequired)
      {
        SetListFileCallback d = new SetListFileCallback(zzResetListFiles);
        this.Invoke(d, new object[] { });
      }
      else
      {
        zzClearList();
        zzAddListItems();
      }
    }

    private void zzClearList()
    {

      listFiles.Items.Clear();

    }

    private void zzAddListItems()
    {
      try
      {
        DirectoryInfo olDirInfo = new DirectoryInfo(textDirectory.Text);

        foreach (FileInfo olFileInfo in olDirInfo.GetFiles("*.*"))
        {
          ListViewItem olFileItem = new ListViewItem(olFileInfo.Name);
          olFileItem.Tag = olFileInfo.FullName;
          listFiles.Items.Add(olFileItem);
        }

      }
      catch (Exception)
      {

        throw;
      }

    }
  
    #endregion

    // Listens to the file system change notifications 
    // and raises events when a directory, or file in 
    // a directory, changes.
    // Event Handlers for file changes or renames
    #region FileSystemWatcher and Event Handlers
    private void zzSetDirectoryListener(String svDirectory)
    {
      try
      {
        // Set the path for the FileSystemWatcher to watch
        omFileSystemWatcher.Path = svDirectory;

        // Watch for changes in LastAccess and LastWrite times, and
        // the renaming of files or directories.
        omFileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
          | NotifyFilters.FileName | NotifyFilters.DirectoryName;

        // Only watch Excel files.
        omFileSystemWatcher.Filter = "*.*";

        // Add event handlers for file notifications.
        omFileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
        omFileSystemWatcher.Created += new FileSystemEventHandler(OnChanged);
        omFileSystemWatcher.Deleted += new FileSystemEventHandler(OnChanged);
        omFileSystemWatcher.Renamed += new RenamedEventHandler(OnRenamed);

        // Begin watching.
        omFileSystemWatcher.EnableRaisingEvents = true;

      }
      catch (Exception)
      {
        return;

      }
    }

    /// <summary>
    /// Event Handler for when the watcher detects a file has been
    /// added, deleted or changed
    /// </summary>
    /// <param name="source">object</param>
    /// <param name="e">FileSystemEventArgs</param>
    private void OnChanged(object source, FileSystemEventArgs e)
    {
      // Specify what is done when a file is changed, created, or deleted.
      String slFile = e.Name;
      String slAction = "File " + slFile + " was: " + e.ChangeType;
      zzSetLabelText(slFile, slAction);
    }

    /// <summary>
    /// Event Handler for when the watcher detects a file's name has changed
    /// </summary>
    /// <param name="source">Object</param>
    /// <param name="e">RenamedEventArgs</param>
    private void OnRenamed(object source, RenamedEventArgs e)
    {
      // Specify what is done when a file is renamed.
      String slFile = e.Name;
      String slAction = "File " + e.OldName + " renamed to " + e.Name;
      zzSetLabelText(slFile, slAction);
    }
    #endregion

    // Helper Functions for changing Labels and Textboxes
    #region Functions
    /// <summary>
    /// Sets both the File and Action label Text.
    /// </summary>
    /// <param name="svFile">The name of the file changed or renamed</param>
    /// <param name="svAction">The action taken on the file.</param>
    private void zzSetLabelText(String svFile, String svAction)
    {
      zzSetAction(svAction);
      zzSetFileName(svFile);
      zzResetListFiles();
    }

    /// <summary>
    /// Shows the FolderDialog so a user can pick which folder to
    /// watch for file changes.
    /// </summary>
    private void zzFolderBrowserDialog()
    {
      DialogResult olResult = omFolderBrowserDialog.ShowDialog();
      if (olResult == DialogResult.OK)
      {
        zzSetDirectoryText(omFolderBrowserDialog.SelectedPath);
        System.Diagnostics.Process.Start(omFolderBrowserDialog.SelectedPath);
      }
    }
    #endregion

  }
}
