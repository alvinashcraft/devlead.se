---
title: 'C# + ReSharper = Awesome: Tip #7–Move String to Resource'
author: Alvin A.
type: post
date: 2012-01-20T20:41:57+00:00
url: /2012/01/20/c-resharper-awesome-tip-7move-string-to-resource/
categories:
  - Development
  - how-to
tags:
  - refactoring
  - resharper
  - visual studio

---
This is the seventh in a series of quick how-to articles on <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>.

### Tip #7 – Move String to Resource

**Use:** Moves a string into a resource file to enable localization.

**Tip:** Ensure your project contains at least one Resource (resx) file or the operation will fail.

##### Before

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>     <span class="kwrd">public</span> <span class="kwrd">string</span> YouRock()</pre>

<pre><span class="lnum">   2:  </span>     {</pre>

<pre><span class="lnum">   3:  </span>         <span class="kwrd">return</span> <span class="str">"No, YOU rock Mr. Method-Caller!"</span>;</pre>

<pre><span class="lnum">   4:  </span>     }</pre>
</div>

##### Right-click the string –> Refactor –> Refactor This…

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb6.png" width="364" height="168" />][1]

##### Move to Resource

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="SNAGHTML6f7080" border="0" alt="SNAGHTML6f7080" src="/wp-content/uploads/SNAGHTML6f7080_thumb.png" width="424" height="307" />][2]

##### After

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>     <span class="kwrd">public</span> <span class="kwrd">string</span> YouRock()</pre>

<pre><span class="lnum">   2:  </span>     {</pre>

<pre><span class="lnum">   3:  </span>         <span class="kwrd">return</span> StringResources.No_YOU_rock_Mr_Method_Caller;</pre>

<pre><span class="lnum">   4:  </span>     }</pre>
</div>

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:4c526044-a7ee-44e7-8132-b613a76d2b95" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/refactoring" rel="tag">refactoring</a>
</div>

 [1]: /wp-content/uploads/image17.png
 [2]: /wp-content/uploads/SNAGHTML6f7080.png