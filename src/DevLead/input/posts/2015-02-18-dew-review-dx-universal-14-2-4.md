---
title: The Dew Review – DevExpress Universal 14.2.4
author: Alvin A.
type: post
date: 2015-02-18T14:00:00+00:00
url: /2015/02/18/dew-review-dx-universal-14-2-4/
categories:
  - Development
  - reviews
  - tools
tags:
  - asp.net mvc
  - devexpress
  - entity framework
  - ms office
  - reporting
  - winforms
  - wpf

---
## Intro

Over the last several years, I have reviewed <a href="http://www.devexpress.com" target="_blank">DevExpress</a> components a number of times. Here are four of my most recent reviews.

  * [The Dew Review- DevExpress ASP.NET 2013.2][1]
  * [The Dew Review – DevExpress WPF Subscription – 2013.1 Release][2]
  * [The Dew Review – DXTREME: Cross-Platform Application Dev Tools by DevExpress][3]
  * [The Dew Review – DevExpress DXv2 WPF 2012.1][4]

This year I have been looking at and starting to use several components from the Universal 14.2.4 release. The <a href="https://www.devexpress.com/Subscriptions/Universal.xml" target="_blank">DevExpress Universal</a> subscription encompasses controls and modules for all types of .NET development as well as cross platform web and mobile development with DevExtreme. From WinForms to WPF and Windows Universal apps on the client, and WebForms, MVC, HTML5/JS on the web, DevExpress has something for every modern developer on the Microsoft stack.

## What’s New

Something that is easily noticed about the 14.2.4 release of DevExpress is that there is a focus on delivering components that enable developers to create great experiences on today’s devices. First and foremost, that means touch. Unless you’re buying a server, it’s hard to find a new Windows device that isn’t touch enabled in some way, either the screen itself or via a multi-touch touchpad. Today’s apps need to support taps, pinches, flicks, and swipes. The Windows and web components from DevExpress help make that possible. Read more about it [here][5].

Let’s call out a few specific new and/or improved features of the 14.2 release.

<a href="https://www.devexpress.com/Subscriptions/New-2014.xml?product=winforms" target="_blank">WinForms</a>

  * Ratings Control
  * TimeSpan Editor
  * SQL Data Access Component
  * Workspace Manager

<a href="https://www.devexpress.com/Subscriptions/New-2014.xml?product=aspnet" target="_blank">ASP.NET WebForms</a>

  * Rich Text Editor
  * New Design-Time Wizards to create controls
  * Adaptive Panels – Get responsive layouts for your content
  * Spreadsheet – Password Protected Sheets and Elements added (<a href="http://demos.devexpress.com/ASPxSpreadsheetDemos/Features/WorksheetProtection.aspx" target="_blank">Demo</a>)

<a href="https://www.devexpress.com/Subscriptions/New-2014.xml?product=mvc" target="_blank">ASP.NET MVC</a>

  * MVC Spell Checker
  * Spreadsheet – Password Protected Sheets and Elements added (<a href="http://demos.devexpress.com/ASPxSpreadsheetDemos/Features/WorksheetProtection.aspx" target="_blank">Demo</a>)

<a href="https://www.devexpress.com/Subscriptions/New-2014.xml?product=wpf" target="_blank">WPF</a>

  * Radial Menu
  * Spell Checker – Check-as-You-Type Mode added
  * Chart Control – New series types added: Spline, Spline Area, Stacked Spline Area & Full-Stacked Spline Area

<a href="https://www.devexpress.com/Subscriptions/New-2014.xml?product=win8xaml" target="_blank">Windows 8 XAML</a>

  * Tile Bar
  * MVVM Support

<a href="https://www.devexpress.com/Subscriptions/New-2014.xml?product=xaf" target="_blank">XAF</a>

  * End-User Report Designer
  * New Notifications Module

<a href="https://www.devexpress.com/Subscriptions/New-2014.xml?product=devextreme" target="_blank">DevExtreme</a>

  * A Slew of new HTML5/JS Widgets
  * iOS 8 and Android 5 Support

## Areas of Focus

