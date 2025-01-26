---
title: The Dew Review – Taking a Look at the Latest Release of Aspose.Email
author: Alvin A.
type: post
date: 2014-06-02T12:31:04+00:00
url: /2014/06/02/the-dew-review-taking-a-look-at-the-latest-release-of-aspose-email/
categories:
  - Development
  - how-to
  - reviews
  - tools
tags:
  - aspose
  - 'c#'
  - exchange
  - mvvm light
  - outlook
  - visual studio
  - wpf

---
## Introduction

I have been spending some time working with the latest <a href="http://www.aspose.com/.net/email-component/key-features.aspx" target="_blank">Apose.Email for .NET</a>. It has been twelve or thirteen years since I have written any email related code. Back in the early 2000s, I did a little bit of work with Visual Basic and the Outlook Collaboration Data Objects (CDO). We have come a long way since that time. Email in the cloud is now becoming the norm with Gmail and Office 365.

There’s still plenty of need for local and Exchange based email processing in business applications as well. I will get to one possible scenario in my own application below.

## Latest Aspose.Email Release

The Aspose.Email library supports just about any email related activity imaginable. Here is just a handful of scenarios developers can code into their own applications with Aspose.Email:

##### Generate emails and send via SMTP







  * Embed objects in message body – Send emails with embedded images or documents.

  * Attach files – Attach files to an email as a user would from their email client. 
  * Mail merge – Powerful support for mail merge and mass emailing. 
  * iCalendar support – Read and manipulate calendar events via the iCalendar standard.
##### Receive POP3 mail

  * Work with IMAP mail sources 
  * Authentication 
  * Work with messages and folders 
  * SSL support (for POP3 and SMTP)

##### Message Files

  * EML/MSG/MHT formats – All common mail message formats are supported. 
  * Work with files or streams – Open messages from disk or network streams. 
  * Manipulate PST files – Create, read and manipulate Outlook PST files and their contents.

##### MS Exchange Server

  * WebDav and Exchange Web Services support 
  * Unified Messaging operations 
  * Send emails and Meeting Invites

##### Advanced support for recurrence

  * Easily and reliably calculate event recurrence 
  * Suppoprt for iCalendar (RFC 2445)

Detailed developer documentation for all of the Aspose.Email features is available online <a href="http://docs.aspose.com:8082/docs/display/emailnet/Home" target="_blank">here</a>.

So, whether your application needs to work with Exchange, Outlook files, POP3/SMTP, or talk to Gmail via IMAP, Aspose.Email has APIs to help with each situation. There are also sample apps for each feature exposed in Aspose.Email to get developers started off on the right track. 

## An IMAP Console Application

There are dozens of sample applications installed along with Apose.Email. To get started, launch the Aspose Examples Dashboard:

[<img loading="lazy" decoding="async" title="asposeexamples" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; margin: 0px 0px 10px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="asposeexamples" src="/wp-content/uploads/2014/06/asposeexamples_thumb.png" width="504" height="304" />][1]

The example apps are grouped by feature set. Developers can view the code in the Sample Browser, launch the solution in C# or VB, or run the example app right from the Browser application.

I decided to take a closer look at one of the IMAP samples. The one I chose was “Fetch Messages from IMAP Server and Save to Disk”, which does exacly what the name implies. It is a console application that connects to a Gmail account via IMAP, selects the Inbox folder and loops through all of the messages, saving each one to a local folder in the “.eml” format. Here is the complete code implementation for the app after a couple of ReSharper refactorings.

<pre class="brush: csharp;">public static void Main(string[] args)
{
    // The path to the documents directory.
    string dataDir = Path.GetFullPath("../../../Data/");
    Directory.CreateDirectory(dataDir);

    //Create an instance of the ImapClient class
    var client = new ImapClient
                 {
                     Host = "imap.gmail.com",
                     Username = "asposetest123@gmail.com",
                     Password = "F123456f",
                     Port = 993,
                     SecurityMode = ImapSslSecurityMode.Implicit,
                     EnableSsl = true
                 };

    try
    {
        client.Connect();
       
        //Log in to the remote server.
        client.Login();

        // Select the inbox folder
        client.SelectFolder(ImapFolderInfo.InBox);

        // Get the message info collection
        ImapMessageInfoCollection list = client.ListMessages();

        // Download each message
        for (int i = 0; i &lt; list.Count; i++)
        {
            //Save the EML file locally
            client.SaveMessage(list[i].UniqueId, dataDir + list[i].UniqueId + ".eml");
        }

        //Disconnect to the remote IMAP server
        client.Disconnect();

        System.Console.WriteLine("Disconnected from the IMAP server");
    }
    catch (System.Exception ex)
    {
        System.Console.Write(ex.ToString());
    }
}
</pre>

It is simple and intuitive to use.

## The PST Archive Utility

I didn’t have the time to write my own applications that use every aspect of the library, so I decided to take one set of features and focus there. For years, I have been meaning to organize my work-related PST files into yearly archives. In fact, I have one PST that covers nearly seven years of email. It is nearly 6gb in size and contains who knows how many thousands of items.

I built a small utility that will read a selected PST file, iterate through all of its folders and move all items for the specified year into a new PST with the year prepended to the PST’s file name, mirroring the folder structure of the original PST. I decided to build the utility as a WPF application, but this could function nicely as a command line utility also.

[<img loading="lazy" decoding="async" title="pst1" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; margin: 0px 0px 10px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="pst1" src="/wp-content/uploads/2014/06/pst1_thumb.png" width="404" height="271" />][2]

