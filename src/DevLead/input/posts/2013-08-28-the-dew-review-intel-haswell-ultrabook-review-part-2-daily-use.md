---
title: 'The Dew Review – Intel Haswell Ultrabook Review – Part 2: Daily Use'
author: Alvin A.
type: post
date: 2013-08-28T17:59:09+00:00
url: /2013/08/28/the-dew-review-intel-haswell-ultrabook-review-part-2-daily-use/
categories:
  - Development
  - hardware
  - reviews
tags:
  - haswell
  - intel
  - ultrabook
  - visual studio

---
<div data-type="ad" data-publisher="lqm.alvinashcraft.site" data-zone="ron" data-format="1x1">
</div>

This is part 2 of a three part series of reviews. You can read part 1 of my review <a href="https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2013/07/28/the-dew-review-intel-haswell-ultrabook-review-part-1-initial-impressions/" target="_blank">here</a>.

### Introduction

With the background and first impressions out of the way, let’s talk about what really matters. How does this machine hold up during daily life of a .NET developer? I have run into some good scenarios over the past few weeks:

  * Traveling to another office, which leads to: 
      * Connecting to unfamiliar Wi-Fi hot spots in airports, hotels, restaurants and on the plane. 
      * Stuck in all-day meetings in a conference room far from the cubicle where I left my power cable. 
      * Accessing corporate resources from a machine that does not belong to the domain. 
      * Testing out my new on-ear <a href="http://www.amazon.com/gp/product/B008OUL1OC/alvinashcraft-20" target="_blank">Bluetooth headphones</a>. 
  * Speaking at a local user group meeting. The potential horrors: 
      * Availability of power source. 
      * Availability of Wi-Fi 
      * Connecting to the projector 
      * Getting through my talk on a keyboard & touchpad I have been using for two days. 

### Traveling

First, I was pretty happy to discover that this Haswell Ultrabook is nearly the name form factor as the Ivy Bridge Ultrabook I <a href="https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/09/04/the-dew-review-intel-next-generation-ultrabook-with-windows-8-initial-impressions/" target="_blank">reviewed</a> <a href="https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/09/25/the-dew-review-intel-next-generation-ultrabook-with-windows-8-playing-with-sensors/" target="_blank">last</a> <a href="https://morningdew-bpc6g3a0fgaxdxcu.eastus2-01.azurewebsites.net/2012/11/21/the-dew-review-intel-next-generation-ultrabook-with-windows-8-a-final-look/" target="_blank">year</a>. Thus, I was able to use the <a href="http://www.amazon.com/iPearl-13-inch-Neoprene-UltraBook-external/dp/B0085B772A/alvinashcraft-20" target="_blank">neoprene sleeve</a> I purchased last fall for this trip. I love how small the power brick is for this Ultrabook. It doesn’t create a huge bulge in the sleeve’s pocket like most other bricks would.

I had no issues connecting to Wi-Fi anywhere during my trip. I always had a good signal, even in my hotel room which I find to be a rare occurrence. If you have the need to be connected and cannot count on Wi-Fi always being available, there is a SIM card slot in the Haswell Ultrabook, which I believe would be functional if I had one to try. It shows up in the network sidebar in Windows 8.

[<img loading="lazy" decoding="async" title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="/wp-content/uploads/image_thumb16.png" width="203" height="244" />][1]

Battery life has been fantastic. I have not done any exact, timed tests of the battery, but in an all-day meeting using OneNote, Outlook, Google Chrome and Visual Studio 2012, I did not have to go seek out the power supply that I left on my desk. I did put it to sleep over lunch and for a quick afternoon cake break.

As far as getting access to company resources while on the road, that’s not a problem because it’s Windows. I have VPN, Lync, Outlook and access to SharePoint through the awesome <a href="http://apps.microsoft.com/windows/en-us/app/ba300264-a01f-460e-9376-ef149dc1093b" target="_blank">GimmalPoint</a> Windows 8 SharePoint client app.

