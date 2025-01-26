---
title: The RavenDB Indexing Process
author: Alvin A.
type: post
date: 2013-06-27T12:16:19+00:00
url: /2013/06/27/the-ravendb-indexing-process/
categories:
  - books
  - Development
tags:
  - books
  - manning publications
  - raven db

---
**By Itamar Syn-Hershko, author of _RavenDB in Action_**

_[<img loading="lazy" decoding="async" title="ravendb" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; margin: 0px 0px 6px 12px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="ravendb" align="right" src="/wp-content/uploads/ravendb.png" width="136" height="169" />][1]Indexes play a crucial part in answering queries. Without them, it is impossible to find data on anything other than the document ID, and, therefore, RavenDB becomes just a bloated key/value store. Indexes are the piece of the puzzle that allows rich queries for data to be satisfied efficiently. In this article, based on chapter 3 of [RavenDB in Action][1], author Itamar Syn-Hershko explains how indexing works in RavenDB._ 

> **<font color="#ffffff">Get </font>**[**<font color="#ffffff">RavenDB in Action</font>**][1]** <font color="#ffffff">for 50% through June 30, 2013 by using promo code RAVDBAA at checkout.</font>**

As a document database, RavenDB has a dedicated storage for documents—where documents are stored and pulled from when accessed. This is the heart of RavenDB, and what we call the _Document Store_. When we stored and updated documents in the previous chapter, we were working directly against the Document Store.

The Document Store has one important feature – it is very efficient in pulling documents out by their ID. However, this is also its only feature, and the only way it can find documents. It can only have one key for a document, and that key is always the document ID; documents cannot be retrieved based on any other criteria.

When you need to pull documents out of the Document Store based on some search criteria other than their ID, the Document Store itself becomes useless. To be able to retrieve documents using some other properties they have, you need to have indexes. Those indexes are being stored separately from the documents themselves—in what we call the _Index Store_.

In this article, we will discuss indexes and the indexing process in RavenDB. It is important to understand what is it and why it is needed before making actual use of it.

### The indexing process

Let’s assume for one moment all we have in our database is the Document Store, in it a couple million documents, and now we got a user query we need to answer. The document store by itself can’t really help us, as the query doesn’t have the document IDs in it. What do we do now?

One option is to go through all the documents in the system and check them one by one to see if they match the query. This is going to work, sure, if the user who issued the query is kind enough to wait for a few hours in a large system. But no user is. In order to efficiently satisfy user queries, we need to have our data indexed. By using indexes, the software can perform searches much more efficiently and complete queries much faster.

Let’s consider for a moment when are they going to be built or updated with the new documents that came in. If we calculate them when the user issues the query, we again delay returning the results. This is going to be much less substantial than going over all the documents, but that still is a performance hit we incur to the user for every query he makes.

Another, perhaps more sensible, option is to update the indexes when the user puts the new documents. This indeed makes more sense at first, but then when you start to consider what it would take to update several complex indexes on every put, it becomes much less attractive. In real systems, this means writes would take quite a lot of time, as now not only the document is being written, but all indexes have to be updated as well. There is also the question of transactions—what happens when a failure occurs while the indexes are being updated, should it fail a transaction?

With RavenDB, a conscious design decision was made to not cause any wait due to indexing. There should be no wait at all, never when you ask for data, and also never during other operations—like adding new documents to the store.

So when _are_ indexes updated?

### Updating indexes

RavenDB has a background process that is handed new documents and document updates as they come in, right after they were stored in the Document Store, and it passes them in batches through all the indexes in the system. For write operations, the user gets an immediate confirmation on their transaction—even before the indexing process started processing these updates—without waiting for indexing, but being 100 percent certain the changes were recorded in the database. Queries do not wait for indexing either—they just use the indexes that exist at the time the query was issued. This ensures both smooth operation on all fronts, and that no documents are left behind.

This is shown in figure 1.

[<img loading="lazy" decoding="async" title="indexstore" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="indexstore" src="/wp-content/uploads/indexstore_thumb.png" width="404" height="280" />][2]

<sup>Figure 1 RavenDB’s background indexing process does not affect response time for neither updates nor queries.</sup>

