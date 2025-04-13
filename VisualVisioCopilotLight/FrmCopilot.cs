using Microsoft.Web.WebView2.Core;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svg;
using WebView2.DevTools.Dom;
using static System.Windows.Forms.AxHost;
using Visio = Microsoft.Office.Interop.Visio;
using Microsoft.Office.Interop.Visio;
using System.Xml.Linq;
using System.Web.UI.HtmlControls;
using System.Drawing.Drawing2D;
using Svg.Transforms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VisualVisioCopilotLight
  {
  public partial class FrmCopilot : Form
    {
    Microsoft.Office.Interop.Visio.Application visApp;
    private static string mermaidHtmlFileName = "VisualMermaidVisio.html";
    private static string mermaidSvgFileName = "VisualMermaidVisio.svg";
    private static string mermaidPngFileName = "VisualMermaidVisio.png";
    private static string mermaidHtmlPlaceHolder = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""utf-8"">
  <link rel=""stylesheet"" href=""mermaid.min.css"">
</head>
<body>
<div id=""diagram"">
  <div class=""mermaid"">
{0}
  </div>
</div>
<script type=""module"">
  import mermaid from 'https://cdn.jsdelivr.net/npm/mermaid@11/dist/mermaid.esm.min.mjs';
</script>
  <script>
    var config = {{
                startOnLoad:true,
                flowchart:{{
                        useMaxWidth:false,
                    }}
            }};
    mermaid.initialize(config);
  </script>
</body>
</html>
";
    string mermaidTextDiagram = @"
graph LR
    A --- B
    B-->C[fa:fa-ban forbidden]
    B-->D(fa:fa-spinner);
";

    public FrmCopilot(Microsoft.Office.Interop.Visio.Application visParamApp)
      {
      InitializeComponent();
      InitializeWebView2Async();
      this.Resize += new System.EventHandler(this.Form_Resize);
      edMermaidText.Text = mermaidTextDiagram;
      visApp = visParamApp;
      }

    public async void InitializeWebView2Async()
      {
      var env = await CoreWebView2Environment.CreateAsync(null, "C:\\Users\\miche\\Documents");
      await webViewMermaid.EnsureCoreWebView2Async(env);
      }

    private void Form_Resize(object sender, EventArgs e)
      {
      webViewMermaid.Size = this.ClientSize - new System.Drawing.Size(webViewMermaid.Location);
      }

    private void edMermaidSVG_TextChanged(object sender, EventArgs e)
      {
      if (edMermaidSVG.Text.Split('\n').Length > 15)
        edMermaidSVG.ScrollBars = ScrollBars.Vertical;
      else
        edMermaidSVG.ScrollBars = ScrollBars.None;
      }


    private void btnGenerate_Click(object sender, EventArgs e)
      {
      string strFullPath = System.IO.Path.Combine(VisualVisioCopilotLight.strProjectPath, mermaidHtmlFileName);
      System.IO.File.WriteAllText(strFullPath, string.Format(mermaidHtmlPlaceHolder, edMermaidText.Text));
      webViewMermaid.CoreWebView2.Navigate(strFullPath);
      }

    private async void CreateHtmlFromMermaidInstruction(string strFullPath)
      {
      var devToolsContext = await webViewMermaid.CoreWebView2.CreateDevToolsContextAsync();
      var elementSvg = await devToolsContext.QuerySelectorAsync<WebView2.DevTools.Dom.HtmlElement>("svg");
      var outerHTMLText = await elementSvg.GetOuterHtmlAsync();
      System.IO.File.WriteAllText(strFullPath, outerHTMLText);
      }

    private void btnPngVisioInsert_Click(object sender, EventArgs e)
      {
      string strFullPath;

      Microsoft.Office.Interop.Visio.Page visActivePage = visApp.ActivePage;
      if (visActivePage == null)
        {
        MessageBox.Show("No active page in Visio document");
        return;
        }
      strFullPath = System.IO.Path.Combine(VisualVisioCopilotLight.strProjectPath, mermaidSvgFileName);
      CreateHtmlFromMermaidInstruction(strFullPath);
      var svgDoc = SvgDocument.Open(strFullPath);
      var pngImage = svgDoc.Draw();
      pngImage.Save(System.IO.Path.Combine(VisualVisioCopilotLight.strProjectPath, mermaidPngFileName));
      visActivePage.Import(System.IO.Path.Combine(VisualVisioCopilotLight.strProjectPath, mermaidPngFileName));
      }

    /// <summary>
    /// Insert SVG elements into Visio
    /// https://www.w3.org/TR/SVG2/coords.html#Introduction
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNativeVisioInsert_Click(object sender, EventArgs e)
      {
      double dblViewBoxX = 0.0;
      double dblViewBoxY = 0.0;
      double dblViewBoxWidth = 0.0;
      double dblViewBoxHeight = 0.0;
      bool bViewBox = false;
      double dblWidthRatio = 0.0;
      double dblHeightRatio = 0.0;
      double dblSVGInchesWidth = 0.0, dblSVGInchesHeight = 0.0;
      string strWidthUnit = "", strHeightUnit = "", strWidth, strHeight;
      double dblSVGWidth = 0.0, dblSVGHeight = 0.0;
      float fltAngle = 0.0F, fltX = 0.0F, fltY = 0.0F;
      string strStrokeColor = "";
      string strFill = "";
      string strFullPath;

      Microsoft.Office.Interop.Visio.Page visActivePage = visApp.ActivePage;
      if (visActivePage != null)
        {
        strFullPath = System.IO.Path.Combine(VisualVisioCopilotLight.strProjectPath, mermaidSvgFileName);
        CreateHtmlFromMermaidInstruction(strFullPath);
        var svgDocument = SvgDocument.Open(strFullPath);
        svgDocument.TryGetAttribute("width", out string strSvgWidth);
        svgDocument.TryGetAttribute("height", out string strSvgHeight);
        if (strSvgWidth != null)
          {
          if (strSvgWidth.EndsWith("%"))
            {
            strSvgWidth = "254px";
            strWidthUnit = strSvgWidth.Remove(0, (strSvgWidth.Length - 2));
            }
          else
            {
            strWidthUnit = strSvgWidth.Remove(0, (strSvgWidth.Length - 2));
            }
          }
        if (strSvgHeight != null)
          {
          if (strSvgHeight.EndsWith("%"))
            {
            strSvgHeight = "254px";
            strHeightUnit = strSvgHeight.Remove(0, (strSvgHeight.Length - 2));
            }
          else
            {
            strHeightUnit = strSvgHeight.Remove(0, (strSvgHeight.Length - 2));
            }
          }
        string strSvgUnit = strWidthUnit;
        switch (strWidthUnit)
          {
          case "px":
            strSvgUnit = "px";
            break;
          case "cm":
            strSvgUnit = "cm";
            break;
          }
        if ((strSvgWidth != "") && (strSvgWidth != null))
          {
          strWidth = strSvgWidth.Replace(strWidthUnit, "");
          dblSVGWidth = Convert.ToDouble(strWidth);
          //if(strWidthUnit == "%")
          //  dblSVGWidth *= 5;
          }
        if ((strSvgHeight != "") && (strSvgHeight != null))
          {
          strHeight = strSvgHeight.Replace(strWidthUnit, "");
          dblSVGHeight = Convert.ToDouble(strHeight);
          //if (strHeightUnit == "%")
          //  dblSVGHeight *= 5;
          }
        if (dblSVGHeight == 0.0)
          dblSVGHeight = dblSVGWidth;
        // Rectangle du SVG
        switch (strWidthUnit)
          {
          case "px":
            strSvgUnit = "px";
            dblSVGInchesWidth = visActivePage.Application.ConvertResult(dblSVGWidth, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches);
            dblSVGInchesHeight = visActivePage.Application.ConvertResult(dblSVGHeight, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches);
            break;
          case "cm":
            strSvgUnit = "cm";
            dblSVGInchesWidth = visActivePage.Application.ConvertResult(dblSVGWidth, (int)Visio.VisUnitCodes.visCentimeters, (int)Visio.VisUnitCodes.visInches);
            dblSVGInchesHeight = visActivePage.Application.ConvertResult(dblSVGHeight, (int)Visio.VisUnitCodes.visCentimeters, (int)Visio.VisUnitCodes.visInches);
            break;
          case "%":
            strSvgUnit = "px";
            dblSVGInchesWidth = visActivePage.Application.ConvertResult(dblSVGWidth, (int)Visio.VisUnitCodes.visCentimeters, (int)Visio.VisUnitCodes.visInches);
            dblSVGInchesHeight = visActivePage.Application.ConvertResult(dblSVGHeight, (int)Visio.VisUnitCodes.visCentimeters, (int)Visio.VisUnitCodes.visInches);
            break;
          }

        dblWidthRatio = visActivePage.Application.ConvertResult(dblSVGWidth, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches) / dblSVGInchesWidth;
        dblHeightRatio = visActivePage.Application.ConvertResult(dblSVGHeight, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches) / dblSVGInchesHeight;
        svgDocument.TryGetAttribute("viewBox", out string strViewbox);
        if (strViewbox == "Svg.SvgViewBox")
          {
          bViewBox = true;
          SvgViewBox svgViewBox = svgDocument.ViewBox;
          dblViewBoxX = svgViewBox.MinX;
          dblViewBoxY = svgViewBox.MinY;
          dblViewBoxWidth = svgViewBox.Width;
          dblViewBoxHeight = svgViewBox.Height;
          dblWidthRatio = visActivePage.Application.ConvertResult(dblViewBoxWidth, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches) / dblSVGInchesWidth;
          dblHeightRatio = visActivePage.Application.ConvertResult(dblViewBoxHeight, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches) / dblSVGInchesHeight;
          }


        //visApp.ConvertResult(strWidth, strWidth.Remove(0, (strWidth.Length - 2)),"mm");
        //

        // Valeur de dblPageWidth et dblPageHeight en pouces (inches)
        double dblPageWidth = visActivePage.PageSheet.get_CellsSRC((int)Visio.VisSectionIndices.visSectionObject,
            (int)Visio.VisRowIndices.visRowPage,
            (int)Visio.VisCellIndices.visPageWidth).ResultIU;
        double dblPageHeight = visActivePage.PageSheet.get_CellsSRC((int)Visio.VisSectionIndices.visSectionObject,
                  (int)Visio.VisRowIndices.visRowPage,
                  (int)Visio.VisCellIndices.visPageHeight).ResultIU;

        //double dblSVGWidthRatio = visActivePage.Application.ConvertResult(dblSVGWidth, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches) / dblSVGInchesWidth;
        //double dblSVGHeightRatio = visActivePage.Application.ConvertResult(dblSVGHeight, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches) / dblSVGInchesHeight;
        Visio.Shape visSVGShape = visActivePage.DrawRectangle(0, 0, dblSVGInchesWidth, -dblSVGInchesHeight);
        // centrage du dessin
        visActivePage.CenterDrawing();
        //double dblWidthRatio = visActivePage.Application.ConvertResult(dblViewBoxWidth, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches) / dblSVGInchesWidth;
        //double dblHeightRatio = visActivePage.Application.ConvertResult(dblViewBoxHeight, (int)Visio.VisUnitCodes.visPoints, (int)Visio.VisUnitCodes.visInches) / dblSVGInchesHeight;

        // Access SVG elements

        foreach (SvgElement element in svgDocument.Children)
          {
          // Perform actions on each element
          var symbol = element.GetType();
          switch (symbol.Name)
            {
            case "SvgTitle":
              break;
            case "SvgDescription":
              break;
            case "SvgRectangle":
              VisualVisioCopilotLightUtil.CreateRect(visActivePage, visSVGShape, element, fltX, fltY, fltAngle, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, bViewBox, strFill, strStrokeColor);
              break;
            case "SvgCircle":
              VisualVisioCopilotLightUtil.CreateCircle(visActivePage, visSVGShape, element, fltX, fltY, fltAngle, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, bViewBox, strFill, strStrokeColor);
              break;
            case "SvgLine":
              double dblBeginX = ((SvgLine)element).StartX * ((1 / dblSVGWidth) * 100);
              double dblBeginY = ((SvgLine)element).StartY * ((1 / dblSVGHeight) * 100);
              double dblEndX = ((SvgLine)element).EndX * ((1 / dblSVGWidth) * 100);
              double dblEndY = ((SvgLine)element).EndY * ((1 / dblSVGHeight) * 100);
              visActivePage.DrawLine(dblBeginX, dblBeginY, dblEndX, dblEndY);
              break;
            case "SvgPolyline":
              VisualVisioCopilotLightUtil.CreatePolyline(visActivePage, visSVGShape, element, fltX, fltY, fltAngle, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, bViewBox, strFill, strStrokeColor);
              break;
            case "SvgPath":
              SvgPath svgPath = ((SvgPath)element);
              Svg.Pathing.SvgPathSegmentList arData = svgPath.PathData;
              VisualVisioCopilotLightUtil.Create2DPolylineFromPath(visActivePage, visSVGShape, element, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight,false);
              break;
            case "SvgGroup":
              ProcessSvgElement(element, visActivePage, visSVGShape, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, strSvgUnit, bViewBox);
              break;
            case "SvgUnknownElement":
              break;
            default:
              break;
            }
          string strElement = symbol.ToString();
          }
        }
      else
        {
        MessageBox.Show("No active page in Visio document");
        }
      }

    private void btnHome_Click(object sender, EventArgs e)
      {
      webViewMermaid.CoreWebView2.Navigate("https://copilot.microsoft.com/onboarding");
      }

    private void btnNavigate_Click(object sender, EventArgs e)
      {
      webViewMermaid.Source = new Uri(edTextUrl.Text);
      }
    private void ProcessSvgElement(SvgElement element, Visio.Page visActivePage, Visio.Shape visSVGShape, double dblWidthRatio, double dblHeightRatio, double dblSVGInchesWidth, double dblSVGInchesHeight, string strSvgUnit, bool bViewBox)
      {
      float fltAngle = 0.0F, fltX = 0.0F, fltY = 0.0F;
      string strTransform = "";
      string strStrokeColor = "";
      string strStrokeWidth = "";
      string strFill = "";

      element.TryGetAttribute("transform", out strTransform);
      element.TryGetAttribute("stroke", out strStrokeColor);
      element.TryGetAttribute("stroke-width", out strStrokeWidth);
      element.TryGetAttribute("fill", out strFill);

      if (!string.IsNullOrEmpty(strTransform))
        {
        if (element.Transforms.Count >= 1 && element.Transforms.ElementAt(0).GetType().Name == "SvgTranslate")
          {
          fltX = ((SvgTranslate)element.Transforms.ElementAt(0)).X;
          fltY = ((SvgTranslate)element.Transforms.ElementAt(0)).Y;
          }
        if (element.Transforms.Count >= 2 && element.Transforms.ElementAt(1).GetType().Name == "SvgRotate")
          {
          fltAngle = ((SvgRotate)element.Transforms.ElementAt(1)).Angle;
          }
        }
      foreach (SvgElement subElement in element.Children)
        {
        switch (subElement.GetType().Name)
          {
          case "SvgLine":
            VisualVisioCopilotLightUtil.CreateLine(visActivePage, visSVGShape, subElement, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight);
            break;
          case "SvgText":
            VisualVisioCopilotLightUtil.CreateText(visActivePage, visSVGShape, subElement, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, strSvgUnit, "pt");
            break;
          case "SvgRectangle":
            SvgCustomAttributeCollection arAttribCollection = subElement.CustomAttributes;
            arAttribCollection.TryGetValue("class", out string strClass);
            switch (strClass)
              {
              case "basic label-container":
                VisualVisioCopilotLightUtil.CreateRectangleWithText(visActivePage, visSVGShape, subElement, fltX, fltY, fltAngle, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, bViewBox, strFill, strStrokeColor);
                break;
              default:
                VisualVisioCopilotLightUtil.CreateRect(visActivePage, visSVGShape, subElement, fltX, fltY, fltAngle, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, bViewBox, strFill, strStrokeColor);
                break;
              }
            break;
          case "SvgCircle":
            VisualVisioCopilotLightUtil.CreateCircle(visActivePage, visSVGShape, subElement, fltX, fltY, fltAngle, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, bViewBox, strFill, strStrokeColor);
            break;
          case "SvgPath":
            SvgPath svgPath = ((SvgPath)subElement);
            Svg.Pathing.SvgPathSegmentList arData = svgPath.PathData;
            //VLMethods.Create1DPolylineFromPath(visActivePage, visSVGShape, element, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight);
            VisualVisioCopilotLightUtil.Create2DPolylineFromPath(visActivePage, visSVGShape, subElement, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight,false);
            break;
          case "SvgMarker":
            SvgMarker svgMarker = ((SvgMarker)subElement);
            VisualVisioCopilotLightUtil.Create2DPolylineFromMarker(visActivePage, visSVGShape, subElement, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight,true);
            break;
          case "SvgForeignObject":
            break;
          case "SvgGroup":
            ProcessSvgElement(subElement, visActivePage, visSVGShape, dblWidthRatio, dblHeightRatio, dblSVGInchesWidth, dblSVGInchesHeight, strSvgUnit, bViewBox);
            break;
          }
        }
      }

    }
  }
