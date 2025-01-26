---
title: Programming with Scratch – Relative Motion
author: Alvin A.
type: post
date: 2012-09-04T13:18:44+00:00
url: /2012/09/04/programming-with-scratch-relative-motion/
categories:
  - Development
  - how-to
tags:
  - arduino
  - java
  - manning
  - scratch

---
<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" width="151">
      <p>
        <a href="/wp-content/uploads/scratch1.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch1" border="0" alt="scratch1" src="/wp-content/uploads/scratch1_thumb.png" width="154" height="191" /></a>
      </p>
    </td>
    
    <td valign="top" width="480">
      <p>
        <a href="http://www.manning.com/marji/">Programming with Scratch</a>
      </p>
      
      <p>
        By Majed S. Marji
      </p>
      
      <p>
        <i>Scratch is a simple, yet powerful, programming language that is intended to make computer programming easy and fun. It is different from the other programming languages in that it is visual. Instead of typing in your commands, you create your program by connecting graphical blocks together. In this article based on chapter 2 of </i><i><a href="http://www.manning.com/marji/">Programming with Scratch</a></i><i>, author Majed Marji shows you how to move sprites on the stage using the relative motion command blocks.</i>
      </p>
    </td>
  </tr>
</table>

### Relative Motion

Figure 1 shows a Scratch program that displays “Hello!” on the screen. The result from running this program is also shown in the figure.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-fig1" border="0" alt="scratch-fig1" src="/wp-content/uploads/scratch-fig1_thumb.png" width="304" height="176" />][1]

<sup>Figure 1 This figure shows: (a) a simple Scratch program that contains a single command block, and (b) the result of running this program.</sup>

The cat that you see in figure 1.1(b) is called a _sprite_. You can think of a sprite as a small robot that understands and obeys a predefined set of commands. You can give a sprite a different look by commanding it to use a different image, called costume. You can use an image of an airplane, snowman, your own photo, or anything else you like. The applications you create would typically contain more than one sprite, and your program will command these sprites to do certain things like move, turn, say something, play music, perform mathematical calculations, and so on. The area of the screen where your sprite move and interact with one another is called the stage.

Programming in Scratch is performed by snapping together “colored” command blocks, similar to putting together jigsaw puzzles or LEGO pieces. The stacked blocks that you create are called scripts.

Consider the grid depicted in figure 2, which shows a rocket sprite and a target (star) sprite. Here, the exact positions of these sprites on the stage are unknown as indicated by the absence of their (x,y) coordinates. If you were asked to give instructions to the rocket to hit the target, you might say, “First, move three steps, then turn right, then move two steps.” The effect of executing these instructions is also illustrated in the figure.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-fig2" border="0" alt="scratch-fig2" src="/wp-content/uploads/scratch-fig2_thumb.png" width="364" height="97" />][2]

<sup>Figure 2 You can move a sprite on the stage using relative motion commands.</sup>

Commands like “move” and “turn” are examples of relative motion commands. The first “move” command, for example, caused the rocket to move up, whereas the second “move” command caused the sprite to move to the right. In essence, the motion depends on (or is relative to) the current direction (or heading) of the sprite.

In addition to its current (x,y) position on the stage, the state of a sprite is also determined by its current direction. The direction convention used in Scratch is illustrated in figure 3. You can explicitly set the direction of a sprite using the [<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch2" border="0" alt="scratch2" src="/wp-content/uploads/scratch2_thumb.png" width="146" height="24" />][3] command. You specify the direction by clicking the down arrow and selecting (up, right, down, or left) from the dropdown list or by typing in any value you want in the white edit box. Note that you can use negative values if you want. Typing 45 or -315, for example, causes the sprite to point northeast.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-fig3" border="0" alt="scratch-fig3" src="/wp-content/uploads/scratch-fig3_thumb.png" width="364" height="186" />][4]

<sup>Figure 3 Direction convention used in Scratch: 0 (up), 90 (right), 180 (down), and -90 (left).</sup>

With this newfound knowledge, let me introduce Scratch’s relative motion commands. These commands are summarized in table 1. I’ll demonstrate how to use these commands with the aid of simple examples.

Table 1 Relative motion commands in Scratch 

