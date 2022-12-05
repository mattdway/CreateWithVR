06-11-22	v1.0.0
Initial commit
 main
@mattdway
mattdway committed on Jul 10

06-11-22	v1.0.0
Initial Commit
Initial Commit 07-10-22 11:37 PM
 main
@mattdway
mattdway committed on Jul 10 

7-13-22		v1.0.1
07-13-22 Scene Removal Committ
I removed a temporary scene I created while testing colliders and physics on my hand objects.  Those assets are now part of the main scene (still in beta testing) so having a second scene for testing is unnecessary.
 main
@mattdway
mattdway committed on Jul 17 

7-17-22		v1.1.0
07-17-22 Committ
* Updated Interaction Board
* Updated Welcome Boards
* Hid Interactive Menu and Added Button In Welcome Menu to Show
* Added Button on Wall By Table To Show Welcome Menu Once Closed
* Fixed Teleportation Anywhere Layer and Fixed Teleportation Limited (the Teleportation Anywhere Plane Height Was Causing Issues)
* Hid Teleportation Mat Mesh Renderer to Neaten Up Room
* Added Two More Mats (One By New Cabinet With Drawer and One By Punch Lists With Correct Direction)
* Added Cabinet With Drawer and Made Drawer and Cabinet Door Function
* Moved Front Door Teleportation Collider and Started to Work on Collider Script To Load New Scene.  This Isn't Working Quite Yet, However.
 main

7-25-22		v1.2.0
07-25-22 Committ
This commit has a working XR Rig Character Controller that follows the main camera's X and Z axis.  This prevents peeking through walls and clipping through walls as well as shrinking the Y transform of the character controller while physically ducking.

The collision script to reload the scene when walking through the front door continues and recent changes need to be tested with the HMD.
 main
@mattdway
mattdway committed on Jul 25 

8-1-22		v1.2.1
08-01-22 Committ
Fixed the crashing when going through the front door transporter (loading another scene).
Found the ideal position for the front door transporter collider.
Fixed the anti-cheating script so that this only occurs when colliding with walls and not furniture.
 main
@mattdway
mattdway committed on Aug 1 

8-2-22		v1.3.0
08-02-22 Committ
Collider Scene Loader Script Unity Editor Crash Bug Squashed.
Set the collider to the ideal position in the white lightbox room outside the front door.
Added a pushable button to the peaceful nowhere scene that takes users can press down with their hand.  It makes a click noise when pressed down and it loads the Matts Room scene upon release.
I also added a custom gold glitter shader for the pedestal, button and button base.
main
@mattdway
mattdway committed on Aug 2 

