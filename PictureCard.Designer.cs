namespace PictureFinder
{
  partial class PictureCard
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      panelBottom = new Panel();
      labelSize = new Label();
      labelBy = new Label();
      panelButton = new Panel();
      buttonDownload = new Button();
      pictureBox = new PictureBox();
      saveFileDialog = new SaveFileDialog();
      panelBottom.SuspendLayout();
      panelButton.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
      SuspendLayout();
      // 
      // panelBottom
      // 
      panelBottom.BorderStyle = BorderStyle.Fixed3D;
      panelBottom.Controls.Add(labelSize);
      panelBottom.Controls.Add(labelBy);
      panelBottom.Controls.Add(panelButton);
      panelBottom.Dock = DockStyle.Bottom;
      panelBottom.Location = new Point(0, 205);
      panelBottom.Name = "panelBottom";
      panelBottom.Size = new Size(236, 54);
      panelBottom.TabIndex = 1;
      // 
      // labelSize
      // 
      labelSize.Dock = DockStyle.Left;
      labelSize.Location = new Point(130, 0);
      labelSize.Name = "labelSize";
      labelSize.Padding = new Padding(0, 0, 5, 0);
      labelSize.Size = new Size(106, 20);
      labelSize.TabIndex = 2;
      labelSize.Text = "800 x 600";
      labelSize.TextAlign = ContentAlignment.MiddleRight;
      // 
      // labelBy
      // 
      labelBy.AutoEllipsis = true;
      labelBy.Dock = DockStyle.Left;
      labelBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      labelBy.Location = new Point(0, 0);
      labelBy.Name = "labelBy";
      labelBy.Size = new Size(130, 20);
      labelBy.TabIndex = 0;
      labelBy.Text = "By: John Doe";
      labelBy.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // panelButton
      // 
      panelButton.Controls.Add(buttonDownload);
      panelButton.Dock = DockStyle.Bottom;
      panelButton.Location = new Point(0, 20);
      panelButton.Name = "panelButton";
      panelButton.Size = new Size(232, 30);
      panelButton.TabIndex = 1;
      // 
      // buttonDownload
      // 
      buttonDownload.BackColor = Color.FromArgb(40, 167, 69);
      buttonDownload.Dock = DockStyle.Left;
      buttonDownload.FlatStyle = FlatStyle.Flat;
      buttonDownload.ForeColor = Color.White;
      buttonDownload.Location = new Point(0, 0);
      buttonDownload.Name = "buttonDownload";
      buttonDownload.Size = new Size(236, 30);
      buttonDownload.TabIndex = 0;
      buttonDownload.Text = "Download...";
      buttonDownload.UseVisualStyleBackColor = false;
      buttonDownload.Click += ButtonDownload_Click;
      // 
      // pictureBox
      // 
      pictureBox.Dock = DockStyle.Fill;
      pictureBox.Location = new Point(0, 0);
      pictureBox.Name = "pictureBox";
      pictureBox.Size = new Size(236, 205);
      pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox.TabIndex = 2;
      pictureBox.TabStop = false;
      pictureBox.DoubleClick += PictureBox_DoubleClick;
      // 
      // saveFileDialog
      // 
      saveFileDialog.Filter = "JPEG Image|*.jpeg|PNG Image|*.png|Bitmap Image|*.bmp";
      saveFileDialog.RestoreDirectory = true;
      saveFileDialog.Title = "Save Picture";
      // 
      // PictureCard
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      BorderStyle = BorderStyle.FixedSingle;
      Controls.Add(pictureBox);
      Controls.Add(panelBottom);
      Name = "PictureCard";
      Size = new Size(236, 259);
      panelBottom.ResumeLayout(false);
      panelButton.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel panelBottom;
    private Panel panelButton;
    private Button buttonDownload;
    private PictureBox pictureBox;
    private Label labelBy;
    private SaveFileDialog saveFileDialog;
    private Label labelSize;
  }
}
