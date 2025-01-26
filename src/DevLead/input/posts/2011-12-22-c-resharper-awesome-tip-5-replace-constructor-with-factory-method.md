---
title: 'C# + ReSharper = Awesome: Tip #5 – Replace Constructor with Factory Method'
author: Alvin A.
type: post
date: 2011-12-22T16:19:35+00:00
url: /2011/12/22/c-resharper-awesome-tip-5-replace-constructor-with-factory-method/
categories:
  - Development
  - how-to
tags:
  - refactoring
  - resharper
  - visual studio

---
This is the fifth in a series of quick how-to articles on <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>.

### Tip #5 – Replace Constructor with Factory Method

**Use:** If an application must control how or when new instances of classes are created, a factory method can achieve this. ReSharper makes it simple to wrap a constructor with a static factory method.

##### Before

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> Car</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">private</span> IList&lt;IPart&gt; _parts;</pre>

<pre><span class="lnum">   4:  </span> </pre>

<pre><span class="lnum">   5:  </span>         <span class="kwrd">public</span> Car(IList&lt;IPart&gt; parts)</pre>

<pre><span class="lnum">   6:  </span>         {</pre>

<pre><span class="lnum">   7:  </span>             _parts = parts;</pre>

<pre><span class="lnum">   8:  </span>         }</pre>

<pre><span class="lnum">   9:  </span>    }</pre>
</div>

##### Right-click the constructor

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb4.png" width="644" height="130" />][1]

##### Name your method or accept the default

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="SNAGHTML1ecbd865" border="0" alt="SNAGHTML1ecbd865" src="/wp-content/uploads/SNAGHTML1ecbd865_thumb.png" width="484" height="199" />][2]

##### After

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> Car</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">public</span> <span class="kwrd">static</span> Car CreateCar(IList&lt;IPart&gt; parts)</pre>

<pre><span class="lnum">   4:  </span>        {</pre>

<pre><span class="lnum">   5:  </span>            <span class="kwrd">return</span> <span class="kwrd">new</span> Car(parts);</pre>

<pre><span class="lnum">   6:  </span>        }</pre>

<pre><span class="lnum">   7:  </span>&#160;</pre>

<pre><span class="lnum">   8:  </span>        <span class="kwrd">private</span> IList&lt;IPart&gt; _parts;</pre>

<pre><span class="lnum">   9:  </span>&#160;</pre>

<pre><span class="lnum">  10:  </span>        <span class="kwrd">private</span> Car(IList&lt;IPart&gt; parts)</pre>

<pre><span class="lnum">  11:  </span>         {</pre>

<pre><span class="lnum">  12:  </span>             _parts = parts;</pre>

<pre><span class="lnum">  13:  </span>         }</pre>

<pre><span class="lnum">  14:  </span>    }</pre>
</div>

&#160;

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:c11c88e7-371b-4d6b-8034-f6d4050614ac" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/refactoring" rel="tag">refactoring</a>
</div>

 [1]: /wp-content/uploads/image15.png
 [2]: /wp-content/uploads/SNAGHTML1ecbd865.png