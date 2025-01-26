---
title: The Dew Review – ABBYY FineReader Engine OCR SDK
author: Alvin A.
type: post
date: 2013-02-24T23:55:58+00:00
url: /2013/02/24/the-dew-review-abbyy-finereader-engine-ocr-sdk/
categories:
  - Development
  - how-to
  - reviews
  - tools
tags:
  - ABBYY
  - COM
  - OCR
  - SDK
  - visual studio
  - vs2012
  - winforms

---
### Intro

Over the last several weeks, I have been building some simple OCR applications in my spare time using a trial version of the FineReader Engine by <a href="http://www.abbyy.com" target="_blank">ABBYY</a>. <a href="http://www.abbyy.com/ocr_sdk/" target="_blank">FineReader Engine</a> is an SDK for building powerful applications that can open images, PDF documents and scanned documents, analyze and parse the contents and output the results. Almost any type of export file containing text results can be produced, including text-based PDF, Microsoft Office formats, XML (particularly useful for integrating OCR results with other systems) and more.

### About FineReader Engine

I think the best summary of the FineReader Engine’s capabilities can be found on ABBYY’s site.

> **ABBYY FineReader Engine** is a powerful OCR SDK to integrate ABBYY’s state-of-the-art document recognition and conversion software technologies such as: optical character recognition (OCR), intelligent character recognition (ICR), optical mark recognition (OMR), barcode recognition (OBR), document imaging, and PDF conversion.

Developers should consider ABBYY FineReader if you are building an application which will require any of the following capabilities:

  * Document Conversion
  * Document Archiving
  * Book Archiving
  * Text Extraction
  * Field Recognition
  * Barcode Recognition
  * Image Preprocessing
  * Scanning

More than a dozen sample apps are included with the SDK, including examples in C++, C#, VB.NET, VB, Delphi, Java and several scripting languages (JavaScript, Perl and VBScript).

### Installation and Setup

There are a couple of steps to setting up FineReader Engine on a development machine. First, a license server must be installed. It can either be installed directly on the development machine if only a single developer will be using the SDK. If several developers will be using FineReader Engine from multiple workstations, the license server should be installed on an application server that is available to all the developer machines. The license server must be installed on a physical machine, not a VM. (Note that the technology can run in VM and cloud environments.) The license manager is where you will add and activate each of your licenses, trial or purchased.

Next the FineReader Engine itself can be installed on the development machine and pointed to the license server.

After installation is complete if you are using Visual Studio 2010 or 2012, there are a couple of additional steps that must be followed to enable the use of the Visual Components (controls). These steps are listed on the “Using Visual Components in Different Versions of Visual Studio” page in the included SDK help file.

To install Interop assemblies manually, do the following:

  1. The Interop assemblies for .NET Framework 4.0 are located in the <span style="font-family: Consolas; font-size: small;">ProgramDataABBYYInc.Net interopsv4.0</span> folder. Register Interop.FREngine.dll and Interop.FineReaderVisualComponents.dll from a Visual Studio Command Prompt: 
      * regasm.exe [path-to-the-interop-assemblies]Interop.FREngine.dll /registered /codebase
      * regasm.exe [path-to-the-interop-assemblies]Interop.FineReaderVisualComponents.dll /registered /codebase
  2. Install the Interop assemblies to GAC: 
      * gacutil.exe /if [path-to-the-interop-assemblies]Interop.FREngine.dll
      * gacutil.exe /if [path-to-the-interop-assemblies]Interop.FineReaderVisualComponents.dll

You are now ready to start developing with the SDK.

### Creating a Project

To get started create a new Windows Forms Application in either C# or Visual Basic. I used Visual Studio 2012 for my application development.

[<img loading="lazy" decoding="async" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="ABBYY.1.NewProject" alt="ABBYY.1.NewProject" src="/wp-content/uploads/2013/02/ABBYY.1.NewProject_thumb.png" width="400" height="277" border="0" />][1]

Next add the ABBYY controls to the Visual Studio Toolbox window. I created a new ABBYY section in the Toolbox.

[<img loading="lazy" decoding="async" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="ABBYY.2.AddControls" alt="ABBYY.2.AddControls" src="/wp-content/uploads/2013/02/ABBYY.2.AddControls_thumb.png" width="400" height="212" border="0" />][2]

Add references to your project to the three Interop DLLs in the ABBYY Inc.Net Interops folder which were registered and added to the GAC during the setup process.

[<img loading="lazy" decoding="async" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="ABBYY.3.AddReferences" alt="ABBYY.3.AddReferences" src="/wp-content/uploads/2013/02/ABBYY.3.AddReferences_thumb.png" width="400" height="205" border="0" />][3]