Due to the breadth of the DevExpress Universal product, I’m going to focus on a couple of areas within the WPF and DevExtreme products.

### WPF

#### Sample &#8211; Video Rental

One of the WPF sample applications provided with DevExpress Universal is the Video Rental application. It is a full-featured application for managing the operation of a video rental shop. Here are a few screen shots of the application in action.

<div id="scid:66721397-FF69-4ca6-AEC4-17E6B3208830:fba70f64-2562-4c14-848c-8203bce9ed4e" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 5px;">
  <a style="border: 0px;" href="/wp-content/uploads/2015/02/InlineRepresentationa7d6d73e6c204b27b570a176988e4c5e.jpg"><img loading="lazy" decoding="async" class="alignnone" style="border: 0px;" src="/wp-content/uploads/2015/02/InlineRepresentationa7d6d73e6c204b27b570a176988e4c5e.jpg" alt="View WPF Video Rental Sample Application" width="400" height="100" /></a></p> 
  
  <div style="width: 400px; text-align: right;">
  </div>
</div>

The application makes use of some of the rich Office-style controls you might find in Outlook, including a ribbon-style toolbar, whose contents are context aware and change while navigating through the application.

The code is extensive and well designed. The ViewModels are broken out into their own project, with other projects for UI, Resources, and Data/Platform Services. Here’s a diagram of the project dependencies.

[<img loading="lazy" decoding="async" style="display: inline; border-width: 0px;" title="Screen Shot 2015-02-07 at 1.57.40 PM" src="/wp-content/uploads/2015/02/ScreenShot20150207at1.57.40PM_thumb.png" alt="Screen Shot 2015-02-07 at 1.57.40 PM" width="644" height="290" border="0" />][6]

This is a good example of a fully baked, line-of-business app that can be built with WPF and DevExpress.

#### Templates

DevExpress Universal includes a template wizard to select the starting point that best suits your project based on platform, DX version, and programming language. When selecting WPF as the platform, the following templates are available.

[<img loading="lazy" decoding="async" style="display: inline; border-width: 0px;" title="WPF Templates 1" src="/wp-content/uploads/2015/02/WPFTemplates1_thumb.png" alt="WPF Templates 1" width="644" height="484" border="0" />][7]

Selecting the ‘Project Wizard’ option, guides the developer through a series of choices to build the best possible starting point for the project. I’ve included the steps I have chosen in this gallery.

<div id="scid:66721397-FF69-4ca6-AEC4-17E6B3208830:d8cd5d19-4718-459f-ae99-2a03e51a79a6" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
  <a style="border: 0px;" href="/wp-content/uploads/2015/02/InlineRepresentationccb39069ca654259aab39769ef452b4e.jpg"><img loading="lazy" decoding="async" class="alignnone" style="border: 0px;" src="/wp-content/uploads/2015/02/InlineRepresentationccb39069ca654259aab39769ef452b4e.jpg" alt="View WPF New Project Wizard" width="400" height="78" /></a></p> 
  
  <div style="width: 400px; text-align: right;">
  </div>
</div>

Obviously, not every project requires all of these features, and every step is an optional selection. Completing the wizard with all of the selections above produces a main window that looks like this. A complete UI ready to be hooked up to a view model with the <a href="https://community.devexpress.com/blogs/wpf/archive/2013/08/29/getting-started-with-devexpress-mvvm-framework-commands-and-view-models.aspx" target="_blank">DevExpress MVVM framework</a> or any other MVVM framework. A reference to DevExpress.Mvvm.dll v14.2 is automatically added to the starting project.

[<img loading="lazy" decoding="async" style="display: inline; border-width: 0px;" title="WPF Main Window" src="/wp-content/uploads/2015/02/WPFMainWindow_thumb.png" alt="WPF Main Window" width="644" height="351" border="0" />][8]

#### Feature Focus &#8211; MVVM Support with POCO ViewModels

There are a handful of popular MVVM frameworks available to .NET developers, including MVVM Light and Caliburn.Micro. The DevExpress MVVM Framework has one feature that sets it apart from many others.