Using the utility is rather straightforward, simply:

  1. Enter the full path to the PST to be read. 
  2. Click ‘Open PST’. 
  3. The available years will display. Select a year. 
  4. Click ‘Process PST’. 
  5. When complete, the status message will update to “New PST Created for Year xxxx”.

The code to display the available years iterates through the folders and items, collecting the unique years into a List<int>. It then sorts them before setting the property in the ViewModel to which the Available Years ListBox is bound.

<pre class="brush: csharp;">/// &lt;summary&gt;
/// Gets all the years of items in a PST file.
/// &lt;/summary&gt;
private void GetPstYears()
{
    if (String.IsNullOrWhiteSpace(PstPath) || !File.Exists(PstPath)) return;

    using (PersonalStorage mainPst = PersonalStorage.FromFile(PstPath, true))
    {
        CurrentStatus = "Processing Years...";

        List&lt;int&gt; years = GetAvailableYears(mainPst.RootFolder);
        years.Sort();
        Years.Clear();

        foreach (int year in years)
        {
            Years.Add(year);
        }

        CurrentStatus = "PST Ready";
    }
}

/// &lt;summary&gt;
/// Gets the available years in a specified Outlook folder.
/// &lt;/summary&gt;
/// &lt;param name="folder"&gt;The folder.&lt;/param&gt;
/// &lt;returns&gt;A list of years.&lt;/returns&gt;
private List&lt;int&gt; GetAvailableYears(FolderInfo folder)
{
    var years = new List&lt;int&gt;();

    foreach (MapiMessage message in
                folder.EnumerateMapiMessages().Where(message =&gt; !years.Contains(message.DeliveryTime.Year)))
    {
        years.Add(message.DeliveryTime.Year);
    }

    foreach (int subYear in from folderInfo in folder.EnumerateFolders()
        where folderInfo.HasSubFolders
        select GetAvailableYears(folderInfo)
        into subYears
        from subYear in subYears
        where !years.Contains(subYear)
        select subYear)
    {
        years.Add(subYear);
    }

    return years;
}
</pre>

Similarly, the code to move the messages for the selected year to the new PST, iterates the folder structure to find any matching items. 

<pre class="brush: csharp;">/// &lt;summary&gt;
/// Process a PST by moving items from a selected year to a new PST
/// while creating the same folder structure.
/// &lt;/summary&gt;
private void ProcessPst()
{
    if (SelectedYearIndex &lt; 0 || String.IsNullOrWhiteSpace(PstPath) || !File.Exists(PstPath)) return;

    int year = Years[SelectedYearIndex];

    using (PersonalStorage mainPst = PersonalStorage.FromFile(PstPath, true))
    {
        string newFileName = PstPath.Insert(PstPath.LastIndexOf("\\", StringComparison.Ordinal) + 1, year.ToString(CultureInfo.InvariantCulture));

        using (PersonalStorage pstWithYear = PersonalStorage.Create(newFileName, FileFormatVersion.Unicode))
        {
            ProcessSubfolders(mainPst.RootFolder, pstWithYear.RootFolder, year);
        }
    }

    CurrentStatus = String.Format("New PST Created for Year {0}", Years[SelectedYearIndex]);
}

/// &lt;summary&gt;
/// Processes the subfolders of a provided PST folder and adds items
/// from the specified year to the new folder provided.
/// &lt;/summary&gt;
/// &lt;param name="folder"&gt;The source folder.&lt;/param&gt;
/// &lt;param name="newParentFolder"&gt;The new folder.&lt;/param&gt;
/// &lt;param name="year"&gt;The year of items to move.&lt;/param&gt;
private void ProcessSubfolders(FolderInfo folder, FolderInfo newParentFolder, int year)
{
    foreach (FolderInfo folderInfo in folder.EnumerateFolders())
    {
        FolderInfo newFolder = newParentFolder.GetSubFolder(folderInfo.DisplayName) ??
                               newParentFolder.AddSubFolder(folderInfo.DisplayName);

        if (folderInfo.HasSubFolders)
        {
            ProcessSubfolders(folderInfo, newFolder, year);
        }

        newFolder.AddMessages(folderInfo.EnumerateMapiMessages().Where(m =&gt; m.DeliveryTime.Year == year));

        if (newFolder.ContentCount == 0 && !newFolder.HasSubFolders && newFolder.DisplayName != "Deleted Items")
            newParentFolder.DeleteChildItem(newFolder.EntryId);
    }
}
</pre>

You can see that all of the PST manipulation is very intuitive. Everything I needed to know, I was able to quickly learn from the documentation and the sample applications. It feels as if the classes are a part of the .NET Framework. It is a very well written API.

You can download the complete source code for the project <a href="http://1drv.ms/1n9b0t8" target="_blank">here</a>.

## Summary

If you are working on any projects involving email processing or access, Aspose.Email can definitely simplify the code required to get the job done. I will definitely keep these libraries in mind for future projects and you should too.

Happy coding!

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:a165d509-2e3c-43f2-97c4-cc172a856714" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  del.icio.us Tags: <a href="http://del.icio.us/popular/.net+framework" rel="tag">.net framework</a>,<a href="http://del.icio.us/popular/aspose" rel="tag">aspose</a>,<a href="http://del.icio.us/popular/wpf" rel="tag">wpf</a>
</div>

&nbsp;

> Disclosure of Material Connection: I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the Federal Trade Commission’s 16 CFR, Part 255: “Guides Concerning the Use of Endorsements and Testimonials in Advertising.”

 [1]: /wp-content/uploads/2014/06/asposeexamples.png
 [2]: /wp-content/uploads/2014/06/pst1.png