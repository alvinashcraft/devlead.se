---
title: 'C# + ReSharper = Awesome: Tip #3 – Convert Into LINQ Expression'
author: Alvin A.
type: post
date: 2011-12-16T21:44:33+00:00
url: /2011/12/16/c-resharper-awesome-tip-3-convert-into-linq-expression/
categories:
  - Development
  - how-to
tags:
  - 'c#'
  - linq
  - resharper
  - visual studio

---
This is the third in a series of quick how-to articles on <a href="http://www.jetbrains.com/resharper/" target="_blank">Resharper</a>.

### Tip #3 – Convert Into LINQ Expression

Use: ForEach blocks that perform simple bits of logic can often times be rewritten as lambda expressions. This reduces the number of lines of code and usually makes the code more readable.

##### Before

<pre class="csharpcode"><span class="kwrd">public</span> IList&lt;Album&gt; FindAlbumsToGiveAway(IList&lt;Album&gt; albums)
         {
             var badAlbums = <span class="kwrd">new</span> List&lt;Album&gt;();

             <span class="kwrd">foreach</span> (Album album <span class="kwrd">in</span> albums)
             {
                 <span class="kwrd">if</span> (album.Genre == <span class="str">"Country"</span>)
                     badAlbums.Add(album);
             }

             <span class="kwrd">return</span> badAlbums;
         }</pre>

##### Press <Alt+Enter>

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb2.png" width="484" height="178" />][1]

##### After

<pre class="csharpcode"><span class="kwrd">public</span> IList&lt;Album&gt; FindAlbumsToGiveAway(IList&lt;Album&gt; albums)
         {
             <span class="kwrd">return</span> albums.Where(album =&gt; album.Genre == <span class="str">"Country"</span>).ToList();
         }</pre>

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:b6393658-a9d7-47da-9a23-170027582297" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/c%23" rel="tag">c#</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/linq" rel="tag">linq</a>
</div>

 [1]: /wp-content/uploads/image13.png