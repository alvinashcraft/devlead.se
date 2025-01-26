---
title: 'The Dew Review – Intel Next Generation Ultrabook™ with Windows 8: A Final Look'
author: Alvin A.
type: post
date: 2012-11-21T12:14:00+00:00
url: /2012/11/21/the-dew-review-intel-next-generation-ultrabook-with-windows-8-a-final-look/
categories:
  - Development
  - hardware
  - reviews
tags:
  - code project
  - intel
  - ultrabook
  - winforms
  - winjs
  - winrt
  - wpf

---
You can read my first two reviews of the Next Gen Ultrabook from Intel here:

  1. [The Dew Review – Intel Next Generation Ultrabook™ with Windows 8: Initial Impressions][1] 
  2. [The Dew Review – Intel Next Generation Ultrabook™ with Windows 8: Playing with Sensors][2] 

### Intro

This is my third and final review of the Intel Ultrabook. I am happy to say it is not the end of my use of the machine. It has become my primary device for development and all other regular use outside of work. My wife and kids also love using it.

### Family Time

I have three daughters. The six-year-old, Luci, likes to practice words and numbers on Mr. Anker Tests. It’s got a variety of Flash-based activities for pre-K and grade school kids. Luci really likes that she can use either the touchpad or the screen to interact with the site. Whenever she sees Windows apps on a non-touch-enabled device, she tends to reach for the screen first. This was not something that happened after using an iPod Touch, iPad or Kindle Fire. I think it’s seeing the same Windows UI that triggers it.

### More Windows 8 Development

I have continued to look at the sensor APIs available in WinRT since my last review. I have created a couple other simple proof-of-concept type apps that just reference all the sensors and display and log the output. One of them is similar to my first C#/XAML SensorFun app, but I wrote it in HTML/JavaScript to see how things are different in that type of app. I found that outside of syntax, it’s pretty much the same. That app is called SensorFunJS, and here is a snippet of the JavaScript code.

<pre class="csharpcode">(<span class="kwrd">function</span> () {
    <span class="str">"use strict"</span>;

    WinJS.Binding.optimizeBindingReferences = <span class="kwrd">true</span>;

    <span class="kwrd">var</span> orientationSensor;
    <span class="kwrd">var</span> app = WinJS.Application;

    <span class="kwrd">function</span> id(elementId) {
        <span class="kwrd">return</span> document.getElementById(elementId);
    }

    <span class="kwrd">function</span> onOrientationChanged(e) {
        <span class="kwrd">switch</span> (e.orientation) {
            <span class="kwrd">case</span> Windows.Devices.Sensors.SimpleOrientation.notRotated:
                id(<span class="str">'orientationElement'</span>).innerHTML = <span class="str">"Not Rotated"</span>;
                <span class="kwrd">break</span>;
            <span class="kwrd">case</span> Windows.Devices.Sensors.SimpleOrientation.rotated90DegreesCounterclockwise:
                id(<span class="str">'orientationElement'</span>).innerHTML = <span class="str">"Rotated 90 degrees"</span>;
                <span class="kwrd">break</span>;
            <span class="kwrd">case</span> Windows.Devices.Sensors.SimpleOrientation.rotated180DegreesCounterclockwise:
                id(<span class="str">'orientationElement'</span>).innerHTML = <span class="str">"Rotated 180 degrees"</span>;
                <span class="kwrd">break</span>;
            <span class="kwrd">case</span> Windows.Devices.Sensors.SimpleOrientation.rotated270DegreesCounterclockwise:
                id(<span class="str">'orientationElement'</span>).innerHTML = <span class="str">"Rotated 270 degrees"</span>;
                <span class="kwrd">break</span>;
            <span class="kwrd">case</span> Windows.Devices.Sensors.SimpleOrientation.faceup:
                id(<span class="str">'orientationElement'</span>).innerHTML = <span class="str">"Face Up"</span>;
                <span class="kwrd">break</span>;
            <span class="kwrd">case</span> Windows.Devices.Sensors.SimpleOrientation.facedown:
                id(<span class="str">'orientationElement'</span>).innerHTML = <span class="str">"Face Down"</span>;
                <span class="kwrd">break</span>;
            <span class="kwrd">default</span>:
                id(<span class="str">'orientationElement'</span>).innerHTML = <span class="str">"Unknown orientation: "</span> + e.orientation;
                <span class="kwrd">break</span>;
        }
    }

    app.onactivated = <span class="kwrd">function</span> (activationArgs) {
        <span class="kwrd">if</span> (activationArgs.detail.kind === Windows.ApplicationModel.Activation.ActivationKind.launch) {
            
            orientationSensor = Windows.Devices.Sensors.SimpleOrientationSensor.getDefault();
            orientationSensor.addEventListener(<span class="str">"orientationchanged"</span>, onOrientationChanged);
            
            WinJS.UI.processAll();
        }
    };
    
    app.start();
})();</pre>

Next, I found [an article on Code Project][3] with a Windows 8 WinForm app referencing the WinRT libraries and using the Sensor API. This same C# code could be used behind a WPF desktop application on WIndows 8. I plan on taking the ideas in this project to create my own library that can be shared across Windows 8 desktop applications. Here’s a sample of the code from Yvan’s article.

