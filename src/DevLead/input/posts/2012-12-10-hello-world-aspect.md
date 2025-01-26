---
title: “Hello, World” Aspect
author: Alvin A.
type: post
date: 2012-12-10T14:19:16+00:00
url: /2012/12/10/hello-world-aspect/
categories:
  - books
  - Development
  - how-to
tags:
  - .net framework
  - aop
  - 'c#'
  - manning
  - postsharp

---
&#160;

> <a href="http://www.manning.com/groves/" target="_blank"><img data-recalc-dims="1" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 0px 10px 10px 0px; padding-left: 0px; padding-right: 0px; display: inline; float: left; border-top: 0px; border-right: 0px; padding-top: 0px" border="0" align="left" src="https://i0.wp.com/www.manning.com/groves/groves_cover150.jpg?w=660" />AOP in .NET</a>  
> By Matthew Groves  
> Aspect-oriented programming is a technique that is complementary to object-oriented programming (OOP). The goal of AOP is to reduce repetitive, boilerplate code. This article, based on <a href="http://www.manning.com/groves/" target="_blank">AOP in .NET</a>, walks you through a very basic "Hello, World" example of using AOP in .NET. He breaks apart that example and identifies the individual puzzle pieces and how they fit together into something called an "aspect." 

### “Hello, World” Aspect

If you’ve never done aspects, we’ll give you a taste of what&#8217;s in store. Don&#8217;t worry if you don&#8217;t fully understand what&#8217;s going on just yet. Follow along just to get your feet wet. I&#8217;ll be using Visual Studio 2010 and PostSharp. Visual Studio Express (which is a free download) should work too. I&#8217;m also using NuGet, which is a great package manager tool for .NET that integrates with Visual Studio. If you&#8217;ve never used NuGet, you should definitely take a few minutes to check it out at NuGet.org and install it: it will make your life as a .NET developer much easier.

Start by selecting File>New Project and then Console Application. Call it whatever you want, but I&#8217;m calling mine "HelloWorld". You should be looking at an empty console project like so:

<pre class="csharpcode"><span class="kwrd">class</span> Program {
    <span class="kwrd">static</span> <span class="kwrd">void</span> Main(<span class="kwrd">string</span>[] args) {
    }
}</pre>

Next, install PostSharp with NuGet. NuGet can work from a PowerShell command-line within Visual Studio, called Package Manager Console. To install PostSharp via the Package Manager Console, just use the Install-Package command.

###### <sub>Listing 1 Installing PostSharp with NuGet PowerShell console</sub>

<pre class="csharpcode">PM&gt; Install-Package postsharp
Successfully installed <span class="str">'PostSharp 2.1.6.17'</span>.
Successfully added <span class="str">'PostSharp 2.1.6.17'</span> to HelloWorld.</pre>

Alternatively, you can do it via the Visual Studio UI by first right-clicking on References in Solution Explorer.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb12.png" width="360" height="226" />][1]

###### <sup>Figure 1 Starting NuGet with the UI</sup>

Select Online, search for PostSharp, and click Install.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb13.png" width="400" height="60" />][2]

###### <sup>Figure 2 Search for PostSharp and install with NuGet UI</sup>

You may get a PostSharp message that asks you about licensing. Accept the free trial and continue. The Starter Edition is free for commercial use, so you can use it for free at your job too. Now that PostSharp is installed, you can close out of the NuGet dialog. In Solution Explorer under References, you should see a new PostSharp reference added to your project.

Now you&#8217;re ready to start writing your first aspect.

Create a class with one simple method that just writes to Console. Mine looks like this:

<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">class</span> MyClass {
    <span class="kwrd">public</span> <span class="kwrd">void</span> MyMethod() {
        Console.WriteLine(<span class="str">"Hello, world!"</span>);
    }
}</pre>

Instantiate this inside of the Main method,and call the method. Here&#8217;s what the Program class should look like now:

<pre class="csharpcode"><span class="kwrd">class</span> Program {
    <span class="kwrd">static</span> <span class="kwrd">void</span> Main(<span class="kwrd">string</span>[] args) {
        var myObject = <span class="kwrd">new</span> MyClass();
        myObject.MyMethod();
    }
}</pre>

Execute that program now (F5 or CTRL+F5 in Visual Studio), and your output should look like this:

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb14.png" width="364" height="150" />][3]

We&#8217;re not really pushing the limits of innovation just yet, but hang in there!

Now, create a new class that inherits from OnMethodBoundaryAspect, which is a base class in the PostSharp namespace. Something like this:

###### <sub>Listing 2 The first step in using the PostSharp API &#8211; derive from OnMethodBoundaryAspect</sub>

<pre class="csharpcode">[Serializable]
<span class="kwrd">public</span> <span class="kwrd">class</span> MyAspect : OnMethodBoundaryAspect {
}</pre>

