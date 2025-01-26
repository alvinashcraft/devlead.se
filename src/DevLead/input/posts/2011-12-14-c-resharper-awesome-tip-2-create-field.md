---
title: 'C# + ReSharper = Awesome: Tip #2 – Create Field'
author: Alvin A.
type: post
date: 2011-12-14T18:54:35+00:00
url: /2011/12/14/c-resharper-awesome-tip-2-create-field/
categories:
  - Development
  - how-to
  - tools
tags:
  - 'c#'
  - resharper
  - visual studio

---
This is the second in a series of quick how-to posts on <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>.

##### Tip #2 – Create Field

**Use:** Within the body of a class or property, you can type the name of a non-existent variable name. When you place your cursor on the variable, ReSharper provides several options to resolve the impending compilation error. Create Field is one of the options.

##### Before

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>        <span class="kwrd">public</span> <span class="kwrd">void</span> AddAlbum(<span class="kwrd">string</span> album)</pre>

<pre><span class="lnum">   2:  </span>        {</pre>

<pre><span class="lnum">   3:  </span>            <span class="kwrd">if</span> (String.IsNullOrWhiteSpace(album))</pre>

<pre><span class="lnum">   4:  </span>                <span class="kwrd">throw</span> <span class="kwrd">new</span> ArgumentOutOfRangeException(<span class="str">"album"</span>,</pre>

<pre><span class="lnum">   5:  </span>                                                      album,</pre>

<pre><span class="lnum">   6:  </span>                                                      <span class="str">"Please provide an album name."</span>);</pre>

<pre><span class="lnum">   7:  </span>&#160;</pre>

<pre><span class="lnum">   8:  </span>            <font color="#ff0000">_albums</font>.Add(album);</pre>

<pre><span class="lnum">   9:  </span>        }</pre>
</div>

##### Press <Alt+Enter>

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb1.png" width="244" height="190" />][1]

##### After

<pre class="csharpcode"><span class="kwrd">private</span> IList&lt;<span class="kwrd">string</span>&gt; _albums = <span class="kwrd">new</span> List&lt;<span class="kwrd">string</span>&gt;();

        <span class="kwrd">public</span> <span class="kwrd">void</span> AddAlbum(<span class="kwrd">string</span> album)
        {
            <span class="kwrd">if</span> (String.IsNullOrWhiteSpace(album))
                <span class="kwrd">throw</span> <span class="kwrd">new</span> ArgumentOutOfRangeException(<span class="str">"album"</span>,
                                                      album,
                                                      <span class="str">"Please provide an album name."</span>);

            _albums.Add(album);
        }</pre>

**Note:** I chose the type IList<string>. The default type selected by ReSharper in this case was object. I also added the initializer to the field to avoid null reference exceptions. Please don’t take any of these examples as best coding practices, they are contrived to demonstrate a particular refactoring.

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:e7b269f4-f697-4e1c-82f7-3e8589274e7f" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/c%23" rel="tag">c#</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>
</div>

 [1]: /wp-content/uploads/image12.png