---
title: Building an Offline HTML5 Application
author: Alvin A.
type: post
date: 2012-07-23T14:00:30+00:00
url: /2012/07/23/building-an-offline-html5-application/
categories:
  - books
  - Development
  - how-to
tags:
  - html5
  - javascript
  - manning
  - web development

---
<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" width="145">
      <p>
        <a href="http://www.manning.com/jackson/"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="clip_image002" border="0" alt="clip_image002" src="/wp-content/uploads/clip_image0021.jpg" width="129" height="161" /></a>
      </p>
    </td>
    
    <td valign="top" width="486">
      <p>
        <a href="http://www.manning.com/jackson/">HTML5 for .NET Developers</a>
      </p>
      
      <p>
        By Jim Jackson II and Ian Gilman
      </p>
      
      <p>
        <i>The idea that you can browse to an application while online and then go back to it when you are offline to continue reading, working, or playing goes against everything most people have learned about how the internet works. This offline capable concept is, however, gaining momentum and familiarity with users. This article based on chapter 9 of <a href="http://www.manning.com/jackson/">HTML5 for .NET Developers</a></i><i> talks about building offline applications.</i>
      </p>
    </td>
  </tr>
</table>

Suppose your partner is upset because you never seem to remember to buy lettuce, carrots, and celery while you are at the grocery store. Perhaps your forgetfulness has to do with the fact that you do not like to eat vegetables; in any case, you know that the criticism is deserved and you have committed to never forget the lettuce again. To that end, we will design and build a simple shopping list application that can be edited either online or offline. This way, your partner can add vegetables to the list, and you can access it even when you are at the grocery store. Figure 1 shows the simple, usable interface that we will be creating.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="clip_image004" border="0" alt="clip_image004" src="/wp-content/uploads/clip_image004_thumb.jpg" width="244" height="194" />][1]

<a name="_Toc321298537"><sup><a name="_Toc321298537">Figure 1 The complete application will allow a user to add and remove shopping items regardless of whether or not they are currently connected.</a></sup></a>

The basic premise of an offline web application is that, with specific directives in the markup and careful site preparation, you can actually take your application with you even when you are not connected to a network. With this feature though come some unique challenges and important design decisions. To make your current site or HTML application available offline you must first inventory the resources that you currently use. Every file you include in your site will need to be evaluated against the following criteria:

  * Is the resource static or is it dynamically called?
  * If the resource is static, should it be available when the application is offline?
  * If not available when offline, should a substitute resource be provided?
  * If the resource is dynamic; how will the application handle requests for it when no network connection is available?

> ### Going offline vs. being offline
> 
> There are two scenarios that you will have to consider when building your offline web site. The first occurs when a user is online and then loses connectivity. This could be because they were using a portable Wi-Fi device and walked out of range or because the airplane mode was switched on. Whatever the reason, the important part is that the page was not reloaded and the browser was not closed and reopened but the network connection was suddenly unavailable. In this scenario, you need to track the current connection status from within the page. 
> 
> The second scenario is when the user visits an offline-accessible page and then closes the browser. When the user reopens the browser and navigates back to the page, there is no connection so nothing can be loaded from the server. At that stage, all content previously saved to the cache is loaded.
> 
> Both of these scenarios imply the ability for the page to suddenly come back online. When that happens, the page should be notified and any connection-related functions should fire. That brings us to the problem of data synchronization.

For your shopping list app, our first thoughts relate to design considerations. The application must show the user when they are connected or disconnected. A simple cue on the screen will help us there. Then, we must decide how to store the data generated locally so that it can be synchronized back and forth with the server. Our application will use LocalStorage and an MVC controller to handle the storage and synchronization. Finally, the client-side logic must work the same from the user’s perspective whether connected or disconnected and gracefully handle changing connectivity states internally. This is where the Offline HTML5 API and some smooth jQuery operations come in. 

> ### Using ASP.NET MVC with offline HTML5 applications
> 
> While this application will be built on an MVC (Model View Controller) platform using a simple JSON controller for the data synchronization and a singleton object to emulate a data storage server, the page we will be visiting will not be an MVC view. Instead we will use a simple HTML page. We must do it this way because offline web applications require a physical page to reference as the starting point for the offline cache. The standard MVC application, by comparison, only presents a URL end point, not a physical file.

