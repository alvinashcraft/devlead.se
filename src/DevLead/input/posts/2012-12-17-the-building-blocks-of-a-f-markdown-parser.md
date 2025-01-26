---
title: 'The Building Blocks of a F# Markdown Parser'
author: Alvin A.
type: post
date: 2012-12-17T18:17:52+00:00
url: /2012/12/17/the-building-blocks-of-a-f-markdown-parser/
categories:
  - books
  - Development
  - how-to
tags:
  - .net framework
  - 'f#'
  - manning
  - markdown

---
##### by Tomas Petricek, author of [F# Deep Dives][1]

> _**Editor’s Note:** The F# Deep Dives MEAP will be 50% on December 18, 2012. Use code <font color="#ffffff"><font face="Courier New">dotd1218au</font> </font>at checkout._

_Markdown is a simple text-based markup language that can be used to produce clean HTML and is used by sites such as StackOverflow or GitHub. You can build your very own an efficient parser that can be extended with custom features and that allows you to process the document after parsing. In this article, based on chapter 11 of <a href="http://www.manning.com/petricek2" target="_blank">F# Deep Dives</a>, author Tomas Petricek describes the key elements of such a project, in particular, the representation of a Markdown document._

I&#8217;ve been writing a blog for a number of years now. Since the beginning, I wanted the website to use clean and simple HTML code. Initially, I just wrote articles in HTML by hand, but then I became a big fan of Markdown, a simple text-based markup language that can be used to produce clean HTML and is used by sites such as StackOverflow or GitHub. However, none of the existing Markdown implementations supported what I wanted: I needed an efficient parser that can be extended with custom features and that allows me to process the document after parsing. That&#8217;s why I decided to write <a href="https://github.com/tpetricek/FSharp.Formatting" target="_blank">my own parser in F#</a>.

In this article, I&#8217;ll describe the key elements of the project. In particular, I&#8217;ll discuss the key subject from a functional perspective: the representation of a Markdown document.

You might not need to implement your own text-formatting engine, but you may often face a similar task. Text processing is not only useful when working with external files (test scripts, behavior specifications, or configuration files) but also when processing user inputs in an application (such as commands or calculations).

#### Introducing the Markdown format

<a href="http://daringfireball.net/projects/markdown" target="_blank">The Markdown format</a> is a markup language that has been designed to be as readable as possible in the plain text form. It is inspired by formatting marks, such as \*emphasis\*, that are often used in text files, emails, or README documents. It specifies the syntax precisely and thus it is possible to translate Markdown documents to HTML.

##### Formatting text with Markdown

The formatting of Markdown documents is based on whitespace and common punctuation marks. The document consists of block elements (such as paragraphs, headings, and lists). A block element can contain emphasized text, links, and other formatting. The following sample demonstrates some of the syntax:

<pre class="csharpcode">Visual F#  
=========
F# is a **programming language** that supports _functional_, as 
well as _object-oriented_ and _imperative_ programming styles. 
Hello world can be written as follows: 

    printfn "Hello world!" 

