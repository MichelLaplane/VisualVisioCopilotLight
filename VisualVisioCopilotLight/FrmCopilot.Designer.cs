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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCopilot));
      this.splitCopilotContainer = new System.Windows.Forms.SplitContainer();
      this.btnNavigate = new System.Windows.Forms.Button();
      this.edTextUrl = new System.Windows.Forms.TextBox();
      this.btnHome = new System.Windows.Forms.Button();
      this.webCopilotView = new Microsoft.Web.WebView2.WinForms.WebView2();
      this.splitSVGContainer = new System.Windows.Forms.SplitContainer();
      this.edMermaidText = new System.Windows.Forms.TextBox();
      this.btnGenerate = new System.Windows.Forms.Button();
      this.edSVG = new System.Windows.Forms.TextBox();
      this.btnPngVisioInsert = new System.Windows.Forms.Button();
      this.btnNativeVisioInsert = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitCopilotContainer)).BeginInit();
      this.splitCopilotContainer.Panel1.SuspendLayout();
      this.splitCopilotContainer.Panel2.SuspendLayout();
      this.splitCopilotContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.webCopilotView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitSVGContainer)).BeginInit();
      this.splitSVGContainer.Panel1.SuspendLayout();
      this.splitSVGContainer.Panel2.SuspendLayout();
      this.splitSVGContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitCopilotContainer
      // 
      this.splitCopilotContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      resources.ApplyResources(this.splitCopilotContainer, "splitCopilotContainer");
      this.splitCopilotContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitCopilotContainer.Name = "splitCopilotContainer";
      // 
      // splitCopilotContainer.Panel1
      // 
      this.splitCopilotContainer.Panel1.Controls.Add(this.btnNavigate);
      this.splitCopilotContainer.Panel1.Controls.Add(this.edTextUrl);
      this.splitCopilotContainer.Panel1.Controls.Add(this.btnHome);
      this.splitCopilotContainer.Panel1.Controls.Add(this.webCopilotView);
      // 
      // splitCopilotContainer.Panel2
      // 
      this.splitCopilotContainer.Panel2.Controls.Add(this.splitSVGContainer);
      // 
      // btnNavigate
      // 
      resources.ApplyResources(this.btnNavigate, "btnNavigate");
      this.btnNavigate.Name = "btnNavigate";
      this.btnNavigate.UseVisualStyleBackColor = true;
      this.btnNavigate.Click += new System.EventHandler(this.btnNavigate_Click);
      // 
      // edTextUrl
      // 
      resources.ApplyResources(this.edTextUrl, "edTextUrl");
      this.edTextUrl.Name = "edTextUrl";
      // 
      // btnHome
      // 
      resources.ApplyResources(this.btnHome, "btnHome");
      this.btnHome.Name = "btnHome";
      this.btnHome.UseVisualStyleBackColor = true;
      this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
      // 
      // webCopilotView
      // 
      resources.ApplyResources(this.webCopilotView, "webCopilotView");
      this.webCopilotView.AllowExternalDrop = false;
      this.webCopilotView.CreationProperties = null;
      this.webCopilotView.DefaultBackgroundColor = System.Drawing.Color.White;
      this.webCopilotView.Name = "webCopilotView";
      this.webCopilotView.Source = new System.Uri("https://copilot.microsoft.com", System.UriKind.Absolute);
      this.webCopilotView.ZoomFactor = 1D;
      // 
      // splitSVGContainer
      // 
      this.splitSVGContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      resources.ApplyResources(this.splitSVGContainer, "splitSVGContainer");
      this.splitSVGContainer.Name = "splitSVGContainer";
      // 
      // splitSVGContainer.Panel1
      // 
      this.splitSVGContainer.Panel1.Controls.Add(this.edMermaidText);
      this.splitSVGContainer.Panel1.Controls.Add(this.btnGenerate);
      // 
      // splitSVGContainer.Panel2
      // 
      this.splitSVGContainer.Panel2.Controls.Add(this.edSVG);
      this.splitSVGContainer.Panel2.Controls.Add(this.btnPngVisioInsert);
      this.splitSVGContainer.Panel2.Controls.Add(this.btnNativeVisioInsert);
      // 
      // edMermaidText
      // 
      resources.ApplyResources(this.edMermaidText, "edMermaidText");
      this.edMermaidText.Name = "edMermaidText";
      // 
      // btnGenerate
      // 
      resources.ApplyResources(this.btnGenerate, "btnGenerate");
      this.btnGenerate.Name = "btnGenerate";
      this.btnGenerate.UseVisualStyleBackColor = true;
      this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
      // 
      // edSVG
      // 
      resources.ApplyResources(this.edSVG, "edSVG");
      this.edSVG.Name = "edSVG";
      this.edSVG.TextChanged += new System.EventHandler(this.edSVG_TextChanged);
      // 
      // btnPngVisioInsert
      // 
      resources.ApplyResources(this.btnPngVisioInsert, "btnPngVisioInsert");
      this.btnPngVisioInsert.Name = "btnPngVisioInsert";
      this.btnPngVisioInsert.UseVisualStyleBackColor = true;
      this.btnPngVisioInsert.Click += new System.EventHandler(this.btnPngVisioInsert_Click);
      // 
      // btnNativeVisioInsert
      // 
      resources.ApplyResources(this.btnNativeVisioInsert, "btnNativeVisioInsert");
      this.btnNativeVisioInsert.Name = "btnNativeVisioInsert";
      this.btnNativeVisioInsert.UseVisualStyleBackColor = true;
      this.btnNativeVisioInsert.Click += new System.EventHandler(this.btnNativeInsert_Click);
      // 
      // FrmCopilot
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitCopilotContainer);
      this.Name = "FrmCopilot";
      this.splitCopilotContainer.Panel1.ResumeLayout(false);
      this.splitCopilotContainer.Panel1.PerformLayout();
      this.splitCopilotContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitCopilotContainer)).EndInit();
      this.splitCopilotContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.webCopilotView)).EndInit();
      this.splitSVGContainer.Panel1.ResumeLayout(false);
      this.splitSVGContainer.Panel1.PerformLayout();
      this.splitSVGContainer.Panel2.ResumeLayout(false);
      this.splitSVGContainer.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitSVGContainer)).EndInit();
      this.splitSVGContainer.ResumeLayout(false);
      this.ResumeLayout(false);

      }

    #endregion
    private System.Windows.Forms.SplitContainer splitCopilotContainer;
    private Microsoft.Web.WebView2.WinForms.WebView2 webCopilotView;
    private System.Windows.Forms.Button btnGenerate;
    private System.Windows.Forms.TextBox edMermaidText;
    private System.Windows.Forms.Button btnPngVisioInsert;
    private System.Windows.Forms.TextBox edSVG;
    private System.Windows.Forms.Button btnNativeVisioInsert;
    private System.Windows.Forms.Button btnHome;
    private System.Windows.Forms.TextBox edTextUrl;
    private System.Windows.Forms.Button btnNavigate;
    private System.Windows.Forms.SplitContainer splitSVGContainer;
    }
  }