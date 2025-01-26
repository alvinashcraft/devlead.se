---
title: Extend a Generic List to Provide Dictionary-Like Lookups
author: Alvin A.
type: post
date: 2008-09-23T01:17:11+00:00
url: /2008/09/22/extend-a-generic-list-to-provide-dictionary-like-lookups/
aktt_tweeted:
  - 1
categories:
  - Development
  - how-to

---
&nbsp;

Welcome to a quick and dirty example in which I’ll make use of interfaces, inheritance and generics. I was working with some code that did a lot of iterating over collections to find objects with a particular ID. This is an abstracted example of what I did to simplify and centralize that code in a reusable manner.

_If you are using Visual Studio 2008, you could achieve the same kind of reuse with an extension method on your generic list. The project I was working on was in .NET 2.0 and Visual Studio 2005._

This method returns a student’s course based on its ID. The student object here is a private class member. The CurrentCourses property is a List<Course> collection.

> <pre class="code"><span style="color: blue">private </span><span style="color: #2b91af">Course </span>FindCourseOld(<span style="color: blue">int </span>id)
{
    <span style="color: blue">foreach </span>(<span style="color: blue">var </span>course <span style="color: blue">in </span>_student.CurrentCourses)
    {
        <span style="color: blue">if </span>(course.ID == id)
        {
            <span style="color: blue">return </span>course;
        }
    }

    <span style="color: blue">return null</span>;
}</pre>

<pre class="code">&nbsp;</pre>

[][1]

It’s pretty simple, but suppose you had a dozen or more types with an ID property that were all queries like this? It smells like an opportunity to do some refactoring. We need to keep all the functionality of the List<T> generic collection, including sorting, index operations, and enumerating, but we want to provide a dictionary-type of lookup on the ID property. Let’s inherit from List<T> and add a method to perform our lookup.

Before an object can be stored in this new collection, our child of List<T>, that we are going to create, we need to ensure it has an ID property on which we can operate. To that end, I present to you the IHasIdentifier interface. I know it’s not grammatically correct, but I think it gets the point across.

> <pre class="code"><span style="color: blue">public interface </span><span style="color: #2b91af">IHasIdentifier
</span>{
<span style="color: gray">    </span><span style="color: blue">int </span>ID { <span style="color: blue">get</span>; <span style="color: blue">set</span>; }
}</pre>

[][1]

&nbsp;

The new interface has a single property named ‘ID’, which many of the types you might consider using in our collection may already have. Next up is the IdentityList<T> itself. The implementation I have here is very simple. There is just a single method, GetItemByID, added to the base class, List<T>.

> <pre class="code"><span style="color: blue">public class </span><span style="color: #2b91af">IdentityList</span>&lt;T&gt; : <span style="color: #2b91af">List</span>&lt;T&gt; <span style="color: blue">where </span>T : <span style="color: #2b91af">IHasIdentifier
</span>{
<span style="color: gray">    </span><span style="color: blue">public </span>T GetItemByID(<span style="color: blue">int </span>id)
    {
        <span style="color: blue">foreach </span>(<span style="color: blue">var </span>obj <span style="color: blue">in this</span>)
        {
            <span style="color: blue">if </span>(obj.ID == id)
            {
                <span style="color: blue">return </span>obj;
            }
        }

        <span style="color: blue">return default</span>(T);
    }
}</pre>

&nbsp;

We’re inheriting from List<T> and specifying that T must implement IHasIdentifier. Now, in the GetItemByID method, we can do our iteration to find the object with the given ID and return it. Finally, let’s take a look at the FindCourseNew method which uses our IdentityList<T> collection.

<pre class="code"><span style="color: blue">private </span><span style="color: #2b91af">Course </span>FindCourseNew(<span style="color: blue">int </span>id)
{
    <span style="color: blue">return </span>_student.CurrentCourses.GetItemByID(id);
}</pre>

[][1]&nbsp;

The code here is much cleaner, and there could be more opportunity for code reuse with the IdentityList<T>. Many of the dictionary type of methods could be adapted and used within this collection. You can download the sample code <a target="_blank" href="https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/code/IdentityListExample.zip">here</a>. As always, any and all feedback is welcome!

&nbsp;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:C16BAC14-9A3D-4c50-9394-FBFEF7A93539:c6dd5048-588f-436d-b6e0-946b0bdaa220" class="wlWriterEditableSmartContent">
  <!--dotnetkickit-->
</div>

&nbsp;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:e2b15131-3d1b-4ff9-b6ef-6322e312684f" class="wlWriterEditableSmartContent">
  Technorati Tags: <a href="http://technorati.com/tags/.net+development" rel="tag">.net development</a>,<a href="http://technorati.com/tags/coding+tips" rel="tag">coding tips</a>,<a href="http://technorati.com/tags/c%23" rel="tag">c#</a>,<a href="http://technorati.com/tags/generics" rel="tag">generics</a>,<a href="http://technorati.com/tags/List+collection" rel="tag">List collection</a>
</div>

 [1]: http://11011.net/software/vspaste