The Bluetooth 4.0 on-ear headphones I use connected to my Ultrabook without any problems. I listened to my music collection on the plane while reviewing some technical design documents for the first day’s meeting.

### Presenting

As I mentioned in my first review, two days after the Ultrabook arrived, I presented a session on <a href="https://github.com/apimash/StarterKits" target="_blank">APIMASH Starter Kits</a> at the <a href="http://firststatedot.net/" target="_blank">First State .NET</a> User Group in Wilmington, DE. The Wi-Fi there was very slow, but I was prepared for that and had planned to do all of my essential demos locally. Had the connection been better, I was planning to demonstrate coding in the cloud with an <a href="http://www.windowsazure.com/en-us/services/virtual-machines/" target="_blank">Azure Virtual Machine</a> set up with Windows Server 2012 and Visual Studio 2012. I have been running this on a medium VM instance recently. It performs great and doesn’t come close to using my monthly MSDN allotment as long as I remember to shut down the VM instance every time I finish using it.

Connecting to the project went smoothly. The Ultrabook has a microHDMI port but adapters for VGA and HDMI were included, along with a USB Ethernet adapter. The VGA adapter did the trick and I was up and presenting.

I am still getting used to the clickable multi-touchpad. It’s very hard to break my habit of resting my left index finger on the bottom of the pad when I am doing a lot of mouse intensive work. I normally rest it on the button down there to click as needed. I am getting better and don’t blame the hardware for this one. It’s all me… getting old and set in my ways, I suppose.&#160;<img decoding="async" class="wlEmoticon wlEmoticon-smile" style="border-top-style: none; border-left-style: none; border-bottom-style: none; border-right-style: none" alt="Smile" src="/wp-content/uploads/wlEmoticon-smile7.png" /> 

### Developing

Ninety percent of the development work I have been doing on the Haswell Ultabook to this point has been either personal Windows Phone and Windows 8 Xaml app development or some sample applications I have been creating while evaluating controls that I have been asked to review. In both of these situations, the Ultrabook has done the job.

I have run three instances of Visual Studio 2012 at some times, along with an instance of Expression Blend without noticing any performance issues or slow-down. With only 4gb of RAM, I wouldn’t recommend running any local virtual machines. I will continue to leverage Windows Azure to host and run my VMs.

I have to say, the 1920&#215;1080 resolution is a joy in which to code. The screen is crisp and looks great. I have used it for coding in Visual Studio and <a href="http://www.jetbrains.com/webstorm/" target="_blank">WebStorm</a> for over 10 hours straight on a couple of occasions.

### The Last Word

That’s it for the review, part 2. I am enjoying my Haswell experience immensely. Stay turned for part three next month when I get into some coding examples with the built-in sensors. I also did this with the Ivy Bridge Ultrabook last year. We will see if anything has been added or improved for the Ultrabook developer in the last year.

&#160;

<div id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:66ceaaef-cdce-4147-a8f8-c07907dfa9e9" class="wlWriterEditableSmartContent" style="float: none; padding-bottom: 0px; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px">
  del.icio.us Tags: <a href="http://del.icio.us/popular/intel" rel="tag">intel</a>,<a href="http://del.icio.us/popular/haswell" rel="tag">haswell</a>,<a href="http://del.icio.us/popular/visual+studio" rel="tag">visual studio</a>,<a href="http://del.icio.us/popular/ultrabook" rel="tag">ultrabook</a>,<a href="http://del.icio.us/popular/open+source" rel="tag">open source</a>
</div>

**Disclosure of Material Connection:** I received one or more of the products or services mentioned above for free in the hope that I would mention it on my blog. Regardless, I only recommend products or services I use personally and believe my readers will enjoy. I am disclosing this in accordance with the [Federal Trade Commission’s 16 CFR, Part 255: “Guides Concerning the Use of Endorsements and Testimonials in Advertising.][2]

 [1]: /wp-content/uploads/image30.png
 [2]: http://www.access.gpo.gov/nara/cfr/waisidx_03/16cfr255_03.html