<pre class="csharpcode"><span class="kwrd">private</span> <span class="kwrd">void</span> SensorListener()
{
    <span class="rem">// Monitor accelerometer events.</span>
    <span class="kwrd">if</span> (_accelerometer != <span class="kwrd">null</span>)
    {
        _accelerometer.ReportInterval = 0; <span class="rem">// default</span>
        _accelerometer.ReadingChanged += AccelerometerOnReadingChanged;
        _accelerometer.Shaken += (s, a) =&gt; _shaken++;
        Log(<span class="str">"Shake activity will be monitored."</span>);
    }

    <span class="rem">// Monitor compass events.</span>
     <span class="kwrd">if</span>(_compass != <span class="kwrd">null</span>)
    {
        _compass.ReportInterval = 0; <span class="rem">// default</span>
        _compass.ReadingChanged += CompassOnReadingChanged;
    }

    <span class="rem">// Monitor gyro events.</span>
    <span class="kwrd">if</span>(_gyrometer != <span class="kwrd">null</span>)
    {
        _gyrometer.ReportInterval = 0; <span class="rem">// default</span>
        _gyrometer.ReadingChanged += GyrometerOnReadingChanged;
    }

    <span class="rem">// Monitor light sensor events.</span>
    <span class="kwrd">if</span> (_light != <span class="kwrd">null</span>)
    {
        _light.ReportInterval = 0; <span class="rem">// default</span>
        _light.ReadingChanged += LightOnReadingChanged;
    }

    <span class="rem">// Monitor position sensor events.</span>
    <span class="kwrd">if</span> (_geolocator != <span class="kwrd">null</span>)
    {
        _geolocator.ReportInterval = 1000;
        _geolocator.MovementThreshold = 1;
        _geolocator.DesiredAccuracy = PositionAccuracy.High;
        _geolocator.StatusChanged += GeolocatorOnStatusChanged;
        _geolocator.PositionChanged += GeolocatorOnPositionChanged;
    }

     <span class="rem">// Monitor NFC proximity events.</span>
     <span class="kwrd">if</span> (_proximity != <span class="kwrd">null</span>)
    {
        _proximity.DeviceArrived += ProximityDeviceArrived;
        _proximity.DeviceDeparted += ProximityDeviceDeparted;
    }
            
    <span class="rem">// The sensor loop.</span>
    <span class="kwrd">while</span> (<span class="kwrd">true</span>)
    {
        <span class="kwrd">if</span> (_stopping)
            <span class="kwrd">return</span>;
        Thread.Sleep(0); <span class="rem">// Defer to other threads that need cycles.</span>
    }
}</pre>

As you can see, the code is no different than that of a WinRT app.

Intel has a really good article titled “<a href="http://software.intel.com/en-us/articles/using-winrt-apis-from-desktop-applications" target="_blank">Using Windows 8 WinRT API from desktop applications</a>.” I highly recommend checking that out if you are developing desktop applications for Windows 8. There are a lot of great (and simple to use) APIs in WinRT. Having the ability to leverage them in our desktop apps is really exciting.

### Sensors in the Real World

As far as the usefulness of sensors in real world applications, I think the biggest opportunity lies in game development. There could also be some simulator and health care related applications for some of these apps as well.

I am in the early stages of creating an app called Steady Hands Challenge. You can read <a href="http://www.codeproject.com/Articles/478507/Steady-Hands-Challenge" target="_blank">my overview of the app on Code Project</a>. Basically, you hold the Ultrabook on the palms of your hands, and the app will use charts on the screen to instruct the user which way to tilt the Ultrabook. The closer you keep the actual X/Y/Z lines to the target lines, the higher your score. Any shaking detected by the accelerometer will result in a penalty. Although I originally envisioned this WPF app as a sort of game, I could see how something similar could be used to gamify physical therapy. As long as your not worried about patients dropping your Ultrabook.&#160;<img decoding="async" class="wlEmoticon wlEmoticon-smile" style="border-top-style: none; border-left-style: none; border-bottom-style: none; border-right-style: none" alt="Smile" src="/wp-content/uploads/wlEmoticon-smile5.png" /> 

### A Final Wrap Up

As I have repeatedly stated, I really have enjoyed developing on this machine. I truly believe that Ultrabooks with Windows 8 are the perfect developer machine today. They provide the power and speed needed to run multiple instances of Visual Studio or any other IDE. The touch screen and sensors also eliminate the need to have a separate tablet for testing your apps. I can write apps that use complex gestures and test with a simple F5. This saves time, money and headaches.

My name is Alvin Ashcraft, and I approve this Ultrabook.

&#160;

_**Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the_ [_Federal Trade Commission’s 16 CFR, Part 255: “Guides Concerning the Use of Endorsements and Testimonials in Advertising.”_][4]

&#160;

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:08f9fca9-8454-415b-bc44-ff7b292ad9d9" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  del.icio.us Tags: <a href="http://del.icio.us/popular/ultrabook" rel="tag">ultrabook</a>,<a href="http://del.icio.us/popular/intel" rel="tag">intel</a>,<a href="http://del.icio.us/popular/code+project" rel="tag">code project</a>,<a href="http://del.icio.us/popular/wpf" rel="tag">wpf</a>,<a href="http://del.icio.us/popular/winforms" rel="tag">winforms</a>,<a href="http://del.icio.us/popular/winrt" rel="tag">winrt</a>,<a href="http://del.icio.us/popular/winjs" rel="tag">winjs</a>
</div>

 [1]: https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/09/04/the-dew-review-intel-next-generation-ultrabook-with-windows-8-initial-impressions/
 [2]: https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/09/25/the-dew-review-intel-next-generation-ultrabook-with-windows-8-playing-with-sensors/
 [3]: http://www.codeproject.com/Articles/490125/Reading-Ultrabook-Sensor-Data-with-the-Windows-8-S
 [4]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html