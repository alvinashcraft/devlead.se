---
title: 'C# + ReSharper = Awesome: Tip #8 – Extract Class From Parameters'
author: Alvin A.
type: post
date: 2012-01-24T01:37:23+00:00
url: /2012/01/23/c-resharper-awesome-tip-8-extract-class-from-parameters/
categories:
  - Development
  - how-to
tags:
  - refactoring
  - resharper
  - visual studio

---
This is the eighth in a series of quick how-to articles on <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>.

### Tip #8 – Extract Class From Parameters

**Use:** If you find yourself passing a set of related values to a method, you should probably put all of those items into a single class or struct. From <a href="http://www.jetbrains.com/resharper/features/code_refactoring.html#Extract_Class_from_Parameters" target="_blank">JetBrains</a>:

> This refactoring creates a new class or struct and converts parameters of the selected method into encapsulated fields of the newly created type (with constructor taking parameters, fields to store values and properties to retrieve values). Usages of parameters are converted to usages of properties of created type.

##### Before

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> EmployeeUtilities</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">public</span> <span class="kwrd">bool</span> ValidateTerminatedEmployeeInfo(<span class="kwrd">int</span> employeeId</pre>

<pre><span class="lnum">   4:  </span>                                                 , <span class="kwrd">string</span> firstName</pre>

<pre><span class="lnum">   5:  </span>                                                 , <span class="kwrd">string</span> lastName</pre>

<pre><span class="lnum">   6:  </span>                                                 , DateTime hireDate</pre>

<pre><span class="lnum">   7:  </span>                                                 , DateTime terminateDate)</pre>

<pre><span class="lnum">   8:  </span>        {</pre>

<pre><span class="lnum">   9:  </span>            <span class="kwrd">if</span> (employeeId &gt; -1 && </pre>

<pre><span class="lnum">  10:  </span>                !String.IsNullOrWhiteSpace(firstName) && </pre>

<pre><span class="lnum">  11:  </span>                !String.IsNullOrWhiteSpace(lastName) &&</pre>

<pre><span class="lnum">  12:  </span>                hireDate &lt; DateTime.Now && </pre>

<pre><span class="lnum">  13:  </span>                terminateDate &gt; hireDate)</pre>

<pre><span class="lnum">  14:  </span>            {</pre>

<pre><span class="lnum">  15:  </span>                <span class="rem">// do awesome stuff</span></pre>

<pre><span class="lnum">  16:  </span>                <span class="kwrd">return</span> <span class="kwrd">true</span>;</pre>

<pre><span class="lnum">  17:  </span>            }</pre>

<pre><span class="lnum">  18:  </span>&#160;</pre>

<pre><span class="lnum">  19:  </span>            <span class="kwrd">return</span> <span class="kwrd">false</span>;</pre>

<pre><span class="lnum">  20:  </span>        }</pre>

<pre><span class="lnum">  21:  </span>    }</pre>
</div>

##### Right-click the method

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="image" border="0" alt="image" src="/wp-content/uploads/image_thumb7.png" width="644" height="153" />][1]

##### Extract Class From Parameters

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="SNAGHTML10f0d4a5" border="0" alt="SNAGHTML10f0d4a5" src="/wp-content/uploads/SNAGHTML10f0d4a5_thumb.png" width="545" height="484" />][2]

##### After

<div class="csharpcode">
  <pre><span class="lnum">   1:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> EmployeeInfo</pre>

