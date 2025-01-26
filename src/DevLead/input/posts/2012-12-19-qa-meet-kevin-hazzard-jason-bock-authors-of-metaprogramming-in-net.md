---
title: 'Q&A: Meet Kevin Hazzard & Jason Bock – Authors of Metaprogramming in .NET'
author: Alvin A.
type: post
date: 2012-12-19T17:08:17+00:00
url: /2012/12/19/qa-meet-kevin-hazzard-jason-bock-authors-of-metaprogramming-in-net/
categories:
  - Daily Links
  - Development
tags:
  - .net framework
  - dynamic language runtime
  - manning
  - reflection
  - roslyn

---
_<a href="http://manning.com/hazzard" target="_blank"><img data-recalc-dims="1" loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; margin: 3px 8px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; float: left; border-top: 0px; border-right: 0px; padding-top: 0px" border="0" align="left" src="https://i0.wp.com/manning.com/hazzard/hazzard_cover150.jpg?resize=120%2C150" width="120" height="150" /></a><a href="http://manning.com/" target="_blank">Manning Publications</a> has just released a new title,_ <a href="http://manning.com/hazzard/" target="_blank"><em>Metaprogramming in .NET</em></a> _by <a href="http://devjourney.com/" target="_blank">Kevin Hazzard</a> and <a href="http://jasonbock.net/JB/Default.aspx" target="_blank">Jason Bock</a>. The PDF eBook is currently available in its final form (ePub and Kindle formats due on January 15th) and the print book will be available on December 28th. I recently had the opportunity to ask them a few question about the release of the book._

> ##### About the Authors
> 
> **Kevin Hazzard** is a Microsoft MVP, consultant, teacher, and developer community leader in the mid-Atlantic USA. **Jason Bock** is an author, Microsoft MVP, and the leader of the Twin Cities Code Camp.

##### **Alvin:** What motivated you to write this book?

**Jason:** I’ve been fortunate with the books I’ve written in the past that they’ve been based on topics that I was passionate about. However, it takes a lot of effort to write a book, and that’s why I decided to stop doing them for a while after I co-authored “Applied .NET Attributes” in 2003. I said to myself that I wouldn’t write another book unless I loved its theme, and that’s exactly what happened with this book. Metaprogramming sounds like a fancy term, but to me it comes down to using techniques such that you write less code to do more. I wanted to take some of the fear away from Reflection and other dynamic coding techniques that some people have in the .NET world where both C# and VB are primarily used as static languages. Being able to write a book that could do that was very appealing to me.

**Kevin:** The opportunity to work with Jason was a strong motivator for Kevin. Also, we looked around the blogosphere and the book-o-sphere (is that a real word) and saw that there just wasn&#8217;t much available regarding metaprogramming. Some books do exist but none that we could find that addressed anything beyond specific tools and techniques. Our book is also carved up into tools and techniques at the chapter level but we tried hard to make the writing address more fundamental questions about metaprogramming. We wanted to convey that metaprogramming isn&#8217;t just a set of tools. It&#8217;s a mindset: a way of thinking about software development from the start of design all the way through to the end. We didn&#8217;t aim to convey that metaprogramming should be used for all your development though. Software creation should be approached like the development of a car, for example. Some parts are rigid by design, some parts are flexible and some parts can be classified as supple. Combining these in the right way makes the automobile safe, durable and comfortable. Software can be safe, durable and comfortable, too. We simply looked at the way we were using metaprogramming in our own designs and realized that there should be a book that helped others to understand it, too.

##### **Alvin:** Who do you see at your target audience? Is the book intended for expert developers only?

**Kevin:** I remember the first phone call we had with the folks at Manning about this book. Jason and I wrestled with this very question during that call. This isn&#8217;t a book with mass appeal like those from Jon Skeet or Jesse Liberty. But it&#8217;s also not strictly for experts. Metaprogramming is a way of thinking about software development and you don&#8217;t have to be an expert developer to think that way. It&#8217;s true that many of the best software developers you&#8217;ll ever meet know how to metaprogram and, more importantly, they know when to do it. But this book isn&#8217;t necessarily aimed at them either. The content is aimed at the middle: those who have good development skills and those who understand that adaptable, flexible code is usually better than rigid, brittle code. After all, we call it SOFT ware. This book is for those developers who want to develop software that remains pliable after it ships and you don&#8217;t have to be an expert to appreciate the value of that.

