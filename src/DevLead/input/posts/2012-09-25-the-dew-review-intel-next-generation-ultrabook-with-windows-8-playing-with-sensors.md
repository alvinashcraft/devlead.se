---
title: 'The Dew Review – Intel Next Generation Ultrabook™ with Windows 8: Playing with Sensors'
author: Alvin A.
type: post
date: 2012-09-25T23:31:54+00:00
url: /2012/09/25/the-dew-review-intel-next-generation-ultrabook-with-windows-8-playing-with-sensors/
categories:
  - Development
  - hardware
  - reviews
tags:
  - intel
  - ultrabook
  - visual studio
  - windows 8
  - winrt
  - xaml

---
My ‘Initial Impressions’ review of the Next Generation Intel Ultrabook is available here:

> [The Dew Review – Intel Next Generation Ultrabook™ with Windows 8: Initial Impressions][1]

Now that I have had a couple of weeks to install some Windows Store apps, various development tools, and generally put the Ultrabook through its paces, I want to provide an update.

### General Use

As I said in the last review, this is preview hardware from Intel. This model will never hit retails shelves and was built so developers like myself could take advantage of the sensor and touch technology that will soon be available in most tablets and Ultrabooks.

That said, this is still a machine I could use for my every day development. It’s faster than the other development PCs I use, and has been very stable. That is a testament to both Intel’s hardware and Windows 8. I won’t turn this into a Windows 8 review, but I disagree with anyone who wants to call it Microsoft’s next Vista.

I have not found any games that make good use of all the sensors in this Ultrabook. I am hoping there will be some released before writing my final review. The GPS works great with Maps app included in Windows 8. I’m sure it won’t be long before Garmin, Google and Nokia all have their own map apps in the Windows Store.

### Development

As I said, developing on Intel’s Ultrabook is a dream. As I do with most notebooks, I connected my external mouse and keyboard to enhance the experience. I am not a big fan of using mobile keyboards and touchpads for extended development sessions. Windows 8 works great with the Microsoft Touch Mouse I bought last year.

So far I have used Visual Studio 2010, Visual Studio 2012, Microsoft WebMatrix, Expression Blend and JetBrains WebStorm on the Ultrabook. They all run smoothly with no hangs or stutters. I have been using ReSharper in VS2010 and Telerik JustCode in VS2012 because I know that a plugin-free Visual Studio instance does not provide a real-world test of performance.

### Sensor Fun

I created a Windows Store app with C# and XAML to explore the sensor API available to WinRT developers in Visual Studio 2012. It is a simple app called Sensor Fun. 

[<img loading="lazy" decoding="async" title="Sensor Fun" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="Sensor Fun" src="/wp-content/uploads/SensorFun_thumb.png" width="420" height="236" />][2]

The Windows contains eight TextBoxes. One for each sensor’s events that I capture.

  * Accelerometer 
  * Accelerometer Shaken 
  * Compass 
  * Gyrometer 
  * Inclinometer 
  * Light Sensor 
  * Orientation 
  * Simple Orientation 

When a sensor event fires, the data captured is appended to the text in the corresponding TextBox. It also writes all the results out to a log file in Isolated Storage. Here is a code sample from one of the event handlers.

<pre class="csharpcode"><span class="kwrd">private</span> <span class="kwrd">void</span> accelerometer_ReadingChanged(Accelerometer sender,
                                          AccelerometerReadingChangedEventArgs args)
{
    coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =&gt;
    {
        <span class="kwrd">string</span> text = String.Format(<span class="str">"{0} / {1} / {2} - {3}rn"</span>, 
                                    args.Reading.AccelerationX, 
                                    args.Reading.AccelerationY, 
                                    args.Reading.AccelerationZ, 
                                    args.Reading.Timestamp);
        Utilities.Logger.LogData(text);
        AccelerometerText += text;
    });
}</pre>

Each sensor has a ReadingChanged event that returns the current data in a Reading object. You can find the details of each sensor’s Reading data <a href="http://msdn.microsoft.com/en-us/library/windows/apps/br206408.aspx" target="_blank">on MSDN</a>.

I found the API very intuitive and it works great with all of the advanced sensors on this Ultrabook. Now I just need that million-download idea to build my next app.&#160;<img decoding="async" class="wlEmoticon wlEmoticon-smile" style="border-top-style: none; border-left-style: none; border-bottom-style: none; border-right-style: none" alt="Smile" src="/wp-content/uploads/wlEmoticon-smile4.png" /> 

If you want to download the source code for Sensor Fun, you can get it <a href="https://www.box.com/s/f5bohv1etkshw1ziwnjx" target="_blank">here</a>.

### The Next Review

In a couple of months, I will return with my final thoughts and recommendations. During that time, I hope to try out a few more apps and games that make use of the sensor capabilities of the Ultrabook. I will also continue to investigate the options they provide developers, perhaps through sensor API available to C++ developers.

If you have any ideas or thoughts about what you would like to see in my final review, please leave a comment.

Thanks!

&#160;

> _**Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the_ [_Federal Trade Commission’s 16 CFR, Part 255: “Guides Concerning the Use of Endorsements and Testimonials in Advertising.”_][3]

&#160;

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:59ec9cc7-2ecd-4975-943b-93fa394dccf5" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  del.icio.us Tags: <a href="http://del.icio.us/popular/intel" rel="tag">intel</a>,<a href="http://del.icio.us/popular/ultrabook" rel="tag">ultrabook</a>,<a href="http://del.icio.us/popular/windows+8" rel="tag">windows 8</a>,<a href="http://del.icio.us/popular/winrt" rel="tag">winrt</a>,<a href="http://del.icio.us/popular/xaml" rel="tag">xaml</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>
</div>

 [1]: https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/09/04/the-dew-review-intel-next-generation-ultrabook-with-windows-8-initial-impressions/
 [2]: /wp-content/uploads/SensorFun.png
 [3]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html