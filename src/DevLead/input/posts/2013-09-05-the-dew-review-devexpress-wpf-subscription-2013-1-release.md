---
title: The Dew Review – DevExpress WPF Subscription – 2013.1 Release
author: Alvin A.
type: post
date: 2013-09-05T18:03:14+00:00
url: /2013/09/05/the-dew-review-devexpress-wpf-subscription-2013-1-release/
categories:
  - Development
  - reviews
  - tools
tags:
  - devexpress
  - mvvm
  - reporting
  - visual studio
  - windows 8
  - wpf

---
### Introduction

I have been using the latest release (2013.1) of <a href="http://www.devexpress.com/Products/NET/Controls/WPF/" target="_blank">DevExpress’ WPF Subscription</a> over the last several weeks on my new <a href="https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2013/07/28/the-dew-review-intel-haswell-ultrabook-review-part-1-initial-impressions/" target="_blank">Ultrabook</a>, and I have had a great time exploring the expansive collection of tools and controls included in the suite. I have only used a fraction of the available controls available in this release, but I have been very impressed with everything I have been able to test drive so far.

### What’s New

DevExpress has been building WPF controls for a long time now, but I cannot remember the last release with so much <a href="http://www.devexpress.com/Products/NET/Controls/WPF/new.xml" target="_blank">new stuff</a> included. Here’s a quick rundown of the new features in 2013.1:

  * Getting Started Tutorial (New – <a href="http://help.devexpress.com/#WPF/CustomDocument15281" target="_blank">Online</a>) 
  * Data Grid (Enhanced) 
  * Chart Control Wizard (New) 
  * Map Control (Enhanced) 
  * Property Grid (New) 
  * Row Multi-Select in Grid Lookup Control (New) 
  * Range Control Integration in Scheduler Control (New) 
  * Design-Time Extensions (SmartTags in the Designer) (New) 
  * Scaffolding Wizards (New) 
  * WPF Data Source Wizard (New) 
  * Instant Layout Assistant (VS2012 Only) (New) 
  * Icon Library w/VS Integrated Image Picker (New) 
  * Windows UI Style Controls (New) 
  * Touch Enabled Theme (New) 
  * Window Visual Effects (New) 
  * Touch-Friendly Date Picker Control (New) 
  * Touch-Friendly Range Control (New) 
  * Visual Studio Template Gallery 

Quite a list, eh?

I will focus this article on a few of the coolest (in my opinion) features: the Template Gallery, the Windows UI Style Controls, and the Touch-Enabled Theme.

### Template Gallery

DevExpress now integrates their own Template Gallery into Visual Studio. Under the DevExpress menu, you will find an ‘All Platforms’ submenu containing ‘New Project’ and ‘New Item’ menu items.

[<img loading="lazy" decoding="async" title="dx1" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="dx1" src="/wp-content/uploads/dx1_thumb.png" width="404" height="114" />][1]

Selecting either of these launches the Template Gallery. The project templates are divided into WPF Common, WPF Business Solutions, and WPF Windows UI Solutions.

[<img loading="lazy" decoding="async" title="dx2" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="dx2" src="/wp-content/uploads/dx2_thumb.png" width="454" height="342" />][2]

The Business Solutions are project templates that create Word and Outlook applications with main windows that are modeled after Microsoft Word and Outlook, each very functional. Here is a screen shot of the Word style application running with no extra code added:

[<img loading="lazy" decoding="async" title="dx3" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="dx3" src="/wp-content/uploads/dx3_thumb.png" width="454" height="291" />][3]

There is a full ribbon control filled with controls that manipulate the rich text editor. Everything I tried works as expected.

The ‘New Item’ Template Gallery window provides the following list of item templates to select:

  * **WPF Common** 
      * DXWindow 
      * DXRibbonWindow 
      * DXSplashScreen 
      * UserControl 
  * **WPF Views for MVVM** 
      * Tabbed MDI View 
      * Business Object View 
      * Collection View 
  * **WPF View Models for MVVM** 
      * Blank View Model 
      * Business Object View Model 
      * Collection View Model 
  * **WPF Data Models for MVVM** 
      * Entity Framework Data Model 

Each of the item templates has its own wizard to assist in binding to existing or new data sources. MVVM out-of-the-box… nice. Hopefully, we will have the same kinds of choices built into Visual Studio’s New Item dialog soon.

### Windows UI Style Controls

Selecting the Tile Application project from the DevExpress Template Gallery will create a WPF project that looks like a Windows UI Style app. Run the project for the first time and here is what you will see:

[<img loading="lazy" decoding="async" title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="/wp-content/uploads/image_thumb17.png" width="454" height="257" />][4]

It is a full-screen WPF desktop application with no close button or other window chrome. If you didn’t alt-tab back to Visual Studio and see the application’s icon in the Windows Desktop taskbar, it would be hard to tell the difference. The Windows 8 look-and-feel is provided by the DevExpress TileLayoutControl and groups of TileControls.

This is an MVVM application with two views (in addition to MainWindow.xaml), two view models and a sample data source used as the model.

[<img loading="lazy" decoding="async" title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="/wp-content/uploads/image_thumb18.png" width="454" height="257" />][5]

### Touch-Enabled Theme

A new theme called TouchlineDark was added to support touch screen PCs and tablets. By changing the dx:ThemeManager.ThemeName to TouchlineDark in MainWindow.xaml from the previous section, the whole app switches to the new theme.

[<img loading="lazy" decoding="async" title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="/wp-content/uploads/image_thumb19.png" width="454" height="257" />][6]

By default, DevExpress WPF controls styled with this theme will be larger and more touch-friendly, as can many of the standard WPF controls from Microsoft. Here’s a shot of the DevExpress WPF Data Grid using TouchlineDark I found in the <a href="http://documentation.devexpress.com/#WPF/CustomDocument7407" target="_blank">online documentation</a>.

[<img loading="lazy" decoding="async" title="HelpResource" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="HelpResource" src="/wp-content/uploads/HelpResource_thumb.jpg" width="404" height="267" />][7]

### Summary

As you can see, the WPF Subscription from DevExpress has everything a developer could ask for to create great-looking line-of-business (LOB) or Windows UI Style applications in as little time as possible. With advanced support for MVVM, data binding, theming and simple but powerful controls, the suite will be an integral part of my developer toolbelt for my next WPF project.

Happy coding!

&#160;

**Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the Federal Trade Commission’s 16 CFR, Part 255: “[Guides Concerning the Use of Endorsements and Testimonials in Advertising.][8]”

&#160;

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:4e1385e9-88e3-4ad0-8d62-72d7763d14e2" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  del.icio.us Tags: <a href="http://del.icio.us/popular/wpf" rel="tag">wpf</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/devexpress" rel="tag">devexpress</a>,<a href="http://del.icio.us/popular/mvvm" rel="tag">mvvm</a>,<a href="http://del.icio.us/popular/reporting" rel="tag">reporting</a>,<a href="http://del.icio.us/popular/windows+8" rel="tag">windows 8</a>
</div>

 [1]: /wp-content/uploads/dx1.png
 [2]: /wp-content/uploads/dx2.png
 [3]: /wp-content/uploads/dx3.png
 [4]: /wp-content/uploads/image31.png
 [5]: /wp-content/uploads/image32.png
 [6]: /wp-content/uploads/image33.png
 [7]: /wp-content/uploads/HelpResource.jpg
 [8]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html