With design considerations considered, in this article, we’ll create the basic site structure and then the offline JavaScript library.

### <a name="_Toc321298515">Creating the basic site structure</a>

Start by opening Visual Studio and creating a new ASP.NET MVC Web Application and call it ShoppingList. Be sure to make it an Internet Application that uses the Razor engine and HTML5 Semantic Markup when you come to the New Project Dialog. Using MVC allows us to create a controller to feed data to and from the client via Ajax, but remember that it does not allow us to use a Razor view for our offline application.

Inside the new solution, we first need to create our offline page. To do so:

  * Right-click on the solution node and select Add > New Item > HTML Page. 
  * Name the new page Shopping.htm, after which your page should now appear in the application’s root folder.
  * Inside the new page, add the complete markup.

Much of the code within that file is unremarkable and not worth discussing here. One thing we do want you to note about the initial markup is the attribute in the opening <html> tag that points to a file named app.manifest.

<pre class="csharpcode"><span class="kwrd">&lt;!</span><span class="html">DOCTYPE</span> <span class="attr">html</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;</span><span class="html">html</span> <span class="attr">manifest</span><span class="kwrd">="app.manifest"</span><span class="kwrd">&gt;</span>

<span class="kwrd">&lt;</span><span class="html">head</span><span class="kwrd">&gt;</span>
...
<span class="kwrd">&lt;/</span><span class="html">head</span><span class="kwrd">&gt;</span>

<span class="kwrd">&lt;</span><span class="html">body</span><span class="kwrd">&gt;</span>
...
<span class="kwrd">&lt;/</span><span class="html">body</span><span class="kwrd">&gt;</span>

<span class="kwrd">&lt;/</span><span class="html">html</span><span class="kwrd">&gt;</span></pre>

App.manifest is the file that, by its presence, tells the browser that this page should be available offline. More on the contents of that file shortly.

Next is the styling for the application. In Solution Explorer:

  * Right-click on the Content folder and select Add > New Item > Style Sheet.
  * Name the new stylesheet offline.css.
  * Grab the required markup and add it to the stylesheet (see [HTML5 for .NET Developers][2] for the code).

We will be creating a brand new set of styles for our offline application since it is not necessary to duplicate the normal tabbed interface in the rest of the application. This will give the user a cue that this page is different and allow us to keep things as streamlined as possible. 

> ### Telling the user that a site is available offline
> 
> The CSS file is a good opportunity to think about how to let your users know that the site they are visiting is available offline. Each application is different so it is more important to understand the scope and nature of the problem rather than specific suggestions for resolving it.
> 
> The first part of the problem is letting your users know in a fluent fashion that the site they are visiting will be available to them later even if they are not connected. It is unnatural for a user to consider opening a browser on a device when he or she knows that there is no connection. So what kinds of indicators on the site could provide that cue? Additionally, you will probably only be building a subset of the site’s functionality for offline consumption. How can this be indicated to the user?
> 
> Next, while a user is working with the site, it is reasonable to expect an occasional loss of connectivity. What are some ways that your application can tell the user what has happened and that there is no cause for concern because their work is being saved locally?
> 
> The area of offline web pages is still very new so little or no research has been done to standardize on a method of identifying these conditions to your users. This leaves the door open to practically any solution with your creativity being the only limitation. Chrome, for instance, will change its home page to monochrome icons if the system is not currently online. This is a very intuitive indicator but you might choose to include an icon or glyph in the corner of the browser window that shows the currently connected status. Even a banner that appears temporarily in your site is not unheard of, though some might consider it heavy handed. Your final solution should make it very clear to anyone visiting the site what is possible and what the current connectivity status is. Any less that this is a recipe for confusion or worse: an unused web site.

### <a name="_Toc321298516">The offline JavaScript library</a>

The next step is to build our JavaScript interface. This will help sort through which functions are responsible for which tasks during execution. Our offline HTML application will use local storage to contain two kinds of data. The first is the current list of shopping list items and the second is a listing of required actions to update the server to reflect the client state. We will also add some utility functions to keep things manageable and reduce duplication of code. 

