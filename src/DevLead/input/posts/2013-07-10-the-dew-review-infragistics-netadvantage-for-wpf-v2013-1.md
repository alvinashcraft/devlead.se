---
title: The Dew Review – Infragistics NetAdvantage for WPF v2013.1
author: Alvin A.
type: post
date: 2013-07-10T13:16:00+00:00
url: /2013/07/10/the-dew-review-infragistics-netadvantage-for-wpf-v2013-1/
categories:
  - Development
  - reviews
  - tools
tags:
  - infragistics
  - netadvantage
  - wpf

---
### Background

I have been using controls from <a href="http://www.infragistics.com/" target="_blank">Infragistics</a> (and previously Sheridan) for nearly fourteen years. I started using Sheridan’s controls for Visual Basic 6 back in late 1999 / early 2000 while developing the UI for a warehouse management system. Since that time, Sheridan has become Infragistics and I have used their WinForm and WPF NetAdvantage suites in several large projects in both the manufacturing and health care industries.

The most recent version of <a href="http://www.infragistics.com/products/wpf/" target="_blank">NetAdvantage for WPF is 2013.1</a>, just released in April. I recently had the opportunity to kick the tires on this release and wanted to share my thoughts.

### Installing the Tools

Installing NetAdvantage for WPF is simple and painless, and a free trial of the suite can be downloaded <a href="http://www.infragistics.com/products/wpf/downloads" target="_blank">online</a>. You have the option of installing sample projects locally. Many WPF samples can also be test-driven <a href="http://www.infragistics.com/products/wpf/samples" target="_blank">live online</a>. Both Visual Studio 2010 and 2012 are supported, as well as Expression Blend 4.0 and later. I have not tried using them with the Visual Studio 2013 beta, but I am sure they will work with that version as well.

Once installed, the 80+ controls are all automatically added to your Visual Studio Toolbox window.

<p align="left">
  <a href="/wp-content/uploads/toolbox1.png"><img loading="lazy" decoding="async" title="toolbox1" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="toolbox1" src="/wp-content/uploads/toolbox1_thumb.png" width="164" height="344" /></a><a href="/wp-content/uploads/toolbox2.png"><img loading="lazy" decoding="async" title="toolbox2" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="toolbox2" src="/wp-content/uploads/toolbox2_thumb.png" width="164" height="490" /></a>
</p>

<p align="left">
  <a href="/wp-content/uploads/toolbox3.png"><img loading="lazy" decoding="async" title="toolbox3" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="toolbox3" src="/wp-content/uploads/toolbox3_thumb.png" width="164" height="595" /></a><a href="/wp-content/uploads/toolbox4.png"><img loading="lazy" decoding="async" title="toolbox4" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="toolbox4" src="/wp-content/uploads/toolbox4_thumb.png" width="164" height="173" /></a>
</p>

<p align="left">
  As you can see, there are controls available for just about any scenario your business analysts can throw your way.
</p>

### Samples

If you choose to install the sample projects, they can be found under an Infragistics folder in Public Documents.

[<img loading="lazy" decoding="async" title="samples location" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="samples location" src="/wp-content/uploads/samples-location_thumb.png" width="244" height="192" />][1]

There is a Showcase sample which is a C# project containing line-of-business samples including a Music Browser, a Stock Trader and a Customer Relationship Manager. This set of samples highlights some of the ways you can use the <a href="http://www.infragistics.com/products/wpf/samples" target="_blank">WPF controls</a> together to build applications with a great user experience.

There are also over 50 projects that highlight how to use individual controls and sets of controls in the NetAdvantage suite. These projects are all part of the Infragistics.Samples.WPF solution found in the CLR4.0 samples folder.

[<img loading="lazy" decoding="async" title="wpf samples" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="wpf samples" src="/wp-content/uploads/wpf-samples_thumb.png" width="404" height="371" />][2]

### What’s New

NetAdvantage 2013.1 has a number of <a href="http://www.infragistics.com/products/wpf/whatsnew" target="_blank">new and updated features</a> for WPF. Several of the data visualization controls have been enhanced, including the Gantt, Geographic Map and Data Chart. New controls include the Doughnut Chart (for visualizing percentages) and the Radial Gauge (in CTP version).