##### **Alvin:** How did you divide up the topics in the book? Do you each have any particular facets of metaprogramming that are strengths or of particular interest?

**Jason:** That was pretty easy. Kevin and I had strengths in certain areas of the material, so we assigned the chapters based on that level of understanding. It ended up being close to a 50/50 split. Kevin did the introduction, CodeDOM, T4 and DLR chapters and I handled the rest.

**Kevin:** Our skills and experience were somewhat different. Jason has a lot of experience deep in the .NET CLI that helped him write and Kevin brought real-world experience with technologies like the DLR and T4 to his writing. I think we learned a lot from each other as we wrote the book which was great. A lot of co-authored technology books have a disjoint feel to them because the individual authors deliver their chapters individually to the publisher. But we worked hard to make sure that ours didn&#8217;t feel that way. We had weekly conference calls with each other and with our development editors. We edited each others chapters and code. It was a great experience that brought our individual strengths to bear in a collaborative way.

##### **Alvin:** Which topics in the book do you use most in your day-to-day development work?

Kevin: Nearly every .NET developer uses the Reflection API every day, whether they realize it or not. That&#8217;s why we opened the book with an examination of it. Reflective, metadata-driven programming techniques add tremendous value to the software development process for most developers, including us. This is why WinRT is so important to the future of Microsoft&#8217;s tools. Moving the metadata model down into the operating system core means that we can share conventions and abstract expressions between programs after the moment of compilation. That&#8217;s a fundamentally "meta" way of thinking and working. I suppose that the other common practices that we use the most are Expression Trees and IL re-writing. Expressions are used throughout LINQ, of course, but they are used rather statically in that context, i.e. not as a metaprogramming tool. However, Expression Trees are the underpinning of a lot of dynamic capability that I add to my code. I used generic Expression<T> and Lazy<T> all over the place in my code, in places where I need flexibility and performance. As we mentioned throughout the book, higher-order functions and lazy evaluation are the hallmarks of functional programming. As it turns out, metaprogramming and functional programming intersect greatly through classes like Expression<T> and Lazy<T>. So I find myself using them all the time both for functional reasons and to make my code more pliable and adaptable. Most of the IL-rewriting that I do is through IOC/DI frameworks that allow for AOP interceptors and such. But I occasionally find myself doing that by hand, so to speak.

##### **Alvin:** We heard a lot about the Dynamic Language Runtime when it was released several years ago. Where does it stand today?

Kevin: As you learn about Microsoft&#8217;s long-term plans for their languages and tools, it makes sense to limit the investments in the DLR&#8217;s way of doing things. What Jim Hugunin and the others on the team did to create the DLR was brilliant for .NET and the DLR will remain a viable platform for dynamic language development for a while longer. However, in a WinRT world, dynamic languages shouldn&#8217;t necessarily be implemented through a dynamic core like the DLR. With WinRT in place, Microsoft is likely to choose the path for new implementations that languages like Boo and Nemerle have taken. In fact, they already have. Look at WinJS, Microsoft&#8217;s JavaScript implementation for Windows 8. Because WinJS runs atop WinRT, it can co-mingle with F#, C#, C++, and Visual Basic in a single application, for the most part. This gives you the flexibility that the DLR designers were after without the DLR&#8217;s ceremony. In the end, language interop is always about sharing metadata and conventions for things like data types. That&#8217;s what the DLR is about and so is WinRT. In recent days, I&#8217;ve begun porting a Python language implementation over to WinRT as an exercise and it&#8217;s going smoothly so far. I know that others are working on porting IronPython over to WinRT, too. In 2013, I predict that you&#8217;ll see one or two more major dynamic languages appear on WinRT, in addition to WinJS. Whether Microsoft will be sponsoring any of that development, who knows? Anyone thinking of implementing any language on WinRT should study the DLR first. There are some truly remarkable inventions in there.

