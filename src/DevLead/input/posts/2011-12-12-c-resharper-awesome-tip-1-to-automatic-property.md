---
title: 'C# + ReSharper = Awesome: Tip #1 – To Automatic Property'
author: Alvin A.
type: post
date: 2011-12-13T02:12:25+00:00
url: /2011/12/12/c-resharper-awesome-tip-1-to-automatic-property/
categories:
  - Development
  - how-to
tags:
  - refactoring
  - resharper

---
This is the first in a series of quick how-to posts on ReSharper. I love ReSharper. It is a tool that I use every day and don’t really realize how much I rely on it until I use a machine without ReSharper installed.

### Tip #1 – To Automatic Property

**Use:** If a public property does not contain any logic, it can be converted to an auto-property, removing the corresponding private field and replacing usages of the private field.

##### Before

<div class="csharpcode">
  <pre>        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void CheckName()
        {
            if (_name == "Dark Side of the Moon")
                Console.WriteLine("Awesome");
        }</pre>
</div>

Place your cursor on the Name property and…

##### Press <Alt-Enter>

[<img loading="lazy" decoding="async" style="background-image: none; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="image" alt="image" src="/wp-content/uploads/image11.png" width="244" height="126" border="0" />][1]

##### After

<div class="csharpcode">
  <pre>        public string Name { get; set; }

        public void CheckName()
        {
            if (Name == "Dark Side of the Moon")
                Console.WriteLine("Awesome");
        }
</pre>
</div>

_Happy coding!_

&nbsp;

<div class="wlWriterEditableSmartContent" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:8f32f3c4-3000-46bb-85fa-28a241285a2b" style="margin: 0px; display: inline; float: none; padding: 0px;">
  del.icio.us Tags: <a href="http://del.icio.us/popular/resharper" rel="tag">resharper</a>,<a href="http://del.icio.us/popular/refactoring" rel="tag">refactoring</a>
</div>

 [1]: /wp-content/uploads/image11.png