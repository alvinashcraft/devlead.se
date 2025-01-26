---
title: 'C# + ReSharper = Awesome: Tip #4 – Convert Abstract Class to Interface'
author: Alvin A.
type: post
date: 2011-12-20T18:09:07+00:00
url: /2011/12/20/c-resharper-awesome-tip-4-convert-abstract-class-to-interface/
categories:
  - Development
  - how-to
tags:
  - refactoring
  - resharper
  - visual studio

---
This is the fourth in a series of quick how-to articles on <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>.

### Tip #4 – Convert Abstract Class to Interface

**Use:** This is used when the class(es) that will be inheriting from a base class also need to inherit from another base class. Derived types can inherit from only one base class but can implement multiple interfaces.

##### Before

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">abstract</span> <span class="kwrd">class</span> Book</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">public</span> <span class="kwrd">abstract</span> <span class="kwrd">string</span> Title { get; set; }</pre>

<pre><span class="lnum">   4:  </span>&#160;</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">public</span> <span class="kwrd">abstract</span> <span class="kwrd">string</span> Year { get; set; }</pre>

<pre><span class="lnum">   6:  </span>&#160;</pre>

<pre><span class="lnum">   7:  </span>        <span class="kwrd">public</span> <span class="kwrd">abstract</span> <span class="kwrd">string</span> Author { get; set; }</pre>

<pre><span class="lnum">   8:  </span>&#160;</pre>

<pre><span class="lnum">   9:  </span>        <span class="kwrd">public</span> <span class="kwrd">abstract</span> <span class="kwrd">void</span> Lend();</pre>

<pre><span class="lnum">  10:  </span>&#160;</pre>

<pre><span class="lnum">  11:  </span>        <span class="kwrd">public</span> <span class="kwrd">abstract</span> <span class="kwrd">void</span> AddToInventory();</pre>

<pre><span class="lnum">  12:  </span>    }</pre>
</div>

##### Right-click the class

[<img loading="lazy" decoding="async" style="background-image: none; border-right-width: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb3.png" width="644" height="110" />][1]

##### After

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">interface</span> Book</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">string</span> Title { get; set; }</pre>

<pre><span class="lnum">   4:  </span>        <span class="kwrd">string</span> Year { get; set; }</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">string</span> Author { get; set; }</pre>

<pre><span class="lnum">   6:  </span>        <span class="kwrd">void</span> Lend();</pre>

<pre><span class="lnum">   7:  </span>        <span class="kwrd">void</span> AddToInventory();</pre>

<pre><span class="lnum">   8:  </span>    }</pre>
</div>

****

**Note:** Notice that this refactoring does not change the name of the type. At this point, there will be a squiggly line under the interface’s name, Book. Placing the cursor on Book and pressing <Alt+Enter> will prompt ReSharper to rename it to IBook.

&#160;

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:2cd1143e-a9e1-4989-a451-a58ace481cff" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/refactoring" rel="tag">refactoring</a>
</div>

 [1]: /wp-content/uploads/image14.png