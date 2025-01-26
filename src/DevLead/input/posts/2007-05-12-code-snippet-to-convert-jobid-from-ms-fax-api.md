---
title: Code snippet to convert JobID from MS Fax API
author: Alvin A.
type: post
date: 2007-05-12T18:00:00+00:00
url: /2007/05/12/code-snippet-to-convert-jobid-from-ms-fax-api/
blogger_blog:
  - alvinleeashcraft.blogspot.com
blogger_author:
  - Alvin
blogger_permalink:
  - /2007/05/code-snippet-to-convert-jobid-from-ms.html
views:
  - 3
categories:
  - Uncategorized

---
Here&#8217;s a quick little code snippet which will convert a job ID into the correct format when you&#8217;re using the MS faxcomexlib.dll. This is needed because you&#8217;ll get different formats back from a ConnectedSubmit depending on whether your application is running on Windows XP or Windows 2003 Server. However, the format does not vary when you get status change events.

<pre><span style="color:rgb(0, 0, 255);">private</span> <span style="color:rgb(0, 0, 255);">string</span> ConvertJobID(<span style="color:rgb(0, 0, 255);">string</span> jobID)<br />       {<br />           <span style="color:rgb(0, 0, 255);">string</span> hexJobId = <span style="color:rgb(0, 0, 255);">string</span>.Empty;<br /><br />           <span style="color:rgb(0, 0, 255);">try</span><br />           {<br />               Int64 i = Convert.ToInt64(jobID);<br />               <span style="color:rgb(0, 128, 0);">//Match event handler format:<br /></span>                <span style="color:rgb(0, 128, 0);">//        hex number; lowercase;<br /></span>                <span style="color:rgb(0, 128, 0);">//        no leading zeroes;<br /></span>                <span style="color:rgb(0, 128, 0);">//        no "0x" or other prefix<br /></span>                hexJobId = i.ToString("x");<br />           }<br />           <span style="color:rgb(0, 0, 255);">catch</span> <span style="color:rgb(0, 128, 0);">// If there's an exception,<br /></span>                  <span style="color:rgb(0, 128, 0);">// then the Job ID is already correct<br /></span>            {<br />               hexJobId = jobID;<br />           }<br /><br />           <span style="color:rgb(0, 0, 255);">return</span> hexJobId;<br />       }</pre>

<pre></pre>



<div class="wlWriterSmartContent" style="display:inline;margin:0;padding:0;">
  Technorati tags: <a href="http://technorati.com/tags/c#" rel="tag">c#</a>, <a href="http://technorati.com/tags/code" rel="tag">code</a>, <a href="http://technorati.com/tags/fax" rel="tag">fax</a>, <a href="http://technorati.com/tags/api" rel="tag">api</a>
</div>

[][1][][1]



<div class="blogger-post-footer">
  <a href="http://www.myspace.com/alvinashcraft">Find me on MySpace and be my friend!</a></p>
</div>

 [1]: http://11011.net/software/vspaste