[<img loading="lazy" decoding="async" title="13_1_donughtCharts" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="13_1_donughtCharts" src="/wp-content/uploads/13_1_donughtCharts_thumb.png" width="404" height="239" />][3]

**<sup><font color="#ffffff">The WPF Doughnut Chart control.</font></sup>**

The <a href="http://www.infragistics.com/products/wpf/ribbon/" target="_blank">WPF Ribbon controls</a> have been updated to include an Office 2010 style Application Menu, and their new <a href="http://www.infragistics.com/products/wpf/syntax-editor/" target="_blank">Syntax Parsing Engine</a> is now RTM. This framework enables developers to embed powerful code editing features into their own applications.

### My Impressions

The applications I typically build focus more on user input and interaction than on data visualization. So, I tend to use controls like Dock Manager, Tab Control, Data Grid, Editors and Menus/Toolbars.

One of the best things about using controls from Infragistics is the built-in theming support. In the included Showcase sample, switching between themes can be done with the click of a button, and the code behind those buttons is relatively straightforward. Each theme has resources in a corresponding xaml resource file. The theme selected has its file loaded into a ResourceDictionary, the existing MergedDictionaries collection is cleared and the new one loaded. Finally, the DataPresenter for the XamDataGrid control has its Theme property set to the name of the new theme. Here’s a snippet of that code:

<pre class="csharpcode"><span class="kwrd">string</span> path = <span class="str">"CustomerRelations/Resources/Themes/"</span> + themeFile; 
Uri uri = <span class="kwrd">new</span> Uri(path, UriKind.Relative); 
ResourceDictionary rd = Application.LoadComponent(uri) <span class="kwrd">as</span> ResourceDictionary; 
  
<span class="rem">// Clear the MergedDictionaries collection </span>
Resources.MergedDictionaries.Clear(); 
  
<span class="rem">// Add the new RD to the MergedDictionaries Collection </span>
Resources.MergedDictionaries.Add(rd); 
  
<span class="rem">// Set Infragistics Theme for XamDataGrid </span>
DataPresenter1.Theme = themeName;</pre>

Any Infragistics WPF control derived from the DataPresenterBase class has a Theme property that can be set at runtime.

I was anxious to try out the new Syntax Editor control, and I was pleasantly surprised how easy it was to get some pretty powerful functionality with almost no code.

[<img loading="lazy" decoding="async" title="code editor" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="code editor" src="/wp-content/uploads/code-editor_thumb.png" width="404" height="266" />][4]

I got line numbers, auto-indentation and C# syntax highlighting with only two lines of code.

<pre class="csharpcode"><span class="kwrd">private</span> <span class="kwrd">void</span> Window_Loaded(<span class="kwrd">object</span> sender, RoutedEventArgs e) 
{ 
    mainSyntaxEditor.Document = <span class="kwrd">new</span> Infragistics.Documents.TextDocument(); 
    mainSyntaxEditor.Document.Language = CSharpLanguage.Instance; 
} </pre>

Support for C#, VB and SQL ship with the editor, but it can be extended to support other languages with custom grammar definition files.

I am looking forward to spending more time with this amazing editor control.

# 

### Wrap-Up

Controls for Windows applications have come a long way since I started building software. User expectations have also evolved quite a bit. It’s no longer good enough to just build applications that are functional. They also need to look great. This focus on user experience understood by the team at Infragistics, and they keep pushing the bar higher with their controls. If you have a WPF project that needs a great UI, I suggest you take a look at the latest NetAdvantage suite for WPF. You will almost always end up saving money in the long run when you buy instead of build from scratch.

&#160;

> **Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the Federal Trade Commission’s 16 CFR, Part 255: “[Guides Concerning the Use of Endorsements and Testimonials in Advertising.][5]”

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:a21c6e9d-0226-4ac0-b334-5219fc7c3f51" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  del.icio.us Tags: <a href="http://del.icio.us/popular/wpf" rel="tag">wpf</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/infragistics" rel="tag">infragistics</a>
</div>

 [1]: /wp-content/uploads/samples-location.png
 [2]: /wp-content/uploads/wpf-samples.png
 [3]: /wp-content/uploads/13_1_donughtCharts.png
 [4]: /wp-content/uploads/code-editor.png
 [5]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html