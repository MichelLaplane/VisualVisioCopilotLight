// DlgOptions.cs
// Librairie VisualVisioCopilotLight
// Copyright © Michel LAPLANE
// All rights reserved.

//-------------------------------------------------------------------------//
//					TABLEAU DE BORD DES MISES A JOUR
//-------------------------------------------------------------------------//
//Modifié: V1.0  |   ML		| 00/00/2011 15:52:49  |
//-------------------------------------------------------------------------//
using System.Windows.Forms;

namespace VisualVisioCopilotLight
  {
  public partial class DlgOptions : Form
    {

    private string strTemplatePath, strStencilPath, strProjectPath, strWebView2Path;
    public string TemplatePath { get => strTemplatePath; set => strTemplatePath = value; }
    public string StencilPath { get => strStencilPath; set => strStencilPath = value; }
    public string ProjectPath { get => strProjectPath; set => strProjectPath = value; }
    public string WebView2Path { get => strWebView2Path; set => strWebView2Path = value; }

    public DlgOptions()
      {
      InitializeComponent();
      InitializeControl();
      }

    private void InitializeControl()
      {
      strStencilPath = VisualVisioCopilotLight.strStencilPath;
      strTemplatePath = VisualVisioCopilotLight.strTemplatePath;
      strProjectPath = VisualVisioCopilotLight.strProjectPath;
      strWebView2Path = VisualVisioCopilotLight.strWebView2Path;
      // Initialisation valeur par défaut
      edStencilPath.Text = strStencilPath;
      edTemplatePath.Text = strTemplatePath;
      edProjectPath.Text = strProjectPath;
      edWebView2Path.Text = strWebView2Path;
      }

    private bool Explore(out string strSelectedPath)
      {
      FolderBrowserDialog dlgExplore;
      bool bSelected = false;

      strSelectedPath = "";
      // Affichage de la boîte de choix d'un répertoire
      dlgExplore = new FolderBrowserDialog();
      dlgExplore.SelectedPath = VisualVisioCopilotLight.strProjectPath;
      if (dlgExplore.ShowDialog() == DialogResult.OK)
        {
        bSelected = true;
        strSelectedPath = dlgExplore.SelectedPath;
        }
      return bSelected;
      }

    private void btnTemplateExplore_Click(object sender, System.EventArgs e)
      {
      string strSelectedPath;

      if (Explore(out strSelectedPath))
        edTemplatePath.Text = strSelectedPath;
      }

    private void btnStencilExplore_Click(object sender, System.EventArgs e)
      {
      string strSelectedPath;

      if (Explore(out strSelectedPath))
        edStencilPath.Text = strSelectedPath;
      }

    private void btnProjectExplore_Click(object sender, System.EventArgs e)
      {
      string strSelectedPath;

      if (Explore(out strSelectedPath))
        edProjectPath.Text = strSelectedPath;
      }

    private void btnWebView2Explore_Click(object sender, System.EventArgs e)
      {
      string strSelectedPath;

      if (Explore(out strSelectedPath))
        edWebView2Path.Text = strSelectedPath;
      }


    private void btnCancel_Click(object sender, System.EventArgs e)
      {
      Close();
      }

    private void btnOk_Click(object sender, System.EventArgs e)
      {
      TemplatePath = edTemplatePath.Text;
      StencilPath = edStencilPath.Text;
      ProjectPath = edProjectPath.Text;
      WebView2Path = edWebView2Path.Text;
      Close();
      }


    }
  }