<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" width="183">
      <p>
        Command
      </p>
    </td>
    
    <td valign="top" width="400">
      <p>
        Description
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="183">
      <a href="/wp-content/uploads/scratch-tab1.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-tab1" border="0" alt="scratch-tab1" src="/wp-content/uploads/scratch-tab1_thumb.png" width="107" height="28" /></a>
    </td>
    
    <td valign="top" width="400">
      <p>
        Moves the sprite in a straight line in the direction of its current heading. It takes an input number that indicates how far the sprite should move. A positive number causes the sprite to move forward, whereas a negative value causes the sprite to move backward.
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="183">
      <a href="/wp-content/uploads/scratch-tab2.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-tab2" border="0" alt="scratch-tab2" src="/wp-content/uploads/scratch-tab2_thumb.png" width="111" height="28" /></a>
    </td>
    
    <td valign="top" width="400">
      <p>
        Changes the sprite’s x-position by a specified amount. This causes a horizontal (left or right) movement of the sprite.
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="183">
      <a href="/wp-content/uploads/scratch-tab3.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-tab3" border="0" alt="scratch-tab3" src="/wp-content/uploads/scratch-tab3_thumb.png" width="111" height="28" /></a>
    </td>
    
    <td valign="top" width="400">
      <p>
        Changes the sprite’s y-position by a specified amount. This causes a vertical (up or down) movement of the sprite.
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="183">
      <a href="/wp-content/uploads/scratch-tab4.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-tab4" border="0" alt="scratch-tab4" src="/wp-content/uploads/scratch-tab4_thumb.png" width="134" height="28" /></a>
    </td>
    
    <td valign="top" width="400">
      <p>
        Rotates the sprite clockwise in reference to its current direction. It takes an input number that indicates the required turn angle. A negative value results in a counterclockwise motion.
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="183">
      <a href="/wp-content/uploads/scratch-tab5.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-tab5" border="0" alt="scratch-tab5" src="/wp-content/uploads/scratch-tab5_thumb.png" width="130" height="28" /></a>
    </td>
    
    <td valign="top" width="400">
      <p>
        Rotates the sprite counterclockwise in reference to its current direction. It takes an input number that indicates the required turn angle. A negative value results in a clockwise motion.
      </p>
    </td>
  </tr>
</table>

You can see the current direction of a sprite in the “sprite info area” of Scratch’s user interface (see figure 4).

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-fig4" border="0" alt="scratch-fig4" src="/wp-content/uploads/scratch-fig4_thumb.png" width="364" height="132" />][5]

<sup>Figure 4 Current sprite info area</sup>

