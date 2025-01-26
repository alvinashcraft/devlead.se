---
title: Broken RSS Feed Fixed
author: Alvin A.
type: post
date: 2008-07-31T18:07:16+00:00
url: /2008/07/31/broken-rss-feed-fixed/
views:
  - 20
aktt_tweeted:
  - 1
categories:
  - announcements
tags:
  - announcements

---
After doing some debugging and research, I&#8217;ve been able to fix the problem with my RSS feeds. It turns out that it hasn&#8217;t been working since I installed WordPress 2.6 several weeks ago. I removed extra line breaks from the end of several PHP files, and voila&#8230; it&#8217;s back! I&#8217;m not exactly sure which was the offending file, but it&#8217;s safe to say that none of your PHP files should have any line breaks after the final $> closing tag.

Thanks to <a title="Keyvan Nayyeri" href="http://nayyeri.net/blog/my-favorite-.net-link-blogs/" target="_blank">Keyvan</a> for getting the word out about my blog today. Some new visitors alerted me to the problem.