---
title: 'C# + ReSharper = Awesome: Tip #6 – Extract Interface'
author: Alvin A.
type: post
date: 2012-01-09T17:15:35+00:00
url: /2012/01/09/c-resharper-awesome-tip-6-extract-interface/
categories:
  - Development
  - how-to
tags:
  - refactoring
  - resharper
  - visual studio

---
This is the sixth in a series of quick how-to articles on <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>.

### Tip #6 – Extract Interface

**Use:** Creates a new interface based on the selected class and updates the class to implement the new interface. This is most useful when working with an existing code base because we all define our interfaces first when doing greenfield development, right?&#160;<img decoding="async" style="border-bottom-style: none; border-left-style: none; border-top-style: none; border-right-style: none" class="wlEmoticon wlEmoticon-smile" alt="Smile" src="/wp-content/uploads/wlEmoticon-smile3.png" /> 

##### Before

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> Shooter</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">public</span> <span class="kwrd">string</span> Name { get; set; }</pre>

<pre><span class="lnum">   4:  </span>&#160;</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">public</span> <span class="kwrd">string</span> ReleaseDate { get; set; }</pre>

<pre><span class="lnum">   6:  </span>&#160;</pre>

<pre><span class="lnum">   7:  </span>        <span class="kwrd">public</span> <span class="kwrd">int</span> MaxPlayers { get; set; }</pre>

<pre><span class="lnum">   8:  </span>&#160;</pre>

<pre><span class="lnum">   9:  </span>        <span class="kwrd">public</span> <span class="kwrd">bool</span> HasZombies { get; set; }</pre>

<pre><span class="lnum">  10:  </span>&#160;</pre>

<pre><span class="lnum">  11:  </span>        <span class="kwrd">public</span> <span class="kwrd">bool</span> IsHalo { get; set; }</pre>

<pre><span class="lnum">  12:  </span>&#160;</pre>

<pre><span class="lnum">  13:  </span>        <span class="kwrd">public</span> <span class="kwrd">void</span> Borrow()</pre>

<pre><span class="lnum">  14:  </span>        {</pre>

<pre><span class="lnum">  15:  </span>            <span class="rem">//TODO: Implement borrow logic.</span></pre>

<pre><span class="lnum">  16:  </span>        }</pre>

<pre><span class="lnum">  17:  </span>    }</pre>
</div>

##### Right-click the class

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb5.png" width="544" height="219" />][1]

##### Select members

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="SNAGHTML4614fae1" border="0" alt="SNAGHTML4614fae1" src="/wp-content/uploads/SNAGHTML4614fae1_thumb.png" width="484" height="345" />][2]

##### After

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">interface</span> IGame</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">string</span> Name { get; set; }</pre>

<pre><span class="lnum">   4:  </span>        <span class="kwrd">string</span> ReleaseDate { get; set; }</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">int</span> MaxPlayers { get; set; }</pre>

<pre><span class="lnum">   6:  </span>        <span class="kwrd">void</span> Borrow();</pre>

<pre><span class="lnum">   7:  </span>    }</pre>

<pre><span class="lnum">   8:  </span>&#160;</pre>

<pre><span class="lnum">   9:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> Shooter : IGame</pre>

<pre><span class="lnum">  10:  </span>    {</pre>

<pre><span class="lnum">  11:  </span>        <span class="kwrd">public</span> <span class="kwrd">string</span> Name { get; set; }</pre>

<pre><span class="lnum">  12:  </span>&#160;</pre>

<pre><span class="lnum">  13:  </span>        <span class="kwrd">public</span> <span class="kwrd">string</span> ReleaseDate { get; set; }</pre>

<pre><span class="lnum">  14:  </span>&#160;</pre>

<pre><span class="lnum">  15:  </span>        <span class="kwrd">public</span> <span class="kwrd">int</span> MaxPlayers { get; set; }</pre>

<pre><span class="lnum">  16:  </span>&#160;</pre>

<pre><span class="lnum">  17:  </span>        <span class="kwrd">public</span> <span class="kwrd">bool</span> HasZombies { get; set; }</pre>

<pre><span class="lnum">  18:  </span>&#160;</pre>

<pre><span class="lnum">  19:  </span>        <span class="kwrd">public</span> <span class="kwrd">bool</span> IsHalo { get; set; }</pre>

<pre><span class="lnum">  20:  </span>&#160;</pre>

<pre><span class="lnum">  21:  </span>        <span class="kwrd">public</span> <span class="kwrd">void</span> Borrow()</pre>

<pre><span class="lnum">  22:  </span>        {</pre>

<pre><span class="lnum">  23:  </span>            <span class="rem">//TODO: Implement borrow logic.</span></pre>

<pre><span class="lnum">  24:  </span>        }</pre>

<pre><span class="lnum">  25:  </span>    }</pre>
</div>

__

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:964ace36-7c8d-484f-8db8-1d7a61162120" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/refactoring" rel="tag">refactoring</a>
</div>

 [1]: /wp-content/uploads/image16.png
 [2]: /wp-content/uploads/SNAGHTML4614fae1.png