##### Alvin: Did you have access to Microsoft&#8217;s language and compiler teams while writing the book?

Kevin: I think we had better access than the average developer and even the average MVP. They knew that we were working on the book and pulled us aside at the MVP Summit to talk about our work. We also exchanged a bunch of e-mails and had some phone calls with various team members. Of course, we stayed true to our Non-Disclosure Agreements and only wrote about the material that was public or was going to become public. The various relevant teams at Microsoft working on WinRT were under a very strict gag order of sorts so we didn&#8217;t learn much about it until the rest of the world did. In hindsight, I wish we had shifted more of the book&#8217;s content to WinRT and Roslyn based on what we learned but it was a bit late for that. Furthermore, the metaprogramming capabilities in the new development stack are very different from .NET so we would have needed to rethink the book to address all of the changes in full. In the end, we ended up with a very .NET-centric book with an eye toward the future.

##### Alvin: What does the future hold for metaprogramming in .NET? Do you see some new tools and techniques coming down the line?

Jason: I see Project Roslyn having a big impact in the .NET world, even if a fair amount of .NET developers never use those APIs directly. Having a common set of APIs to analyze, change and compile code will open more doors for .NET developers to do some amazing things. There’s a lot of cool work already done in the .NET world to facilitate metaprogramming, but I can see Roslyn being a core part of that work in a lot of areas.

Kevin: .NET has had rich metadata and a delegate class since day one. Metaprogramming is baked into the soul of .NET, you might say. With the advent of Expression Trees, metaprogramming took a big leap forward. The next frontier is access to the Abstract Syntax Tree (AST) of code. In this respect, we see hints of what will be available in the future through the Roslyn project. The capability to inspect ASTs will come first, allowing some truly revolutionary development tools to be created. The logical step after that is opening access to the ASTs at runtime. When that happens and after we&#8217;ve addressed the obvious security concerns, metaprogramming will become much more popular. Reflection against metadata to drive program behavior is fairly common in .NET development today. When ASTs, which are really just algorithmic metadata, become available, we expect developers to embrace this way of working as a natural extension of what they already know. You see this mindset emerging today in jQuery, for example, albeit at a higher level. It&#8217;s common in jQuery to test for the existence of a function or even attach one on the fly to accomplish a task. This is a hallmark of dynamic languages but will soon become a common capability in traditionally statically-typed languages. After all, functions are just building blocks that are made up of smaller building blocks. The assembly of functions in the right order and at the right time is really the only thing that separates traditionally imperative languages from declarative ones. The lines between those types of languages are blurring and it will be metaprogramming frameworks like Roslyn and its derivatives that drive it.

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:7dc1bd33-94bd-46fd-a20b-0131235bcd47:5128f62c-e052-4443-adab-361be1eef368" class="wlWriterEditableSmartContent">
  <table cellspacing="0" cellpadding="2" width="400" border="0" unselectable="on">
    <tr>
      <td valign="top" width="400">
        <p>
          <a title="Metaprogramming in .NET: Kevin Hazzard, Jason Bock: 9781617290268: Books" href="http://www.amazon.com/exec/obidos/ASIN/1617290262/alvinashcraft-20"><img data-recalc-dims="1" decoding="async" src="https://i0.wp.com/images.amazon.com/images/P/1617290262.01.MZZZZZZZ.jpg?w=660" border="0" align="left" style="float:left" />Metaprogramming in .NET: Kevin Hazzard, Jason Bock: 9781617290268: Books</a>
        </p>
        
        <p>
          <b>ISBN</b>: 1617290262<br /><b>ISBN-13</b>: 9781617290268
        </p>
      </td>
    </tr>
  </table>
</div>

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:d19fb65a-532b-42b0-86a4-68055a206a04" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/.net+framework" rel="tag">.net framework</a>,<a href="http://del.icio.us/popular/roslyn" rel="tag">roslyn</a>,<a href="http://del.icio.us/popular/reflection" rel="tag">reflection</a>,<a href="http://del.icio.us/popular/dynamic+language+runtime" rel="tag">dynamic language runtime</a>,<a href="http://del.icio.us/popular/manning" rel="tag">manning</a>
</div>