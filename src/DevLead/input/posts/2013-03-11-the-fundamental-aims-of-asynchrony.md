---
title: The Fundamental Aims of Asynchrony
author: Alvin A.
type: post
date: 2013-03-11T20:28:07+00:00
url: /2013/03/11/the-fundamental-aims-of-asynchrony/
categories:
  - books
  - Development
  - how-to
tags:
  - async
  - 'c#'
  - jon skeet
  - manning

---
<a name="_Toc190056276"></a> 

<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top" width="133">
      <p>
        <a href="/wp-content/uploads/async1.png"><img loading="lazy" decoding="async" title="async1" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 4px 8px 0px 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="async1" src="/wp-content/uploads/async1_thumb.png" width="150" height="188" /></a>
      </p>
    </td>
    
    <td valign="top" width="498">
      <p>
        <a href="http://www.manning.com/skeet3/">C# in Depth, Third Edition</a>
      </p>
      
      <p>
        By Jon Skeet
      </p>
      
      <p>
        <i>Asynchrony has been a thorn in the side of developers for years. It’s been known to be useful as a way of avoiding tying up a thread while waiting for some arbitrary task to complete, but it’s also been a pain in the neck to implement correctly. In this article, based on chapter 15 of <a href="http://www.manning.com/skeet3/">C# in Depth, Third Edition</a>, author Jon Skeet explains the purpose of asynchrony in C#.</i>
      </p>
    </td>
  </tr>
</table>

At the time of this writing, I’ve been playing with async/await for about two years, and it still makes me feel like a giddy schoolboy. I firmly believe it will do for asynchrony what LINQ did for data handling when C# 3 came out—except that dealing with asynchrony was a far harder problem. 

Even within the .NET framework (which is still relatively young in the grand scheme of things), we’ve had three different models to try to make things simpler:

  * The BeginFoo/EndFoo approach from .NET 1.x, using IAsyncResult and AsyncCallback to propagate results
  * The _event-based asynchronous pattern_ ****from .NET 2.0, as implemented by BackgroundWorker and WebClient
  * The Task Parallel Library (TPL) introduced in .NET 4, but then expanded in .NET 4.5

Despite its generally excellent design, writing robust and readable asynchronous code with the TPL was hard. While the support for parallelism was great, there are some aspects of general asynchrony that are simply much better fixed in a language instead of purely in libraries.

The main feature of C# 5 builds on the TPL so that you can write synchronously looking code that uses asynchrony where appropriate. Gone is the spaghetti of callbacks, event subscriptions and fragmented error handling; instead, asynchronous code expresses its intentions clearly, and in a form that builds on the structures developers are already familiar with. A new language construct allows you to “await” an asynchronous operation. This “awaiting” looks very much like a normal blocking call, in that the rest of your code won’t continue until the operation has completed, but it manages to do this without actually blocking the currently executing thread. Don’t worry if that statement sounds completely contradictory.

The .NET framework has embraced asynchrony wholeheartedly in version 4.5, exposing asynchronous versions of a great many operations, following a newly documented _task-based asynchronous pattern_ ****to give a consistent experience across multiple APIs. The WinRT framework used to create applications for Windows 8 enforces asynchrony for all long-running (or potentially long-running) operations. In short, the future is asynchronous and you’d be foolish not to take advantage of the new language features when trying to manage the additional complexity.

Just to be clear, C# hasn’t become omniscient, guessing where you might want to perform operations concurrently or asynchronously. The compiler is smart, but it doesn’t even attempt to remove the inherent ****complexity of asynchronous execution. You still need to think carefully, but the beauty of C# 5 is that all the tedious and confusing boilerplate code that used to be required has gone. Without the distraction of all fluff required just to make your code asynchronous to start with, you can concentrate on the hard bits.

A word of warning: this topic is reasonably advanced. It has the unfortunate properties of being incredibly important (realistically, even entry-level developers will need to have a passing understanding of it in a few years) but also quite tricky to get your head round to start with. I’m not going to shy away from the complexity; we’ll look at what’s going on in a fair amount of detail.

