---
title: 'The Dew Review- DevExpress ASP.NET 2013.2'
author: Alvin A.
type: post
date: 2013-12-04T11:00:00+00:00
url: /2013/12/04/the-dew-review-devexpress-asp-net-2013-2/
categories:
  - Development
tags:
  - asp.net
  - asp.net mvc
  - devexpress
  - excel

---
### Introduction

<a href="https://www.devexpress.com/" target="_blank">DevExpress</a> has just launched a new release of their <a href="https://www.devexpress.com/Subscriptions/DXperience.xml" target="_blank">.NET components</a>. The new release, 2013.2 (aka 13.2), has a ton of new features and enhancements across the entire suite. I have spent the last several weeks getting to know the latest incarnation of their <a href="https://www.devexpress.com/Products/NET/Controls/ASP/" target="_blank">ASP.NET line of controls</a>. A couple of years back when I was working at Oracle, I used their ASP.NET controls. While much of the API feels familiar in the new product, the controls have a clearer, modern looks (with theming support, of course), and they also feel faster and more responsive than I remember.

### WebForms and MVC Controls

The ASP.NET product includes controls for both WebForms and MVC. They now have nearly 100 WebForms controls and over 50 for ASP.NET MVC. While modern web developers tend to gravitate toward MVC, there are still many organizations that embrace WebForms for its rapid UI development support and the richness of server-side controls.

### What’s New

Of the <a href="https://www.devexpress.com/Products/NET/Controls/ASP/features.xml" target="_blank">new controls</a>, most seem to be available to both WebForms and MVC. Many of the new MVC controls are client-side versions of existing, popular WebForms controls. One significant addition that is WebForms-only is the new ASP.NET Spreadsheet control. A new theme, called Moderno, is available in 13.2. It looks a little like their Metropolis Blue theme with less flatness and a little more rounded around the edges.

There are so many new and updated controls in this release. I didn’t have time to explore them all. Let’s take a closer look at a few of the ones I have been experimenting with.

### Spreadsheet & Ribbon Controls

These controls are definitely the biggest and most impressive piece of the 13.2 release. Here’s a screenshot of the two controls together from the included ‘Formulas’ sample.

[<img loading="lazy" decoding="async" title="devexpress aspnet 1" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; margin: 0px 0px 10px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="devexpress aspnet 1" src="/wp-content/uploads/2013/12/devexpress-aspnet-1_thumb.png" width="644" height="433" />][1]

A completely custom ribbon control can be created with a series of RibbonTab, RibbonGroup and RibbonCommand items in the HTML markup or dynamically in the code behind. This Data tab:

[<img loading="lazy" decoding="async" title="devexpress aspnet 2" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; margin: 0px 0px 10px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="devexpress aspnet 2" src="/wp-content/uploads/2013/12/devexpress-aspnet-2_thumb.png" width="644" height="92" />][2]

was created with this markup:

<pre class="csharpcode"><span class="kwrd">&lt;</span><span class="html">dx:RibbonTab</span> <span class="attr">Name</span><span class="kwrd">="Data"</span> <span class="attr">Text</span><span class="kwrd">="Data"</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">groups</span><span class="kwrd">&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">dx:RibbonGroup</span> <span class="attr">Name</span><span class="kwrd">="Common"</span> <span class="attr">Text</span><span class="kwrd">="Common"</span><span class="kwrd">&gt;</span>
            <span class="kwrd">&lt;</span><span class="html">Items</span><span class="kwrd">&gt;</span>
                <span class="kwrd">&lt;</span><span class="html">dx:SPDataSortAscendingRibbonCommand</span><span class="kwrd">&gt;</span>
                <span class="kwrd">&lt;/</span><span class="html">dx:SPDataSortAscendingRibbonCommand</span><span class="kwrd">&gt;</span>
                <span class="kwrd">&lt;</span><span class="html">dx:SPDataSortDescendingRibbonCommand</span><span class="kwrd">&gt;</span>
                <span class="kwrd">&lt;/</span><span class="html">dx:SPDataSortDescendingRibbonCommand</span><span class="kwrd">&gt;</span>
            <span class="kwrd">&lt;/</span><span class="html">Items</span><span class="kwrd">&gt;</span>
        <span class="kwrd">&lt;/</span><span class="html">dx:RibbonGroup</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;/</span><span class="html">groups</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">dx:RibbonTab</span><span class="kwrd">&gt;</span></pre>

Pretty straightforward, I think.

The RibbonTabs and all of their children are created within the spreadsheet control, and each type of RibbonCommand control knows how to act upon the selected cells in the spreadsheet. So, right out of the box, developers get a ton of Excel functionality in their applications, no extra coding is necessary.