It all sounds suspiciously good, doesn’t it? Obviously, there is a catch. Since indexing is done in the background, when enough data comes in that process can take a while to complete. This means it may take a while for new documents until they appear in query results. While RavenDB is highly optimized to minimize such cases, it can still happen, and when this happens we say the index results are stale. This is by design, and we discuss the implications of that in the end of this section.

### What is an index?

Consider the following list of books:

[<img loading="lazy" decoding="async" title="booklist0" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: none; padding-top: 0px; padding-left: 0px; margin-left: auto; border-left: 0px; display: block; padding-right: 0px; margin-right: auto" border="0" alt="booklist0" src="/wp-content/uploads/booklist0_thumb.png" width="304" height="359" />][3]

If I asked you what was the price of the book written by J.K. Rowling, or to name all the books with more than 600 pages in them—how would you find the answer to that? Obviously going through the entire list is not too cumbersome when there are only 10 books in it, but it becomes a problem rather quickly as the list grows.

An index is just a way to help us answer such questions more quickly. It is all about making a list of all possible values grouped by their context, and ordering it alphabetically. As a result, the list of books from above becomes the following lists of values, each value accompanied by the book number it was taken from:

[<img loading="lazy" decoding="async" title="booklist" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: none; padding-top: 0px; padding-left: 0px; margin-left: auto; border-left: 0px; display: block; padding-right: 0px; margin-right: auto" border="0" alt="booklist" src="/wp-content/uploads/booklist_thumb.png" width="364" height="348" />][4]

<sup>Figure 2 A list of books (left) and lists of all possible searchable values, grouped by context</sup>

Since the values are grouped by context (a Title, an Author name, and so on), and are sorted lexicographically, it is now rather easy to find a book by any of those values even if we had millions of them. You simply go to the appropriate list (say, Author Names) and look the value up; since the lists are lexicographically sorted, this can be done rather efficiently. Once the value has been found in the list, the book number that is associated with it is returned, and can be used to get the actual book if you need more information on it.

Surprisingly, the process of creating an index like that is called indexing. RavenDB uses Lucene.NET as its indexing mechanism. Lucene.NET is the .NET port of the popular open-source search engine library Lucene. Originally written in Java and first released in 2000, Lucene is the leading open-source search engine library. It is being used by big names like Twitter, LinkedIn, and other online services to make their content searchable, and is constantly being improved to be made faster and better.

### Summary

Having a scalable key/value store database is nice, but indexes are what really make RavenDB so special. Indexes make querying possible and efficient, and the more flexible indexes are, the more querying possibilities you have.

In this article, we laid the basics for understanding indexes in RavenDB and became familiar with RavenDB’s novel approach to indexing.

<a name="Related"></a>**Here are some other Manning titles you might be interested in:**

<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/banker"><img loading="lazy" decoding="async" title="mongodb" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: left; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="mongodb" align="left" src="/wp-content/uploads/mongodb.jpg" width="64" height="79" />MongoDB in Action</a>
      </p>
      
      <p>
        Kyle Banker
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/bauer3/"><img loading="lazy" decoding="async" title="hibernate" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: left; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="hibernate" align="left" src="/wp-content/uploads/hibernate.jpg" width="64" height="79" />Java Persistence with Hibernate, Second Edition</a>
      </p>
      
      <p>
        Christian Bauer, Gavin King, and Gary Gregory
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/partner/"><img loading="lazy" decoding="async" title="neo4j" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: left; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="neo4j" align="left" src="/wp-content/uploads/neo4j.jpg" width="64" height="79" />Neo4j in Action</a>
      </p>
      
      <p>
        Jonas Partner, Aleksa Vukotic, and Nicki Watt
      </p>
    </td>
  </tr>
</table>

&#160;

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:a2511104-73b3-49be-8140-65764ad69616" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  Technorati Tags: <a href="http://technorati.com/tags/raven+db" rel="tag">raven db</a>,<a href="http://technorati.com/tags/books" rel="tag">books</a>,<a href="http://technorati.com/tags/manning" rel="tag">manning</a>
</div>

 [1]: http://www.manning.com/synhershko/
 [2]: /wp-content/uploads/indexstore.png
 [3]: /wp-content/uploads/booklist0.png
 [4]: /wp-content/uploads/booklist.png