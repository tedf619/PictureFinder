namespace PictureFinder
{
  partial class FormImageInspector
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
      panelBottom = new Panel();
      buttonOk = new Button();
      pictureBox = new PictureBox();
      panelInfo = new Panel();
      labelDescription = new Label();
      labelCreated = new Label();
      labelSize = new Label();
      panelSpacer = new Panel();
      panelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
      panelInfo.SuspendLayout();
      SuspendLayout();
      // 
      // panelBottom
      // 
      panelBottom.Controls.Add(buttonOk);
      panelBottom.Dock = DockStyle.Bottom;
      panelBottom.Location = new Point(0, 433);
      panelBottom.Name = "panelBottom";
      panelBottom.Size = new Size(756, 38);
      panelBottom.TabIndex = 0;
      // 
      // buttonOk
      // 
      buttonOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      buttonOk.DialogResult = DialogResult.OK;
      buttonOk.Location = new Point(656, 6);
      buttonOk.Name = "buttonOk";
      buttonOk.Size = new Size(75, 26);
      buttonOk.TabIndex = 0;
      buttonOk.Text = "OK";
      buttonOk.UseVisualStyleBackColor = true;
      // 
      // pictureBox
      // 
      pictureBox.Dock = DockStyle.Fill;
      pictureBox.Location = new Point(0, 0);
      pictureBox.Name = "pictureBox";
      pictureBox.Size = new Size(756, 391);
      pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox.TabIndex = 1;
      pictureBox.TabStop = false;
      // 
      // panelInfo
      // 
      panelInfo.BackColor = Color.WhiteSmoke;
      panelInfo.BorderStyle = BorderStyle.FixedSingle;
      panelInfo.Controls.Add(labelDescription);
      panelInfo.Controls.Add(labelCreated);
      panelInfo.Controls.Add(labelSize);
      panelInfo.Dock = DockStyle.Bottom;
      panelInfo.Location = new Point(0, 401);
      panelInfo.Name = "panelInfo";
      panelInfo.Size = new Size(756, 32);
      panelInfo.TabIndex = 2;
      // 
      // labelDescription
      // 
      labelDescription.AutoEllipsis = true;
      labelDescription.Dock = DockStyle.Fill;
      labelDescription.Location = new Point(264, 0);
      labelDescription.Name = "labelDescription";
      labelDescription.Size = new Size(490, 30);
      labelDescription.TabIndex = 2;
      labelDescription.Text = "Description: ...";
      labelDescription.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // labelCreated
      // 
      labelCreated.Dock = DockStyle.Left;
      labelCreated.Location = new Point(124, 0);
      labelCreated.Name = "labelCreated";
      labelCreated.Size = new Size(140, 30);
      labelCreated.TabIndex = 1;
      labelCreated.Text = "Created: 2019-07-14";
      labelCreated.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // labelSize
      // 
      labelSize.Dock = DockStyle.Left;
      labelSize.Location = new Point(0, 0);
      labelSize.Name = "labelSize";
      labelSize.Padding = new Padding(5, 0, 0, 0);
      labelSize.Size = new Size(124, 30);
      labelSize.TabIndex = 0;
      labelSize.Text = "Size: 1920 x 1080";
      labelSize.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // panelSpacer
      // 
      panelSpacer.Dock = DockStyle.Bottom;
      panelSpacer.Location = new Point(0, 391);
      panelSpacer.Name = "panelSpacer";
      panelSpacer.Size = new Size(756, 10);
      panelSpacer.TabIndex = 3;
      // 
      // FormImageInspector
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(756, 471);
      Controls.Add(pictureBox);
      Controls.Add(panelSpacer);
      Controls.Add(panelInfo);
      Controls.Add(panelBottom);
      MinimumSize = new Size(300, 250);
      Name = "FormImageInspector";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Image Inspector";
      panelBottom.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
      panelInfo.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel panelBottom;
    private Button buttonOk;
    private PictureBox pictureBox;
    private Panel panelInfo;
    private Label labelSize;
    private Label labelDescription;
    private Label labelCreated;
    private Panel panelSpacer;
  }
}