<pre><span class="lnum">   2:  </span>    {</pre>

<pre><span class="lnum">   3:  </span>        <span class="kwrd">private</span> <span class="kwrd">int</span> _employeeId;</pre>

<pre><span class="lnum">   4:  </span>        <span class="kwrd">private</span> <span class="kwrd">string</span> _firstName;</pre>

<pre><span class="lnum">   5:  </span>        <span class="kwrd">private</span> <span class="kwrd">string</span> _lastName;</pre>

<pre><span class="lnum">   6:  </span>        <span class="kwrd">private</span> DateTime _hireDate;</pre>

<pre><span class="lnum">   7:  </span>        <span class="kwrd">private</span> DateTime _terminateDate;</pre>

<pre><span class="lnum">   8:  </span>&#160;</pre>

<pre><span class="lnum">   9:  </span>        <span class="kwrd">public</span> EmployeeInfo(<span class="kwrd">int</span> employeeId, <span class="kwrd">string</span> firstName, <span class="kwrd">string</span> lastName, DateTime hireDate, DateTime terminateDate)</pre>

<pre><span class="lnum">  10:  </span>        {</pre>

<pre><span class="lnum">  11:  </span>            _employeeId = employeeId;</pre>

<pre><span class="lnum">  12:  </span>            _firstName = firstName;</pre>

<pre><span class="lnum">  13:  </span>            _lastName = lastName;</pre>

<pre><span class="lnum">  14:  </span>            _hireDate = hireDate;</pre>

<pre><span class="lnum">  15:  </span>            _terminateDate = terminateDate;</pre>

<pre><span class="lnum">  16:  </span>        }</pre>

<pre><span class="lnum">  17:  </span>&#160;</pre>

<pre><span class="lnum">  18:  </span>        <span class="kwrd">public</span> <span class="kwrd">int</span> EmployeeId</pre>

<pre><span class="lnum">  19:  </span>        {</pre>

<pre><span class="lnum">  20:  </span>            get { <span class="kwrd">return</span> _employeeId; }</pre>

<pre><span class="lnum">  21:  </span>        }</pre>

<pre><span class="lnum">  22:  </span>&#160;</pre>

<pre><span class="lnum">  23:  </span>        <span class="kwrd">public</span> <span class="kwrd">string</span> FirstName</pre>

<pre><span class="lnum">  24:  </span>        {</pre>

<pre><span class="lnum">  25:  </span>            get { <span class="kwrd">return</span> _firstName; }</pre>

<pre><span class="lnum">  26:  </span>        }</pre>

<pre><span class="lnum">  27:  </span>&#160;</pre>

<pre><span class="lnum">  28:  </span>        <span class="kwrd">public</span> <span class="kwrd">string</span> LastName</pre>

<pre><span class="lnum">  29:  </span>        {</pre>

<pre><span class="lnum">  30:  </span>            get { <span class="kwrd">return</span> _lastName; }</pre>

<pre><span class="lnum">  31:  </span>        }</pre>

<pre><span class="lnum">  32:  </span>&#160;</pre>

<pre><span class="lnum">  33:  </span>        <span class="kwrd">public</span> DateTime HireDate</pre>

<pre><span class="lnum">  34:  </span>        {</pre>

<pre><span class="lnum">  35:  </span>            get { <span class="kwrd">return</span> _hireDate; }</pre>

<pre><span class="lnum">  36:  </span>        }</pre>

<pre><span class="lnum">  37:  </span>&#160;</pre>

<pre><span class="lnum">  38:  </span>        <span class="kwrd">public</span> DateTime TerminateDate</pre>

<pre><span class="lnum">  39:  </span>        {</pre>

<pre><span class="lnum">  40:  </span>            get { <span class="kwrd">return</span> _terminateDate; }</pre>

<pre><span class="lnum">  41:  </span>        }</pre>

<pre><span class="lnum">  42:  </span>    }</pre>

<pre><span class="lnum">  43:  </span>&#160;</pre>

<pre><span class="lnum">  44:  </span>    <span class="kwrd">public</span> <span class="kwrd">class</span> EmployeeUtilities</pre>

<pre><span class="lnum">  45:  </span>    {</pre>

<pre><span class="lnum">  46:  </span>        <span class="kwrd">public</span> <span class="kwrd">bool</span> ValidateTerminatedEmployeeInfo(EmployeeInfo employeeInfo)</pre>

<pre><span class="lnum">  47:  </span>        {</pre>

<pre><span class="lnum">  48:  </span>            <span class="kwrd">if</span> (employeeInfo.EmployeeId &gt; -1 && </pre>

<pre><span class="lnum">  49:  </span>                !String.IsNullOrWhiteSpace(employeeInfo.FirstName) && </pre>

<pre><span class="lnum">  50:  </span>                !String.IsNullOrWhiteSpace(employeeInfo.LastName) &&</pre>

<pre><span class="lnum">  51:  </span>                employeeInfo.HireDate &lt; DateTime.Now && </pre>

<pre><span class="lnum">  52:  </span>                employeeInfo.TerminateDate &gt; employeeInfo.HireDate)</pre>

<pre><span class="lnum">  53:  </span>            {</pre>

<pre><span class="lnum">  54:  </span>                <span class="rem">// do awesome stuff</span></pre>

<pre><span class="lnum">  55:  </span>                <span class="kwrd">return</span> <span class="kwrd">true</span>;</pre>

<pre><span class="lnum">  56:  </span>            }</pre>

<pre><span class="lnum">  57:  </span>&#160;</pre>

<pre><span class="lnum">  58:  </span>            <span class="kwrd">return</span> <span class="kwrd">false</span>;</pre>

<pre><span class="lnum">  59:  </span>        }</pre>

<pre><span class="lnum">  60:  </span>    }</pre>
</div>

_Happy coding!_

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:5e099003-602b-436f-af23-5c4dda0a44f1" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/refactoring" rel="tag">refactoring</a>
</div>

 [1]: /wp-content/uploads/image18.png
 [2]: /wp-content/uploads/SNAGHTML10f0d4a5.png