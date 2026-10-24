namespace PictureFinder
{
  partial class FormMain
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      panelTop = new Panel();
      buttonSearch = new Button();
      textBoxSearch = new TextBox();
      panelBottom = new Panel();
      labelStatusbarMessage = new Label();
      panelMiddle = new Panel();
      flowLayoutPanelPictures = new FlowLayoutPanel();
      panelResultsTitle = new Panel();
      label1 = new Label();
      label2 = new Label();
      panelTop.SuspendLayout();
      panelBottom.SuspendLayout();
      panelMiddle.SuspendLayout();
      panelResultsTitle.SuspendLayout();
      SuspendLayout();
      // 
      // panelTop
      // 
      panelTop.Controls.Add(buttonSearch);
      panelTop.Controls.Add(textBoxSearch);
      panelTop.Dock = DockStyle.Top;
      panelTop.Location = new Point(0, 0);
      panelTop.Name = "panelTop";
      panelTop.Size = new Size(1021, 57);
      panelTop.TabIndex = 0;
      // 
      // buttonSearch
      // 
      buttonSearch.Location = new Point(669, 17);
      buttonSearch.Name = "buttonSearch";
      buttonSearch.Size = new Size(75, 23);
      buttonSearch.TabIndex = 0;
      buttonSearch.Text = "Search";
      buttonSearch.UseVisualStyleBackColor = true;
      buttonSearch.Click += buttonSearch_Click;
      // 
      // textBoxSearch
      // 
      textBoxSearch.Location = new Point(27, 16);
      textBoxSearch.Name = "textBoxSearch";
      textBoxSearch.PlaceholderText = "Enter keywords to search for";
      textBoxSearch.Size = new Size(623, 23);
      textBoxSearch.TabIndex = 1;
      textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
      // 
      // panelBottom
      // 
      panelBottom.BorderStyle = BorderStyle.FixedSingle;
      panelBottom.Controls.Add(labelStatusbarMessage);
      panelBottom.Controls.Add(label2);
      panelBottom.Dock = DockStyle.Bottom;
      panelBottom.Location = new Point(0, 632);
      panelBottom.Name = "panelBottom";
      panelBottom.Size = new Size(1021, 25);
      panelBottom.TabIndex = 1;
      // 
      // labelStatusbarMessage
      // 
      labelStatusbarMessage.Dock = DockStyle.Fill;
      labelStatusbarMessage.Location = new Point(0, 0);
      labelStatusbarMessage.Name = "labelStatusbarMessage";
      labelStatusbarMessage.Size = new Size(793, 23);
      labelStatusbarMessage.TabIndex = 0;
      labelStatusbarMessage.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // panelMiddle
      // 
      panelMiddle.Controls.Add(flowLayoutPanelPictures);
      panelMiddle.Controls.Add(panelResultsTitle);
      panelMiddle.Dock = DockStyle.Fill;
      panelMiddle.Location = new Point(0, 57);
      panelMiddle.Name = "panelMiddle";
      panelMiddle.Size = new Size(1021, 575);
      panelMiddle.TabIndex = 2;
      // 
      // flowLayoutPanelPictures
      // 
      flowLayoutPanelPictures.AutoScroll = true;
      flowLayoutPanelPictures.AutoSize = true;
      flowLayoutPanelPictures.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      flowLayoutPanelPictures.Dock = DockStyle.Fill;
      flowLayoutPanelPictures.Location = new Point(0, 30);
      flowLayoutPanelPictures.Name = "flowLayoutPanelPictures";
      flowLayoutPanelPictures.Padding = new Padding(10);
      flowLayoutPanelPictures.Size = new Size(1021, 545);
      flowLayoutPanelPictures.TabIndex = 0;
      // 
      // panelResultsTitle
      // 
      panelResultsTitle.BackColor = Color.Blue;
      panelResultsTitle.Controls.Add(label1);
      panelResultsTitle.Dock = DockStyle.Top;
      panelResultsTitle.Location = new Point(0, 0);
      panelResultsTitle.Name = "panelResultsTitle";
      panelResultsTitle.Size = new Size(1021, 30);
      panelResultsTitle.TabIndex = 1;
      // 
      // label1
      // 
      label1.Dock = DockStyle.Fill;
      label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label1.ForeColor = Color.White;
      label1.Location = new Point(0, 0);
      label1.Name = "label1";
      label1.Size = new Size(1021, 30);
      label1.TabIndex = 0;
      label1.Text = "Pictures Found";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      label2.Dock = DockStyle.Right;
      label2.ForeColor = Color.Gray;
      label2.Location = new Point(793, 0);
      label2.Name = "label2";
      label2.Padding = new Padding(0, 0, 5, 0);
      label2.Size = new Size(226, 23);
      label2.TabIndex = 1;
      label2.Text = "Pictures provided by Unsplash.com";
      label2.TextAlign = ContentAlignment.MiddleRight;
      // 
      // FormMain
      // 
      AcceptButton = buttonSearch;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1021, 657);
      Controls.Add(panelMiddle);
      Controls.Add(panelBottom);
      Controls.Add(panelTop);
      MinimumSize = new Size(400, 300);
      Name = "FormMain";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Picture Finder";
      panelTop.ResumeLayout(false);
      panelTop.PerformLayout();
      panelBottom.ResumeLayout(false);
      panelMiddle.ResumeLayout(false);
      panelMiddle.PerformLayout();
      panelResultsTitle.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel panelTop;
    private Panel panelBottom;
    private Label labelStatusbarMessage;
    private Panel panelMiddle;
    private FlowLayoutPanel flowLayoutPanelPictures;
    private Panel panelResultsTitle;
    private Label label1;
    private Button buttonSearch;
    private TextBox textBoxSearch;
    private Label label2;
  }
}
