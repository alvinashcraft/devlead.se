---
title: The Dew Review – DevExpress DXv2 WPF 2012.1
author: Alvin A.
type: post
date: 2012-06-21T15:29:40+00:00
url: /2012/06/21/the-dew-review-devexpress-dxv2-wpf-2012-1/
categories:
  - Development
  - reviews
  - tools
tags:
  - devexpress
  - expression blend
  - metro
  - visual studio
  - wpf
  - xaml

---
### Intro

I recently had the opportunity to use a beta release of the WPF controls coming in the exciting new 2012.1 release of [DevExpress DXv2][1]. This release is a major one for DevExpress’ WPF suite, the biggest addition being a set of Metro-inspired controls. With these controls, developers will have the ability to create desktop applications that look and feel like Windows 8 Metro apps. I had previously only used the ASP.NET controls from DevExpress, and I was pleasantly surprised at how easy it was to pick up the WPF controls and start using them. Here is a quick review of my impressions.

### Install Experience

Even the installer has been given the Metro treatment. It looks cool, clean and simple. It feels more like an application than an installer. Kudos to the team for not forgetting how important first impressions can be. Here are a couple of the installer screens.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="installer_welcome" border="0" alt="installer_welcome" src="/wp-content/uploads/installer_welcome_thumb.png" width="244" height="151" />][2]

<sup>Figure 1 &#8211; Installer Welcome Screen</sup>

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="installer_readytoinstall" border="0" alt="installer_readytoinstall" src="/wp-content/uploads/installer_readytoinstall_thumb.png" width="244" height="151" />][3]

<sup>Figure 2 &#8211; Ready to Install</sup>

### Demo Center

After the installer completes, it launches a Metro-styled Demo Center. There are several WPF demo applications to explore, including Video Rental, Realtor World, a Stock Market Trader and a mail client. The full source is available for each of the demo applications as well. I decided to explore the Realtor World app because it looks and feels like a Windows 8 Metro app.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="devexpress demo-center" border="0" alt="devexpress demo-center" src="/wp-content/uploads/devexpress-demo-center_thumb.png" width="244" height="156" />][4]

<sup>Figure 3 &#8211; The Demo Center</sup>

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="wpf-demos" border="0" alt="wpf-demos" src="/wp-content/uploads/wpf-demos_thumb.png" width="244" height="160" />][5]

<sup>Figure 4 &#8211; WPF Demos</sup>

Realtor World includes a main screen with Windows 8 styled buttons to navigate to the other screens in the app. The other screens show off controls like a Metro-styled listbox, graphs and charts. It is a cool-looking app that looks like something you would install from the Windows Marketplace in Windows 8.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="realtorworld_home" border="0" alt="realtorworld_home" src="/wp-content/uploads/realtorworld_home_thumb.png" width="244" height="139" />][6]

<sup>Figure 5 &#8211; Realtor World Main Screen</sup>

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="realtorworld_loancalc" border="0" alt="realtorworld_loancalc" src="/wp-content/uploads/realtorworld_loancalc_thumb.png" width="244" height="139" />][7]

<sup>Figure 6 &#8211; Realtor World Loan Calculator</sup>

### WPF Project Templates

When you start a new WPF project, you have a couple of options. You can create a regular WPF Application project, or you can use the DXperience v12.1 WPF Application project template that is included with the controls.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="newproject" border="0" alt="newproject" src="/wp-content/uploads/newproject_thumb.png" width="244" height="170" />][8]

<sup>Figure 7 &#8211; The New Project Dialog</sup>

If you choose the DevExpress template, you are presented with another dialog where you can choose which features to include in the main dialog of your new application, such as Dock Manager, Toolbar Manager, Ribbon, Grid, Theming and others. Each of those features can be tweaked from the dialog. For example, if you choose to include the dock manager, you can select from different styles for the docked windows. One of the styles looks like Visual Studio tool windows which can be pinned, auto-hide or float. The can look even more like Visual Studio windows if you choose the Visual Studio 2010 theme for your application.

### Controls

After playing around with the demos and tools for building a new project, I decided to get down to business and start a new project as if I were building a real application from scratch. When I build WPF apps, always use the Model-View-ViewModel (MVVM) pattern and usually use Laurent Bugion’s open source [MVVM Light Toolkit][9]. I found that the DXv2 controls’ data binding just works in MVVM applications.

Overall, the controls are intuitive to use and good-looking too. I built a simple music library application on top of the [Chinook database][10]. I used a DXRibbonWindow with the MetropolisDark theme, a BarManager, DockLayoutManager, a GridControl, and the TileLayoutControl. I am still working on enhancing the app, but putting together a nice looking read-only UI took only a few hours.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="MyMusicLibary_blend" border="0" alt="MyMusicLibary_blend" src="/wp-content/uploads/MyMusicLibary_blend_thumb.png" width="244" height="149" />][11]

<sup>Figure 8 &#8211; Building &#8216;My Music Library&#8217; in Expression Blend (In Progress)</sup>

### Summary

I had a lot of fun developing with the WPF controls in DXv2. I am really looking forward to spending more time with the controls and enhancing my application. You can [download][12] and try a trial version of the tools today. I think you will be as impressed as I was.

> **Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the Federal Trade Commission’s 16 CFR, Part 255: “[Guides Concerning the Use of Endorsements and Testimonials in Advertising.][13]” 

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:8535cf56-5dc5-4e9c-8cb2-396a0ece5857" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/wpf" rel="tag">wpf</a>,<a href="http://del.icio.us/popular/devexpress" rel="tag">devexpress</a>,<a href="http://del.icio.us/popular/xaml" rel="tag">xaml</a>,<a href="http://del.icio.us/popular/metro" rel="tag">metro</a>,<a href="http://del.icio.us/popular/expression+blend" rel="tag">expression blend</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>
</div>

 [1]: http://devexpress.com/Subscriptions/DXperience/DXv2/announce.xml
 [2]: /wp-content/uploads/installer_welcome.png
 [3]: /wp-content/uploads/installer_readytoinstall.png
 [4]: /wp-content/uploads/devexpress-demo-center.png
 [5]: /wp-content/uploads/wpf-demos.png
 [6]: /wp-content/uploads/realtorworld_home.png
 [7]: /wp-content/uploads/realtorworld_loancalc.png
 [8]: /wp-content/uploads/newproject.png
 [9]: http://mvvmlight.codeplex.com/
 [10]: http://chinookdatabase.codeplex.com/
 [11]: /wp-content/uploads/MyMusicLibary_blend.png
 [12]: http://devexpress.com/Home/try.xml
 [13]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html