8-2-22		v1.4.0
08-02-22 Committ
Worked on trying to fix the front door rubber banding hinge problem but didn't completely solve it.  I did make changes to the hinges, door and surrounding wall in the process.
Fixed various other bugs including "X" button position on Settings, Welcome and Interaction boards.
Fixed a few interaction board font issues (to remove glow effect on text mesh pro).
Added a fifth punch list (as I filled the previous four).  Added new socket for this and filled in additional bugs that need fixed and some new ideas of things to add (as well as adding items for mechanics and features I added to this world, previously.
main
@mattdway
mattdway committed on Aug 2 

8-4-22		v2.0.0
08-04-22 Committ
This commit contains the physical hands being activated (they were always part of the hierarchy but not previously activiated and not linked in the hand controllers due to a  bug that caused your physical body to raise up to the ceiling whenever an interactable was grabbed.  That bug is squashed and the hands with colliders and physics are now enabled by default and the non-physics hands are disabled and unlinked.

I also changed the structure by duplicating my left and right hand controllers and linking the physical hands to two and the non-physical hands to the other two.  This way linking each time wasn't necessary.  Now I've disabled the non-physical hand controllers and hands and if I ever need to enable them again, I can do so in the hierarchy without any other setup.

There are still a few things with the physical hands I haven't yet figured out that I am working on.  Mainly the hands are not colliding with furniture, doors or walls yet (although I haven't yet figured out the reason why has the collision matrix has been set to allow collisions there and the direct interactable doesn't have any layer exclusions set).

I added two buttons to my room.  One I gave an all glass look to by changing the mesh render for those components.  This one has the text RESET and is on the counter.  When pressed it activates a script that resets the room.  Handy for HTC Vive users as they don't have a Y or B secondary button they can press to reset this room on their controllers.

The second button I gave a gray base with a red button and a different font and this one is labeled OPEN.  This button calls a function in another script that opens the door 100% (-130 degrees) when pressed.  Users can also open the door using the door knob but this gives two examples of physical buttons that carry out two different functions.

I also fixed a few more bugs in the room and slightly moved a few game objects around slightly.

I found and fixed a bug with the checklists (two toggles were not aligned properly with the fourth check list previously, now they are).
 main
@mattdway
mattdway committed on Aug 4 

8-9-22		v2.1.0
08-09-22 Comitt
* Added a free 3D head model from Sketchfab (https://sketchfab.com/3d-models/head-planes-reference-7b6167ae3e484f1884ae0491a491e856) and I scaled and attached this to my main camera.
* Added a free Dalek 3D model from Sketchfab (https://sketchfab.com/3d-models/bronze-new-series-dalek-rigged-f4b5e527d478485f975aa9f9193248be), I scaled this and made it an XR Grab Interactable for the coffee table.
 main
@mattdway
mattdway committed on Aug 9 

8-9-22		v2.1.0
08-09-22 Commit
* Added the free "bronze-new-series-dalek-rigged" model from Sketchfab (https://sketchfab.com/3d-models/bronze-new-series-dalek-rigged-f4b5e527d478485f975aa9f9193248be), scaled this down and made this an XR Grab Interactable for the coffee table.
* Added the free "head-planes-reference" model from Sketchfab (https://sketchfab.com/3d-models/head-planes-reference-7b6167ae3e484f1884ae0491a491e856), scaled this up and attached this to the main camera as a head in VR.
 main
@mattdway
mattdway committed on Aug 9 

8-9-22		Merge branch 'main' of https://github.com/mattdway/CreateWithVR
Merge branch 'main' of https://github.com/mattdway/CreateWithVR
 main
@mattdway
mattdway committed on Aug 9 

8-21-22		v2.2.0
08-21-22 Commit
* Changed borrowed OpenDoor script (that opens the door from 0 to 100 completely in one button press) to a script that enacts the HingeJoint motors to open the door gradually.  Door can still be opened and closed manually, as well.
* Moved Dalek game object under the --DYNAMIC-- empty game object and alphabetized.
 main
@mattdway
mattdway committed on Aug 21 

8-21-22		v2.2.1
8-21-22 11:53 PM Commit
*Adjusted wall colliders.
*Separated wall colliders into separate game objects to make it easier to adjust, resize and show one collider at a time for troubleshooting.
* Fixed Dalek Grab Interactable glitch (was spinning when held).
* Fixed head clipping into view by moving head object back just far enough until no longer clipping.
* Fixed top hat and captain hat attach point so that both hats sat correctly on mannequin head object.
* Tried to fix "open" push button limit so that button did not push in so far, but I have been (so far) unable to correct this.
* Tried to fix walls so that hands do not clip through but so far hands still clip through walls.  This also allows me to manipulate/push the button towards me from the back end (bug).
*There is also an invisible collider that is preventing me from being able to throw the hats towards the hooks.  But so far I have not been able to determine which collider is doing this (bug).
*I was able to push back the collider on the north wall where the desk is so that throwing photos at the board is again successful (may need to adjust further to perfect).
 main
@mattdway
mattdway committed on Aug 21 

8-22-22		v2.2.2
08-22-22 Commit
Improved Front Door Open Button Pressing Configurable Joint Limits and Spring.
 main
@mattdway
mattdway committed on Aug 22 

11-3-22		v2.2.3
11-03-22 Commit
Fixed a bug that one of my students found play testing on 11-03-22.  Under the correct circumstances when using teleport anywhere he was able to teleport himself outside the bounds of the room by placing the cursor between the room and the watering can.  I adjusted the teleportation anywhere plane so that there is now a  buffer on all four sides of floor and the outside walls in which teleportation is no longer possible.

I tested and I was not able to get out of bounds in the way found previous.

Papers can still clip through the floor and this does not appear to be due to this teleportation area layer.
 main
@mattdway
mattdway committed on Nov 3

11-27-22	v2.3.1
11-27-22 Commit
No individual commits for 11/17/22 or 11/20/22 so all commits for these two dates plus on 11/27/22 are being made in the 11-27-22 Commit.

On 11/17/22 By creating no teleport plane that I made the same size as the furniture and plant by the window and by setting it slightly above the teleport anywhere plane by about .01 I was able to create a blocked area where teleportation can’t happen. This is neater and easier than trying to shrink the teleport anywhere plane as there are still areas by the window I want people to be able to get to.

I also duplicated this no teleport plane and positioned it under the desk and table with the food. Essentially any opportunity to teleport under/into an object and/or an object near s collider wall I want to eliminate as a teleport anywhere area.

Thus no teleporting outside the room (hopefully).

On 11/17/22 I also organized my hands, hands controllers and hand rays into child objects of parent objects for neatness and organization sake. It is now much easier to find the physics hand game objects, the non-physics hand game objects, the hand controller game objects and the hand ray game objects in the Hierarchy, especially since these objects are no longer exclusively childed. 

On 11/20/22 I was able to rotate the ghost hands in scene so that these are facing the same way as my physical hands in the beginning. This means the ghost hands now have the same rotation as my physical hands without having to set it in C# code. 

On 11/20/22 The colliders are still an issue. The swirling ghost hands at the beginning are still an issue. The hands not being hidden when picking something up is still an issue. I'm still troubleshooting to try and figure out why these bugs exist so that i have a better idea of how to patch these.

One more bug I have added to my list... whenever I use any reset button (or a reset from the reset menu) my physics hands are not present. So I also need to look at the code for that reset and see why the scene resets without those hand game objects present.

On 11/20/22 I solved the swirling hand issue by setting the controller parent object for both NP hands to be the exact same transform as my physics hand controllers. It's the controller difference and not the hand difference, I think, that was triggering the ghost hand code. I've tested twice and the physics hands are the active hands immediately and the non physics hands still show up when I press down on the couch arm. So both are activated and the NP hands only show up with that 0.05m

On 11/27/22 Turning off the Interactables/Right Hand Physics and the Interactables/Left Hand Physics in the Physics Matrix of the Project Settings stopped the weird collisions from happening while holding items but because the interactables also have both Rigidbodies and colliders (as they already had to have this for the XR Grab Interactable to work), this means my hands still knock around objects that I pick up. This also allows the hide hands method to work correctly, so my hands once again disappear.  

By changing the interactable's Rigidbody's Collision Detection from Continuous Dynamic to Continuous Speculative I was also able to prevent interactable objects from clipping through the walls.  These items are now stopped when hitting walls.  You also now can't clip through the walls while holding items.

I was able to use a Hierarchy search for Rigidbody then I was able to Ctrl + select all my interactable items and then I set the Rigidbody Collision Detection to Continuous Speculative on all those objects at once.  

Fixed the interactable items not colliding with the walls and door issue.  The XR Grab Interactable's Movement Type wasn't set to Velocity Tracking in all cases, thus in some cases where this was set to Kinematic, collisions were being ignored.  Fixed now and all the interactable items now seem to be stuck within the confines of the room without exiting out.  Also, I haven't yet found any item that I am holding that allows my hands to clip through the walls, despite the code that disables the colliders when holding an item.  So this seems to work well with physics hands.

I still need to fix the reset bug that reverts the objects in play mode back to non-interactable hands with no physical hands present.  This may be because code is reloading the main scene and not the secondary scene I saved as for building and testing purposes.  That scene will eventually be saved back over to the main scene once I've done a few more play tests and this may fix that issue.

I also need to work more on the bug which sometimes causes the pushback on the body Player Controller capsule collider when leaning over furniture.  This is ideally only supposed to push back when leaning forward against a wall, door or window and sometimes the tag read works first time and sometimes only after 3-4 collisions.  I'm not yet sure why.
@mattdway
mattdway committed on Nov 27

11-29-22	v2.4.0
11-29-22 Commit

I merged my True Physics Hands Setup.unity scene with my Matt Room.unity scene today. So now when using the reset menu and/or the reset button you start over with physics hands (as the original scene without full physics hands doesn't exist. Only the one with physics hands).

My teleport anywhere buffers weren't quite positioned or sized right and I found one spot where I was able to teleport outside the room between the cabinet with the drawer and the window. I found another where I could teleport out by teleporting by the trash bin and the window. I adjusted the buffer on what I am calling the west window and I added a new buffer to the south wall from the corner behind the stove to the lamp by the window. 

I made sure all buffers were inside the room walls and adjusted to be near the walls so that you couldn't teleport near any walls where there are objects that can possibly push you outside the walls. So far I haven't been able to teleport out, since.

I also fixed the pushback code by ditching the bool variable idea and instead running the pushback code inside OnCollisonEnter and OnCollisionTrigger methods directly.  The height adjustment code is still running under the FixedUpdate.  Tested and the pushback still occurs for walls, windows and doors (anything with a tag of "wall") but not anywhere internal to the room.

I also fixed an issue where the photograph collision was causing the polaroid camera to spin while holding it by turning off the photograph and interactive physics in the physics matrix.  Tested OK.

Play tested and the interactive hands and interactive objects all seem to be working well, as well.
@mattdway
mattdway committed on Nov 29

11-30-22	v2.5.0
11-30-22 Commit
* I fixed the MotorizedFrontDoorOpen.cs script, which I rewrote on 11-29-30 but that wasn't working correctly yet.  
* This script now fully toggles the door open if closed and toggles the door closed if open.  
* I changed the TextMeshPro text for the button to the left of the door from: OPEN to DOOR to reflect this change.
* If the door is partially open the button press will fully open the door first.  Then a second press will close the door again.  This is also true behavior if the door starts as closed.
* There is a small bug in the button in that if the user manually opens the door completely (including pushing on it slightly with their physics hands) and then press the DOOR button the door will start by trying to open.  Because the door is already open it will look like the button doesn't do anything.
* I played with the idea of using a EulerLocalAngle to evaluate the starting position of the door so that I could set the open variable appropiately.  

This change was in place and didn't cause any errors but... Euler angles are sort of weird when it comes to accuracy. 

I also couldn't decide on the best place to have this evaluation. If I set it at start obviously the value is going to reflect a closed door, every time and if I set it to evaluate at the start of the button press, that ends up messing with the toggle of my button. 

Because it's hard to get the door all the way open by hand anyway I decided to leave that evaluation out of the equation for now. I think it works well enough as is and I don't think there is much chance someone would open the door all the way (including pushing on it to make sure it is as open as possible) then would press the button. If they do the worst that will happen is the button won't do anything on first press but would close on second. I'll leave it as is now and if I have an ah-ha moment later I'll modify the code.
* I also added my physics hands to the "This is the End" hidden scene so when someone finds that area, they'll have the same full physics hands and ghost hands as in the main area.
* Odd door physics when pressing against the hinge the wrong direction is still an issue that will need to be addressed at some point in the future.
* I also removed/archived to a different drive the "Not Working or Not Used" sub-folder under scripts.  This still gives me access to old scripts should I need to reference or revive one of these old scripts while these don't need to be stored in my project folder.
@mattdway
mattdway committed on Nov 30

12-4-22	v2.5.1
12-4-22 Commit

* Added a white board with tray for the pen to the left of the door.
* Coded the functionality of this whiteboard.
* The white board is not quite registering every pen tip touch to the board (tag read issue? It's not entering one specific IF statement) and the pen writes are sporadic and don't always match the pen's movement.  The pen's rotation also isn't always locked so the pen flops flat against the board.
* I fixed the east wall collider so that items don't fall partially behind the wall.
* I moved the door button and the white board forward as both those were being interfered by the wall collider.
* I troubleshot and worked on the Door button in hopes of turning off the motor when the door is all the way open or closed.  I have code in place to do this based on the eular angle and the Y rotation of the door but I was getting inconsistent readings on what that angle is and inconsistent results as well.  I ran out of time and need to come back to troubleshoot this more with a fresh set of eyes. 
* I discovered that only the top motor renderer has the motor activated.  Not a big deal as one motor is enough but I am curious as to why I am not activating all three hinge joints.
* I broke and fixed 
	- The watering can when you try and use it hits so many items it acts funky and when you set it down on any surface it almost always knocks over and makes that annoying water pouring sound. (Came back and fixed)
	- The notebooks have some sort of physics issue that is causing them to spin in your hand in place. (Came back and fixed).
	- The stapler and the dart gun are running into issues where the staples and the darts create physics that cause the stapler/dart gun to be knocked about in unintended ways. (Came back and fixed)
	- The cabinet door intersects with the table that houses the candles. This is because I had to turn off the physics between the furniture and doors to allow the cabinet doors to open properly. They were rubbing and not opening otherwise. (Came back and fixed by creating a small invisible collider that stops the cabinet doors when opened. The only caveat is that my hands can collide with this collider, currently. I could select a different layer or create a new layer that only interacts with the door (and nothing else) and it would fix that).
	- I accidently turned off the physics for the lighter and candles. I think when I turned off interactions between layers of the same type. Some weren't needed/unadvisable from the physics point of view but that one I need to look at and turn back on. (Came back and fixed).
	- I tested the other items on the kitchen table and the water bottle with the lid on is still causing major issues, which I'm not sure why. You put the lid on and it starts spinning like a propeller in your hand. It does make for a fun bottle flipping challenge (it's awesome when it happens to lands right side up after you let it go!), but it's not expected or wanted behavior. Even though it is sort of different. Who knows, maybe I'll decide to leave it. At the moment I think it's the physics interaction between the bottle and the lid but I can't disable those because the socket doesn't work without collision. I'll look at it again on a different date.
	- The wax fruit are all OK.
	- There is also a possible problem with my physics hands. When holding larger items (like the watering can, art, etc.) if you hit it accidently with your left hand then it causes it to start to spin in place. I might need to code something to turn off colliders for both hands, not just the hand holding the item to solve this. This would also fix a sound issue when trying to grab an item in my right hand with my left hand, or vice versa. There is probably a more eloquent coding solution for switching holding the item between hands but in the mean time if I change the C# code to disable both colliders then that would solve a lot of the immediate issues.
	- The whiteboard and motors on the front door still need to be fixed.
	- The door when I lean against it the Player Control still pushes the door out of the way (against the hinges). This doesn't seem to happen when just pressing myself against the door and this also doesn't happen with my hands. I started to research this on Friday so I have some ideas of what to look at and what may or may not help.
@mattdway
mattdway committed on Dec 4

12-5-22	v2.5.1
12-5-22 Commit
Installed Git LFS (Large File Support) and I used this to track and upload MP4 video files to an LFS server as part of my workflow.
@mattdway
mattdway committed on Dec 5