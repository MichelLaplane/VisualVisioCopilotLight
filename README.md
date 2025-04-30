# VisualVisioCopilotLight
This application helps you to create Visio Diagrams using Copilot responses.
Just ask copilot the type of diagram you want to create? Don't forget to tell copilot to create the diagram using Mermaid syntax.

If you just want to use it, the installer is in the "VisualVisioCopilotLight/Installer
/en-US directory".
Launch the msi file and choose "Typical" for default installation.

## Settings of the application
![Settings](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/Settings.png)

![Applicationsettings](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/Application%20setting.png)

![Pathsettings](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/Path%20settings.png)

VisualVisioCopilotLight uses the Microsoft Edge WebView2 control. The "WebView2Path" is for the app to be able to use the Edge WebView2 control

## Creating Visio Diagram with VisualVisioCopilotLight
You first need to create a Visio File from the backstage file menu
![New](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/New.png)

Then click on the "Create fueled Copilot Visio Diagram" Command in the "VisualVisioSVGLight" Tab
![CopilotAidedVisioDiagram](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/CopilotAidedVisioDiagram.png)

The dialog box of the application is displayed
![CopilotVisioDialog](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/CopilotVisioDialog.png)

You can see a predefined Worflow Diagram in Mermaid syntax

![GenerateDefault](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/GenerateDefault.png)

Click on "Generate diagram". The diagram will be created in SVG format.
![GeneratedDefaultDiagram](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/GeneratedDefaultDiagram.png)

Click on "Insert Diagram as Visio" for creating the Visio Diagram.
![VisioCopilotDefaultVisioDiagram](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/VisioCopilotDefaultVisioDiagram.png)

If you want to insert a png image of the diagram, click on "Insert Diagram as PNG". You will notice that the result is much more less accurate.
![VisioCopilotDefaultPngDiagram](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/VisioCopilotDefaultPngDiagram.png)

Now let's ask copilot to create my simple process diagram
type.
For example "Could you create a workflow diagram with a begin step, a test step with the result of two new steps and a end test using Mermaid syntax"
![CopilotRequest](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/CopilotRequest.png)

Copilot is thinking and gives the result. Copy the Mermaid syntax response
![CopilotResponse](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/CopilotResponse.png)

Paste in the edit mermaid syntax textbox. Click the "Generate diagram" button to generate the svg result.
![CopilotResponseSVGDiagram](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/CopilotResponseSVGDiagram.png)

Click "Insert Diagram as Visio" to create the Visio Diagram corresponding to hte Copilot response.
![VisioDiagramCopilotResponse](https://github.com/MichelLaplane/VisualVisioCopilotLight/blob/master/VisualVisioCopilotLight/Readme/VisioDiagramCopilotResponse.png)




