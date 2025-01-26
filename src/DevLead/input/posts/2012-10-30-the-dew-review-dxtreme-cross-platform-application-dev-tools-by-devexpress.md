---
title: 'The Dew Review – DXTREME: Cross-Platform Application Dev Tools by DevExpress'
author: Alvin A.
type: post
date: 2012-10-30T20:02:44+00:00
url: /2012/10/30/the-dew-review-dxtreme-cross-platform-application-dev-tools-by-devexpress/
categories:
  - Development
  - how-to
  - reviews
tags:
  - asp.net mvc web api
  - devexpress
  - html5
  - iOS
  - javascript
  - json
  - knockout.js
  - visual studio

---
DevExpress has released a new set of cross-platform tools that enable developers to create rich web applications targeting mobile and desktop browsers. DXTREME is the name of the new package that aims to make developers more productive in these scenarios.

Just how easy is it to jump in and build a simple application? I have had little experience developing for platforms other than Windows and Windows Phone, and I have been wanting to find a way to target iOS and Android. So, when I was asked to take a look at DXTREME, I jumped at the opportunity.

### Installation and Getting Started

Installation was quick and painless, as is the case with all DevExpress tools (<a href="https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/06/21/the-dew-review-devexpress-dxv2-wpf-2012-1/" target="_blank">see my review of their WPF suite</a>). After installing, a new DevExpress template category is added in Visual Studio 2012’s New Project dialog. In there, select the  DXTREME 12.2 Application Project template to get started.

[<img loading="lazy" decoding="async" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="NewProject" src="/wp-content/uploads/NewProject_thumb.png" alt="NewProject" width="404" height="279" border="0" />][1]

The default project contains quite a few files. App.html is the default page and acts as the container for all of your views. Index.html is the default view loaded by App.html. Each of these html files has a corresponding .js and .css file. The navigation bar for DXTREME apps has its files located under layoutsNavbar. The default navigation buttons are Home and About (which loads the included About.html file). The datadb.js file performs data retrieval for the app.

[<img loading="lazy" decoding="async" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="SolutionExplorer" src="/wp-content/uploads/SolutionExplorer_thumb.png" alt="SolutionExplorer" width="304" height="518" border="0" />][2]

### Data Retrieval

I am a big fan of the <a href="http://www.asp.net/web-api" target="_blank">ASP.NET Web API</a>, and I wanted to see how easily I could get a DXTREME application to work with a Web API data source. I downloaded the <a href="http://code.msdn.microsoft.com/Contact-Manager-Web-API-0e8e373d" target="_blank">Contact Manager Web API sample</a> and running in IIS Express on port 8081. Getting the data in my app was as simple as adding this code to db.js.

<div class="csharpcode">
  <pre><span class="lnum"> 1: </span>$(<span class="kwrd">function</span>() {</pre>

<pre><span class="lnum"> 2: </span>    ContactSample.db = <span class="kwrd">new</span> DevExpress.data.RestService({</pre>

<pre><span class="lnum"> 3: </span>        url: <span class="str">"http://localhost:8081/api/"</span>,</pre>

<pre><span class="lnum"> 4: </span>        sources: {</pre>

<pre><span class="lnum"> 5: </span>            contacts: {</pre>

<pre><span class="lnum"> 6: </span>                read: <span class="str">"Contacts.json"</span></pre>

<pre><span class="lnum"> 7: </span>            }</pre>

<pre><span class="lnum"> 8: </span>        }</pre>

<pre><span class="lnum"> 9: </span>    });</pre>

<pre><span class="lnum"> 10: </span>});</pre>
</div>

The included DevExpress JavaScript libraries have functions to retrieve data from different types of data sources. The next step is to make the contact data available by calling the data function from the ViewModel (index.js).

<div class="csharpcode">
  <pre><span class="lnum"> 1: </span>ContactSample.index = <span class="kwrd">function</span>(<span class="kwrd">params</span>) {</pre>

<pre><span class="lnum"> 2: </span></pre>

<pre><span class="lnum"> 3: </span>    <span class="kwrd">var</span> viewModel = {</pre>

<pre><span class="lnum"> 4: </span>        contacts: {</pre>

<pre><span class="lnum"> 5: </span>            store: ContactSample.db.contacts</pre>

<pre><span class="lnum"> 6: </span>        }</pre>

<pre><span class="lnum"> 7: </span>    };</pre>

<pre><span class="lnum"> 8: </span></pre>

<pre><span class="lnum"> 9: </span>    <span class="kwrd">return</span> viewModel;</pre>

<pre><span class="lnum"> 10: </span>};</pre>
</div>

### The View

DXTREME uses knockout.js for binding data in views to the ViewModels. So, the last thing to do to get the main page up and running is adding a few lines of code to index.html.