Here is a high-level listing of the features of the Spreadsheet control.

  * Automatically Generated UI 
  * Automated Formula Calculation Engine 
  * Built-in Spreadsheet Functions 
  * Cell References and Formatting 
  * Cell and Cell Ranges 
  * Rows and Columns 
  * Charting, Pictures 
  * Worksheet Management

Having this kind of functionality in a web application is pretty amazing.

### Batch Editing in Grid

Now in both WebForms and MVC, you can support batch editing in the ASP.NET Grid control. Change the Mode property to Batch and updates on the client side will be sent to the server when the user clicks Save. As changes are being made in the control, edits are shown in green.

[<img loading="lazy" decoding="async" title="devexpress aspnet 3" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; margin: 0px 0px 10px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="devexpress aspnet 3" src="/wp-content/uploads/2013/12/devexpress-aspnet-3_thumb.png" width="644" height="246" />][3]

No more round-trips as each record needs to be updated on the server. Just a little data binding and a few SQL commands and you are ready to go.

### Token Box

The last new control I want to write about is the Token Box. The Token Box is a new editor control that can auto-complete multiple values from a list. This is something you commonly see online for adding tags or filters to a search. Here is the Token Box sample with a few list item values selected.

[<img loading="lazy" decoding="async" title="devexpress aspnet 4" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; margin: 0px 0px 10px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="devexpress aspnet 4" src="/wp-content/uploads/2013/12/devexpress-aspnet-4_thumb.png" width="644" height="63" />][4]

If I remove one and then start searching for a new value, I get a filtered list in a dropdown list.

[<img loading="lazy" decoding="async" title="devexpress aspnet 5" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; margin: 0px 0px 10px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="devexpress aspnet 5" src="/wp-content/uploads/2013/12/devexpress-aspnet-5_thumb.png" width="644" height="107" />][5]

You can set the filtering mode to either a Starts With or a Contains style of filtering. You can also specify whether custom tokens not available in the list can be entered by the user.&nbsp; The control in the sample is bound to an xml file with bindings set for Text (name) and Value (email address).

<pre class="csharpcode"><span class="kwrd">&lt;</span><span class="html">dx:ASPxTokenBox</span> <span class="attr">ID</span><span class="kwrd">="ASPxTokenBox1"</span> <span class="attr">runat</span><span class="kwrd">="server"</span> <span class="attr">Width</span><span class="kwrd">="100%"</span> <span class="attr">DataSourceID</span><span class="kwrd">="AddressBookXml"</span> <span class="attr">TextField</span><span class="kwrd">="Name"</span> <span class="attr">ValueField</span><span class="kwrd">="Email"</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">dx:ASPxTokenBox</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;</span><span class="html">asp:XmlDataSource</span> <span class="attr">ID</span><span class="kwrd">="AddressBookXml"</span> <span class="attr">runat</span><span class="kwrd">="server"</span> <span class="attr">DataFile</span><span class="kwrd">="~/App_Data/Contacts.xml"</span> <span class="attr">XPath</span><span class="kwrd">="//Contacts/*"</span> <span class="kwrd">/&gt;</span></pre>

### Summary

These are a few of the highlights of the new <a href="https://www.devexpress.com/Products/NET/Controls/ASP/" target="_blank">ASP.NET release from DevExpress</a>, but it really just scratches the surface. Go check it out for yourself. There is a free <a href="https://www.devexpress.com/Home/try.xml" target="_blank">30 day trial</a> available for all of DevExpress’ .NET products with full support available during the trial period.

Happy coding!

&nbsp;

**Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the [Federal Trade Commission’s 16 CFR, Part 255: “Guides Concerning the Use of Endorsements and Testimonials in Advertising.][6]

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:432a33aa-e9d6-4dae-8463-a2f14ee56d34" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  del.icio.us Tags: <a href="http://del.icio.us/popular/devexpress" rel="tag">devexpress</a>,<a href="http://del.icio.us/popular/asp.net" rel="tag">asp.net</a>,<a href="http://del.icio.us/popular/asp.net+mvc" rel="tag">asp.net mvc</a>,<a href="http://del.icio.us/popular/excel" rel="tag">excel</a>
</div><div data-type="ad" data-publisher="lqm.alvinashcraft.site" data-zone="ron" data-format="1x1"</div> </div>

 [1]: /wp-content/uploads/2013/12/devexpress-aspnet-1.png
 [2]: /wp-content/uploads/2013/12/devexpress-aspnet-2.png
 [3]: /wp-content/uploads/2013/12/devexpress-aspnet-3.png
 [4]: /wp-content/uploads/2013/12/devexpress-aspnet-4.png
 [5]: /wp-content/uploads/2013/12/devexpress-aspnet-5.png
 [6]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html