It’s just possible that I may temporarily break your brain a little, before hopefully putting it back together again later on. If it all starts sounding a little crazy, don’t worry—it’s not just you; bafflement is an entirely natural reaction. The good news is that when you’re using C# 5, it all makes sense on the surface. It’s only when you try to think of exactly what’s going on behind the scenes that things get tough.

Let’s get started!

### Introducing asynchronous functions

C# 5 introduces the concept of an asynchronous function. This is always either a method or an anonymous function<a href="file:///C:/Users/Alvin/Downloads/#_ftn1_4505" name="_ftnref1_4505">[1]</a> which is declared with the async modifier, and can include await expressions. These await expressions are the points where things get interesting from a language perspective: if the value that the expression is awaiting isn’t available yet, the asynchronous function will return immediately, and then continue where it left off (in the “right” thread) when the value becomes available. The natural flow of “don’t execute the next statement until this one has completed” is still maintained, but without blocking.

We’ll break that woolly description down into more concrete terms and behavior later on, but you really need to see an example of it before it’s likely to make any sense.

### First encounters of the asynchronous kind

Let’s start with something very simple, but which demonstrates asynchrony in a practical way. We often curse network latency for causing delays in our real applications, but it does make it easy to show why asynchrony is so important, as we can see in 1.

<sub>Listing 1 Displaying a page length asynchronously</sub>

