namespace VisualVisioCopilotLight
  {
  partial class FrmCopilot
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
      this.splitMermaidContainer = new System.Windows.Forms.SplitContainer();
      this.btnNavigate = new System.Windows.Forms.Button();
      this.edTextUrl = new System.Windows.Forms.TextBox();
      this.btnHome = new System.Windows.Forms.Button();
      this.webViewMermaid = new Microsoft.Web.WebView2.WinForms.WebView2();
      this.btnNativeVisioInsert = new System.Windows.Forms.Button();
      this.edMermaidSVG = new System.Windows.Forms.TextBox();
      this.edMermaidText = new System.Windows.Forms.TextBox();
      this.btnPngVisioInsert = new System.Windows.Forms.Button();
      this.btnGenerate = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitMermaidContainer)).BeginInit();
      this.splitMermaidContainer.Panel1.SuspendLayout();
      this.splitMermaidContainer.Panel2.SuspendLayout();
      this.splitMermaidContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.webViewMermaid)).BeginInit();
      this.SuspendLayout();
      // 
      // splitMermaidContainer
      // 
      this.splitMermaidContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitMermaidContainer.Location = new System.Drawing.Point(0, 0);
      this.splitMermaidContainer.Name = "splitMermaidContainer";
      // 
      // splitMermaidContainer.Panel1
      // 
      this.splitMermaidContainer.Panel1.Controls.Add(this.btnNavigate);
      this.splitMermaidContainer.Panel1.Controls.Add(this.edTextUrl);
      this.splitMermaidContainer.Panel1.Controls.Add(this.btnHome);
      this.splitMermaidContainer.Panel1.Controls.Add(this.webViewMermaid);
      // 
      // splitMermaidContainer.Panel2
      // 
      this.splitMermaidContainer.Panel2.Controls.Add(this.btnNativeVisioInsert);
      this.splitMermaidContainer.Panel2.Controls.Add(this.edMermaidSVG);
      this.splitMermaidContainer.Panel2.Controls.Add(this.edMermaidText);
      this.splitMermaidContainer.Panel2.Controls.Add(this.btnPngVisioInsert);
      this.splitMermaidContainer.Panel2.Controls.Add(this.btnGenerate);
      this.splitMermaidContainer.Size = new System.Drawing.Size(1197, 450);
      this.splitMermaidContainer.SplitterDistance = 690;
      this.splitMermaidContainer.TabIndex = 0;
      // 
      // btnNavigate
      // 
      this.btnNavigate.Location = new System.Drawing.Point(650, 9);
      this.btnNavigate.Name = "btnNavigate";
      this.btnNavigate.Size = new System.Drawing.Size(33, 23);
      this.btnNavigate.TabIndex = 6;
      this.btnNavigate.Text = "Go";
      this.btnNavigate.UseVisualStyleBackColor = true;
      this.btnNavigate.Click += new System.EventHandler(this.btnNavigate_Click);
      // 
      // edTextUrl
      // 
      this.edTextUrl.Location = new System.Drawing.Point(208, 11);
      this.edTextUrl.Name = "edTextUrl";
      this.edTextUrl.Size = new System.Drawing.Size(436, 20);
      this.edTextUrl.TabIndex = 5;
      this.edTextUrl.Text = "https://copilot.microsoft.com/onboarding";
      // 
      // btnHome
      // 
      this.btnHome.Location = new System.Drawing.Point(12, 9);
      this.btnHome.Name = "btnHome";
      this.btnHome.Size = new System.Drawing.Size(60, 23);
      this.btnHome.TabIndex = 1;
      this.btnHome.Text = "Home";
      this.btnHome.UseVisualStyleBackColor = true;
      this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
      // 
      // webViewMermaid
      // 
      this.webViewMermaid.AccessibleName = "webViewMermaid";
      this.webViewMermaid.AllowExternalDrop = false;
      this.webViewMermaid.CreationProperties = null;
      this.webViewMermaid.DefaultBackgroundColor = System.Drawing.Color.White;
      this.webViewMermaid.Location = new System.Drawing.Point(12, 38);
      this.webViewMermaid.Name = "webViewMermaid";
      this.webViewMermaid.Size = new System.Drawing.Size(675, 409);
      this.webViewMermaid.Source = new System.Uri("https://copilot.microsoft.com/onboarding", System.UriKind.Absolute);
      this.webViewMermaid.TabIndex = 0;
      this.webViewMermaid.ZoomFactor = 1D;
      // 
      // btnNativeVisioInsert
      // 
      this.btnNativeVisioInsert.Location = new System.Drawing.Point(203, 415);
      this.btnNativeVisioInsert.Name = "btnNativeVisioInsert";
      this.btnNativeVisioInsert.Size = new System.Drawing.Size(140, 23);
      this.btnNativeVisioInsert.TabIndex = 5;
      this.btnNativeVisioInsert.Text = "Insert Diagram as Visio";
      this.btnNativeVisioInsert.UseVisualStyleBackColor = true;
      this.btnNativeVisioInsert.Click += new System.EventHandler(this.btnNativeVisioInsert_Click);
      // 
      // edMermaidSVG
      // 
      this.edMermaidSVG.Location = new System.Drawing.Point(0, 206);
      this.edMermaidSVG.Multiline = true;
      this.edMermaidSVG.Name = "edMermaidSVG";
      this.edMermaidSVG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edMermaidSVG.Size = new System.Drawing.Size(369, 203);
      this.edMermaidSVG.TabIndex = 2;
      this.edMermaidSVG.TextChanged += new System.EventHandler(this.edMermaidSVG_TextChanged);
      // 
      // edMermaidText
      // 
      this.edMermaidText.Location = new System.Drawing.Point(0, 0);
      this.edMermaidText.Multiline = true;
      this.edMermaidText.Name = "edMermaidText";
      this.edMermaidText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.edMermaidText.Size = new System.Drawing.Size(369, 200);
      this.edMermaidText.TabIndex = 1;
      // 
      // btnPngVisioInsert
      // 
      this.btnPngVisioInsert.Location = new System.Drawing.Point(3, 414);
      this.btnPngVisioInsert.Name = "btnPngVisioInsert";
      this.btnPngVisioInsert.Size = new System.Drawing.Size(140, 23);
      this.btnPngVisioInsert.TabIndex = 0;
      this.btnPngVisioInsert.Text = "Insert Diagram as PNG";
      this.btnPngVisioInsert.UseVisualStyleBackColor = true;
      this.btnPngVisioInsert.Click += new System.EventHandler(this.btnPngVisioInsert_Click);
      // 
      // btnGenerate
      // 
      this.btnGenerate.Location = new System.Drawing.Point(380, 94);
      this.btnGenerate.Name = "btnGenerate";
      this.btnGenerate.Size = new System.Drawing.Size(110, 23);
      this.btnGenerate.TabIndex = 0;
      this.btnGenerate.Text = "Generate diagram";
      this.btnGenerate.UseVisualStyleBackColor = true;
      this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
      // 
      // FrmCopilot
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1197, 450);
      this.Controls.Add(this.splitMermaidContainer);
      this.Name = "FrmCopilot";
      this.Text = "FrmMermaid";
      this.splitMermaidContainer.Panel1.ResumeLayout(false);
      this.splitMermaidContainer.Panel1.PerformLayout();
      this.splitMermaidContainer.Panel2.ResumeLayout(false);
      this.splitMermaidContainer.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitMermaidContainer)).EndInit();
      this.splitMermaidContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.webViewMermaid)).EndInit();
      this.ResumeLayout(false);

      }

    #endregion
    private System.Windows.Forms.SplitContainer splitMermaidContainer;
    private Microsoft.Web.WebView2.WinForms.WebView2 webViewMermaid;
    private System.Windows.Forms.Button btnGenerate;
    private System.Windows.Forms.TextBox edMermaidText;
    private System.Windows.Forms.Button btnPngVisioInsert;
    private System.Windows.Forms.TextBox edMermaidSVG;
    private System.Windows.Forms.Button btnNativeVisioInsert;
    private System.Windows.Forms.Button btnHome;
    private System.Windows.Forms.TextBox edTextUrl;
    private System.Windows.Forms.Button btnNavigate;
    }
  }