### UI Controls

This is a look at all five of the ABBYY controls on a Windows Form in design view.

[<img loading="lazy" decoding="async" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="ABBYY.4.ControlsOnForm" alt="ABBYY.4.ControlsOnForm" src="/wp-content/uploads/2013/02/ABBYY.4.ControlsOnForm_thumb.png" width="400" height="258" border="0" />][4]

Going clockwise from the top left, the controls are:

DocumentViewer – This control shows the list of pages loaded from an image/document and the processing status of each page. The pages can be shown in a thumbnail or details view.

ImageViewer – This control allows the application’s user to view and edit the page selected in the DocumentViewer.

TextEditor – The TextEditor allows users to view and edit the text that was recognized by the FREngine on the selected page.

ZoomViewer – This control allows users to zoom in and out of a area selected in the ImageViewer.

TextValidator – This control provides and interface for users to make adjustments to areas of text not recognized during the scanning and validation process. This is also the user interface for spell checking a document.

Synchronizing documents and pages across these controls is as easy as adding each one to a ComponentSynchronizer object in the code like so:

<pre class="csharpcode"><span class="rem">// Attach components to Synchronizer</span>
Synchronizer = <span class="kwrd">new</span> FineReaderVisualComponents.ComponentSynchronizerClass();
Synchronizer.DocumentViewer = ( FineReaderVisualComponents.DocumentViewer ) documentViewer.GetOcx();
Synchronizer.ImageViewer = ( FineReaderVisualComponents.ImageViewer ) imageViewer.GetOcx();
Synchronizer.ZoomViewer = ( FineReaderVisualComponents.ZoomViewer ) zoomViewer.GetOcx();
Synchronizer.TextEditor = ( FineReaderVisualComponents.TextEditor ) textEditor.GetOcx();</pre>

### The Engine

Here’s a simple example of how to launch a form with all five FineReader controls and load a PDF file.

<pre class="csharpcode">IEngine engine;
FRDocument document;
ComponentSynchronizer synchronizer;
IEngineLoader loader;

<span class="kwrd">private</span> <span class="kwrd">void</span> LoadEngine()
{
    loader = <span class="kwrd">new</span> FREngine.InprocLoader();
    engine = loader.GetEngineObject(<span class="str">"xxxx-xxxx-xxxx-xxxx-xxxx-xxxx"</span>);

    engine.ParentWindow = <span class="kwrd">this</span>.Handle.ToInt32();
    engine.ApplicationTitle = <span class="kwrd">this</span>.Text;
    document = engine.CreateFRDocumentFromImage(<span class="str">@"C:UsersAlvinMiscDocuments10-22-08_2012letter.pdf"</span>);
    synchronizer.Document = document;
}

<span class="kwrd">private</span> <span class="kwrd">void</span> SyncComponents()
{
    synchronizer = <span class="kwrd">new</span> ComponentSynchronizer();
    synchronizer.DocumentViewer = (FineReaderVisualComponents.DocumentViewer)DocViewer.GetOcx();
    synchronizer.ImageViewer = (FineReaderVisualComponents.ImageViewer)ImgViewer.GetOcx();
    synchronizer.TextEditor = (FineReaderVisualComponents.TextEditor)textEdit.GetOcx();
    synchronizer.ZoomViewer = (FineReaderVisualComponents.ZoomViewer)zoomView.GetOcx();
    synchronizer.TextValidator = (FineReaderVisualComponents.TextValidator)textVal.GetOcx();
}

<span class="kwrd">private</span> <span class="kwrd">void</span> UnloadEngine()
{
    <span class="rem">// If Engine was loaded, unload it</span>
    <span class="kwrd">if</span> (engine != <span class="kwrd">null</span>)
    {
        engine = <span class="kwrd">null</span>;
    }
}

<span class="kwrd">private</span> <span class="kwrd">void</span> DocumentForm_Load(<span class="kwrd">object</span> sender, EventArgs e)
{
    SyncComponents();
    LoadEngine();
}

<span class="kwrd">private</span> <span class="kwrd">void</span> DocumentForm_FormClosing(<span class="kwrd">object</span> sender, FormClosingEventArgs e)
{
    UnloadEngine();
}</pre>

Of course in a real-world application, you will probably implement a button the user can invoke to choose a file from the file system to open. It is important to note that unloading the engine is very important. Failing to do so will tie up the license for your workstation until it is manually released from the license server. We are dealing with COM interop… resource and memory management is very important.

### Recognition

Running recognition processing on a loaded document is a relatively simple matter as well. Here is a method that manages the process.