We have not created the main.js file in the Scripts folder of our site yet, so, do that now. Open it and add the code in listing 1 to stub out our entire API. This code creates the outline that you can fill in as you dig deeper into offline applications. (Remember, if you have any questions about where specific pieces of code fit in the main.js file, the complete listing is in the book.)

##### <a name="_Toc321298543">Listing 1 The JavaScript API for the offline web application</a>

<pre class="csharpcode"><span class="rem">/// &lt;reference path="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.7.1.js" /&gt;</span>
<span class="rem">/// &lt;reference path="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.7.1-vsdoc.js" /&gt;</span>

$(document).ready(<span class="kwrd">function</span> () {
    Main.init();
});

window.Main = {
    $status: <span class="kwrd">null</span>, #A
    $input: <span class="kwrd">null</span>, #A
    shoppingItems: [], #B
    itemActions: [], #C
    init: <span class="kwrd">function</span> () { #D
},

updateForNetStatus: <span class="kwrd">function</span> (connected) { #E
},

newItem: <span class="kwrd">function</span> (title) { #F
},

loadState: <span class="kwrd">function</span> () { #G
},

saveState: <span class="kwrd">function</span> () { #H
},

syncWithServer: <span class="kwrd">function</span> () { #I
}
};</pre>

<sup>#A The ShoppingList object will contain a place holder for the status and input elements to prevent us from having to requery the DOM every time </sup>

<sup>#B Keeps a list of current shopping items</sup>

<sup>#C Keeps a list of all items that must be synchronized to the server</sup>

<sup>#D Initializes the object </sup>

<sup>#E Starts listening for the current online status</sup>

<sup>#F The newItem function updates the user interface with a new element and then assigns that element’s delete key to an anonymous function </sup>

<sup>#G The loadState function is called when initializing the screen and pulls data from LocalStorage, calling newItem on each value</sup>

<sup>#H saveState takes all items in the local shoppingItems array and update LocalStorages with the same. </sup>

<sup>#I Finally, syncWithServer takes the all items cached for server updates and sends them off</sup>

This JavaScript file is the last client side file you need before starting the process of making the site available offline. 

## Summary

Offline web applications can be robust and responsive in most modern browsers and the proliferation of tablet-based devices with only Wi-Fi support should increase their popularity. The biggest drawback is still the fact that users are unaccustomed to using a web site while not connected. Once this barrier is overcome though, proper design and attention to details in an offline application will yield a rich experience and a web site that is usable in many more circumstances than has been traditionally possible in web development.

In this article, you learned about creating basic HTML and CSS structure and developing a JavaScript interface as part of the process of building an offline HTML5 application.

**  
  
** 

**Here are some other Manning titles you might be interested in:**

****

<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" width="67">
      <p>
        <a href="http://www.manning.com/crowther/"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="clip_image006" border="0" alt="clip_image006" src="/wp-content/uploads/clip_image0061.jpg" width="52" height="64" /></a>
      </p>
    </td>
    
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/crowther/">Quick & Easy HTML5 and CSS3</a>
      </p>
      
      <p>
        Rob Crowther
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="67">
      <p>
        <a href="http://www.manning.com/netherland/"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="clip_image008" border="0" alt="clip_image008" src="/wp-content/uploads/clip_image008.jpg" width="52" height="64" /></a>
      </p>
    </td>
    
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/netherland/">Sass and Compass in Action</a>
      </p>
      
      <p>
        Wynn Netherland, Nathan Weizenbaum, and Chris Eppstein
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="67">
      <p>
        <a href="http://www.manning.com/resig/"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="clip_image010" border="0" alt="clip_image010" src="/wp-content/uploads/clip_image010.jpg" width="52" height="64" /></a>
      </p>
    </td>
    
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/resig/">Secrets of the JavaScript Ninja</a>
      </p>
      
      <p>
        John Resig and Bear Bibeault
      </p>
    </td>
  </tr>
</table>

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:a1e82d6d-6312-4daf-8f3f-e98364563cf3" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/html5" rel="tag">html5</a>,<a href="http://del.icio.us/popular/manning" rel="tag">manning</a>,<a href="http://del.icio.us/popular/web+development" rel="tag">web development</a>,<a href="http://del.icio.us/popular/javascript" rel="tag">javascript</a>
</div>

 [1]: /wp-content/uploads/clip_image0041.jpg
 [2]: http://www.manning.com/jackson