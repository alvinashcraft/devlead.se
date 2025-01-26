---
title: 'C# + ReSharper = Awesome: Tip #9 – Move Types into Matching Files'
author: Alvin A.
type: post
date: 2012-02-04T15:46:59+00:00
url: /2012/02/04/c-resharper-awesome-tip-9-move-types-into-matching-files/
categories:
  - Daily Links

---
This is the ninth in a series of quick how-to articles on <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>.

### Tip #9 &#8211; Move Types into Matching Files

**Use:** Let’s say you’re coding away on a class, and you’re doing things like letting Visual Studio or ReSharper create additional types in the same code file based on usage. Suddenly, you have three or four classes in the same code file. Now it’s time to step back and get things organized. From <a href="http://www.jetbrains.com/resharper/features/code_refactoring.html#Move_Types_into_Matching_Files" target="_blank">JetBrains</a>:

> This refactoring can applied to a single file or a selection of files that have multiple types each. ReSharper creates dedicated files for each of these types are moves them there.

##### Before

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> Movie : IMovie</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">private</span> IList&lt;IActor&gt; actors;</pre>

<pre><span class="lnum">   4:  </span>&#160;</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">public</span> Movie(IList&lt;IActor&gt; actors)</pre>

<pre><span class="lnum">   6:  </span>        {</pre>

<pre><span class="lnum">   7:  </span>            <span class="kwrd">this</span>.actors = actors;</pre>

<pre><span class="lnum">   8:  </span>        }</pre>

<pre><span class="lnum">   9:  </span>&#160;</pre>

<pre><span class="lnum">  10:  </span>        <span class="kwrd">public</span> ProductionStatus Status { get; set; }</pre>

<pre><span class="lnum">  11:  </span>&#160;</pre>

<pre><span class="lnum">  12:  </span>        <span class="kwrd">public</span> IList&lt;IActor&gt; Actors</pre>

<pre><span class="lnum">  13:  </span>        {</pre>

<pre><span class="lnum">  14:  </span>            get { <span class="kwrd">return</span> <span class="kwrd">this</span>.actors; }</pre>

<pre><span class="lnum">  15:  </span>        }</pre>

<pre><span class="lnum">  16:  </span>    }</pre>

<pre><span class="lnum">  17:  </span>&#160;</pre>

<pre><span class="lnum">  18:  </span>    <span class="kwrd">public</span> <span class="kwrd">enum</span> ProductionStatus</pre>

<pre><span class="lnum">  19:  </span>    {</pre>

<pre><span class="lnum">  20:  </span>        NotYetInProduction,</pre>

<pre><span class="lnum">  21:  </span>        PreProduction,</pre>

<pre><span class="lnum">  22:  </span>        Production,</pre>

<pre><span class="lnum">  23:  </span>        PostProduction,</pre>

<pre><span class="lnum">  24:  </span>        Released</pre>

<pre><span class="lnum">  25:  </span>    }</pre>

<pre><span class="lnum">  26:  </span>&#160;</pre>

<pre><span class="lnum">  27:  </span>    <span class="kwrd">public</span> <span class="kwrd">interface</span> IMovie</pre>

<pre><span class="lnum">  28:  </span>    {</pre>

<pre><span class="lnum">  29:  </span>        ProductionStatus Status { get; set; }</pre>

<pre><span class="lnum">  30:  </span>        IList&lt;IActor&gt; Actors { get; } </pre>

<pre><span class="lnum">  31:  </span>    }</pre>

<pre><span class="lnum">  32:  </span>&#160;</pre>

<pre><span class="lnum">  33:  </span>    <span class="kwrd">public</span> <span class="kwrd">interface</span> IActor</pre>

<pre><span class="lnum">  34:  </span>    {</pre>

<pre><span class="lnum">  35:  </span>        <span class="kwrd">string</span> Name { get; }</pre>

<pre><span class="lnum">  36:  </span>    }</pre>
</div>

##### Right-click the code file in Solution Explorer

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb8.png" width="644" height="146" />][1]

##### Select options and finish

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="SNAGHTML34215b3b" border="0" alt="SNAGHTML34215b3b" src="/wp-content/uploads/SNAGHTML34215b3b_thumb.png" width="544" height="250" />][2]

##### After

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb9.png" width="201" height="95" />][3]

##### New contents of Movie.cs

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> Movie : IMovie</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">private</span> IList&lt;IActor&gt; actors;</pre>

<pre><span class="lnum">   4:  </span>&#160;</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">public</span> Movie(IList&lt;IActor&gt; actors)</pre>

<pre><span class="lnum">   6:  </span>        {</pre>

<pre><span class="lnum">   7:  </span>            <span class="kwrd">this</span>.actors = actors;</pre>

<pre><span class="lnum">   8:  </span>        }</pre>

<pre><span class="lnum">   9:  </span>&#160;</pre>

<pre><span class="lnum">  10:  </span>        <span class="kwrd">public</span> ProductionStatus Status { get; set; }</pre>

<pre><span class="lnum">  11:  </span>&#160;</pre>

<pre><span class="lnum">  12:  </span>        <span class="kwrd">public</span> IList&lt;IActor&gt; Actors</pre>

<pre><span class="lnum">  13:  </span>        {</pre>

<pre><span class="lnum">  14:  </span>            get { <span class="kwrd">return</span> <span class="kwrd">this</span>.actors; }</pre>

<pre><span class="lnum">  15:  </span>        }</pre>

<pre><span class="lnum">  16:  </span>    }</pre>
</div>

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:8434d320-116b-447f-b7a0-34077007ab06" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/refactoring" rel="tag">refactoring</a>
</div>

 [1]: /wp-content/uploads/image19.png
 [2]: /wp-content/uploads/SNAGHTML34215b3b.png
 [3]: /wp-content/uploads/image20.png