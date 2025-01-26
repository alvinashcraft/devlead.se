---
title: Take Your Xamarin Skills to the Next Level with Ed Snider’s ‘Mastering Xamarin.Forms’
author: Alvin A.
type: post
date: 2020-01-19T16:58:49+00:00
url: /2020/01/19/take-your-xamarin-skills-to-the-next-level-with-ed-sniders-mastering-xamarin-forms/
categories:
  - books
  - reviews
tags:
  - .net
  - azure functions
  - packt publishing
  - vs app center
  - xamarin
  - xamarin.forms

---
There aren’t a lot of great [Xamarin][1] books available, but you can add this one to the shortlist. [Packt][2] Publishing&#8217;s <span style="text-decoration: underline;"><a href="https://www.amazon.com/Mastering-Xamarin-Forms-architecture-techniques-multi-platform/dp/1839213388/?tag=amavin-20">Mastering Xamarin.Forms</a></span> (3rd Edition) by Ed Snider is a fantastic reference for mobile developers. If you’re a .NET developer with at least some exposure to Xamarin development, this book will give you the knowledge you need to build great mobile apps with Xamarin.Forms with Visual Studio on your Mac or Windows environment.

<div class="wp-block-image">
  <figure class="alignleft size-large is-resized"><img loading="lazy" decoding="async" src="https://m.media-amazon.com/images/I/71VhxdrrcOL._AC_UL640_FMwebp_QL65_.jpg" alt="" width="200" height="240" /></figure>
</div>

Snider takes my favorite approach when writing the book. He builds an end-to-end sample app throughout the book, building onto it with the patterns and practices learned in each chapter. For me, getting hands-on and building a real-world app while reading a book or watching a video training course reinforces the lessons. The app in this book is a TripLog, which can be used as a travel log or diary.

After creating the project and a couple of initial screens, Snider dives right into some patterns for mobile app development, starting with the MVVM (model-view-view model) pattern. With each pattern or practice, he explains the concept, how to implement it in Xamarin.Forms and .NET, and then explains how our apps benefit from the implementation. For MVVM, he goes into data binding and validation, which become trivial with the pattern.

The next several chapters detail best practices for navigation, leveraging dependency injection to create platform-specific implementations across iOS, Android or UWP on Windows, and some UI tips for handling platform differences through custom renderers. Snider pulls some Azure concepts into the book with Azure Functions. Learn to make API calls from an app service into Azure Functions and then add authentication to Azure Functions and a login screen to the app. I’ve never used any data caching frameworks in my mobile apps, so the section on [Akavache][3] for caching was really helpful. It was pretty trivial to add some offline caching to the Xamarin app.

The unit testing section is really thorough. I have seen many .NET books that just glance over the topic of unit testing and best practices for testing, but Snider really gives a solid base for readers here. Finally, in the final chapter, monitoring is covered. He mainly explains how to set up [Visual Studio App Center][4] to track some usage and the health of the app while it’s running out in the world. When optimally configured, this data can give the information developers need to keep their user base happy and engaged. Kudos to Ed Snider for a really well-written book for Xamarin.Forms developers. I strongly encourage you to check it out if you’re getting serious about building mobile apps.

**Full disclosure:** I received a free review copy of this eBook from Packt Publishing. The opinions in this review are completely honest totally my own.

 [1]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/
 [2]: https://www.packtpub.com/mobile/mastering-xamarin-forms-third-edition
 [3]: https://github.com/reactiveui/Akavache
 [4]: https://visualstudio.microsoft.com/app-center/