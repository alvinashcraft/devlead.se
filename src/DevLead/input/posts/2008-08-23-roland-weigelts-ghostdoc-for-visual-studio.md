---
title: Roland Weigelt’s GhostDoc for Visual Studio
author: Alvin A.
type: post
date: 2008-08-23T18:29:06+00:00
url: /2008/08/23/roland-weigelts-ghostdoc-for-visual-studio/
views:
  - 386
aktt_tweeted:
  - 1
categories:
  - Development
  - how-to

---
</p> 

&#160;

I have been using <a href="http://www.roland-weigelt.de/ghostdoc/" target="_blank">Roland WeigeIt’s GhostDoc</a> 2.1.3 for both Visual Studio 2005 and 2008 for about six months, and I am hooked. For those of you who have not heard of GhostDoc, here is the summary from Roland’s site:

> GhostDoc is a free add-in for Visual Studio that automatically generates XML documentation comments for C#. Either by using existing documentation inherited from base classes or implemented interfaces, or by deducing comments from name and type of e.g. methods, properties or parameters.</p> </p> 

It saves me so much time writing XML documentation in my code that there is no longer any excuse for any docs being missing. Documenting a piece of code is as simple as right-clicking on it and selcting ‘Document This’ (there is also a keyboard shortcut – CTRL-D is the default). The built-in rules for creating the comments are probably sufficient for most developers, but more advanced users can edit existing rules or add their own.

I have attached a small sample project containing some domain classes representing part of a pharmacy system. Here are a few examples of the XML documentation that is generated using GhostDoc’s default configuration. Some of the code is a bit contrived so that I could demonstrate different types of comments.</p> </p> </p> 

##### Documenting a Constructor

> <pre class="code"><span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Initializes a new instance of the </span><span style="color: gray">&lt;see cref="Drug"/&gt; </span><span style="color: green">class.
</span><span style="color: gray">/// &lt;/summary&gt;
/// &lt;param name="id"&gt;</span><span style="color: green">The id.</span><span style="color: gray">&lt;/param&gt;
</span><span style="color: blue">public </span>Drug(<span style="color: blue">int </span>id)
{
    LoadDrug(id);
}</pre>

[][1]

##### Documenting a Dispose Method

> <pre class="code"><span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
</span><span style="color: gray">/// &lt;/summary&gt;
</span><span style="color: blue">public void </span>Dispose()
{
    <span style="color: green">// TODO: clean up resources
</span>}</pre>

[][1]

&#160;

##### Documenting Properties

> <pre class="code"><span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Gets or sets the therapeutic categories.
</span><span style="color: gray">/// &lt;/summary&gt;
/// &lt;value&gt;</span><span style="color: green">The therapeutic categories.</span><span style="color: gray">&lt;/value&gt;
</span><span style="color: blue">public </span><span style="color: #2b91af">List</span>&lt;<span style="color: #2b91af">DrugCategory</span>&gt; TherapeuticCategories { <span style="color: blue">get</span>; <span style="color: blue">set</span>; }

<span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Gets or sets the NDC.
</span><span style="color: gray">/// &lt;/summary&gt;
/// &lt;value&gt;</span><span style="color: green">The NDC.</span><span style="color: gray">&lt;/value&gt;
</span><span style="color: blue">public string </span>NDC { <span style="color: blue">get</span>; <span style="color: blue">set</span>; }

<span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Gets or sets a value indicating whether this instance is generic.
</span><span style="color: gray">/// &lt;/summary&gt;
/// &lt;value&gt;
///     &lt;c&gt;</span><span style="color: green">true</span><span style="color: gray">&lt;/c&gt; </span><span style="color: green">if this instance is generic; otherwise, </span><span style="color: gray">&lt;c&gt;</span><span style="color: green">false</span><span style="color: gray">&lt;/c&gt;</span><span style="color: green">.
</span><span style="color: gray">/// &lt;/value&gt;
</span><span style="color: blue">public bool </span>IsGeneric { <span style="color: blue">get</span>; <span style="color: blue">set</span>; }</pre>

[][1]

&#160;

##### Documenting a Method

> <pre class="code"><span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Loads the drug.
</span><span style="color: gray">/// &lt;/summary&gt;
/// &lt;param name="id"&gt;</span><span style="color: green">The id.</span><span style="color: gray">&lt;/param&gt;
</span><span style="color: blue">private void </span>LoadDrug(<span style="color: blue">int </span>id)
{
    <span style="color: green">// do nothing... just an example
</span>}</pre>

[][1]

&#160;

##### Documenting an Inherited/Implemented Method