For more information, see the [F# home page] (http://fsharp.net) or 
read [Real-World Functional Programming](http://manning.com/petricek) 
published by [Manning](http://manning.com).</pre>

The document above consists of four block elements. It starts with a heading. The separator "=" is used for first level headings. We can also create second level headings using "-" as a separator. An alternative style uses a certain number of "#" characters at the beginning of the line, so, for example, ## Example is a second-level heading.

The second block is a paragraph, followed by a code sample and one more paragraph. The text in paragraphs is formatted using ** (strong) and _ (emphasis). Both asterisk and underscore can be used for strong and emphasized text—one character means emphasis and two characters means strong text. We can also create hyperlinks, which is demonstrated by the last line.

From a programming language perspective, formats such as Markdown can be viewed as domain specific languages, which is explained in the following sidebar.

> ##### Meta: external domain specific languages
> 
> The term domain specific languages (DSLs) refers to programming languages that are designed to solve problems from a particular domain or field. DSLs are useful when you need to solve a large number of problems of the same class. In that case, the time spent on developing the DSL will be balanced out by the time that you save when using the DSL to solve particular problems.
> 
> DSL can be categorized into two groups. Internal DSLs are embedded in another language (like F# or C#). Functions from the List module with the pipelining operator (|>) can be viewed as a DSL. They solve a specific problem—list processing—and solve it very well without other dependencies.
> 
> External DSLs are languages that are not constructed on top of other languages. They may be used as embedded strings (for example, regular expressions or SQL) or as standalone files (including Markdown, configuration files, Makefile, or for example, behavior specifications using language such as Cucumber).

Now that I&#8217;ve introduced the Markdown format and domain specific languages in general, let&#8217;s look at a number of benefits that we can expect from a Markdown parser written in F#.

##### Why another Markdown parser?

Markdown is a well-established format and there is a number of existing tools that convert it to HTML. Most of these are written using regular expressions and there are some written for almost any platform, including .NET. So, why do we need yet another processor? Here are a few reasons:

  * Creating a custom syntax extension for Markdown is quite difficult when using an implementation based on regular expressions. It is hard to find where the syntax is being processed, and changing a regular expression can lead to various unexpected interactions. 
  * Most of the tools transform Markdown directly to HTML. This makes it hard to add a custom-processing step, for example, to process all code samples in the document before generating HTML. 
  * A related problem is that HTML is the only supported output. What if we wanted to turn Markdown documents into another document format, such as Word or LaTeX? 
  * Finally, performing a single regular expression replacement may be quite efficient, but, if the processor performs a huge number of them, the code can get quite CPU consuming. A custom implementation may give us better performance. 

Let&#8217;s now look how we can achieve these goals using F#. The key element of the solution is an elegant functional representation of the document structure.

#### Representing Markdown documents

When solving problems in functional languages, the first question we need to answer often is: "What data structures do we need to represent the data we work with?" In case of Markdown processor, the data structure represents a document. As discussed earlier, a document consists of blocks of different kinds. Some of the blocks (like paragraphs) may contain additional inline formatting and hyperlinks.

[<img loading="lazy" decoding="async" style="background-image: none; border-right-width: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px; padding-top: 0px" title="fdeep101" border="0" alt="fdeep101" src="/wp-content/uploads/fdeep101_thumb.png" width="240" height="156" />][2]

**Figure 1 Here you can see how different MarkdownBlock elements and different MarkdownSpan elements are used to format the sample document. All other unmarked text is represented as Literal.**

**<sub>Listing 1 Representation of Markdown document</sub>**

<pre class="csharpcode">type MarkdownDocument = list

and MarkdownBlock =  
  | Heading of <span class="kwrd">int</span> * MarkdownSpans
  | Paragraph of MarkdownSpans
  | CodeBlock of list

and MarkdownSpans = list

and MarkdownSpan =  
  | Literal of <span class="kwrd">string</span>
  | InlineCode of <span class="kwrd">string</span>
  | Strong of MarkdownSpans
  | Emphasis of MarkdownSpans
  | HyperLink of MarkdownSpans * string</pre>

The types that model Markdown documents are shown and explained in listing 1. I defined the types as a mutually recursive using the and keyword for two reasons. Firstly, the MakdownSpans and MarkdownSpan types are mutually recursive and they both reference each other. Secondly, I wanted to start with a type that represents the entire document rather than starting from the span to make the explanation easier to follow.

#### Summary

Broadly speaking, this article was about external domain specific languages. An external DSL is a small programming language or document format that has its own syntax and represents some script, document, or command. External DSLs can be used to configure an application, to provide scripting capabilities, customization, and various other tasks.

The domain specific language that we focused on was the Markdown document format. When working with external DSLs, we first write an F# representation of the language and then implement processing of the DSL.

The functional representation that I described in this article is the cornerstone of a new Markdown processor. Other components are all built around this representation. Chapter 3 of F# Deep Dives looks at three additional aspects: writing a parser that turns text into MarkdownDocument, writing an HTML generator that turns MarkdownDocument into a HTML file, and implementing the pre-processing of a document that generates the references section with all of the document links. All of these tasks are built on top of a simple representation using powerful F# features like pattern matching and active patterns.

1. The project can be found at <a href="https://github.com/tpetricek/FSharp.Formatting" target="_blank">https://github.com/tpetricek/FSharp.Formatting</a> 

2. For more information about Markdown, see <a href="http://daringfireball.net/projects/markdown" target="_blank">http://daringfireball.net/projects/markdown</a> 

**Here are some other Manning titles you might be interested in:**

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: left; border-top: 0px; border-right: 0px; padding-top: 0px" title="fdeep102" border="0" alt="fdeep102" align="left" src="/wp-content/uploads/fdeep102.jpg" width="40" height="49" />][3]

[The Real-World Functional Programming][3] 

Tomas Petricek with Jon Skeet

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: left; border-top: 0px; border-right: 0px; padding-top: 0px" title="fdeep103" border="0" alt="fdeep103" align="left" src="/wp-content/uploads/fdeep103.jpg" width="40" height="49" />][4]

[HTML5 for .NET Developers][4] 

Jim Jackson II and Ian Gilman

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: left; border-top: 0px; border-right: 0px; padding-top: 0px" title="fdeep104" border="0" alt="fdeep104" align="left" src="/wp-content/uploads/fdeep104.jpg" width="40" height="49" />][5]

[IronPython in Action][5] 

Michael J. Foord and Christian Muirhead

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:c4b9d967-4ae3-4ce1-add1-746510ccae58" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/f%23" rel="tag">f#</a>,<a href="http://del.icio.us/popular/markdown" rel="tag">markdown</a>,<a href="http://del.icio.us/popular/.net+framework" rel="tag">.net framework</a>,<a href="http://del.icio.us/popular/manning" rel="tag">manning</a>
</div>

 [1]: http://www.manning.com/petricek2
 [2]: /wp-content/uploads/fdeep101.png
 [3]: http://www.manning.com/petricek
 [4]: http://www.manning.com/jackson
 [5]: http://www.manning.com/foord