Another way to see this information is provided by the [<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch3" border="0" alt="scratch3" src="/wp-content/uploads/scratch3_thumb.png" width="79" height="17" />][6] block. Clicking the checkbox next to this block allows you to see the sprite’s direction on the stage.

### Using move and turn commands

Figure 5 illustrates how the <font color="#ffffff" face="Consolas"><strong>move</strong></font> and <font color="#ffffff" face="Consolas"><strong>turn</strong></font> commands work in relation to the current direction of the sprite. The first command causes the sprite to point up. The second command turns the sprite 45° clockwise. Then, the sprite moves 100 steps in its current direction (in other words, northeast). The last command turns the sprite 45° counterclockwise, which changes the sprite’s direction to the up position. 

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-fig5" border="0" alt="scratch-fig5" src="/wp-content/uploads/scratch-fig5_thumb.png" width="364" height="182" />][7]

Figure 5 A simple script that illustrates using the move and turn commands

There are many other ways to implement this script and still have the same end result. For example, instead of commanding the sprite to point up then turn right 45°, we can directly command it to point in the direction of 45° using the [<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch4" border="0" alt="scratch4" src="/wp-content/uploads/scratch4_thumb.png" width="146" height="24" />][8] command. Another way is to have the sprite point right, move some distance, turn left 90°, then move the same distance up. The scripts for these two alternatives are shown in figure 6. As you can see, the second script used the Pythagorean Theorem to calculate the horizontal and vertical distances.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-fig6" border="0" alt="scratch-fig6" src="/wp-content/uploads/scratch-fig6_thumb.png" width="364" height="128" />][9]

<sup>Figure 6 Different scripts that produce the same result as the script of figure 5</sup>

**TRY IT OUT (1)** &#8211; What do you think would happen if you used negative values in motion commands? Try the script shown in figure 7 to check your answer. (2) To know the direction of the sprite, check the box next to the [<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch5" border="0" alt="scratch5" src="/wp-content/uploads/scratch5_thumb.png" width="79" height="17" />][10] block, then turn the sprite by different angles (using the <font color="#ffffff" face="Consolas"><strong>turn</strong></font> commands). What values are displayed in the direction monitor box on the stage?

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-fig7" border="0" alt="scratch-fig7" src="/wp-content/uploads/scratch-fig7_thumb.png" width="162" height="88" />][11]

<sup>Figure 7 Using negative parameters in motion blocks</sup>

### Using “change x by” and “change y by” commands

Figure 8 shows a simple script that illustrates the effect of the [<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-change1" border="0" alt="scratch-change1" src="/wp-content/uploads/scratch-change1_thumb.png" width="107" height="24" />][12] and [<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-change2" border="0" alt="scratch-change2" src="/wp-content/uploads/scratch-change2_thumb.png" width="107" height="24" />][13] commands. The first command moves the rocket sprite to the center of the stage, setting its x-coordinate to 0 and its y-coordinate to 0. The [<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-change3" border="0" alt="scratch-change3" src="/wp-content/uploads/scratch-change3_thumb.png" width="107" height="24" />][14] command changes the x-coordinate to 50 (in other words, 0+50), which causes the sprite to move 50 steps to the right. The next command ([<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-change4" border="0" alt="scratch-change4" src="/wp-content/uploads/scratch-change4_thumb.png" width="107" height="24" />][15]) changes the y-coordinate to 50, which causes the sprite to move up 50 steps. The (x,y) coordinates of the sprite after executing this command will be (50,50). When the second [<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-change5" border="0" alt="scratch-change5" src="/wp-content/uploads/scratch-change5_thumb.png" width="107" height="24" />][16] command is executed, the sprite will move additional 50 steps to the right ending at point (100,50). You should now be able to trace the motion of the sprite caused by this script, which is also illustrated in the figure.

[<img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="scratch-fig8" border="0" alt="scratch-fig8" src="/wp-content/uploads/scratch-fig8_thumb.png" width="364" height="178" />][17]

<sup>Figure 8 A simple script that illustrates using the “change x by” and “change y by” commands</sup>

### Summary

Scratch programs (also called _scripts_) are created by snapping together command blocks that control graphical objects called _sprites_. You can give a sprite a different look by assigning it a different image, called _costume_. Sprites move and interact with one another on a background area called the _stage_. You can change the appearance of the stage by assigning it a different image, called _background_. Scratch has four kinds of blocks: command blocks, function blocks, trigger blocks, and control structure blocks.

In this article, you learned how to use relative motion commands to move sprites with reference to their own position and direction.

&#160;

<a name="Related"></a>**Here are some other Manning titles you might be interested in:** 

<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" width="73">
      <p>
        <a href="/wp-content/uploads/arduino.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="arduino" border="0" alt="arduino" src="/wp-content/uploads/arduino_thumb.png" width="104" height="129" /></a>
      </p>
    </td>
    
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/mevans">Arduino in Action</a>
      </p>
      
      <p>
        Martin Evans, Joshua Noble, Mark Sproul, and Jordan Hochenbaum
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="73">
      <p>
        <a href="/wp-content/uploads/java.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="java" border="0" alt="java" src="/wp-content/uploads/java_thumb.png" width="104" height="130" /></a>
      </p>
    </td>
    
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/evans/">The Well-Grounded Java Developer</a>
      </p>
      
      <p>
        Benjamin J. Evans and Martijn Verburg
      </p>
    </td>
  </tr>
  
  <tr>
    <td valign="top" width="73">
      <p>
        <a href="/wp-content/uploads/machinelearning.png"><img loading="lazy" decoding="async" style="background-image: none; border-bottom: 0px; border-left: 0px; padding-left: 0px; padding-right: 0px; display: inline; border-top: 0px; border-right: 0px; padding-top: 0px" title="machinelearning" border="0" alt="machinelearning" src="/wp-content/uploads/machinelearning_thumb.png" width="104" height="130" /></a>
      </p>
    </td>
    
    <td valign="top" width="451">
      <p>
        <a href="http://www.manning.com/pharrington/">Machine Learning in Action</a>
      </p>
      
      <p>
        Peter Harrington
      </p>
    </td>
  </tr>
</table>

&#160;

&#160;

<div style="padding-bottom: 0px; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; float: none; padding-top: 0px" id="scid:0767317B-992E-4b12-91E0-4F059A8CECA8:6c784fee-1f1e-484c-9ea7-29085d424a7c" class="wlWriterEditableSmartContent">
  del.icio.us Tags: <a href="http://del.icio.us/popular/scratch" rel="tag">scratch</a>,<a href="http://del.icio.us/popular/manning" rel="tag">manning</a>,<a href="http://del.icio.us/popular/arduino" rel="tag">arduino</a>,<a href="http://del.icio.us/popular/java" rel="tag">java</a>
</div>

 [1]: /wp-content/uploads/scratch-fig1.png
 [2]: /wp-content/uploads/scratch-fig2.png
 [3]: /wp-content/uploads/scratch2.png
 [4]: /wp-content/uploads/scratch-fig3.png
 [5]: /wp-content/uploads/scratch-fig4.png
 [6]: /wp-content/uploads/scratch3.png
 [7]: /wp-content/uploads/scratch-fig5.png
 [8]: /wp-content/uploads/scratch4.png
 [9]: /wp-content/uploads/scratch-fig6.png
 [10]: /wp-content/uploads/scratch5.png
 [11]: /wp-content/uploads/scratch-fig7.png
 [12]: /wp-content/uploads/scratch-change1.png
 [13]: /wp-content/uploads/scratch-change2.png
 [14]: /wp-content/uploads/scratch-change3.png
 [15]: /wp-content/uploads/scratch-change4.png
 [16]: /wp-content/uploads/scratch-change5.png
 [17]: /wp-content/uploads/scratch-fig8.png