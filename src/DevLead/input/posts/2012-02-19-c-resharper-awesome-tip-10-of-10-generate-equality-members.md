---
title: 'C# + ReSharper = Awesome: Tip #10 of 10 – Generate Equality Members'
author: Alvin A.
type: post
date: 2012-02-19T15:56:40+00:00
url: /2012/02/19/c-resharper-awesome-tip-10-of-10-generate-equality-members/
categories:
  - Development
  - how-to
tags:
  - refactoring
  - resharper
  - visual studio

---
This is the tenth and final in a series of quick how-to articles on <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>. There are obviously many more awesome features to explore, but I want to give equal time to the other available productivity tools for Visual Studio. Next week I will be starting a new series of tips on <a href="http://www.telerik.com/products/justcode.aspx" target="_blank">Telerik JustCode</a>. Following that series, I will take a look at <a href="http://devexpress.com/Products/Visual_Studio_Add-in/Coding_Assistance/" target="_blank">DevExpress CodeRush</a>.

### Tip #10 – Generate Equality Members

**Use:** If you are creating a class that will need to participate in equality operations, ReSharper can quickly generate the necessary method implementations for you.

##### Before

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> Order : IOrder</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">public</span> <span class="kwrd">int</span> OrderId { get; set; }</pre>

<pre><span class="lnum">   4:  </span>&#160;</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">public</span> <span class="kwrd">int</span> CustomerId { get; set; }</pre>

<pre><span class="lnum">   6:  </span>&#160;</pre>

<pre><span class="lnum">   7:  </span>        <span class="kwrd">public</span> DateTime OrderDate { get; set; }</pre>

<pre><span class="lnum">   8:  </span>&#160;</pre>

<pre><span class="lnum">   9:  </span>        <span class="kwrd">public</span> IList&lt;OrderDetail&gt; OrderDetails { get; set; }</pre>

<pre><span class="lnum">  10:  </span>    }</pre>
</div>

##### Click Generate Code

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb10.png" width="364" height="386" />][1]

##### Select Equality Members

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb11.png" width="162" height="218" />][2]

##### Select options and finish

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="SNAGHTML337d04cf" border="0" alt="SNAGHTML337d04cf" src="/wp-content/uploads/SNAGHTML337d04cf_thumb.png" width="404" height="404" />][3]

##### After

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> Order : IOrder, IEquatable&lt;Order&gt;</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">public</span> <span class="kwrd">int</span> OrderId { get; set; }</pre>

<pre><span class="lnum">   4:  </span>&#160;</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">public</span> <span class="kwrd">int</span> CustomerId { get; set; }</pre>

<pre><span class="lnum">   6:  </span>&#160;</pre>

<pre><span class="lnum">   7:  </span>        <span class="kwrd">public</span> DateTime OrderDate { get; set; }</pre>

<pre><span class="lnum">   8:  </span>&#160;</pre>

<pre><span class="lnum">   9:  </span>        <span class="kwrd">public</span> IList&lt;OrderDetail&gt; OrderDetails { get; set; }</pre>

<pre><span class="lnum">  10:  </span>&#160;</pre>

<pre><span class="lnum">  11:  </span>        <span class="kwrd">public</span> <span class="kwrd">bool</span> Equals(Order other)</pre>

<pre><span class="lnum">  12:  </span>        {</pre>

<pre><span class="lnum">  13:  </span>            <span class="kwrd">if</span> (ReferenceEquals(<span class="kwrd">null</span>, other)) <span class="kwrd">return</span> <span class="kwrd">false</span>;</pre>

<pre><span class="lnum">  14:  </span>            <span class="kwrd">if</span> (ReferenceEquals(<span class="kwrd">this</span>, other)) <span class="kwrd">return</span> <span class="kwrd">true</span>;</pre>

<pre><span class="lnum">  15:  </span>            <span class="kwrd">return</span> other.OrderId == OrderId;</pre>

<pre><span class="lnum">  16:  </span>        }</pre>

<pre><span class="lnum">  17:  </span>&#160;</pre>

<pre><span class="lnum">  18:  </span>        <span class="kwrd">public</span> <span class="kwrd">override</span> <span class="kwrd">bool</span> Equals(<span class="kwrd">object</span> obj)</pre>

<pre><span class="lnum">  19:  </span>        {</pre>

<pre><span class="lnum">  20:  </span>            <span class="kwrd">if</span> (ReferenceEquals(<span class="kwrd">null</span>, obj)) <span class="kwrd">return</span> <span class="kwrd">false</span>;</pre>

<pre><span class="lnum">  21:  </span>            <span class="kwrd">if</span> (ReferenceEquals(<span class="kwrd">this</span>, obj)) <span class="kwrd">return</span> <span class="kwrd">true</span>;</pre>

<pre><span class="lnum">  22:  </span>            <span class="kwrd">if</span> (obj.GetType() != <span class="kwrd">typeof</span> (Order)) <span class="kwrd">return</span> <span class="kwrd">false</span>;</pre>

<pre><span class="lnum">  23:  </span>            <span class="kwrd">return</span> Equals((Order) obj);</pre>

<pre><span class="lnum">  24:  </span>        }</pre>

<pre><span class="lnum">  25:  </span>&#160;</pre>

<pre><span class="lnum">  26:  </span>        <span class="kwrd">public</span> <span class="kwrd">override</span> <span class="kwrd">int</span> GetHashCode()</pre>

<pre><span class="lnum">  27:  </span>        {</pre>

<pre><span class="lnum">  28:  </span>            <span class="kwrd">return</span> OrderId;</pre>

<pre><span class="lnum">  29:  </span>        }</pre>

<pre><span class="lnum">  30:  </span>&#160;</pre>

<pre><span class="lnum">  31:  </span>        <span class="kwrd">public</span> <span class="kwrd">static</span> <span class="kwrd">bool</span> <span class="kwrd">operator</span> ==(Order left, Order right)</pre>

<pre><span class="lnum">  32:  </span>        {</pre>

<pre><span class="lnum">  33:  </span>            <span class="kwrd">return</span> Equals(left, right);</pre>

<pre><span class="lnum">  34:  </span>        }</pre>

<pre><span class="lnum">  35:  </span>&#160;</pre>

<pre><span class="lnum">  36:  </span>        <span class="kwrd">public</span> <span class="kwrd">static</span> <span class="kwrd">bool</span> <span class="kwrd">operator</span> !=(Order left, Order right)</pre>

<pre><span class="lnum">  37:  </span>        {</pre>

<pre><span class="lnum">  38:  </span>            <span class="kwrd">return</span> !Equals(left, right);</pre>

<pre><span class="lnum">  39:  </span>        }</pre>

<pre><span class="lnum">  40:  </span>    }</pre>
</div>

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:ddac5d68-f09a-46d9-85d8-3b883711c415" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/refactoring" rel="tag">refactoring</a>
</div>

 [1]: /wp-content/uploads/image21.png
 [2]: /wp-content/uploads/image22.png
 [3]: /wp-content/uploads/SNAGHTML337d04cf.png