<div class="csharpcode">
  <pre><span class="lnum"> 1: </span><span class="kwrd">&lt;</span><span class="html">div</span> <span class="attr">data-role</span><span class="kwrd">="view"</span> <span class="attr">data-name</span><span class="kwrd">="index"</span> <span class="attr">data-title</span><span class="kwrd">="Home"</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 2: </span>    <span class="kwrd">&lt;</span><span class="html">div</span> <span class="attr">data-target-placeholder</span><span class="kwrd">="content"</span> <span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 3: </span>        <span class="kwrd">&lt;</span><span class="html">h2</span> <span class="attr">style</span><span class="kwrd">="padding: 4px"</span><span class="kwrd">&gt;</span>My Contacts<span class="kwrd">&lt;/</span><span class="html">h2</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 4: </span>        <span class="kwrd">&lt;</span><span class="html">p</span> <span class="attr">style</span><span class="kwrd">="padding: 2px"</span><span class="kwrd">&gt;</span>Contact name, email and twitter handle.<span class="kwrd">&lt;/</span><span class="html">p</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 5: </span>        <span class="kwrd">&lt;</span><span class="html">div</span> <span class="attr">data-bind</span><span class="kwrd">="dxList: { dataSource: contacts }"</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 6: </span>            <span class="kwrd">&lt;</span><span class="html">div</span> <span class="attr">data-dx-role</span><span class="kwrd">="template"</span> <span class="attr">data-dx-name</span><span class="kwrd">="item"</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 7: </span>                <span class="kwrd">&lt;</span><span class="html">div</span> <span class="attr">data-bind</span><span class="kwrd">="uri: 'ContactDetail/{ContactId}'"</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 8: </span>                    <span class="kwrd">&lt;</span><span class="html">div</span> <span class="attr">data-bind</span><span class="kwrd">="text: Name"</span><span class="kwrd">&gt;&lt;/</span><span class="html">div</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 9: </span>                <span class="kwrd">&lt;/</span><span class="html">div</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 10: </span>            <span class="kwrd">&lt;/</span><span class="html">div</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 11: </span>        <span class="kwrd">&lt;/</span><span class="html">div</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 12: </span>    <span class="kwrd">&lt;/</span><span class="html">div</span><span class="kwrd">&gt;</span></pre>

<pre><span class="lnum"> 13: </span><span class="kwrd">&lt;/</span><span class="html">div</span><span class="kwrd">&gt;</span></pre>
</div>

Now when we run the app, we get a list of contacts from the Web API service in our app. The page can be viewed in simulators for iPad, iPhone, Android or Android tablets. There are also options to view the simulators in portrait or landscape mode. This is what our page looks like in the iPhone simulator.

[<img loading="lazy" decoding="async" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Sim" src="/wp-content/uploads/Sim_thumb.png" alt="Sim" width="404" height="229" border="0" />][3]

Navigation is also very easy to accomplish in DXTREME. I added a second page to display contact details for a selected contact name with very little effort.

[<img loading="lazy" decoding="async" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="Page2" src="/wp-content/uploads/Page2_thumb.png" alt="Page2" width="404" height="229" border="0" />][4]

You can download the entire project <a href="/wp-content/uploads/ContactSample.zip" target="_blank">here</a>.

### The Path Forward

As a next step in your DXTREME learning experience, I recommend downloading a trial version <a href="http://www.devexpress.com/Subscriptions/DXTREME/" target="_blank">here</a>, and then head over to the <a href="http://help.devexpress.com/HTML/#!Overview" target="_blank">DXTREME Learning Center</a>. There is a simple app walkthrough with code and a simulator as well as detailed documentation around more advanced controls, data access, routing and navigation.

I enjoyed building with DXTREME and plan to use it on a couple of personal projects in the near future. I recommend giving the tools a try for yourself.

&nbsp;

> **Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the Federal Trade Commission’s 16 CFR, Part 255: “[Guides Concerning the Use of Endorsements and Testimonials in Advertising.][5]”

&nbsp;

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:dad860ce-af80-4e0b-9035-fa44f5ab4dd6" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
  del.icio.us Tags: <a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/html5" rel="tag">html5</a>,<a href="http://del.icio.us/popular/iOS" rel="tag">iOS</a>,<a href="http://del.icio.us/popular/devexpress" rel="tag">devexpress</a>,<a href="http://del.icio.us/popular/javascript" rel="tag">javascript</a>,<a href="http://del.icio.us/popular/knockout.js" rel="tag">knockout.js</a>,<a href="http://del.icio.us/popular/json" rel="tag">json</a>,<a href="http://del.icio.us/popular/asp.net+mvc+web+api" rel="tag">asp.net mvc web api</a>
</div>

 [1]: /wp-content/uploads/NewProject.png
 [2]: /wp-content/uploads/SolutionExplorer.png
 [3]: /wp-content/uploads/Sim.png
 [4]: /wp-content/uploads/Page2.png
 [5]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html