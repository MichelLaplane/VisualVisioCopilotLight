// RibbonVisualVisioCopilotLight.cs
// Librairie VisualVisioCopilotLight
// Copyright © Michel LAPLANE
// All rights reserved.

//-------------------------------------------------------------------------//
//					TABLEAU DE BORD DES MISES A JOUR
//-------------------------------------------------------------------------//
//Modifié: V1.0  |   ML		| 00/00/2011 15:52:49  |
//-------------------------------------------------------------------------//

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Office = Microsoft.Office.Core;

namespace VisualVisioCopilotLight
  {
  [ComVisible(true)]
  public class RibbonVisualVisioCopilotLight : Office.IRibbonExtensibility
    {
    internal Office.IRibbonUI ribbon;
    string strCulture;

    public RibbonVisualVisioCopilotLight(string strCultureParam)
      {
      strCulture = strCultureParam;
      }

    #region Membres IRibbonExtensibility

    public string GetCustomUI(string ribbonID)
      {
      switch (strCulture)
        {
        case "fr-FR":
          return GetResourceText("VisualVisioCopilotLight.RibbonVisualVisioCopilotLight_fr-FR.xml");
        case "en-US":
          return GetResourceText("VisualVisioCopilotLight.RibbonVisualVisioCopilotLight_en-US.xml");
        default:
          return GetResourceText("VisualVisioCopilotLight.RibbonVisualVisioCopilotLight.xml");
        }
      }

    #endregion

    #region Rappels du ruban
    //Créez des méthodes de rappel ici. Pour plus d'informations sur l'ajout de méthodes de rappel, sélectionnez l'élément XML Ruban dans l'Explorateur de solutions, puis appuyez sur F1

    public void Ribbon_Load(Office.IRibbonUI ribbonUI)
      {
      this.ribbon = ribbonUI;
      }

    #endregion

    #region Programmes d'assistance

    private static string GetResourceText(string resourceName)
      {
      Assembly asm = Assembly.GetExecutingAssembly();
      string[] resourceNames = asm.GetManifestResourceNames();
      for (int i = 0; i < resourceNames.Length; ++i)
        {
        if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
          {
          using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
            {
            if (resourceReader != null)
              {
              return resourceReader.ReadToEnd();
              }
            }
          }
        }
      return null;
      }

    #endregion

    public void OnAction(Office.IRibbonControl control)
      {
      switch (control.Id)
        {
        case "btnCopilotForm":
          // Launch SVG form
          ThisAddIn.addinApplication.DisplayCopilotWindow();
          break;
        case "btnAbout":
          ThisAddIn.addinApplication.About();
          break;
          //backstage
        case "btnProjectNew":
          ThisAddIn.addinApplication.NewFile();
          break;
        case "btnProjectOpen":
          ThisAddIn.addinApplication.OpenFile();
          break;
        case "btnProjectSave":
          ThisAddIn.addinApplication.SaveFile();
          break;
        case "btnProjectSaveAs":
          ThisAddIn.addinApplication.SaveAsFile();
          break;
        case "btnProjectClose":
          ThisAddIn.addinApplication.CloseFile();
          break;
        case "btnBackStageOptionsApplication":
          ThisAddIn.addinApplication.Options();
          break;
        }
      }

    public bool GetVisible(Microsoft.Office.Core.IRibbonControl control)
      {
      bool bRetour = true;

      if (ThisAddIn.addinApplication != null)
        {
        switch (control.Id)
          {
          default:
            break;
          }
        }
      return bRetour;
      }

    public bool GetEnabled(Microsoft.Office.Core.IRibbonControl control)
      {
      bool bRetour = true;

      switch (control.Id)
        {
        case "btnNew":
          {
          bRetour = true;
          break;
          }
        default:
          break;
        }
      return bRetour;
      }

    public string GetLabel(Microsoft.Office.Core.IRibbonControl control)
      {
      Assembly applicationAssembly;
      string strVersion = "", strVersions = "";

      switch (control.Id)
        {
        case "labelLicenseInfo":
          applicationAssembly = Assembly.GetCallingAssembly();
          strVersion = "Version : " + applicationAssembly.GetName().Version.ToString();
          if (strVersions != "")
            strVersion += Environment.NewLine + strVersions;
          break;
        default:
          break;
        }
      return strVersion;
      }

    /// <summary>
    /// Renvoi une image à l'appelant pour un bouton.
    /// </summary>
    /// <param name="control"></param>
    /// <returns></returns>
    public System.Drawing.Bitmap GetImage(Microsoft.Office.Core.IRibbonControl control)
      {
      switch (control.Id)
        {
        // Backstage
        case "taskCatFiles":
          return Properties.Resources.FileManagement64;
        case "taskCatOptions":
          return Properties.Resources.ApplicationOptions64;
        case "taskCatExport":
          return Properties.Resources.Export64;
        case "btnProjectNew":
          return Properties.Resources.ProjectNew64;
        case "btnProjectOpen":
          return Properties.Resources.ProjectOpen64;
        case "btnProjectSave":
          return Properties.Resources.ProjectSave64;
        case "btnProjectSaveAs":
          return Properties.Resources.ProjectSaveAs64;
        case "btnProjectClose":
          return Properties.Resources.ProjectClose64;
        case "btnProjectDelete":
          return Properties.Resources.ProjectDelete64;
        case "btnBackStageExportPDFProject":
          return Properties.Resources.PDF64;
        case "btnBackStageReportProject":
          return Properties.Resources.Report64;
        case "btnBackStageOptionsApplication":
          return Properties.Resources.ApplicationInfos64;
        // Ruban
        case "btnCopilotForm":
          return Properties.Resources.Copilot32;
        }
      // we should not get here for these buttons
      return null;
      }
    }
  }
