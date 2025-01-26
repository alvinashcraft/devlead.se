---
title: Nullable DateTime in .NET 2.0
author: Alvin A.
type: post
date: 2007-05-24T15:18:00+00:00
url: /2007/05/24/nullable-datetime-in-net-20/
blogger_blog:
  - alvinleeashcraft.blogspot.com
  - alvinleeashcraft.blogspot.com
blogger_author:
  - Alvin
  - Alvin
blogger_permalink:
  - /2007/05/nullable-datetime-in-net-20.html
  - /2007/05/nullable-datetime-in-net-20.html
views:
  - 62
  - 62
categories:
  - Uncategorized

---
Thanks to generics in 2.0, now any value type can be NULL.

<pre><span style="color:rgb(0,0,255);">public</span> <span style="color:rgb(0,0,255);">class</span> <span style="color:rgb(43,145,175);">DateTimeNullTest<br /></span>    {<br />        <span style="color:rgb(0,0,255);">private</span> <span style="color:rgb(43,145,175);">Nullable</span>&lt;<span style="color:rgb(43,145,175);">DateTime</span>&gt; oDate = <span style="color:rgb(0,0,255);">new</span> <span style="color:rgb(43,145,175);">Nullable</span>&lt;<span style="color:rgb(43,145,175);">DateTime</span>&gt;(<span style="color:rgb(43,145,175);">DateTime</span>.Now);<br /><br />        <span style="color:rgb(0,0,255);">public</span> DateTimeNullTest()<br />        {<br />            <span style="color:rgb(0,128,0);">// Yay - It doesn't blow up!<br /></span>            <span style="color:rgb(0,0,255);">if</span> (oDate != <span style="color:rgb(0,0,255);">null</span>)<br />                oDate = <span style="color:rgb(0,0,255);">null</span>;<br />        }<br />    }</pre>

[][1]

&nbsp;

<!-- AddThis Bookmark Button BEGIN -->

  
<a href="http://www.addthis.com/bookmark.php" target="_blank"><img data-recalc-dims="1" loading="lazy" decoding="async" src="https://i0.wp.com/s9.addthis.com/button1-bm.gif?resize=125%2C16" width="125" height="16" border="0" alt="AddThis Social Bookmark Button" /></a> var addthis_pub = &#8216;alashcraft&#8217;;  
<!-- AddThis Bookmark Button END -->

<div class="wlWriterSmartContent" style="display:inline;margin:0;padding:0;">
  Technorati tags: <a href="http://technorati.com/tags/c#" rel="tag">c#</a>, <a href="http://technorati.com/tags/.net" rel="tag">.net</a>, <a href="http://technorati.com/tags/null" rel="tag">null</a>, <a href="http://technorati.com/tags/generics" rel="tag">generics</a>, <a href="http://technorati.com/tags/pattern" rel="tag">pattern</a>
</div>

<div class="blogger-post-footer">
  <a href="http://www.myspace.com/alvinashcraft">Find me on MySpace and be my friend!</a></p>
</div>

 [1]: http://11011.net/software/vspaste