A developer can create a POCO (plain old CLR object), and turn it into a ViewModel based on convention and a call to the DevExpress.Mvvm.POCO.ViewModelSource class. The following conventions define how ViewModelSource will create the resulting ViewModel from the provided POCO.

  * All public virtual and auto properties with public getters and public/protected setters will have bindable properties generated.
  * If specific logic is to be executed when a property changes, a method should be created with either of these formats:  <span style="font-family: Consolas; font-size: small;">On[Property Name]Changed()</span> or <span style="font-family: Consolas; font-size: small;">On[Property Name]Changing()</span>.
  * Commands are generated for all public methods with 0 or 1 parameters. There is an optional Command attribute and a fluent API to control the creation of the commands.
  * IDataErrorInfo can be added to POCO classes for validation by adding a class level attribute

Here’s a simple POCO that will be turned into a full-featured ViewModel at runtime by ViewModelSource using Reflection Emit.

<pre class="brush: csharp;">using System;
using System.ComponentModel.DataAnnotations;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace Alvin.DXWPF.Sample1
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class MainViewModel
    {
        //Bindable SummaryName property will be created with validation
        [Required(ErrorMessage = "Please enter the summary name.")] 
        public virtual string SummaryName { get; set; }

        //Bindable Categories property will be created
        public virtual IObservable&lt;string&gt; Categories { get; set; } 

        //SaveSettingsCommand will be created
        public void SaveSettings(string fileName) {
            // save logic here
        }

        //Will validate if the SaveSettingsCommand can be executed
        public bool CanSaveSettings(string fileName) {
            return !String.IsNullOrEmpty(fileName);
        }

        //Method that will NOT become a Command
        [Command(isCommand: false)]
        public void DoSomethingThatIsNotACommand()
        {
            // doing stuff
        }

        //prevent creating the View Model without the ViewModelSource 
        protected MainViewModel() { }

        //Use the ViewModelSource class to create a MainViewModel instance 
        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() =&gt; new MainViewModel());
        } 
    }
}
</pre>

As you can see, this method of creating view models can keep classes simple and clean.

### DevExtreme

#### Sample – DX Hotels

The DX Hotels sample application is a web application for booking hotel rooms. It is built on the DevExtreme platform using ASP.NET MVC, Razor views, OData, Entity Framework, jQuery and <a href="http://knockoutjs.com/" target="_blank">Knockout.js</a>. Here’s a peek at the project structure.

[<img loading="lazy" decoding="async" style="display: inline; border-width: 0px;" title="Screen Shot 2015-02-07 at 12.29.39 PM" src="/wp-content/uploads/2015/02/ScreenShot20150207at12.29.39PM_thumb.png" alt="Screen Shot 2015-02-07 at 12.29.39 PM" width="349" height="484" border="0" />][9]

This is what the page looks like when first loaded. The web application’s user can select a location and dates for booking.

[<img loading="lazy" decoding="async" style="display: inline; border-width: 0px;" title="DX Hotels Screen" src="/wp-content/uploads/2015/02/DXHotelsScreen_thumb.png" alt="DX Hotels Screen" width="644" height="349" border="0" />][10]

The amount of code in this project is much less than the WPF sample project for Video Rentals, but it also has a good deal of feature function. Users can search for, select and book hotels, and there is a simple login function that takes any user/password combo and simulates a logged-in state.

#### Templates

DevExtreme templates provide options to create JavaScript or <a href="http://www.typescriptlang.org/" target="_blank">TypeScript</a> applications, as well as <a href="http://www.odata.org/" target="_blank">OData</a> service projects in Visual Basic or C#.

[<img loading="lazy" decoding="async" style="display: inline; border-width: 0px;" title="Screen Shot 2015-02-07 at 2.55.18 PM" src="/wp-content/uploads/2015/02/ScreenShot20150207at2.55.18PM_thumb.png" alt="Screen Shot 2015-02-07 at 2.55.18 PM" width="644" height="449" border="0" />][11]

Selecting the “DevExtreme 14.2 Basic Application” template produces the following for a new project.