<pre class="csharpcode"><span class="kwrd">private</span> <span class="kwrd">void</span> RecognizeDocument()
{
    FREngine.ProcessingParams processingParams = synchronizer.ProcessingParams;

    FREngine.DIFRDocumentEvents_OnProgressEventHandler progressHandler =
        <span class="kwrd">new</span> FREngine.DIFRDocumentEvents_OnProgressEventHandler(document_OnProgress);

    document.OnProgress += progressHandler;

    document.Process(processingParams.PageProcessingParams,
        processingParams.SynthesisParamsForPage, processingParams.SynthesisParamsForDocument);

    document.OnProgress -= progressHandler;
}</pre>

The progressHanlder provides the opportunity to keep the UI responsive and allows users to invoke a Cancel command to stop a long-running document recognition process.

### Exporting

To export a loaded document, the Export() method on your document object is invoked. Here is an example snippet that exports the loaded document to an RTF file:

<pre class="csharpcode">synthesizeIfNeed();
Document.Export(fileName, FREngine.FileExportFormatEnum.FEF_RTF, <span class="kwrd">null</span>);</pre>

### Profiles

ABBYY FineReader Engine also supports ‘Profiles’ which enable the engine to optimize its processing based on the current usage scenario. Here are the Profiles currently available.

  * _**DocumentConversion_Accuracy**_ — for converting documents into editable formats, optimized for accuracy
  * _**DocumentConversion_Speed**_ — for converting documents into editable formats, optimized for speed
  * _**DocumentArchiving_Accuracy**_ — for creating an electronic archive, optimized for accuracy
  * _**DocumentArchiving_Speed**_ — for creating an electronic archive, optimized for speed
  * _**BookArchiving_Accuracy**_ — for creating an electronic library, optimized for accuracy
  * _**BookArchiving_Speed**_ — for creating an electronic library, optimized for speed
  * _**TextExtraction_Accuracy**_ — for extracting text from documents, optimized for accuracy
  * _**TextExtraction_Speed**_ — for extracting text from documents, optimized for speed
  * _**FieldLevelRecognition**_ — for recognizing short text fragments
  * _**BarcodeRecognition**_ — for extracting barcodes
  * _**Version9Compatibility**_ — provided for compatibility, sets the processing parameters to the default values of ABBYY FineReader Engine 9.0.

The <span style="color: #ffffff; font-family: 'Courier New';">Engine.LoadPredefinedProfile(profileName)</span> method is used to load one of these profiles. Creating a custom user-defined profile is also supported via an INI-style format. There are detailed instructions in the included help file for assistance in creating these custom profiles. Custom user profiles are loaded with a call to <span style="color: #ffffff; font-family: Consolas;">Engine.LoadProfile(fileName)</span>.

### Other Platforms and Products

I only used the Windows SDK for FineReader, but there are several other products available from ABBYY. There are Mac OS, Linux, Embedded and Mobile SDKs available as well. Also available is Web API for developers via ABBYY’s hosted Cloud environment on Azure (go to [www.ocrsdk.com][5]). ABBYY also has some powerful out-of-the-box OCR products to choose from. Visit their site to check out all of their offerings.

### The Bottom Line

Setting up and using the ABBYY FineReader Engine SDK is really simple and it provides access to powerful OCR capabilities for your applications. I highly recommend reviewing their products if you have OCR requirements for your own application. Why re-invent the wheel?

> **Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the Federal Trade Commission’s 16 CFR, Part 255: “[Guides Concerning the Use of Endorsements and Testimonials in Advertising.][6]”

<div class="wlWriterEditableSmartContent" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:148951b5-6521-450b-ad42-7888e2acad26" style="float: none; margin: 0px; display: inline; padding: 0px;">
  del.icio.us Tags: <a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/ABBYY" rel="tag">ABBYY</a>,<a href="http://del.icio.us/popular/OCR" rel="tag">OCR</a>,<a href="http://del.icio.us/popular/SDK" rel="tag">SDK</a>,<a href="http://del.icio.us/popular/winforms" rel="tag">winforms</a>,<a href="http://del.icio.us/popular/vs2012" rel="tag">vs2012</a>,<a href="http://del.icio.us/popular/COM" rel="tag">COM</a>
</div>

 [1]: /wp-content/uploads/2013/02/ABBYY.1.NewProject.png
 [2]: /wp-content/uploads/2013/02/ABBYY.2.AddControls.png
 [3]: /wp-content/uploads/2013/02/ABBYY.3.AddReferences.png
 [4]: /wp-content/uploads/2013/02/ABBYY.4.ControlsOnForm.png
 [5]: http://www.ocrsdk.com
 [6]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html