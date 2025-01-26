---
title: Making Animations over the Canvas – Excerpt from 60 Android Hacks
author: Alvin A.
type: post
date: 2012-06-18T15:54:18+00:00
url: /2012/06/18/making-animations-over-the-canvas-excerpt-from-60-android-hacks/
categories:
  - Daily Links

---
<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" width="115">
      <p>
        <a href="http://www.manning.com/sessa/"><img loading="lazy" decoding="async" style="background-image: none; border-right-width: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px; padding-top: 0px" title="clip_image002" border="0" alt="clip_image002" src="/wp-content/uploads/clip_image002.jpg" width="110" height="134" /></a>
      </p>
    </td>
    
    <td valign="top" width="516">
      <p>
        <a href="http://www.manning.com/sessa/">60 Android Hacks</a>
      </p>
      
      <p>
        By Carlos Sessa
      </p>
      
      <p>
        <i>To draw directly on the screen, you can use Android’s Canvas class. In this hack from <a href="http://www.manning.com/sessa/">60 Android Hacks</a>, the author shows how to use this class to create a box that bounces around screen. </i>
      </p>
      
      <p>
        <u><a href="#titles">You may also be interested in…</a> </u><u></u>
      </p>
    </td>
  </tr>
</table>

If you’re animating your own widgets, you might find that the Android APIs are a bit limited. Is there an Android API to draw things directly to the screen? The answer is yes. Android offers us a class called Canvas. In this hack, we see how we can use the Canvas class to draw elements and animate them by creating a box that will bounce around screen.

First of all, let’s make sure we understand what the Canvas class is. A Canvas works for you as a pretense, or interface, to the actual surface upon which your graphics will be drawn—it holds all of your “draw” calls. Via the Canvas, your drawing is actually performed upon an underlying Bitmap, which is placed into the window.

So the Canvas class holds all the draw calls. We can create a View, override the onDraw() method, and start drawing primitives there. To make everything clearer, we’ll crate a DrawView class that will take care of drawing the box and updating its position. Since we don’t have anything else onscreen, we’ll make it the activity’s content view. Here’s the code for the Activity:

<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">class</span> MainActivity extends Activity {
    <span class="kwrd">private</span> DrawView mDrawView;

    @Override
    <span class="kwrd">public</span> <span class="kwrd">void</span> onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Display display = getWindowManager().getDefaultDisplay(); #1
        mDrawView = <span class="kwrd">new</span> DrawView(<span class="kwrd">this</span>);
        mDrawView.height = display.getHeight();
        mDrawView.width = display.getWidth();

        setContentView(mDrawView); #2
    }
}</pre>

In #1, we use the WindowManager to get the screen width and height. These values will be used inside the DrawView to limit where to draw. In we set the DrawView as the Activity’s contentView. This means that the DrawView will take all the available space.

Let’s take a look of what’s done inside the DrawView class:

<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">class</span> DrawView extends View {
    <span class="kwrd">private</span> Rectangle mRectangle;
    <span class="kwrd">public</span> <span class="kwrd">int</span> width;
    <span class="kwrd">public</span> <span class="kwrd">int</span> height;

    <span class="kwrd">public</span> DrawView(Context context) {
        super(context);

        mRectangle = <span class="kwrd">new</span> Rectangle(context, <span class="kwrd">this</span>); #1
        mRectangle.setARGB(255, 255, 0, 0);
        mRectangle.setSpeedX(3);
        mRectangle.setSpeedY(3);
    }

    @Override
    <span class="kwrd">protected</span> <span class="kwrd">void</span> onDraw(Canvas canvas) { #2
        mRectangle.move(); #3
        mRectangle.onDraw(canvas); #4
        invalidate();
    }
}</pre>

In #1, we create a Rectangle instance that will play the role of the box. The Rectangle class also knows how to draw itself to a canvas and contains all the boring logic of how to update its position to get drawn in the correct place. When the onDraw() method is called, we change the rectangle’s position (#2) and we draw it to the canvas (#3). The invalidate() call in #4 is the hack itself.

The invalidate() is a View’s method to force a view to draw. Placing it inside the onDraw() method means that onDraw() will be called as soon as the view finishes drawing itself. To put it differently, we’ll loop over the Rectangle ’s move() and onDraw() calls, creating a nice animation!

### Summary

Updating views positions in the onDraw() method through the invalidate() call is an easy way to provide custom animations. If you’re planning to make a small game, using this trick is a simple way to handle the game’s main loop.

### External links

  * <http://developer.android.com/reference/android/graphics/Canvas.html> 
  * <http://developer.android.com/guide/topics/graphics/2d-graphics.html> 

&#160;

<a name="titles"><b>Here are some other Manning titles you might be interested in:</b></a> 

<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" width="61">
      <p>
        <a href="/wp-content/uploads/clip_image0024.jpg"><img loading="lazy" decoding="async" style="background-image: none; border-right-width: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px; padding-top: 0px" title="clip_image002[4]" border="0" alt="clip_image002[4]" src="/wp-content/uploads/clip_image0024_thumb.jpg" width="51" height="63" /></a>
      </p>
    </td>
    
    <td valign="top" width="463">
      <p>
        <a href="http://www.manning.com/ableson3/">Android in Action, Third Edition</a>
      </p>
      
      <p>
        W. Frank Ableson, Robi Sen, Chris King, and C. Enrique Ortiz
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="61">
      <p>
        <a href="http://www.manning.com/collins/"><img loading="lazy" decoding="async" style="background-image: none; border-right-width: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px; padding-top: 0px" title="clip_image004" border="0" alt="clip_image004" src="/wp-content/uploads/clip_image004.jpg" width="51" height="63" /></a>
      </p>
    </td>
    
    <td valign="top" width="463">
      <p>
        <a href="http://www.manning.com/collins/">Android in Practice</a>
      </p>
      
      <p>
        Charlie Collins, Michael D. Galpin, and Matthias Kaeppler
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="61">
      <p>
        <a href="http://www.manning.com/fairbairn/"><img loading="lazy" decoding="async" style="background-image: none; border-right-width: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px; padding-top: 0px" title="clip_image006" border="0" alt="clip_image006" src="/wp-content/uploads/clip_image006.jpg" width="51" height="63" /></a>
      </p>
    </td>
    
    <td valign="top" width="463">
      <p>
        <a href="http://www.manning.com/fairbairn/">Objective-C Fundamentals</a>
      </p>
      
      <p>
        Christopher K. Fairbairn, Johannes Fahrenkrug, and Collin Ruffenach
      </p>
    </td>
  </tr>
</table>