<pre class="csharpcode"><span class="kwrd">class</span> AsyncForm : Form
{
    Label label;
    Button button;

    <span class="kwrd">public</span> AsyncForm()
    {
        label = <span class="kwrd">new</span> Label { Location = <span class="kwrd">new</span> Point(10, 20), Text = “Length” };
        button = <span class="kwrd">new</span> Button { Location = <span class="kwrd">new</span> Point(10, 50), Text = “Click” };
        button.Click += DisplayWebSiteLength;  <span class="rem">// #1</span>
        AutoSize = <span class="kwrd">true</span>;
        Controls.Add(label);
        Controls.Add(button);
    }

    async <span class="kwrd">void</span> DisplayWebSiteLength(<span class="kwrd">object</span> sender, EventArgs e)
    {
        label.Text = “Fetching...”;
        HttpClient client = <span class="kwrd">new</span> HttpClient();  <span class="rem">// #2</span>
        <span class="kwrd">string</span> text = await client.GetStringAsync(“http:<span class="rem">//csharpindepth.com”);  // #2</span>
        label.Text = text.Length.ToString();  <span class="rem">// #3</span>
    }
}</pre>

&#8230;

Application.Run(new AsyncForm());laying a page length asynchronously

#1 Wires up event handler

#2 Starts fetching the page

#3 Updates the UI

The first part of listing 1 simply creates the UI and hooks up an event handler for the button in a straightforward way. It’s the DisplayWebSiteLength method that we’re interested in. When you click on the button, the text of the book’s home page is fetched, and the label is updated to display the HTML length in characters.

I could have written a smaller example program as a console app, but hopefully this makes a more convincing demo. In particular, if you remove the async and await contextual keywords, change HttpClient to WebClient, and change GetStringAsync to DownloadString, the code will still compile and work… but the UI will freeze while it fetches the contents of the page.<a href="file:///C:/Users/Alvin/Downloads/#_ftn2_4505" name="_ftnref2_4505">[2]</a> If you run the async version (ideally over a slow network connection), you’ll see that the UI is responsive; you can still move the window around while the web page is fetching.

Most developers are familiar with the two golden rules of threading in Windows Forms development:

  * Don’t perform any time-consuming action on the UI thread
  * Don’t access any UI controls other than on the UI thread

These are easier to state than to obey. As an exercise, you might want to try a few different ways of creating similar code to listing 1 without using the new features of C# 5. For this extremely simple example, it’s not actually too bad to use the event-based WebClient.DownloadStringAsync method, but as soon as more complex flow control (error handling, waiting for multiple pages to complete, and so on) comes into the equation, the “legacy” code quickly becomes hard to maintain, whereas the C# 5 code can be modified in a natural way.

At this point, the DisplayWebSiteLength method feels somewhat magical: we know it does what we need it to, but we have no idea how. Let’s take it apart just a little bit, saving the really gory details for later.

### Breaking down the first example

First I’ll start by expanding the method very slightly &#8211; splitting the call to HttpClient.GetStringAsync from the await expression to highlight the types involved:

<pre class="csharpcode">async <span class="kwrd">void</span> DisplayWebSiteLength(<span class="kwrd">object</span> sender, EventArgs e)
{
    label.Text = “Fetching...”;
    HttpClient client = <span class="kwrd">new</span> HttpClient();
    Task&lt;<span class="kwrd">string</span>&gt; task = client.GetStringAsync(“http:<span class="rem">//csharpindepth.com”);</span>
    <span class="kwrd">string</span> text = await task;
    label.Text = text.Length.ToString();
}</pre>

Notice how the type of task is Task<string>, but the type of the await task expression is just string. In this sense, an await expression performs an “unwrapping” operation, at least when the value being awaited is a Task<TResult>. (You can await other types too, as we’ll see, but Task<TResult> acts as a good starting point.) That’s one aspect of await &#8211; which doesn’t seem directly related to asynchrony, but makes life easier.

The main purpose of await is to avoid blocking while we wait for time-consuming operations to complete. You may be wondering how this all works in the concrete terms of threading. We’re setting label.Text at both the start and end of the method, so it’s reasonable to assume that both of those statements are executed on the UI thread, and yet we’re clearly not blocking the UI thread while we wait for the web page to download.

The trick is that the method actually returns as soon as we hit the await expression. Up until that point, it executes synchronously on the UI thread just as any other event handler would. If you put a breakpoint on the first line and hit it in the debugger, you’ll see that the stack trace shows that the button is busy raising its Click event. When we reach the await, the code checks whether the result is already available, and if it’s not (which will almost certainly be the case) it schedules a continuation to be executed when the web operation has completed. A continuation is effectively a callback which maintains the control state of the method: just as a closure maintains its environment in terms of variables, a continuation also remembers where it had got to, so it can continue from there when it’s executed. It’s very much like an iterator block, except that instead of yielding a value and then waiting to be executed again, await just “pauses” the method until the asynchronous operation has completed.<a href="file:///C:/Users/Alvin/Downloads/#_ftn3_4505" name="_ftnref3_4505">[3]</a>

In our case, the continuation executes the rest of the method, effectively jumping to the end of the await expression, back in the UI thread just as we want in order to manipulate the UI.

In case you’re wondering, all of this is handled by the compiler creating a complicated state machine. That’s an implementation detail. It’s instructive to examine it to get a better grasp of what’s going on, but before that, we need a more concrete description of what we’re trying to achieve and what the language actually specifies.

### Thinking about asynchrony

If you ask a developer what they understand by asynchronous execution, chances are they’ll start talking about multi-threading. While that’s an important part of uses of asynchrony, it’s not really required for asynchronous typical execution. To fully appreciate how the async feature of C# 5 works, it’s best to strip away any thoughts of threading, and go back to basics. 

Asynchrony strikes at the very heart of the execution model that C# developers are familiar with. Consider simple code like this:

<pre class="csharpcode">Console.WriteLine(“First”);

Console.WriteLine(“Second”);</pre>

We expect the first call to complete, and then the second call to start. Execution flows from one statement to the next, in order. An asynchronous execution model doesn’t work that way. Instead, it’s all about continuations. When you start doing something, you tell that operation what you want to happen when that operation has completed. You may have heard (or used) the term callback for the same idea, but that’s got a broader meaning than the one we’re after here. We’re only interested in preserving the control state of the program, not arbitrary callbacks for other purposes.

Continuations are naturally represented as delegates in .NET, typically actions that receive the results of the asynchronous operation. That’s why to use the asynchronous methods in WebClient prior to C# 5, you would wire up various events to say what code should be executed in the case of success, failure and so on. The trouble is that creating all those delegates for a complicated sequence of steps ends up being very complicated, even with the benefit of lambda expressions. It’s even worse when you try to make sure that your error handling is correct. (On a good day, I can be reasonably confident that the success paths of hand-written asynchronous code are correct. I’m typically less certain that it reacts the right way on failure.)

Essentially, all that async in C# does is ask the compiler to build continuations for you. For an idea that can be expressed so simply, however, the consequences for readability and developer sanity are remarkable.

When I wrote earlier that we pass the continuation to the asynchronous operation at the same time that we start it, I was thinking about asynchrony in a classic, idealized sense. The reality in the task-based asynchronous pattern is very slightly different. Instead of the continuation being passed to the asynchronous operation, the asynchronous operation starts and returns us a token we can used to provide the continuation later. It represents the ongoing operation, which may have completed even before it’s returned to the calling actually code or may still be in progress. That token is then used whenever we want to express the idea of “I can’t proceed any further until this operation has completed.” Typically the token is in the form of a Task or Task<TResult>, but it doesn’t have to be.

So, the execution flow in an asynchronous method in C# 5 is typically along the lines of:

  * Do some work
  * Start an asynchronous operation, and remember the token it returns
  * Possibly do some more work. (Often you really can’t make any further progress until the asynchronous operation has completed, in which case this step is empty.)
  * “Wait” for the asynchronous operation to complete (via the token)
  * Do some more work
  * Finish

If we didn’t care about exactly what the “wait” part meant, we could do all of this in C# 4. If we’re happy to block until the asynchronous operation completes, the token will normally provide us some way of doing so. For a Task, we could just call Wait(). At that point, though, we’re taking up a valuable resource (a thread) and not doing any useful work. It’s a little like phoning for a takeaway pizza, and then standing at the front door until it arrives. What we really want to do is get on with something else, ignoring the pizza until it arrives. That’s where async comes in.

When we “wait” for an asynchronous operation, what we’re really saying is, “I’ve gone as far as I can go for now. Keep going when the operation has completed.” But if we’re not going to block the thread, what can we do? Very simply, we can return right there and then. We’ll continue asynchronously ourselves. And if we want our caller to know when our asynchronous method has completed, we’ll pass a token back to them, which they can block on if they want, or (more likely) use with another continuation. Very often you’ll end up with a whole stack of asynchronous methods calling each other. It’s almost as if you go into “async mode” for a section of code. There’s nothing in the language which states that it has to be done that way, but the fact that the same code which makes consuming asynchronous operations also behaves as an asynchronous operation certainly encourages it.

With the theory out of the way, let’s take a closer look at the concrete details of asynchronous methods. Asynchronous anonymous functions fit into the same mental model, but it’s much easier to talk about asynchronous methods.

### Modelling asynchronous methods

I find it very useful to think about asynchronous methods in the form of figure 1.

[<img loading="lazy" decoding="async" title="async2" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="async2" src="/wp-content/uploads/async2_thumb.png" width="244" height="118" />][1]

<sup>Figure 1 Async model</sup>

Here we have three blocks of code (the methods) and two boundaries (the method return types). To give a very simple example, we might have:

<pre class="csharpcode"><span class="kwrd">static</span> async Task&lt;<span class="kwrd">int</span>&gt; GetPageLengthAsync(<span class="kwrd">string</span> url)
{
    HttpClient client = <span class="kwrd">new</span> HttpClient();
    Task&lt;<span class="kwrd">string</span>&gt; fetchTextTask = client.GetStringAsync(url);
    <span class="kwrd">int</span> length = await fetchTextTask;
    <span class="kwrd">return</span> length;
}

<span class="kwrd">static</span> <span class="kwrd">void</span> PrintPageLength()
{
    Task&lt;<span class="kwrd">int</span>&gt; lengthTask = GetPageLengthAsync(“http:<span class="rem">//csharpindepth.com”);</span>
    Console.WriteLine(lengthTask.Result);
}</pre>

Here the five parts of the diagram correspond like this:

  * The calling method is PrintPageLength.
  * The async method is GetPageLengthAsync.
  * The asynchronous operation is HttpClient.GetStringAsync.
  * The boundary between the calling method and the async method is Task<int>.
  * The boundary between the async method and the asynchronous operation is Task<string>.

We’re mainly interested in the async method itself, but I’ve included the other methods so we can work out how they all interact together. In particular, you definitely need to know about the valid types at the method boundaries.

### Summary

I hope that the more complicated, deep-dive sections of this chapter haven’t put you off the elegance of the asynchronous features of C# 5. The ability to write efficient asynchronous code in a more familiar execution model is a huge step forward, and I believe it will be transformative—once it’s well understood. In my experience giving presentations about async, many developers get easily confused by the feature the first time they see and use it. That’s entirely understandable, but please don’t let that put you off. ****

**  
  
** 

<a name="Related"></a>**Here are some other Manning titles you might be interested in:**

<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top" width="61">
      <p>
        <a href="/wp-content/uploads/async-3.png"><img loading="lazy" decoding="async" title="async 3" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="async 3" src="/wp-content/uploads/async-3_thumb.png" width="64" height="80" /></a>
      </p>
    </td>
    
    <td valign="top" width="500">
      <p>
        <a href="http://www.manning.com/seemann/">Dependency Injection in .NET</a>
      </p>
      
      <p>
        Mark Seemann
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="61">
      <p>
        <a href="/wp-content/uploads/async-4.png"><img loading="lazy" decoding="async" title="async 4" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="async 4" src="/wp-content/uploads/async-4_thumb.png" width="64" height="80" /></a>
      </p>
    </td>
    
    <td valign="top" width="500">
      <p>
        <a href="http://www.manning.com/perga/">Windows Phone 7 in Action</a>
      </p>
      
      <p>
        Timothy Binkley-Jones, Massimo Perga and Michael Sync<i></i>
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="61">
      <p>
        <a href="/wp-content/uploads/async5.png"><img loading="lazy" decoding="async" title="async5" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="async5" src="/wp-content/uploads/async5_thumb.png" width="64" height="80" /></a>
      </p>
    </td>
    
    <td valign="top" width="500">
      <p>
        <a href="http://www.manning.com/petricek/">Real-World Functional Programming</a>
      </p>
      
      <p>
        Tomas Petricek
      </p>
    </td>
  </tr>
</table>

&#160;

<a href="file:///C:/Users/Alvin/Downloads/#_ftnref1_4505" name="_ftn1_4505">[1]</a> As a reminder, an anonymous function is either a lambda expression or an anonymous method.

<a href="file:///C:/Users/Alvin/Downloads/#_ftnref2_4505" name="_ftn2_4505">[2]</a> HttpClient is in some senses the “new and improved” WebClient—it’s the preferred HTTP API for .NET 4.5 onwards and only contains asynchronous operations. If you’re writing a Windows Store app, you don’t even have the option of using WebClient.

<a href="file:///C:/Users/Alvin/Downloads/#_ftnref3_4505" name="_ftn3_4505">[3]</a> There are many parallels to be drawn between iterator blocks and asynchronous functions, but don’t be fooled into thinking they’re equivalent features. In the past, asynchronous libraries have been built on top of iterators to take advantage of the generated state machines, but the fact that asynchronous functions have been designed specifically for asynchrony makes them considerably cleaner.

&#160;

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:aab4d715-0e99-44e1-88cc-b39ccf625e00" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  del.icio.us Tags: <a href="http://del.icio.us/popular/c%23" rel="tag">c#</a>,<a href="http://del.icio.us/popular/async" rel="tag">async</a>,<a href="http://del.icio.us/popular/manning" rel="tag">manning</a>,<a href="http://del.icio.us/popular/jon+skeet" rel="tag">jon skeet</a>
</div>

 [1]: /wp-content/uploads/async2.png