[<img loading="lazy" decoding="async" style="display: inline; border-width: 0px;" title="Screen Shot 2015-02-07 at 3.04.45 PM" src="/wp-content/uploads/2015/02/ScreenShot20150207at3.04.45PM_thumb.png" alt="Screen Shot 2015-02-07 at 3.04.45 PM" width="315" height="484" border="0" />][12]

In addition, there are 13 CSS files inside the css folder. The project is a cross-platform mobile web app which will launch in web based simulators in the selected browser when running the solution. By default, iOS is the selected simulator. Here’s the bare-bones project running as an iOS DX app.

[<img loading="lazy" decoding="async" style="display: inline; border-width: 0px;" title="Screen Shot 2015-02-07 at 3.07.15 PM" src="/wp-content/uploads/2015/02/ScreenShot20150207at3.07.15PM_thumb.png" alt="Screen Shot 2015-02-07 at 3.07.15 PM" width="252" height="484" border="0" />][13]

Because DevExtreme apps take advantage of <a href="http://cordova.apache.org/" target="_blank">Apache Cordova</a>, your apps can access native platform features like camera and location across device types. There has been a lot of discussion around Cordova app development recently, with the capability to build these apps being built in to Visual Studio 2013 and 2015. DevExtreme has been making this possible for a couple of years now.

## Wrapping Up

This article has taken a look at just a small part of what is possible with the controls and modules available in <a href="https://www.devexpress.com/Subscriptions/Universal.xml" target="_blank">DevExpress Universal 14.2</a>. Visit the <a href="https://www.devexpress.com/" target="_blank">DevExpress website</a> to learn more about what their control suite can do to accelerate your application development in 2015, and don’t forget to <a href="https://go.devexpress.com/DevExpressDownload_UniversalTrial.aspx" target="_blank">download a free trial</a>.

My next review will focus on <a href="http://testcafe.devexpress.com/" target="_blank">DevExpress TestCafé</a>, a powerful to make functional web testing easy and fun. Check back soon to read all about it.

&nbsp;

Happy Coding!

&nbsp;

> **Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the Federal Trade Commission’s 16 CFR, Part 255: “[Guides Concerning the Use of Endorsements and Testimonials in Advertising.][14]”

&nbsp;

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:628393c1-bd47-4317-ba12-7a6fac2782b1" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
  del.icio.us Tags: <a href="http://del.icio.us/popular/devexpress" rel="tag">devexpress</a>,<a href="http://del.icio.us/popular/wpf" rel="tag">wpf</a>,<a href="http://del.icio.us/popular/asp.net+mvc" rel="tag">asp.net mvc</a>,<a href="http://del.icio.us/popular/winforms" rel="tag">winforms</a>,<a href="http://del.icio.us/popular/entity+framework" rel="tag">entity framework</a>,<a href="http://del.icio.us/popular/ms+office" rel="tag">ms office</a>,<a href="http://del.icio.us/popular/reporting" rel="tag">reporting</a>
</div>

 [1]: https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2013/12/04/the-dew-review-devexpress-asp-net-2013-2/
 [2]: https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2013/09/05/the-dew-review-devexpress-wpf-subscription-2013-1-release/
 [3]: https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/10/30/the-dew-review-dxtreme-cross-platform-application-dev-tools-by-devexpress/
 [4]: https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/06/21/the-dew-review-devexpress-dxv2-wpf-2012-1/
 [5]: https://www.devexpress.com/Products/NET/Controls/Touch.xml
 [6]: /wp-content/uploads/2015/02/ScreenShot20150207at1.57.40PM.png
 [7]: /wp-content/uploads/2015/02/WPFTemplates1.png
 [8]: /wp-content/uploads/2015/02/WPFMainWindow.png
 [9]: /wp-content/uploads/2015/02/ScreenShot20150207at12.29.39PM.png
 [10]: /wp-content/uploads/2015/02/DXHotelsScreen.png
 [11]: /wp-content/uploads/2015/02/ScreenShot20150207at2.55.18PM.png
 [12]: /wp-content/uploads/2015/02/ScreenShot20150207at3.04.45PM.png
 [13]: /wp-content/uploads/2015/02/ScreenShot20150207at3.07.15PM.png
 [14]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html