PostSharp requires aspect classes to be serializable (this is because PostSharp instantiates aspects at compile time, so they can be persisted between compile time and run time).

Congratulations, you just wrote an aspect, even though it doesn&#8217;t do anything yet. Like the name implies, this aspect allows you to insert code on the boundaries of a method. Let&#8217;s make an aspect that inserts code before and after a method gets called. Start by overriding the OnEntry method. Inside of that method, write something to Console, like this:

###### <sub>Listing 3 Override the OnEntry method to add some functionality</sub>

<pre class="csharpcode">[Serializable]
<span class="kwrd">public</span> <span class="kwrd">class</span> MyAspect : OnMethodBoundaryAspect {
    <span class="kwrd">public</span> <span class="kwrd">override</span> <span class="kwrd">void</span> OnEntry(MethodExecutionArgs args) {
        Console.WriteLine(<span class="str">"Before the method"</span>);
    }
}</pre>

Notice the <font face="Courier New">MethodExecutionArgs</font> parameter. It&#8217;s there to give information and context about the method being bounded. We won&#8217;t use it in this simple example, but argument objects like that are almost always used in a real aspect. Create another override, but, this time, override <font face="Courier New">OnExit</font>.

###### <sub>Listing 4 Override the OnExit to add more functionality</sub>

<pre class="csharpcode">[Serializable]
<span class="kwrd">public</span> <span class="kwrd">class</span> MyAspect : OnMethodBoundaryAspect {
    <span class="kwrd">public</span> <span class="kwrd">override</span> <span class="kwrd">void</span> OnEntry(MethodExecutionArgs args) {
        Console.WriteLine(<span class="str">"Before the method"</span>);
    }
    <span class="kwrd">public</span> <span class="kwrd">override</span> <span class="kwrd">void</span> OnExit(MethodExecutionArgs args) {
        Console.WriteLine(<span class="str">"After the method"</span>);
    }
}</pre>

Now you have written an aspect that will write to Console before and after a method. But, which method? The most basic way to tell PostSharp which method (or methods) to apply this aspect to is to use the aspect as an attribute on the method. For instance, to put it on the boundaries of the earlier "Hello, World" method, just use it on the method like so:

###### <sub>Listing 5 Apply the aspect to a method by using an attribute</sub>

<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">class</span> MyClass {
    [MyAspect]
    <span class="kwrd">public</span> <span class="kwrd">void</span> MyMethod() {
        Console.WriteLine(<span class="str">"Hello, world!"</span>);
    }
}</pre>

Now, run the application again (F5 or CTRL+F5). You should see an output like this:

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb15.png" width="364" height="163" />][4]

###### <sup>Figure 4 Output with MyAspect applied</sup>

That&#8217;s it. You&#8217;ve now written an aspect and told PostSharp where to use that aspect. This example may not seem that impressive, but notice that you were able to put code around the method without making MyMethod any changes to MyMethod itself. Yeah, you did have to add that [MyAspect] attribute, but there are more efficient and/or centralized ways of applying PostSharp aspects.

&#160;

**Here are some other Manning titles you might be interested in:**

<table border="0" cellspacing="0" cellpadding="2" width="380">
  <tr>
    <td valign="top" width="151">
      <a href="http://www.manning.com/walls2/"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image27.png" width="100" height="126" /></a>
    </td>
    
    <td valign="top" width="227">
      <p>
        <a href="http://www.manning.com/walls2/" target="_blank">Spring in Action, Third Edition</a>
      </p>
      
      <p>
        Craig Walls
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="160">
      <a href="http://www.manning.com/wheeler/"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image28.png" width="100" height="126" /></a>
    </td>
    
    <td valign="top" width="233">
      <p>
        <a href="http://www.manning.com/wheeler/">Spring in Practice</a>
      </p>
      
      <p>
        Willie Wheeler, John Wheeler, and Joshua White
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="164">
      <a href="http://www.manning.com/fisher/"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image29.png" width="100" height="126" /></a>
    </td>
    
    <td valign="top" width="232">
      <p>
        <a href="http://www.manning.com/fisher/">Spring Integration in Action</a>
      </p>
      
      <p>
        Mark Fisher, Jonas Partner, Marius Bogoevici, and Iwein Fuld
      </p>
    </td>
  </tr>
</table>

&#160;

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:c849eab4-92bd-4006-9d16-38b25bb07d08" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/aop" rel="tag">aop</a>,<a href="http://del.icio.us/popular/postsharp" rel="tag">postsharp</a>,<a href="http://del.icio.us/popular/.net+framework" rel="tag">.net framework</a>,<a href="http://del.icio.us/popular/c%23" rel="tag">c#</a>,<a href="http://del.icio.us/popular/manning" rel="tag">manning</a>
</div>

 [1]: /wp-content/uploads/image23.png
 [2]: /wp-content/uploads/image24.png
 [3]: /wp-content/uploads/image25.png
 [4]: /wp-content/uploads/image26.png