> <pre class="code"><span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Creates a new object that is a copy of the current instance.
</span><span style="color: gray">/// &lt;/summary&gt;
/// &lt;returns&gt;
/// </span><span style="color: green">A new object that is a copy of this instance.
</span><span style="color: gray">/// &lt;/returns&gt;
</span><span style="color: blue">public object </span>Clone()
{
    <span style="color: blue">return </span>MemberwiseClone();
}</pre>

[][1]

&#160;

##### Documenting an Overridden Method

> <pre class="code"><span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Returns a </span><span style="color: gray">&lt;see cref="T:System.String"/&gt; </span><span style="color: green">that represents the current </span><span style="color: gray">&lt;see cref="T:System.Object"/&gt;</span><span style="color: green">.
</span><span style="color: gray">/// &lt;/summary&gt;
/// &lt;returns&gt;
/// </span><span style="color: green">A </span><span style="color: gray">&lt;see cref="T:System.String"/&gt; </span><span style="color: green">that represents the current </span><span style="color: gray">&lt;see cref="T:System.Object"/&gt;</span><span style="color: green">.
</span><span style="color: gray">/// &lt;/returns&gt;
</span><span style="color: blue">public override string </span>ToString()
{
    <span style="color: blue">return </span><span style="color: #2b91af">String</span>.Format(<span style="color: #a31515">"{0} {1}"</span>, Name, DoseRoute);
}</pre>

[][1]

&#160;

##### Documenting an Event</p> </p> </p> </p> 

> <pre class="code"><span style="color: gray">/// &lt;summary&gt;
/// </span><span style="color: green">Occurs when [allergy detected].
</span><span style="color: gray">/// &lt;/summary&gt;
</span><span style="color: blue">public event </span><span style="color: #2b91af">EventHandler </span>AllergyDetected;</pre>

[][1]

&#160;

&#160;

As you can see, the default configuration of GhostDoc is pretty intelligent. Here are some shots of the rules configuration options provided by default:

&#160;

[<img loading="lazy" decoding="async" title="GhostDoc Rules Config" style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px" height="484" alt="GhostDoc Rules Config" src="/wp-content/uploads/ghostdocconfig1-thumb.png" width="598" border="0" />][2] 

&#160;

[<img loading="lazy" decoding="async" title="GhostDoc Rules Config 2" style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px" height="484" alt="GhostDoc Rules Config 2" src="/wp-content/uploads/ghostdocconfig1a-thumb.png" width="598" border="0" />][3] 

_(I added the shading in the second shot to mask options that were visible in the previous one.)_

&#160;

Users have the ability to change any of these existing rules or add their own. This post is just a brief overview of the product, so I won’t go into details on how to configure a rule at this time. Let me know if you would be interested in more posts that dive into more details on the configuration of GhostDoc.

If you don’t already use it, I encourage you to download it and give it a try. The learning curve is not steep and the benefits are great. Plus, it’s free! One more quick note, VB support is experimental at this time, and it is turned off by default. To enable it, go to the Options tab on the config screen.</p> </p> </p> 

GhostDoc download links are <a href="http://www.roland-weigelt.de/ghostdoc/" target="_blank">here</a>.

My sample project (VS2008) can be downloaded <a href="https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/code/GhostDocSample.zip" target="_blank">here</a>.

&#160;

<div class="wlWriterSmartContent" id="scid:C16BAC14-9A3D-4c50-9394-FBFEF7A93539:e62d18fd-5122-4db3-a428-a7e167c01b8a" style="padding-right: 0px; display: inline; padding-left: 0px; float: none; padding-bottom: 0px; margin: 0px; padding-top: 0px">
  <!--dotnetkickit-->
</div>

<div class="wlWriterSmartContent" id="scid:d7bf807d-7bb0-458a-811f-90c51817d5c2:1d523341-a33f-434d-9a12-8619e9fc9a8f" style="padding-right: 0px; display: inline; padding-left: 0px; float: none; padding-bottom: 0px; margin: 0px; padding-top: 0px">
  <p>
    <span class="TagSite">Technorati:</span> <a href="http://technorati.com/tag/visual+studio" rel="tag" class="tag">visual studio</a>, <a href="http://technorati.com/tag/add-ins" rel="tag" class="tag">add-ins</a>, <a href="http://technorati.com/tag/ghostdoc" rel="tag" class="tag">ghostdoc</a>, <a href="http://technorati.com/tag/xml+documentation" rel="tag" class="tag">xml documentation</a><br /><!-- StartInsertedTags: visual studio, add-ins, ghostdoc, xml documentation :EndInsertedTags -->
  </p>
</div>

 [1]: http://11011.net/software/vspaste
 [2]: /wp-content/uploads/ghostdocconfig1.png
 [3]: /wp-content/uploads/ghostdocconfig1a.png