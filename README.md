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
07-13-22 Scene Removal Commit
I removed a temporary scene I created while testing colliders and physics on my hand objects.  Those assets are now part of the main scene (still in beta testing) so having a second scene for testing is unnecessary.
 main
@mattdway
mattdway committed on Jul 17 

7-17-22		v1.1.0
07-17-22 Commit
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
07-25-22 Commit
This commit has a working XR Rig Character Controller that follows the main camera's X and Z axis.  This prevents peeking through walls and clipping through walls as well as shrinking the Y transform of the character controller while physically ducking.

The collision script to reload the scene when walking through the front door continues and recent changes need to be tested with the HMD.
 main
@mattdway
mattdway committed on Jul 25 

8-1-22		v1.2.1
08-01-22 Commit
Fixed the crashing when going through the front door transporter (loading another scene).
Found the ideal position for the front door transporter collider.
Fixed the anti-cheating script so that this only occurs when colliding with walls and not furniture.
 main
@mattdway
mattdway committed on Aug 1 

8-2-22		v1.3.0
08-02-22 Commit
Collider Scene Loader Script Unity Editor Crash Bug Squashed.
Set the collider to the ideal position in the white lightbox room outside the front door.
Added a pushable button to the peaceful nowhere scene that takes users can press down with their hand.  It makes a click noise when pressed down and it loads the Matts Room scene upon release.
I also added a custom gold glitter shader for the pedestal, button and button base.
main
@mattdway
mattdway committed on Aug 2 

8-2-22		v1.4.0
08-02-22 Commit
Worked on trying to fix the front door rubber banding hinge problem but didn't completely solve it.  I did make changes to the hinges, door and surrounding wall in the process.
Fixed various other bugs including "X" button position on Settings, Welcome and Interaction boards.
Fixed a few interaction board font issues (to remove glow effect on text mesh pro).
Added a fifth punch list (as I filled the previous four).  Added new socket for this and filled in additional bugs that need fixed and some new ideas of things to add (as well as adding items for mechanics and features I added to this world, previously.
main
@mattdway
mattdway committed on Aug 2 

8-4-22		v2.0.0
08-04-22 Commit
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

12-13-22 v2.5.2
12-13-22 Commit
I was able to work out a many of the remaining issues with my physics hands tonight.

Being able to spam select things is now gone by changing Select Action Trigger on the XR Interactable from State to State Selected on the "LeftHand Controller With Physics" and the "RightHand Controller With Physics" controller game objects.

Not only can't you spam the select button to select something over and over again, this also prevents being able to pick up multiple objects with the same hand and it also prevents being able to grab an interactable with a single grab point with both hands at once, which also eliminates the obnoxious haptic and sound feedback that would happen when grabbing an object with a single grab point with both hands at once. Now, the behavior is that it simply switches hands.

I also turned off physics hands on the opposite hand in one instance by adding some additional Interactable Events for "Select Entered" and "Select Exited" on the XR Interactable on the "LeftHand Controller With Physics" and the "RiightHand Controller With Physics" controller game objects.

Each controller object now has the following:

Select Entered
LeftHandPhysics Hand.ToggleVisiibility
LeftHandPhysics HandPhysics.DisableHandCollider
RightHandPhysics HandPhysics.DisableCollider

Select Exited
LeftHandPhysics   Hand.ToggleVisiibility
LeftHandPhysics   HandPhysics.EnableHandColliderDelay with a time duration of 0.5
RightHandPhysics  HandPhysics.EnableHandColliderDelay with a time duration of 0.5

This means whenever something is picked up in the right hand, the right hand disappears and both the right hand colliders are disabled as are the left hand colliders. When something is dropped from the right hand the right hand reappears and both the right hand colliders and left hand colliders are re-enabled again after a wait duration of 0.5ms.

The same is true when something is picked up in the left hand.

The only instance where this isn't true is when you pick something up in the right hand and then switch to the left hand. It appears in this instance the "Selected Exit" executes and the collider for the opposite hand turns back on but this switching of an object in hands for whatever reason doesn't register as a "Select Entered", which means that opposite hand collider isn't turned off again. 

If the object is dropped completely and picked back up this triggers Select Entered. I'm not entirely sure why but I haven't found many instances where having the opposite hand physics turned off when holding something is much of a problem. Sometimes you can bump it with a hand and it'll move slightly but even with large objects like the painting, that doesn't cause any severe physics issues, it simply nudges the object slightly. So maybe I'll even allow physics in the opposite hand to remain when picking up an object and only have it disabled for the hand holding the item. We'll see.

I re-enabled distance grab for both hands. At one point I had turned this off on the left hand and I don't remember why. It wasn't a problem that I recall and being able to pick up objects with either hands is helpful. Especially when picking up two items (such as the bottle and the lid) from a table where getting close enough to the object to direct pick up is difficult.

I thought there was a collision issue with distance grab to where I would distance grab an object and it would hit my hand and fly in an odd direction before grabbing. I went ahead and set the same "Select Entered" and "Select Exited" as with the XR Direct Interaction to disable collisions when using the rays. 

Select Entered
LeftHandPhysics Hand.ToggleVisiibility
LeftHandPhysics HandPhysics.DisableHandCollider
RightHandPhysics HandPhysics.DisableCollider

Select Exited
LeftHandPhysics   Hand.ToggleVisiibility
LeftHandPhysics   HandPhysics.EnableHandColliderDelay with a time duration of 0.5
RightHandPhysics  HandPhysics.EnableHandColliderDelay with a time duration of 0.5

While I'll keep those Interactor Events enabled what I found in play testing is that this wasn't a problem with the collisions but with the thumbstick press to toggle the ray. It's very easy to let go too soon, thus breaking the distance grab before it completes. Pressing down on the thumbstick is an alternative technique that in some ways works better for distance grabbing. However, pressing on the thumbstick can also accidently engage the snap turning and/or continuous movement when unintended. So distance grabbing with either continuous movement or snap turning can be persnickety and takes some practice and patience on the part of the user. There is maybe a better way to do this to avoid conflicts and to have less work or annoyance on the part of the player. I'll have to research this more and/or pay more attention to how this works in commercial games.

I tried to duplicate the wall glitch by the fireplace but was unable to. I'm not entirely sure what the sequence of events were that allowed this glitch to happen, at this point in time. I'm checking with the student who found this glitch to see how I can reproduce it.

All in all things are working pretty well with the hands and they seem less glitchy than before with these changes made.

I also turned off the Direct Interactor for the ghost hands. Those hands now animate but are not capable of directly picking anything up.

I have tried (using ChatGPT to spitball ideas) to troubleshoot and add 90 degree hand rotation on the physics hands so that these start rotated with the palms facing in. So far any start rotation I add to these interferes with the constant rotation being applied and this causes the hand assets (target per the C# code) to shake. There is most likely a coding solution to this but I haven't found it yet. I'll come back to this one again later.

While it is possible to sometimes get into weird situations where the physics hands will get stuck on something, with collisions with most every object, including walls, floors, interactables, non-interactables, furniture, etc. this is somewhat rare. While I am confident those glitches can occur, I don't know if I can code around every instance of that happening and I don't currently have a known repeatable method of making the physics hands get stuck on something, which would be an instance where I could then further troubleshoot and fix those issues.

I also, at some point, want to add hand-poses for different objects to these hands instead of making the hand disappear.
@mattdway
mattdway committed on Dec 13

12-18-22 v2.5.3
12-18-22 Commit
With the help of Paul in a forum, the physics hands now start rotated 90/-90 degrees inward so that the palms are facing inward (as opposed to palms facing towards the ground) on start.  This orients the hands in the same direction as the player's physical hands while holding the VR hand controllers.  This rotation is also stable and is no longer causing the hands to shake uncontrolably due to that rotation every frame, which was part of the solution Paul helped me with.

As part of this solution I renamed my HandPhysics.cs script to HandPhysicsPosRight and I duplicated this script and I renamed it to HandPhyisicsPosLeft.  The then assigned these to the proper left and right physics hands and I relinked the proper game object and mesh render to each.  The only difference between these two scripts is that one script has a rotation of 90 degrees and the other script has a rotation of -90 degrees.

I also rotated adjusted the starting rotation of the non-physics hands to match so that when the non-physics hands are shown, the rotation matches those of the physics hand model at the time of collision. 

I fixed the reset button in the Peaceful Nowhere scene by changing the Clicker's threshold from 1.0f to 1.5f so that the button pressed a little further and registered as a click and release (thus triggering the script that resets the scene).

I fixed the spinning ghost hands at the start of a new scene and when restarting a scene using a button by changing the Y and X position transform of the physics hands and then matching the position transform of the non-physics controllers to match. The hands are now closer to the actual starting position that the physical controllers are likely to be and not on the floor at the start of the scene.  

Lastly, I also updated these physics and non-physics hand changes in the Peaceful Nowhere scene by updating my -- XR -- prefab.  I then unpacked the -- XR -- prefab in my Hierarchy completely in my Matt's Room scene.  I then loaded the Peaceful Nowhere scene where I deleted -- XR -- from the Hierarchy pane and I brought back in -- XR -- from the prefabs.  I then unpacked the -- XR -- prefab in my Hierarchy completely in my Peaceful Nowhere scene.

I also made my Projectiles parent object a prefab so that my custom dart gun and stapler could be exported or duplicated, if need be.
@mattdway
mattdway committed on Dec 18

12-20-22 v2.5.5
12-20-22 Commit
Bug fixes.

The No Teleport Zone on the east wall (by the front door) now runs from the corner behind the fireplace to the door without any gaps.  This has cut off the ability to teleport out of the room anywhere around the stove.

I double checked that my hidden mat (with the Mesh Render off) was on top of the No Teleport Zone.  It is.

I duplicated that mat by the punch lists so that when teleporting in a limited area, it is possible to teleport anywhere in front of any of the four punch lists to be able to easily reach this.

I double checked that my hidden mats by the punch list were back far enough and that this prevented teleporting out, it did.

I fixed the bug where when going from Continuous Motion to Teleport Anywhere and then back to Continuous Motion again in the Settings menu this kept the teleport anywhere plane turned on so that it appeared like you could teleport anywhere, even though you couldn't because you were in Continuous Motion (the teleportation provider was turned off so this gave the effect of showing the reticle even though you couldn't complete the teleportation).  The fix was to set the teleportation area to be disabled whenever Continuous Motion is selected from the settings menu.

The toggle colliders for my left and right physics hands were in Select Enter and Select Exit for direct interactor and ray casting were lost in a previous save when making changes to my physics hands.  Thus, colliders on those physics hands were staying on, on both left and right hand regardless of which hand picked up the item).  I re-set this up for the direct interactor and for the rays.

There is still a bug that needs to be fixed in the C# code for these physics hands and I have a coding solution I can implement and test.  But this will have to wait until tomorrow.  The bug is both when an item is dropped and picked up again and I suspect that this same bug happens when switching items between hands (due to the timing of dropping something and then picking it back up again before the duration timer is up).  The bug allows the hand colliders to be turned back on, on both hands, again in both instances while still holding an item.  This causes certain items to act buggy due to collisions between the hand colliders and the interactable colliders.  Implementing this change should fix this issue.

I play tested the stapler and the balls again and neither acted buggy when the hand colliders were turned off so no changes need to be made to the interactables themselves.  In short, these ended up not colliding with themselves (at one point they had but I had previously fixed this and that piece is still in place) but with the hands.  The above last fix should help to prevent any bugginess when picking up items.

I also increased the scale of the table by 1.15 on the z-axis.  This allowed me to move the right chair over a little to make a little more room to get up to the table.  I also adjusted the lamp's transform (with the baked in shadows) so that it again matched the shadows and those shadows didn't look out of place.

However, while that gap increase between chairs was needed to the user to be able to get up to the table in Continuous Motion, there is still a collision happening before reaching the table.  I've disabled both the chairs and the table and play tested to confirm that collisions aren't happening with any of those three items.  They are not.  So I will need to investigate this further to see what other object's collider is preventing getting up to the table.  That investigation will also need to be tomorrow.
I play tested and found that this problem only occurs when the setting is set to Continuous Motion.  This problem is non-existent when on Teleport Anywhere or Teleport (Limited Area).

I moved the invisible mat by the study over to the right a little bit more (this was inadvertently to far to the left and under the watering can).

I checked the rigidbody of my XR Rig and I tried changing the mass from 1 to .4 to see if that prevented me from being able to open the door by leaning into it.  It did not.  Leaning into the door causes the door to rubber band or the hinge joint to break (both are great Google search terms to use when investigating this problem further).  Leaning into the door handle causes the door handle to freak out and to rapidly glitch and rotate and even clip in and out of the door.  This is something I still need to investigate.

I haven't yet come up with any solutions as to why the white board marker is so glitchy when moving the marker certain directions and/or why its rotation lock doesn't always happen (per the C# code).
 
That's all for tonight! Most of those are fixed now with the exception of the front door leaning, the whiteboard marker (I didn't do any further troubleshooting of it this evening -- no time, but I hope to dive into it again over break) and the mysterious invisible collider in front of the table.  The table collider piece I'm pretty sure I'll be able to resolve pretty easily.  The front door and marker, may be much more difficult to pin down what is happening and/or a fix.  I have a discord post (of the YouTuber who made the video) asking for help with the marker glitch that currently has no replies.  I may post back to see if there is anyone who might have any ideas for me there.
@mattdway
mattdway committed on Dec 20

12-23-22 v2.6.1
12-23-22 Commit
On 12-21-22 I found the hidden colliders that were preventing players from reaching the desk using continuous motion.  When I had moved the chairs I neglected to also move the hidden mats with the teleportation anchors that sit on top the chair bottom.  By using filters and gismos I was able to expose and see all colliders, which lead me to the cause.  I turned on the mesh render to see the mats, I moved these back over and then turned off the mesh render again.

On 12-22-22 I fixed and added the following:

I researched and made some changes to the door to try and fix the hinge joint buckling/breaking/rubber banding but in the end none of those changes helped.  This is still a bug with my door when the player leans against the door or the door handle that needs to be fixed.

I also found another bug in which the chair colliders are allowing my hands to clip through them.

I tested the bottle and the lid and physics are still going amok when the lid is placed on the bottle using a socket.  I looked at the physics matrix to see if I could find an answer there, but I have not yet fixed this bug.  In the mean time it makes for a great game of bottle flip.  So maybe I keep it as a hidden easter egg?

I fixed the whiteboard marker not drawing properly issue.  I can now draw well with my whiteboard marker! Martin Kjær's reply in the comment section of Justin's tutorial video is what solved the issue for me. The comment by Itama, when I read it, was the same behavior that I recognized in my marker in that when I drag from right to left, only one corner was touching/writing. Martin's solution of changing the _tip.transform.position.up to _tip.transform.position.forward helped my pen to write smoothly on the board. Apparently my tip was facing a different direction than was expected by the code. My pen is writing well now.

I also added an eraser and a red marker to my whiteboard out of 3D shapes.  The red marker is working as expected in that it writes with red ink. The eraser isn't yet erasing and I am in the middle of troubleshooting the game object's transform and C# code to determine why.

I also fixed the tennis racket attach transform so that it's at a much more natural position (both height, distance to the right of your body and rotation (I think this is a more natural starting position now -- I tried to use tennis player images as references but I don't play tennis so it's hard to know for sure until someone who plays tennis is able to play test for me).

I also tested that I can walk up to the dinning room table now and that I am not hitting any colliders.  

I fixed the physics hand starting position transform, which was causing an issue where the hands sometimes started out where the dart gun is, before snapping in place.  That caused the dart gun to fly which sometimes also had a chain reaction of other things being knocked over or about too.

I rearranged things on the dinning room table to make it easier to grab things without having to rely on distance grabbing.
@mattdway
mattdway committed on Dec 23

12-24-22 v2.7.1
12-24-22 Commit

On 12-23-22 I came up with a solution for the front door physics and being able to lean into the door.  What I ended up doing was I duplicated the door and I removed everything except for the collider from that object.  I then moved that in front of the actual door and I resized it slightly to be a little wider and a little deeper than the door.  I then set its tag to Wall and its layer to Room.  This made it so that when I lean into this new collider in front of the door, I am repelled using the same pushback code that I have for all the other walls.  Note that setting the door with this tag and layer was tested and didn't work.  The physics between my pseudo body and the hinges didn't allow the code to push back.
 

I then set up a collider that filled the space from when the door is half open to all the way open with a script I write that checks for OnCollisionEnter.  When entered, and if the tag match is DoorHandle, the collider is disabled.  When exited, and if the tag match is DoorHandle, the collider is re-enabled. 
 

This collider's depth and width prevents not only leaning into the door to push and break the hinges open (causing janky physics as your head pushes against the door) but it also prevents the door knob from going crazy when pushing against it.  Locking the position and rotation of the door handle wasn't a solution because of how the physics of the door handle and door interact with one another to open the door (the only way around that would be to script a hidden object you pull on instead of the door handle to open the door).  
 

Note that because your hands can go through this new collider you can still open the door with your hand grabbing the handle, in addition to pressing the button.  What this collider does is it stops your pseudo body from colliding with the door (especially when leaning forward) causing adverse physics interactions that cause the hinge joints to rubber band and to eventually break from the physics.  
 

I also added a hidden cube with a collider and rigidbody to the back of the chairs just to give these chair backs physics.  It doesn't serve any purpose except to give these chairs more of a physical presence in the room to go with the physics hands.
 

I am thinking I may use the collider idea with a public variable to determine if the door is open or closed.  This would allow me to be able to set a bool variable in my door button that detects the initial state of the door when pressing the button which could then close the door immediately if physically opened by hand.  
 

I added a collision game object that collides with the door handle when the door is all the way open.  This triggers a script that sets a public bool doorOpen to from false to true.  When the door handle exits this collider it changes that book from true to false.
 

I then modified my motorized front door script to read that public bool from the other script and to react in two ways.
 

1.) My motorized front door script now uses that bool to determine the opening state of the door.  If open the button closes the door first.  If closed the button opens the door first.  If the door is partially open the bool still reads as closed and it opens the door fully upon press.  No longer does a Door button press ever result in trying to open the door while already open or to close the door when already closed, resulting in what looks like nothing happening when the button is pressed.
 

2.) I added a coroutine to my motorized front door script and that script now waits 25 seconds for the door to fully open or close then it shuts off the motors of all three hinge joints.  This way when the button is used to either open or close the door, the user can manually adjust the door using the door knob without having the motor change that state afterwards.  Before the motor checkboxes were still checked after pressing the button and were never unchecked after the desired open or close action had completed.
 

At some point I may learn what property of the angular velocity can help determine if the motor is currently in motion or not and to use that (instead of a set wait time) to turn off the motors.  But for now waiting 25 seconds seems to give the motor enough time to complete (even if pressed multiple times in a row) before turning off the motors and seems OK (at least on my home gaming rig I play tested on).
 

So the door and the Door button both seem to be working as expected now.
 

Up next to fix:
 

Physics hands and putting in a bool variable to prevent the collisions from reenacting when dropping and picking something up quickly in succession. 
 

Figuring out why the whiteboard eraser is not detecting that it is touching the whiteboard, thus not erasing properly.


Thin items like photos from the polaroid camera and my punch list sheets are still sometimes getting stuck under the floor and I need to troubleshoot that more.  


I still need to add the version number to the opening Welcome (tutorial) board so that it's easier to see the version number and the last commit date of the version being run.
 

If I get that working I feel like I have a lot of the bug pieces in my room fixed.  I'll have to go back to my bug list to check to be sure, but off the top of my head there aren't any others that are coming to mind that I need to fix.

@mattdway
mattdway committed on Dec 24

12-29-22 v2.7.2
12-29-22 Commit

Fixed whiteboard eraser so that it now properly erases and that erased texture is the reapplied texture of the whiteboard itself, wherever the eraser touches.  I also troubleshot and fixed a serious visual stutter due to an FPS drop when erasing.  I optimized my code as best I could and I lowered the set resolution of the whiteboard texture from 2048x2048 to 1024x1024 and I set the eraser size to 200, which helped to reduce this greatly.

I added the current version number and commit date to the left side of the Welcome menu so that it is easier, moving forward, to see which version of the project we are running.

I went through my created C# scripts and I commented out all Debug.Logs no longer needed, as troubleshooting of those scripts are complete.

Up next to fix:
 
Physics hands and putting in a bool variable to prevent the collisions from reenacting when dropping and picking something up quickly in succession. 
 
Thin items like photos from the polaroid camera and my punch list sheets are still sometimes getting stuck under the floor and I need to troubleshoot that more.  

Updating the Interactive board and/or punch lists.  I'm running out of room on my punch lists and I have no more room to add additional punch lists, so I'll have to decide how I wish to use these moving forward.  I still love the idea of having bugs and/or future features viewable in VR and I have a lot of future ideas (both from ideas I've come up with and that my students have come up with that could be added).

If I get that working I feel like I have a lot of the bug pieces in my room fixed.  I'll have to go back to my bug list to check to be sure, but off the top of my head there aren't any others that are coming to mind that I need to fix.  At this point I may choose a new feature to add to this room, just to continue my (and my student's) learning.
@mattdway
mattdway committed on Dec 29

12-30-22 v2.8.1
12-30-22 Commit

Dev Log For 12/29/22 and 12/30/22 (into the evening):

I added an isGrabbed bool, per the suggestion of Nemu in the comment section of Valem Tutorials video on physics hands.  Grabbing an item still disables all colliders on both hands and dropping an item re-enables all colliders on both hands after a .5 second delay.  The real change to adding the bool is that when dropping an item and grabbing an item again quickly before that .5 second countdown concludes, the collider does not re-enable.  

Before when dropping and picking up an item within short succession (for example when switching an item from the left hand to the right hand or vice versa or when dropping and picking up an item again, such as to reload the darts or the staples, the collider would re-enable while still holding the item.  

This caused two distinct and noticeable bugs.  First, your opposite hand could suddenly interact with the item you are holding which, for larger items, caused all sorts of physics issues -- especially if accidently bumping the item in your hand around while carrying it.  This was most noticeable when carrying larger items such as a piece of art off the walls or the watering can (which can be somewhat annoying when tipped).  Secondly, when holding an item and having the collider enabled on the same hand, when letting go of the item a collision could (and often) did occur causing the item you dropped to be unintentionally flung across the room in a violent fashion instead of dropping to the ground where you stood.

I tested this with both switching an item between the right and left hand and in dropping and immediately picking the object up again and the colliders stay off for both hands in both scenarios now, which is much more stable and works a lot better from a mechanic stand-point.

Another idea I had for my room.  The water bottle already spins uncontrollably whenever you are both holding it and you put on the lid.  The collisions cause it to spin in a circle in your hand and when you let it go sometimes the water bottle lands right side up and sometimes not.  Rather than fix this (as this is an interesting and amusing bug) I think I'm going to keep it as a fun little easter egg interaction for the room.  Tonight I created a note out of a white plane and a text mesh pro component that says "Can you complete the water bottle flip challenge?" and I placed that under the bottle and the lid.  I also created an empty  game object to house all three and I moved these closer to the table's edge to make it easier to reach without having to use distance grabbing.  I made this note a XR Grab Interactable with a collider and rigidbody.

What I'd also like to do is add a quick script so that if the water bottle is in the air and then drops right side up (collider on the bottom of the bottle on the Y axis) then a cheering sound plays.  And if it lands on either side axis (I'd put colliders there too) a booing sound plays.  It would be a fun way to add a silly little interaction.  Maybe later I'd even come back and add a scoring system to it to count how many times it lands right side up vs. not.

I didn't specify that you put the lid on to spin it but if I hope the subtle hint of having the lid and bottle on top of the bottle would be a clue that you can get some real spin by putting it on and I don't want to spell it all out but for there to be a little self discovery there.

I also added the colliders necessary to determine if the bottle has hit right side up or on any other plane and I also added a script component to this bottle (but I haven't yet written the script that will go with this).

I fixed the north wall collider, which was back too far and allowed objects to partially clip when pressed against the wall (this is because the collider was behind the mesh render rather than in front of it).

I fixed the decretive record_blue so that you can now pick this up by recreating this item and setting it as an XR Interactable with a collider and a rigid body and configuring.

I fixed all of the locomotion settings on the Settings menu: Continuous_Movement_Settings_Toggle, Teleportation_Anywhere_Settings_Toggle and Teleportation_Limited_Settings_Toggle.  In the On Value Change (Boolean) section of each of these UI toggles I hadn't updated and added in the all of the new teleportation mats (with the mesh render turned off) I'd added to my room since.  There are 12 of these teleportation mats and 1 rug in my room now.  Thus, when selecting Continuous Motion not all of these teleportation anchors were being disabled and when selecting this toggle and when selecting Teleportation (Limited) and Teleportation (Anywhere) those teleportation anchors were not being re-enabled.

For neatness and tracking sake I went ahead and relinked all the teleportation mats and the teleportation rug in the exact same alphabetical order listed in the hierarchy, within the On Value Change (Boolean) for each of these three toggle menus I mentioned.  This makes it easier to see if I am missing any linked game objects in the future.  I also added TeleportAnchorWithFade.enabled (TeleportationAnchorWithFade > bool enabled) and I made sure that the currect checkbox was checked for each toggle.

I re-adjusted the collider on the back of the two dinning room chairs.  It was too far forward and I was able to move my hand through those chairs at will.  Readjusting the rotation and the X position helped.

Of note, I find that with the chairs and the dinning room table that if I move my hand fast enough I can still phase my hand through those objects.  This is not true on the outside walls/windows nor the couch arm.  No matter how fast I move my controller my hand hits those solidly.  I started to investigate and troubleshoot why (colliders and rigidbody settings are all the same and I experimented with does the collider's thickness make a difference so I increased the Y size of the collider but found that this did not solve the issue).  I've tabled this investigation for another day but I would like to figure it out.

I added a secret message to the back of the clock (Job Sim inspired) and I gave the clock a box collider, a rigidbody, and a XR Grab Interactable component so that this can be picked up.

I also added a socket hook (a duplicate of the art hook and socket) and I adjusted the settings on both the socket and on the clock so that this should work for socketing the clock to the wall.  I also adjusted the size of the sphere collider to be smaller and more akin to the size of the clock.

I also moved the clock from under the -- INTERACTIVE STATIC -- menu to the -- DYNAMIC -- menu, now that this clock is fully 

A few things need fixing with the clock.

1.) That socket isn't working correctly and the clock falls down when starting the game.  This needs to be troubleshot and fixed.

2.) The clock does not respond to distance grabbing and the raycast, currently and this needs to also be fixed.

3.) The shadow for the clock is currently baked and I need to set this back to dynamic so that that shadow is no longer baked now that the clock is an interactable.  This also needs to be fixed.

4.) When picking up the clock for the first time rotating the clock is difficult.  I'm not sure why this is but when I drop the clock and re-pick up everything is fine again.  I also notice the first time I pick this up (albeit it is half-way clipped through the wall after falling) the attach is not being used.  Maybe once the other pieces have been fixed this will resolve itself.  If not I need to investigate, troubleshoot and fix this too.

The art socket on the north wall was way too large.  I resized it to be an appropriate radius and more akin to the other art sockets.

The north wall art can be picked up via distance grabbing while the art on the east and south walls cannot.  I don't recall if I disabled those on purpose due to collisions while being pulled towards you or not.  I need to test that and to at least make all the art work the same.  This is something I need to fix.

I fixed the cabinet door's rigidbody settings to be Continuous Speculative so that these would properly collide with the shelf colliders inside the cabinets.  I choose Continuous Speculative as I notice that my pseudo body collider (and more specifically the Character Controller that tilts forward when I lean forward) also has the ability to push in on these doors hard enough it skips through the collider (where as pushing with the physics hands does not) and I wanted to see ifi Continuous Speculative had the ability to better stop this from happening.  This had little to no effect on the cabinets when pushing against them with my pseudo collider so I may change this back to Continuous Dynamic later.  

I don't have a great solution for the character controller pushing on the doors.  I could make these not interact but then any door (including the front door, at least when opened -- as I have a wall collider in front of the closed front door, currently to prevent this behavior) you'd be able to walk through.  Including when the front door is open, and that isn't a behavior I necessarily want unless this is really problematic.  I may need to come up with a different solution for this.

I ran into one weird bug in which when play testing I am facing the wall (punch lists) and all of the Continuous Motion controls are reversed (right is left, left is right, forwards is backwards and backwards is forwards.  I thought this was either a bug introduced at random or something I inadvertently changed in the project.  I closed and reopened the project and the same behavior persisted.  I then closed Unity, Unity Hub, Oculus and I turned off my Oculus Quest 2 headset.  I then turned my Oculus Quest 2 back on and I reopened Unity Hub, Unity (and my project), connected via Airlink and play tested again and the problem went away and everything was normal again.  I think taking my headset off and letting it go to sleep while making changes in Unity caused the issue.  Maybe something to do with my standing play space in the headset.  I've seen this once before and it also reverted itself.  I'll watch out for this in the future.

I also updated the version number and the commit date on the Welcome Menu screen.

Up next to fix:
 
The four clock pieces listed above.

1.) That socket isn't working correctly and the clock falls down when starting the game.  This needs to be troubleshot and fixed.

2.) The clock does not respond to distance grabbing and the raycast, currently and this needs to also be fixed.

3.) The shadow for the clock is currently baked and I need to set this back to dynamic so that that shadow is no longer baked now that the clock is an interactable.  This also needs to be fixed.

4.) When picking up the clock for the first time rotating the clock is difficult.  I'm not sure why this is but when I drop the clock and re-pick up everything is fine again.  I also notice the first time I pick this up (albeit it is half-way clipped through the wall after falling) the attach is not being used.  Maybe once the other pieces have been fixed this will resolve itself.  If not I need to investigate, troubleshoot and fix this too.
 
Some of the art being able to be grabbed via distance grabbing while others can not.  While I the idea of distance grabbing the art for the ease of use, I'm not sure how much destruction that may cause if distance grabbing from half way around the room and having it collide with everything in-between the player and the art.  So it may be better to just turn this off for all art instead of turning it on.  I can play test both to see which is better.

Determine if there is a good solution for the character controller colliding with the cabinet doors when leaning forward. 

Determine why my physics hands can clip through the dinning room table and chairs when at a fast enough speed.  Try and make this work more like the couch or outside colliders.  Test with other furniture to see if anything else in the room allows this to happen.  Compare and contrast to troubleshoot.

Thin items like photos from the polaroid camera and my punch list sheets are still sometimes getting stuck under the floor and I need to troubleshoot that more to try and fix.

Updating the Interactive board and/or punch lists.  I'm running out of room on my punch lists and I have no more room to add additional punch lists, so I'll have to decide how I wish to use these moving forward.  I still love the idea of having bugs and/or future features viewable in VR and I have a lot of future ideas (both from ideas I've come up with and that my students have come up with that could be added).

If I get that working I feel like I have a lot of the bug pieces in my room fixed.  I'll have to go back to my bug list to check to be sure, but off the top of my head there aren't any others that are coming to mind that I need to fix.  At this point I may choose a new feature to add to this room, just to continue my (and my student's) learning.
@mattdway
mattdway committed on Dec 30

12-31-22 v2.8.2 12-31-22 Commit Up next to fix:

These four clock pieces have been fixed.

1.) The clock socket has been fixed. This was a combination of the socket's Interaction Layer Mask settings to include the clock, the positioning of the socket on the wall (it needed to come forward away from the wall just a tad) and adjusting the rotation of the socket on the wall (180, 180, 180) so that when the clock did socket it didn't socket to the outside of the wall. Adjustining these three pieces allowed the clock to socket to the wall without any further issue.

2.) I also adjusted the LeftHand Ray and Righthand Ray Interaction Layer Mask to include the clock and to exclude Art. This way the art could not be picked up via raycast (I tested and this did cause a lot of distruction when calling for the large painting from across the room -- anything it hit between its original position and my position went flying) and so that I could grab the clock from afar.

This was also a great reminder to be sure to update these Interaction Layer Masks (as these are not set to Everything) whenever a new item has been added to the room otherwise these won't be able to be picked up via distance grabbing. I checked and all items that should be able to be grabbed with distance grabbing can be and anything not able to be grabbed by distance grabbing: the doors, the drawer and the art) cannot.

3.) I rebaked my lighting to get rid of the static shadow behind the clock, now that the clock is dynamic and is able to be grabbed.

To do this, I adjusted my lighting to make sure that every light in my room (minus the flashlight) were set to baked. This includes: Chandellers, Entire_Room_Point_Light (which I had thought was legacy and should be set to real time and disabled but in doing this I found out that most of my room was in shadows, so I changed this back to baked and rebaked my lighting for my room to correct), Outside_Directional_Light, Fireplace_Modern, Lamp_Floor_Double, Lamp_Table_Red and Sconces.

I also went through and made sure that all of my "-- STATIC --" and all of my "-- STATIC INTERACTIVE --" and that all of my "-- LIGHTS --" game objects were set to "Static" in the inspector, to the right of each game object's name. Under "-- DYNAMIC --" I also checked that nothing there was set to static with the exception of these items:

Under "-- DYNAMIC --" > "Cabinets" > the following items were set to static: "Cabinet With Drawer" "Left side panel" "Shelf" "Top" "Right side panel" "Bottom panel"

"Door and "Drawer" do not have the "Static" checkmark, however, since those objects are grabable and are ment to move.

Under "-- DYNAMIC --" > "Cabinets" > "Cabinets With Two Doors" > "Cabinet_Modern_Left" and "Cabinet_Modern_Right" the following items were set to static: "Cabinet_Body"

"Cabinet_Door_Left" and "Cabinet_Door_Right" and their child object "Handle" do not have the "Static" checkmark, however, since those objects are grabable and are ment to move.

I used the trick of searchingi for t:light in the Hierarchy search bar to expose all the lights, I then used "Ctrl" + "A" to select all, I held down the "Ctrl" key and then single left-clicked on "Lightsource_FLashlight_Yellow_Spot Light" and then in the "Inspector" pane under "Light" I changed the "Mode" parameter from "Realtime" to "Baked."
Then, under the "Lighting" tab or "Windows" > "Rendering" > "Lighting" I single left-clicked on the "Generate Lighting" button to render a new lightmap.

I made the mistake of under the "Lighting" tab > "Enviorment" > "Skybox Material" of having the "MegaSun" skybox selected. When baking a lightmap the lightbox light color and reflection colors are included and this gave a very washed out orange tint to everything in my lightmap. To fix this I had to temporarily change the "Skybox Material" back to "Sky-Default" then rebaking my lightmap again. After this baked I then changed the "Skybox Material" back to my "MegaSun" skybox, of choice.

4.) I fixed the roation on of the clock when picking it up. I had to go into "Edit" > "Project Settings" > "Physics" and I had to disable the physics interactions for both "Clock/Clock" and "Clock/Pseudo Body" so that the clock couldn't interact with either. Once set this object rotated as normal. I also doublechecked that "Smooth Position" and "Smooth Rotation" were both checked in the "XR Grab Interactable" component settings. They were.

I turned off raycast distance grabbing for all objects of the "Art" layer. Due to the large size of this art and its collisions this caused too many issues distance grabbing from across the room. Art must be grabbed using "Direct Interactable", now, only.

I moved the dinning room chairs and the hidden teleportation anchor mats back so that it is easier to climb onto the chairs to climb onto the table to reach the shelf where the record player, record, and books live. From this vantage point players can also directly reach the clock and the painting, if they so wish.

I moved the "Measuring Stick" game object from static to "-- DYNAMIC --" as this is a grabable object and this is where this should live. The "Measuring Stick" is a disabled game object used as a quick referene for sizing objects to all be the same. Yesterday I changed the height of this measuring stick to 0.3048 meters, which is 12 inches. The same length of a standard ruler.

I also updated the version number and the commit date on the Welcome Menu screen.

To Fix Next:

Writing a script for the Water Bottle Flip Challenge to detect when there is a floor collision with either the top, sides or bottom and to play a corresponding sound when that happens.

Determine if there is a good solution for the character controller colliding with the cabinet doors when leaning forward.

Determine why my physics hands can clip through the dinning room table and chairs when at a fast enough speed. Try and make this work more like the couch or outside colliders. Test with other furniture to see if anything else in the room allows this to happen. Compare and contrast to troubleshoot.

Thin items like photos from the polaroid camera and my punch list sheets are still sometimes getting stuck under the floor and I need to troubleshoot that more to try and fix.

Updating the Interactive board and/or punch lists.  I'm running out of room on my punch lists and I have no more room to add additional punch lists, so I'll have to decide how I wish to use these moving forward.  I still love the idea of having bugs and/or future features viewable in VR and I have a lot of future ideas (both from ideas I've come up with and that my students have come up with that could be added).

If I get that working I feel like I have a lot of the bug pieces for all the current items added to my room fixed. I'll have to go back to my bug list to check to be sure, but off the top of my head there aren't any others that are coming to mind that I need to fix.  At this point I may choose a new feature to add to this room, just to continue my (and my student's) learning. @mattdway mattdway committed on Dec 31

01-18-23 v2.9.1 01-18-23 Commit

01/17/23 -
So far, looking at the door intensely hasn't solved the issue.  Maybe if I were The Rock.  Looking at the door layers, hinge joint settings, connected articulated and rigidbodies, checking position, checking the door handle settings haven't worked either.  Nor are there any major differences between the hinge joints on the cabinets and the hinge joints on the door.  
 
I tried removing the connected articulated and the rigidbodies from the hinge joints, that didn't work.  I tried resetting the hinge settings and re-setting up and that didn't work.  I tried deleting and recreatring the hinge joints from scratch and that didn't work.  
I tried copying the hinge joint component from the cabinet, flipping its rotation to match the door and testing and that didn't work.  I tried deleting and re-adding the motorized script and re-setting up and that also didn't work.  
 
I also tried deleting the door prefab files and re-adding from the starter file from Unity but that also didn't work.  So far I'm batting 100%.
 
Short of drawing myself a key and a keyhole in hopes that this will magicly open the door, I'm running out of ideas.
 
At the moment I am downloading the 12-30-22 commit from GitHub to see if the door was working on this date.  I'll just keep going with commits until I find one that works and then I'll see if I can take the door and export that as a package I can bring into my current project.  Not sure if that will work since the Environment is already a prefab and unpacking that breaks more than it fixes.  But I can maybe bring that into the current prefab and delete within the prefab editor.  It's a working theory at least.  Something is off about this door and I am not visually figuring out what that something is (at least not yet).
 
So the good news is that my door in my VR project was working perfectly on 12-30-22 but not on 12-31-22 and beyond.  So now I just have to figure out how to export this from one project and into the other.  Or to have both projects open at the same time to see if I can figure out what is causing the issue in the first place.   
 
It's already a child of a prefab (and thus a prefab itself) but not in the sense this is in the prefabs folder.  So my other changes aren't currently captured in that prefab (they are on top of the prefab in my Hierarchy).  So I can't simply drag the door parent to the prefabs folder.  It also wouldn't help to take the \Assets\_Course Library\_Prefabs door prefab and to export that as that only contains the original door prefab as provided by the course (a door frame, a door and a door handle) and not any of my changes.  So it's a puzzle and a challenge.

01/18/23 -
Heh, so I stayed up half the night but I got my door working, finally.  
 
I compared side by side with my original project and every setting was the same so I still don't know what the problem was.  But I started off taking the entire door structure, I figured out how to make that a prefab and then I copied that prefab over to my other project.  
But then, because I had to unpack my Environment prefab, which also included my room prefab, in order to make the door a prefab, my lighting was all messed up.  So I tried undoing but the lightmap was still messed up.  So I tried rebaking my lightmap, but that didn't fix it and the colors and lack of realistic shadows was weird.  
 
I also noticed issues at this point with my two door colliders.  The collider that prevents you from walking through the door and that pushes back if you lean into the door never deactivated , the door button did nothing (although opening and closing the door manually was OK at this point).  My door open detection script was also not working.
 
At this point I decided to adopt the 12-30-22 project as my main project because I was unsure how to fix the lighting issue that had occurred from unpacking my prefabs.  
It seemed even though I did Ctrl + Zs the lightmap was still irreparably changed.  So at this point I went into my old project, I made prefabs out of everything I had modified with a script or some setting change and I moved all those things over to the 12-30-22 folder.  I also went into my github folder (where my old project was), I selected all and I copied those items over to my 12-30-22 folder but I told Windows to skip any files that were already there.  The purpose of this was to simply make sure that all the other files not in the 12-30-22 folder were copied there, including all the extra git files like my readme.md, my log file and the gitignore files.  This way hopefully I have a complete project that doesn't freak GitHub out when I go to replace my old project with the new one (currently this is in a completely separate folder structure) and I make my next commit.
 
So, in my 12-30-22 project.  I've made all the same changes I'd made on 12-31-22 (thanks to my dev log and record keeping of all the changes made) and by making use of things like my sockets prefab and my clock prefab and my cabinet prefab, so that I didn't have to try and make all the same changes again (or possibly miss making a change needed).
 
I fixed all three cabinets with the freeze position and rotation script and I also changed all the cabinet doors and drawers with a "Wall" tag, which means there is also pushback when trying to lean into any of (just those) items.
 
I found an issue with corrupt Unity ad video files for the TV and tablet so I copied my entire _Course folder from my old project to the 12-30-22 project, replacing all files.
 
This reminds me, I need to check the Super Mario World video file tomorrow to make sure that is still working.
 
This also reminds me that tomorrow I need to update the version number on the main tutorial board.
 
I also fixed the tablet black attach point angle and orientation as I was having to twist my wrist in a weird way to use it.  This is probably because my hand model orientation has since changed since the days where I had static hands.
 
A lot of my door scripts/colliders weren't working at this point and some hidden collider was preventing my raycast from reaching the tutorial board from the starting position, so I troubleshot those.  I found my door collider, my door open detection collider and my disable door colliders were not correctly in place and in the middle of my room so I repositioned and resized each to be the right shape and size to catch the door just where I wanted it.  Those misplaced colliders were also duplicated (part of my prefab and part of my 12-30-22 project) so I deleted the prefab versions and kept the other.  But then I also had to relink all the scripts and game objects to get these to work again.
 
Now there are no colliders in the middle of the room and my Door button correctly opens and closes the door again, it correctly detects if the door is open or closed and it correctly disabled the door collider when opened part way (starting about at the point and angle of being opened where the player could slip past the door).
 
I fixed the "Matt's Photos" red pushpin that was stretched to unrealistic proportions to make this look more like the object it is, a pushpin.
 
I double checked the Bon Apatite sign to make sure this was readable (I had apparently fixed this prior to my 12-30-22 commit (by making this text larger and making sure it wasn't stretched via the scale and adjusting the font color and font properties), but I couldn't find mention of this in my previous log, so I might have forgotten to note that previous change.
 
I play tested as much as I could in the room and eveyrthing so far is looking pretty good.  I'll play test some more tomorrow before commiting this new version to GitHub.  I want to try and make sure any other known bugs have been addressed before pushing to the cloud.
 
That's it for tonight.

I added random sounds to my Dalek figure, just because I could. :-D  I added random sounds to my Dalek figure, just because I could. :-D  When you pick up the Dalek and activate (press the trigger on the VR controller) a random Dalek clip plays (out of ten total).  I was going to write my own script to play random sounds but Unity had included their own in the CreateWithVR course so I just ended up using it instead.

Everything looks good!
 
Door and Door button are working correctly, my two three colliders are working correctly.  
 
I fixed the attach transform for the dart gun (as it was being picked up and pushed/clipping through where the body would be and tilted upward.  I changed this so it's straight and away from the body.  
 
I added an attach transform to the Dalek so that when you pick it up, it's facing you.  Pressing the trigger button plays a random clip of about 10.  
 
I fixed the magnifying glass so that it now magnifies either direction.  There's an attach transform on it so you have to sort of bend your wrist to see the other side but before it was like a mirror (showing what was behind you) on the backside instead of being identical to the front side.  I also fixed the magnification so that it magnified more without clipping through the wall and showing outside the room.
 
I fixed the Mario clip (which was corrupt from the download from the LFS (Large File Storage) so I copied the videos back over from my other project (the one that went pear shape) and that is working well now.
 
I fixed the tablet so that it's rotation is correct (not upside down) and so that it's tilted slightly back and at about the same angle as the hand holding it.
 
I didn't go through the physics tutorials today (I've watched them before -- I just haven't built them) - making sure my project was restored and again whole and working was more important - so the climbing mechanic is still yet to come. 
 
I'm going to move this over to the folder where my CreateWithVR room was before, I'm going to make up the log files and change the version number on the welcome (tutorial) screen and then I'm going to make sure this commits and pushes OK.  That'll be a good stopping point for tonight.  But everything is looking good again. 

If I didn't have version control I'd probably be spending weeks trying to get everything broken fixed again so it's a good thing that I was able to find and download a former commit that was working and that I had the dev log to be able to see exactly what I had done since that commit so I could put everything back together again.

One of my favorite scripts I've ever written.  
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WateringCanDropUpright : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Floor" | other.gameObject.tag == "Floor" | other.gameObject.tag == "Furniture" | other.gameObject.tag == "Untagged")
        {
            //Debug.Log("Rotating Game Object");
            float currentY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(0, currentY, 0);
        }
    }
}
 
This is attached to the watering can and It causes the watering can's X and Z axis to reset to 0 whenever it collides with another object.  Maybe not realistic (although I am ***THAT*** good at the water bottle flip challenge.   ) but now there is no more listening to "glug glug glug" every time the watering can is dropped.  Yes, with physics you can still knock it over and it sometimes doesn't detect that collision but now if you pick it up and drop it, it drops upright, which fixes the issue.   I just spent the last 8 minutes throwing the watering can at every object I could and watching it land and upright.  Sometimes there is a slight jitter (where it may detect more than one collision depending on how it lands, correcting itself twice) but it's still better than before.
 
I also tested everything and so far it's looking pretty good.  I found one slight glitch on the cabinet doors.  If the doors are open and push against them with your pseudo body instead of locking the rotation it's pushing all the way open.  The script was working and I think what I'm going to do is to use the above script to better this.
 
I also added attach transforms to the Bon Apatite sign and to the Polaroid Camera.  

OK, I fixed the open cabinet doors breaking when pushing against them.  The cabinet doors and drawers are using OnCollisionEnter with a tag check now instead of OnTriggerEnter with a tag check.  This allows me to keep the collider as a collider for physics and to make sure objects don't fall through while also locks the x, y, z position and the x, y, z rotation of the rigidbody for the duration of the collision.  
I also set these doors and drawers with the tag "Walls" which also invokes Justin's code for pushback if leaning into those doors or drawers.  The pushback only happens when the doors and drawers are shut but it adds and addition bit of protection against the cabinet doors from being knocked around by the big brute of a player who otherwise might have run into it.
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CollisionFreezeRotCol : MonoBehaviour
{
    Rigidbody m_Rigidbody;
 
    //Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Tag Check Passed.  Freezing Position and Rotation");
            //Freeze Position and Rotation
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }
 
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Tag Check Passed.  Freezing Position and Rotation");
            //Unfreeze Position and Rotation
            m_Rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
 
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Tag Check Passed.  Freezing Position and Rotation");
            //Freeze Position and Rotation
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }
 
    void OnCollisionExit(Collision other)
    {
        Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Tag Check Passed.  Freezing Position and Rotation");
            //Unfreeze Position and Rotation
            m_Rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}

To Fix Next:

Writing a script for the Water Bottle Flip Challenge to detect when there is a floor collision with either the top, sides or bottom and to play a corresponding sound when that happens.

Determine why my physics hands can clip through the dinning room table and chairs when at a fast enough speed. Try and make this work more like the couch or outside colliders. Test with other furniture to see if anything else in the room allows this to happen. Compare and contrast to troubleshoot.

Thin items like photos from the polaroid camera and my punch list sheets are still sometimes getting stuck under the floor and I need to troubleshoot that more to try and fix.

Updating the Interactive board and/or punch lists.  I'm running out of room on my punch lists and I have no more room to add additional punch lists, so I'll have to decide how I wish to use these moving forward.  I still love the idea of having bugs and/or future features viewable in VR and I have a lot of future ideas (both from ideas I've come up with and that my students have come up with that could be added).  I'm about 1/3 of the way through laying this out but moved onto other parts of the project - just because of the amount of work involved and in not knowing if everything will fit or what the end result of this may look like.

If I get that working I feel like I have a lot of the bug pieces for all the current items added to my room fixed. I'll have to go back to my bug list to check to be sure, but off the top of my head there aren't any others that are coming to mind that I need to fix.  At this point I may choose a new feature to add to this room, just to continue my (and my student's) learning. 
@mattdway mattdway committed on Jan 18

01-23-23 v2.10.1 01-23-23 Commit
A fun little weekend project that started off as an example of how to write C# code that detects collisions turned into a creative project of my own to see how far I could flesh out all the different ideas I had in my head.

The original question was how to turn on a piece of machinery by pressing on the screen using collision.  I gave several examples of how to do this using OnTriggerEnter and OnCollisionEnter then I created a laptop of my own I could turn on using collision with a power button.  For this project I decided I'd make the laptop turn on and play a video when the power button was pressed.

The laptop asset I sourced from: https://assetstore.unity.com/packages/3d/props/electronics/hq-laptop-computer-42030

The Rick Astley video I got from: https://www.youtube.com/watch?v=dQw4w9WgXcQ

The broken laptop wallpapers I sourced from:
https://www.geckoandfly.com/19230/broken-screen-wallpaper-prank-iphone-ipod-windows-mac-laptop/ and https://wallpapersafari.com/realistic-broken-screen-wallpaper/

The laptop drop sound I sourced from: https://pixabay.com/sound-effects/search/dropped%20laptop/?manual_search=1&order=None but I shorted this and changed it's pitch and volume slightly.

I added my own screen object to this laptop, to replace the one that came with the asset.  I also added a reflection probe to that screen so that it looks like glass with blurry partial reflections as it moves around the room in different lights.

The laptop asset works as such.  It sits on the couch.  When you press the power button above the keyboard, the 'Rick Roll' "Never Gonna Let You Down" video plays on the screen.  It is set to play in a constant loop.  If you take the laptop and throw it against the wall or the floor the screen breaks and the video stops playing.  The broken screen here is lit but obviously broken.  If you press the power button again the Rick Roll video starts playing again but because the screen is broken you obviously can no longer see the video, you can just listen to the audio.  There is a counter involved and once the collider has reached a count of 4 the material of the screen is changed to a broken screen that is obviously off and the isBroken public variable is invoked, making it impossible to turn the laptop on further past this point.

Some of the ideas of having it continue to play past the first screen breaking and the counter were pitched to me by students.

I updated the version number and date on the welcome tutorial screen to reflect the current version.

I also was thinking about having one punch list in the future with interactive UI using a scrollbar and I found this video that will help me, I think, to achieve this: https://www.youtube.com/watch?v=wwInYfwD7q0 as well as this video: https://www.youtube.com/watch?v=TCixKyOGTRU
@mattdway mattdway committed on Jan 23

02-01-23 v2.11.2 02-01-23 Commit

Changes made between 01-27-23 and 02-01-23.

I changed the script for the laptop so that when the laptop is dropped the screen breaks but the video does not stop.  The screen may be broken but the video keeps on playing the Rick Roll audio.  I also increased the counter to 8 before entering the if statement so that the laptop need to be dropped (on average) 4 times before the laptop no longer boots. On average the laptop registers about 2 collisions per drop so this increases the number of drops before reaching the non-boot state to about 4 drops, from 2 before.

In this version I also added a whiteboard marker picker that stemmed from a question on Justin P. Barnett's Discord server here: https://discord.com/channels/830805044030079046/1068519782992850965  The question was how to change the marker's materials using three sliders, representing the red, green and blue (RGB) values seperately.  I jumped in to help and got stuck at a particular point and the user choccy was able to get take my script and to get a final version of his own working.  I decided to implement this in my project as I had previously thought about adding a feature like this, only I had envisioned having static materials that would be swapped out via some sort of interface (maybe some spheres via collision detection).  But I liked this idea much better because the code is shorter and simplier and because there are multiple copies of the same material attached to different parts of the same marker.  

In my case the material are attached to the large cylinder and small cylinder of the marker lid, to the middle part of the handle, to the visible tip (which is a ProBuilder shape (for show only) that mimics the shape of an actual Expo marker tip) the invisible tip (which is sphere shaped for better and more consistant movement across the whiteboard material).  

Previously my Expo whiteboard marker label was made up of a material containing a 2D texture wrapped around the shape.  But because that material's wrapped color and font were set via a jpg graphic I made the change to the handle, recreating this as three parts that fit perfectly together without any overlap.  This allowed me to apply the color material (named Marker_One and Marker_Two) to the middle section of that handle.  I then applied two sprites brought in as .png (that consisted of a circle with a line above and below in a graphics program) into the project.  I set the remainder of the graphic as transparent, within the graphics program, with the exception of the white circle, which remained white, and I copied this over to the Assets folder in Windows Explorer of my Unity project.  The transparent pieces were so that the material color on the middle section of the handle would still show through.

After bringing in the sprint I changed the "Texture Type" of the png, in the Inspector window, to "Sprite (2D and UI)."  I then was able to assign this to a new UI Image game object I created in the Hierarchy.  I then scaled this UI Image game object until it was an oval of about the right shape and size. 

I then rotated that oval down and I sunk it back as far as I could into the handle.  This way it was not floating in front of the handle but looks to be a part of it.

I duplicated that oval and then moved it to the other side of the marker (as Expo markers have the logo on both sides of the marker).

The left and right handles I applied a Faded_White material to.

Lastly, I imported a new Expo font into Unity that I downloaded from a font website.  Under the Assets folder I created a sub-folder called "Fonts" and I moved the two font .ttf files into this folder.  This makes those fonts available to import into Windows.  Then, in Unity via the Windows menu > TextMeshPro > Font Asset Creator I set up the Exposition and Exposition Shadow as new fonts in TextMeshPro.  
I created a new TextMeshPro text box and I used that to write out the word EXPO.  I bolded this and duplicated that TextMeshPro textbox to double up and make the font thicker.  I then played with its scale until I got it looking roughly the same shape and size as the original logo.  The red marker is using TextMeshPro and a material whereas the blue marker hasn't been set up yet and is still the imported graphic.

My  Marker One Color Picker sliders script is as follows and I also added code to change the font at the same time as I change the materials.  I had to play with the shader lighting of those TextMeshPro game objects in order to have this match the color of the Marker_One material.  This appeared as lighter and neon prior.  

The Whiteboard Marker Color Pickers was placed under the -- INTERFACES -- game object and the Whiteboard placed under the -- DYNAMIC -- game object.  The Whiteboard Accessories child object contains the two marker and eraser game object.

My next idea was that there would be two markers and buttons for toggling the showing and hiding of the Marker Color Picker slider interface (canvas) for the first marker and then the second marker. I created two UI buttons named Marker One and Marker Two and I set their background color the same as the the wall color.  I then set up the OnClick() event of each button to show and hide the appropiate interfaces.  The Marker Two Color Picker was then keyed into the second marker and the Marker One Color Picker was keyed into the first marker via the script's listeners and link boxes that linked to the specific components of the first marker and second marker that contained those color materials.  

For the sliders working in VR piece (per https://www.youtube.com/watch?v=BZt74PVb7sM) I needed to add a "Tracked Device Graphic Raycaster" component to the canvas hosting my sliders.  Because I already had working UI interfaces in my VR project I already had the "XRUI Input Module" added as a component of my EventSystem game object.  Lastly, through troubleshooting I disovered my TextMeshPro headers to the left ("Red Value", "Blue Value", "Green Value") were too large (width of either 100 or 200) and that these overlapped over the sliders, making it impossible to grab the sliders.  I resized these appropiately and tested.  I found that scaling wasn't an issue and I also found that a known bug that could interfer with the ability to be able to detect the slider in a VR project (due to depth issues and how the sliders work) was not an issue.  I did end up increasing the Slider Background (game object) "Raycast Padding" from 0 (for Left, Right, Top and Bottom) to 1 across the board, just as a precaution, however (per this forum post here: https://forum.unity.com/threads/vr-ui-slider-issues.1025887/). I also needed to change my raycast masking to allow the sliders to be manipulated using my raycasts.

I also added three TextMeshPro game objects that I positioned to the right of the sliders and I added code to my MarkerColorPickerSlider script that grabbed the value of each slider, updated using listeners so that this would update real time, and wrote that to each textbox.  I made all of my text and my slider handles match as being either red text, green text or blue text to signify the value being displayed). 

I also went into play mode and I moved the RGB sliders until I arrived at the same shade red (by looking at the values of each material for the red color and the blue color under Assets > Materials).  I then noted the slider value for each of the three: RGB and then I stopped play mode and I set those slider values in my Inspector.  This way when the user starts the game the first marker is the same shade red and the second marker is the same shade blue as seen in the scene view.  The user can then adjust the colors of the markers using the slider but because those changes are being applied to the material on the marker game object and not the material in the Assets > Materials folder that material color change is not saved when play mode is exited in the Unity Editor.  

Both the marker color and the values update in real time as the sliders are moved across the screen using the raycast.

There was also a missing piece to having that material color update to where the render line would use the newly selected color changed by the RGB sliders.  While the material color and font color both updated visually on screen, in real time, the material was still drawing in red and blue, the original set material color.  The change needing to be made (thanks to choccy on Discord, who knew immediately what change needed to be made) was adding _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray(); to the Update() method of the WhiteboardMarker.cs script.

My oval sprite files somehow were removed from my Images folder so I had to download those from my GitHub repository (from yesterday's commit) where I moved these back into the assets folder and re-set back up.

I tested and everything regarding the marker color picker now worked from having the marker start out the same red and blue as in the scene view, changing the color or marker one and two, from switching between the two sliders succesfully, from changing each to different colors and drawing on the board with those same colors, with the Expo label being positioned correctly, with having that font color change at the same time as the material and matching that material color, to being able to erase the board using the eraser.

MarkerColorPickerSlider.cs:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarkerColorPickerSlider : MonoBehaviour
{
    public GameObject largerCylinderLid;
    public GameObject smallerCylinderLid;
    public GameObject handleMiddle;
    public GameObject visibleTip;
    public GameObject hiddenTip;
    public GameObject expoFontOneOvalFront;
    public GameObject expoFontTwoOvalFront;
    public GameObject expoFontOneOvalBack;
    public GameObject expoFontTwoOvalBack;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public TextMeshProUGUI redValueDisplay;
    public TextMeshProUGUI greenValueDisplay;
    public TextMeshProUGUI blueValueDisplay;
    private Material largerCylinderLidMaterial;
    private Material smallerCylinderLidMaterial;
    private Material handleMiddleMaterial;
    private Material visibleTipMaterial;
    private Material hiddenTipMaterial;
    private TextMeshProUGUI expoFontOneOvalFrontTMP;
    private TextMeshProUGUI expoFontTwoOvalFrontTMP;
    private TextMeshProUGUI expoFontOneOvalBackTMP;
    private TextMeshProUGUI expoFontTwoOvalBackTMP;

    void Start()
    {
        Renderer largerCylinderLidRenderer = largerCylinderLid.GetComponent<Renderer>();
        largerCylinderLidMaterial = largerCylinderLidRenderer.material;

        Renderer smallerCylinderLidRenderer = smallerCylinderLid.GetComponent<Renderer>();
        smallerCylinderLidMaterial = smallerCylinderLidRenderer.material;

        Renderer handleMiddleRenderer = handleMiddle.GetComponent<Renderer>();
        handleMiddleMaterial = handleMiddleRenderer.material;

        Renderer visibleTipRenderer = visibleTip.GetComponent<Renderer>();
        visibleTipMaterial = visibleTipRenderer.material;

        Renderer hiddenTipRenderer = hiddenTip.GetComponent<Renderer>();
        hiddenTipMaterial = hiddenTipRenderer.material;

        expoFontOneOvalFrontTMP = expoFontOneOvalFront.GetComponentInChildren<TextMeshProUGUI>();
        expoFontTwoOvalFrontTMP = expoFontTwoOvalFront.GetComponentInChildren<TextMeshProUGUI>();
        expoFontOneOvalBackTMP = expoFontOneOvalBack.GetComponentInChildren<TextMeshProUGUI>();
        expoFontTwoOvalBackTMP = expoFontTwoOvalBack.GetComponentInChildren<TextMeshProUGUI>();

        redSlider.onValueChanged.AddListener(UpdateRedValueDisplay);
        greenSlider.onValueChanged.AddListener(UpdateGreenValueDisplay);
        blueSlider.onValueChanged.AddListener(UpdateBlueValueDisplay);
    }

    void Update()
    {
        Color color = new Color(redSlider.value, greenSlider.value, blueSlider.value, 1.0f);
        color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));

        largerCylinderLidMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        smallerCylinderLidMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        handleMiddleMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        visibleTipMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        hiddenTipMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));

        expoFontOneOvalFrontTMP.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        expoFontTwoOvalFrontTMP.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        expoFontOneOvalBackTMP.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        expoFontTwoOvalBackTMP.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
    }

    private void UpdateRedValueDisplay(float value)
    {
        redValueDisplay.text = value.ToString();
    }

    private void UpdateGreenValueDisplay(float value)
    {
        greenValueDisplay.text = value.ToString();
    }

    private void UpdateBlueValueDisplay(float value)
    {
        blueValueDisplay.text = value.ToString();
    }
}

WhiteboardMarker.cs:

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardMarker : MonoBehaviour
{
    //The transform component of the marker's tip
    [SerializeField] private Transform _tip;
    //The size of the pen, in pixels
    [SerializeField] private int _penSize = 5;

    //The renderer component of the marker's tip
    private Renderer _renderer;
    //An array of the marker's color, repeated _penSize * _penSize times
    private Color[] _colors;
    //The height of the marker's tip
    private float _tipHeight;

    //The result of the raycast from the marker's tip
    private RaycastHit _touch;
    //The Whiteboard component of the object that the marker's tip is touching
    private Whiteboard _whiteboard;
    //The texture coordinates of the point where the marker's tip is touching the whiteboard
    //The texture coordinates of the point where the marker's tip was touching the whiteboard on the previous frame
    private Vector2 _touchPos, _lastTouchPos;
    //Whether the marker's tip was touching the whiteboard on the previous frame
    private bool _touchedLastFrame;
    //The rotation of the marker on the previous frame when the marker's tip was touching the whiteboard
    private Quaternion _lastTouchRot;

    //Start is called before the first frame update
    void Start()
    {
        //Get the renderer component of the marker's tip
        _renderer = _tip.GetComponent<Renderer>();
        //Set _colors to an array of the marker's color, repeated _penSize * _penSize times
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        //Set _tipHeight to the height of the marker's tip
        _tipHeight = _tip.localScale.y;
    }

    //Update is called once per frame
    void Update()
    {
        //Execute the Draw method
        Draw();
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
    }

    private void Draw()
    {
        //Cast a ray from the marker's tip in the direction the marker is facing
        if (Physics.Raycast(_tip.position, transform.forward, out _touch, _tipHeight))
        {
            //Debug.Log("Marker is Touching Something");
            //If the ray hits an object with the "Whiteboard" tag
            if (_touch.transform.CompareTag("Whiteboard"))
            {
                //Debug.Log("Marker is Touching the Whiteboard");
                //Get the Whiteboard component of the object that the marker's tip is touching
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }

                //Get the texture coordinates of the point where the ray hit the whiteboard
                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                //Convert the texture coordinates to pixel coordinates on the whiteboard's texture
                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));

                //Checks if the x and y pixel coordinates are within the bounds of the whiteboard's texture. If either x or y is less than 0 or greater than the width or height of the whiteboard's texture, exits method
                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x) return;

                //Checks if the marker's tip was touching the whiteboard on the previous frame
                if (_touchedLastFrame)
                {
                    //Set a square of pixels on the whiteboard's texture to the color of the marker
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    //Interpolate between the current pixel coordinates and the pixel coordinates from the last frame to create a line between the two points
                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        //Calculate the interpolated pixel coordinates
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        //Set a square of pixels on the whiteboard's texture to the color of the marker
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                    }

                    //Debug.Log("Locking Rotation To " + _lastTouchRot);
                    //Lock the rotation of the marker to the rotation on the previous frame when the marker's tip was touching the whiteboard
                    transform.rotation = _lastTouchRot;

                    //Apply the changes to the whiteboard's texture
                    _whiteboard.texture.Apply();
                }

                //Update the last touch position and rotation
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                //Set _touchedLastFrame to true
                _touchedLastFrame = true;
                return;
            }
        }

        //If the marker's tip is not touching the whiteboard
        _whiteboard = null;
        //Set _touchedLastFrame to false
        _touchedLastFrame = false;
    }
}

Lastly I fixed the physics issue with the brown notebook when picking it up.  I had internal pages set to the Interactable layer as well as the outside and those physics were allowing physic interactions and collisions to occur.  The fix was to set all internal components of that notebook to the Non-Interactable layer.  Those two layers aren't allowed to interact with one another via the Physics Matrix.

This fixed the book jumping around in your hand but I also noticed there is a bug/issue with the text showing up as black when tilting the pages away from the player.  So if the book is held back at an agle the text fades and is no longer visible.  I'll have to look into this to see if TextMeshPro has occulsion when not looking at it directly on and to see if there is a way to fix that.  I played with lighting settings for that TMP component but that wasn't the issue.

I updated the version number and date on the tutorial welcome board.

To Fix Next:

Writing a script for the Water Bottle Flip Challenge to detect when there is a floor collision with either the top, sides or bottom and to play a corresponding sound when that happens.

Determine why my physics hands can clip through the dinning room table and chairs when at a fast enough speed. Try and make this work more like the couch or outside colliders. Test with other furniture to see if anything else in the room allows this to happen. Compare and contrast to troubleshoot.

Thin items like photos from the polaroid camera and my punch list sheets are still sometimes getting stuck under the floor and the area rug and I need to troubleshoot that more to try and fix.

Updating the Interactive board and/or punch lists.  I'm running out of room on my punch lists and I have no more room to add additional punch lists, so I'll have to decide how I wish to use these moving forward.  I still love the idea of having bugs and/or future features viewable in VR and I have a lot of future ideas (both from ideas I've come up with and that my students have come up with that could be added).  I'm about 1/3 of the way through laying this out but moved onto other parts of the project - just because of the amount of work involved and in not knowing if everything will fit or what the end result of this may look like.

I also was thinking about having one punch list in the future with interactive UI using a scrollbar and I found this video that will help me, I think, to achieve this: https://www.youtube.com/watch?v=wwInYfwD7q0 as well as this video: https://www.youtube.com/watch?v=TCixKyOGTRU

If I get that working I feel like I have a lot of the bug pieces for all the current items added to my room fixed. I'll have to go back to my bug list to check to be sure, but off the top of my head there aren't any others that are coming to mind that I need to fix.  At this point I may choose a new feature to add to this room, just to continue my (and my student's) learning.

Something I started to dig into was a climbing mechanic and I've created a duplicate scene of my room, I scaled it up to make it larger, I rebaked the lighting (using the MegaSun Eviorment, which gave the entire room a very cool, soothing, golden glow. I removed all the furniture and other interactables keeping only the overhead lighting and the mirror and I added a vertical ladder, horizontal ladder (across the ceiling) a climbing poll and a rock climbing wall on the east window made of different shapes and colors.  However, in writing the script I realized that my version of XRIT for this room is not new enough to contain a namespace and methods needed to create a climbing anchor and it doesn't appeear that there was a different method avaialable before.  So to proceed I'm going to have to puzzle out how to upgrade XRIT and all other Project Manager plugins and to fix all errors that occur in upgrading, before building a climbing mechanism will be possible.  This is something on my short list of things to learn sooner rather than later.
@mattdway mattdway committed on Feb 01

02-02-23 v2.11.2 02-01-23 Commit
I added scripts and logic for my bottle flip challenge.

using UnityEngine; public class BottleFlipChallengeWin : MonoBehaviour
{
    private bool _collisionActive = false;
    private float _collisionStartTime = 0f;
    private AudioSource _audioSource;     private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }     private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.tag == "Floor")
        {
            //Debug.Log("Tag check passed. Setting _collisionActive and _collisionStartTime");
            _collisionActive = true;
            _collisionStartTime = Time.time;
        }
    }     private void OnTriggerStay(Collider other)
    {
        if (_collisionActive && Time.time - _collisionStartTime >= 1f)
        {
            if (other.tag == "Floor")
            {
                //Debug.Log("Collision active for more than 1 second. Playing audio source file.");
                _audioSource.Play();
                _collisionActive = false;
            }
        }
    }     private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Setting _collisionActive to false");
        _collisionActive = false;
    }
}

using UnityEngine; public class BottleFlipChallengeLose : MonoBehaviour
{
    private bool _collisionActive = false;
    private float _collisionStartTime = 0f;
    private AudioSource _audioSource;     private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }     private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.tag == "Floor")
        {
            //Debug.Log("Tag check passed. Setting _collisionActive and _collisionStartTime");
            _collisionActive = true;
            _collisionStartTime = Time.time;
        }
    }     private void OnTriggerStay(Collider other)
    {
        if (_collisionActive && Time.time - _collisionStartTime >= 1f)
        {
            if (other.tag == "Floor")
            {
                //Debug.Log("Collision active for more than 1 second. Playing audio source file.");
                _audioSource.Play();
                _collisionActive = false;
            }
        }
    }     private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Setting _collisionActive to false");
        _collisionActive = false;
    }
}

So the logic of the water bottle challenge is that I have a weird bug with my water bottle in that if you put the lid on the water bottle and then pick it up the physics go wild and it starts to flip end over end in your hand.  Rather than figure out what was causing the bug and fixing it I decided to instead spend all my time making a sheet of paper asking "Can you complete the water bottle challenge" and placing the water bottle and lid on top of that note. I then added a large collider around the sides and a sphere collider on the bottom and the script is using an OnCollisionTrigger method with a tag check to make sure the item colliding with the water bottle is something with the tag "Floor" (which is obviously the ceiling.  Just kidding.  It's obviously the floor).     That then starts a 1 second timer and if the water bottle is on it's side colliding with the floor for a whole second then it plays the audio clip of clapping and cheering.  If the water bottle is on it's side and colliding with the floor for a whole second it plays a booing audio clip. The player could pick up the bottle and throw it in the air, flipping it manually or if they figure out that the lid makes the water bottle really spin they can try that way.

I got the idea putting the lid on (it's only happened a few times so far) and having the water bottle land right side up when it hit the floor.  I thought that was hilarious and kind of cool, so I made a mini game out of it.

I got the idea putting the lid on (it's only happened a few times so far) and having the water bottle land right side up when it hit the floor.  I thought that was hilarious and kind of cool, so I made a mini game out of it.

There is a slight bug that the water bottle has enough velocity to sometimes clip through the wall or floor when the lid is on, despite the colliders and the rigid body being set to Continuous Speculative.  I don't have a good solution for that bug yet as I've already set physics between the bottle and lid and nearly everything else and I have the rigidbody collision detection set to the mode that best handles high velocity.
@mattdway mattdway committed on Feb 02

02-12-23 v3.0.0 Commit
Updated this project to Unity 2021.3.11f1 and I also updated all of the Project Manager plugins to their latest versions including XRIT to version 2.3-pre1.  I fixed a slew of bugs that occured as part of that upgrade and I've done a lot of beta testing.

I also added a new feature where the players can now set the area rug on fire using the lighter as a little easter egg.

To follow is the dev log for those changes.

[2/5 10:38 PM] Way, Matt - PRE
So here is the short list of problems I ran into after creating a copy of my current working CreateWithVR room (with all the features I've recently created included) and then re-upgrading the Unity Editor version, XRIT version and all other Project Manager plugins to their latest version. In fairness, I'm pretty sure the broken functionality is also that I downloaded and updated the prefabs from Unity Learn's CreateWithVR For Educators page.  Some of those prefabs had scripts or other modifications that I essentially wrote over.  I was able to fix all the locomotion issues except for one problem with the raycast depth for teleport anywhere and also my tiny height (my head is slightly taller than the couch cushions when walking) with the new XR Origin game object.  So that's good. This is all a copy of my project (not my original) so I can either copy back those prefabs and see if that fixes the issues with things like the stapler, polaroid camera, dart gun, etc. or I can delete that folder, make another copy, upgrade everything again and then fix all the set up and locomotion/turning settings again.  Probably will try the first one, as that'd be the least amount of work. Things to Fix in Upgraded XRIT CreateWithVR Project to the latest XRIT along with other Project Manager plugins to their latest versions, and converting the project to open in Unity Editor 2021.3.11f1:  
* Teleport Anywhere raycast slightly too long -- have to pull back hand to get distance where reticle shows up
* XR Origin height waaay too short once moved from original location.  Nearly crawling on ground.
* Door handle not interactable
* Door button not working
* Consumable eaten portion of food not facing towards player (watermelon, maybe others too)
* Some objects don't have distance grab enacted
* Cheat system not functioning (not moving with main camera).  Can't find script for this
* Staples hanging in midair (gravity or kinematic), like Matrix.  There is no velocity on those objects now.  Also no destroy script.  Count on dart gun also no longer subtracting
* Dart gun darts hanging in midair (gravity or kinematic), like Matrix.  There is no velocity on those objects now.  Also no destroy script.  Count on dart gun also no longer subtracting
* Polaroid decoupling script no longer working  
* All screens are faded/red (TV, tablet, laptop screen) when playing video
* Tablet no longer plays random video/only the one with activate
* No sockets for books at bottom of TV cabinet (Not sure if I kept these under the cabinet.  Will have to check my other project to see)
* Watering can collides with leaves.  Can't tilt watering can/water plant as a result
* Red wax apple has no collider/grab interactable
* Hat sockets for head not working
* Hat physics caused me to be propelled outside room
* Brown book physics acting sort of funny when in hand (wants to constantly turn/rotate in the direction of the motor for the cover)

[2/5 10:54 PM] Way, Matt - PRE
Copied my original _prefabs folder back in and this is my list now: Things to Fix in Upgraded XRIT CreateWithVR Project to the latest XRIT along with other Project Manager plugins to their latest versions, and converting the project to open in Unity Editor 2021.3.11f1: * Teleport Anywhere raycast slightly too long -- have to pull back hand to get distance where reticle shows up
* XR Origin height waaay too short once moved from original location.  Nearly crawling on ground.
* Door button not working
* Some objects don't have distance grab enacted
* Cheat system not functioning (not moving with main camera).  Can't find script for this
* No sockets for books at bottom of TV cabinet (Not sure if I kept these under the cabinet.  Will have to check my other project to see)
* Watering can collides with leaves.  Can't tilt watering can/water plant as a result
* Red wax apple has no collider/grab interactable
* Hat sockets for head questionable.  Need more testing after getting to correct height via XR Origin
* Hat physics caused me to be propelled outside room
* Brown book physics OK now but TMP text is fading in and out depending on angle* Magnifying glass physics not right (causing the entire magnifying glass to jitter and turn 

[2/5 11:35 PM] Way, Matt - PRE
Last update for tonight.  I got the XR origin height fixed and I also got the anti-cheat script updated (it had references to the old, replaced, XR Rig game object, which is partly why it wasn't working).  This script was also not attached to my new XR Origin game object, which is the other reason why this wasn't working.  I updated all the references to XR Rig (and some of the methods for camera height and positioning, which changed between these two) and attached and that is working now. Things to Fix in Upgraded XRIT CreateWithVR Project to the latest XRIT along with other Project Manager plugins to their latest versions, and converting the project to open in Unity Editor 2021.3.11f1: * Teleport Anywhere raycast slightly too long -- have to pull back hand to get distance where reticle shows up
* Door button not working (see next item in list)
* Door collider to prevent leaning into and breaking door not working correctly.  I'd guess none of the three door colliders are in their correct locations.  This would also explain why the door button isn't working
* Some objects don't have distance grab enacted/distance grabbing isn't working for all objectsCould maybe adjust consumable food game object orientation slightly to make the eating feel more realistic 
* No sockets for books at bottom of TV cabinet (Not sure if I kept these under the cabinet.  Will have to check my other project to see)
* Watering can collides with leaves.  Can't tilt watering can/water plant as a result (physics collision issue in the physic matrix)
* Red wax apple has no collider/grab interactable
* Hat sockets for head questionable.  Need more testing after getting to correct height via XR Origin
* Hat physics caused me to be propelled outside room (probably a physics collision issue in the physics matrix)
* Brown book physics OK now but TMP text is fading in and out depending on angle (probably a physics collision issue in the physics matrix)
* Magnifying glass physics not right (causing the entire magnifying glass to jitter and turn (probably a physics collision issue in the physics matrix) 

The good news is, none of these bugs (outside the mystery of the grab interactables not working -- which I have no idea why yet) should be too difficult to solve.  Then I should have a fully working project that is updated that I can continue to add too -- which will be great. 

I also need to go into the Gym scene so that I can replicate any changes there.  Probably I'll make my XR Origin a prefab to bring all those changes over to the other scene easily.

[2/7 9:32 PM] Way, Matt - PRE
Things to Fix in Upgraded XRIT CreateWithVR Project to the latest XRIT along with other Project Manager plugins to their latest versions, and converting the project to open in Unity Editor 2021.3.11f1:  
* Teleport Anywhere raycast slightly too long -- have to pull back hand to get distance where reticle shows up
* Some objects don't have distance grab enacted/distance grabbing isn't working for all objects
* No sockets for books at bottom of TV cabinet (Not sure if I kept these under the cabinet.  Will have to check my other project to see)
* Watering can collides with leaves.  Can't tilt watering can/water plant as a result (physics collision issue in the physic matrix)
* Hat sockets for head questionable.  Need more testing after getting to correct height via XR Origin
* Hat physics caused me to be propelled outside room (probably a physics collision issue in the physics matrix)
* Brown book physics OK now but TMP text is fading in and out depending on angle (probably a physics collision issue in the physics matrix)
* Magnifying glass physics not right (causing the entire magnifying glass to jitter and turn (probably a physics collision issue in the physics matrix)
* Physics hands are cursed.  They want to turn on their own as well as to turn while pressed up against a collider.  The results is two-fold.  The physics hands want to continue to gyrate and rotate and this causes the non-physics hands to appear due to the distance piece.  This only started after the updates.
* Consume mechanic not activating.  Food collides with head.  Going to start by comparing physics matrix between old project (2020) and new updated project (2021) to see if anything is different.  I can also confirm functionality worked before the upgrade and wasn't an unknown bug there.
* I also need to go into the Gym scene so that I can replicate any changes there.  Probably I'll make my XR Origin a prefab to bring all those changes over to the other scene easily.

[2/7 10:21 PM] Way, Matt - PRE
Updated project   Original Project   

[2/7 10:43 PM] Way, Matt - PRE
OK, so not really much different in the physics matrix.  The only differences in the physics matrix between the original project and the updated project are that I didn't have collisions between Clock/Hats, Hats/Bookshelf Books, and Hats/Art.  I also didn't have any collision between Bookshelf Books/Clock.  Nothing that should break or act janky if collided (those items normally wouldn't interact and I don't see any reason not to have collisions on those items if they were to interact).  And nothing to do with the consumer. 

I also looked and in the original project both the consumer and the food are set to the default layer and default is allowed to interact with default in the original project's physics matrix as well default can interact with default in the upgraded project.  The table below the food is also set to default and if default can't interact with default then not only does the food fall through the table but the collision needed to trigger consume wouldn't happen.  So layers set or physics matrix doesn't appear to be the problem.   

The consumer works in the old project (no collision issues) so differential diagnostics: there is a positioning issue with my colliders/head object (which I'm going to look at next), a script isn't linked.  I'm going to check and document those pieces in the original project next so I can compare to the upgraded project. 

Goal is that i have time to fix one more thing on my above list and getting the colliders working is what I am hoping to complete.  Then I can continue to work on the rest of the list tomorrow.

[2/7 10:48 PM] Way, Matt - PRE
Also just confirmed that with Clock/Hats, Hats/Bookshelf Books, and Hats/Art, Bookshelf Books/Clock checked in the physics matrix of the original project, this causes no issues.  I also confirmed that consumption still works and I tested and hats do not cause an issue with pushing the player outside the room.  

[2/7 10:51 PM] Way, Matt - PRE
And no hand instability or turning in the original project.

[2/8 12:05 AM] Way, Matt - PRE
No luck fixing the consumer issue.  It's definitely a collider issue.  At first I thought it was maybe the consumer collider being positioned with the astro head rather than the camera so I positioned the head's y position to where the camera is lined up with the head's eyes, with the head being behind the camera (so that this head does not partially clip in front of the camera and show pieces of the head in the VR headset view).  But this didn't help.  I then made the collider taller and I increased it's Z axis so that this collider stuck out more.  I can sort of get the consume to happen but not consistently and not when the watermelon is entering the consume collider.  But it also appears some collision is taking place just before the watermelon collides with the consume collider and I can't figure out what it might be hitting.  Even when exposing and showing all collisions at the same time, from the Scene view while in play mode.  I could see my hand controller sphere colliders were huge (0.1 scale) and I halved those.  But those sphere colliders on the hands are "Is Trigger" anyway, so no collisions should be happening with those anyway.  I also made sure all my transforms were the same as in my original project and they are.  For the astro head, colliders, etc.   

So I'm not sure what is going on but I'll have to solve that mystery tomorrow (I hope).

[2/8 12:13 AM] Way, Matt - PRE
I was able to put right the door script (which wasn't linked), I was able to put all the door related colliders back, which were in the middle of my scene and really just needed to be moved back on the z axis and then tested.  Everything with the door is working OK. I also added the rigidbody, collider and grab interactable to the red (wax) apple in the bowl.  It was simply missing those components. The hat and other physics interactions haven't yet been fixed and will need to be addressed in the days to come.

[2/9 12:19 AM] Way, Matt - PRE
OK, great news.  I fixed most the physics and layer issues including with the physics hands.  The consumables are also all working now.  I also fixed the hat sockets, the attach transform for all the food items and for the hats and I fixed the grab interactable issue. 

The physics hands issue had to do with the default layer interacting with the physics hands.  But I couldn't simply turn off physics in the matrix between default and my LeftHandPhysics and RightHandPhysics layers because the default layer was set to a bunch of other items in my scene.  So I ended up looking at every game object set to default and I changed those to be on either the Interactable, Furniture or Non-Interactable layer, depending.  I also had a bunch of items under XR Origin that had to do with the camera, my astro head, my consumable, etc. that had accidently been set to Whiteboard.  Obviously that shouldn't have been (that layer is specifically to allow layers to draw on the whiteboard).  So I set those to the layer Pseudobody or default (if an empty game object parent).  All of this fixed the random rotation and jitteriness I was seeing with the physics hands and allowed those to 'calm down.'   

With consumables this was a combination of a few things.  I had consumable attached to an empty game object but with my astrohead having a convex mesh collider too that consumable collider moved to unexpected positions and rotations as I moved the head around.  I was able to observe this looking at my scene view while play testing and trying to eat something.  This was causing the 'hit zone' of that collider to sometimes be to the right of my head, to the left of my head, my forehead, etc.   

The other issue was that the position of the astro head was off (lower than) the main camera whereas the main camera is really the view we are seeing out of when we play 1st person VR.  So using gismos I unchecked all but the main camera and all the colliders and I turned up the 3D icons slightly so I could better see where my camera was in relationship to the 3D head game object.  I then moved the astro head up so that the camera aligned with about where the eyes would be on the head and back (so that the head doesn't appear in the camera view (otherwise we see clipped portions of the head in the view when playing). 

Lastly, having the consumable game object as a parent of main camera seemed redundant with the game object hosting the astro head so I copied the components of that consumable game object (including the collider and script and I pasted these as new components on the astro game object.  I then readjusted the consumable box collider (I kept the astro head convex mesh collider on the head also) so that it was aligned properly from the bridge of the nose to the chin and tested.  The consumable game mechanic is working perfectly again. 

Next, in game I paused, disabled layer 4/4 and enabled layer 3/4 and then I changed the rotation of the attach transform game object so that the object, when held, is rotated/tilted towards the user's face.  This allows the food to look like it is facing the user's mouth when the additional layers are disabled and the new eatten layers are enabled.  This adds to the realism of being an eatting mechanic through having the bit area facing the player (not facing away from the user).  I then noted the rotational transform and changed this when out of play mode, so that this change would stick.  I tested and all the rotations are perfect for everything from the watermelon, to the ham, the bread, the ribs to the potion. 

I also added a Select Enter and Select Exit event for the potion via the Grab Interactable component so that when the user picks up the potion the cork game object is disabled and when dropped the cork game object is put back into place.  This just adds a little extra realism to that drink mechanic. 

The hat socket placements were now all off because I'd adjusted the astro head position so in game mode I adjusted the attach transform position (and with the captain's hat also the rotation because I didn't love how that looked sitting on the head).  The attach transform needed to move the opposite direction than what one would think (if the hat was too far forward then the attach transform needed to move forward (away) from the head to move the hat back).  I adjusted all three hats by placing on my head in play mode and then paused, changed the attach transform, unpaused, took the hat off and put it back on my head and then adjusted more until I had the hat positioned perfectly on my head in every direction (x, y and z axes).  Then I noted the position and rotation transform of each of the three hats in Notepad so that I could then apply those to the attach transform of all three hats in scene view.  I tested and everything looks good on the hooks and when placing these on my head. 

The grab interactable issue was with the XR Grab Interactable Interactable Layer Mask.  I needed to allow Raycast here, as confirmed with just the hats to begin with.  The LeftHandRay and RightHandRay game object's XR Ray Intercator's Interactable Layer Mask was already set correctly to allow interaction with all objects except for art (too large and with collisions and physics enabled - pulling these across the room with a ray collider just caused a mess) doors, door handles and drawers (opening large doors, cabinet doors and drawers with the raycast causes all sorts of bad/undesirable behaviors so those are set to work with direct interactables only.  I used the Hierarchy trick of t:xrgrabinteractable to see all objects that had the XR Grab Interactable component attached.  However, because there are varying Ineractable Layer Masks set, depending on the item, I couldn't select all items (minus those I mentioned above -- door handles, cabinet handles, drawers and art) and make that change to all the objects at once.  If I did then I ended up adding the average of all layer masks listed here and especially on any item with a socket, this caused the sockets to fail and all those socketed items to immediately fall in play mode.  So I just took note of what those items were with XR Grab Interactable and I then undid the Hierarchy t: filter and made those changes per game object. 

I had no sockets for the books under the table, I simply had grab interactable set and those game objects were stacked.  Because that TV media cabinet is so low to the ground, making it hard to place and socket the books there, I suspect I skipped adding sockets in that area. 

The fixes above with the layers fixed the hat and head physics that propelled me outside the room while wearing hats.  That piece is now fixed. 

For the brown notebook I had an Interactive Layer set for the empty parent game object and the cover and I set the empty game object to the default layer.  This fixed the notebook's physics bug, which caused the notebook to want to rotate to the left when holding this notebook open.  There is still an issue with the TextMeshPro text fading when holding the notebook at an angle away from you that I haven't looked at or fixed yet.  This was also an issue in my original (non-upgraded project) and I'll still look into this to see why that is happening and to see what an appropriate fix would be. 

For the plant, it is made up of three parts and the Plant_Fig game object contains the colliders for the leaves themselves.  I set this game object to the Non-Interactable layer.  Because there are no collisions/physics allowed between the Interactable and Non-Interactable layers, this allows the watering can to pass through the leaves, allowing the watering can to be able to tilt over the pot of the plant. 

The magnifying issue was fixed with the above layer changes. 

I had one instance where I picked up the polaroid camera with my physics hands and the hand colliders re-enabled immediately when dropping the items instead of on a delay.  This caused the camera to fling across the room instead of just dropping.  However, on additional tests picking this and other items up I was able to confirm the colliders were disabled on both hands and the colliders enabled but only after the set delay.  Because this bug wasn't repeatable I'll keep an eye on this and if I see it continuing to occur I'll troubleshoot why this is happening and I'll work to try and fix this.

[2/9 12:32 AM] Way, Matt - PRE
So, this is where this leaves me with my list. 

Things to Fix in Upgraded XRIT CreateWithVR Project to the latest XRIT along with other Project Manager plugins to their latest versions, and converting the project to open in Unity Editor 2021.3.11f1:  

* Teleport Anywhere raycast slightly too long -- have to pull back hand to get distance where reticle shows up
* Brown book physics OK now but TMP text is fading in and out depending on angle (probably a physics collision issue in the physics matrix)
* This is an old bug that has been around for a while but I notice that items with thinner colliders (such as the polaroid photos and the punch lists) clip through the (teleport area) rug.
* I also need to go into the Gym scene so that I can replicate any changes there.  Probably I'll make my XR Origin a prefab to bring all those changes over to the other scene easily.
* I also need to bring the updated XR Origin as a prefab into the Peaceful Nowhere scene so that all the changes I made tonight to the main scene are carried over to my two other scenes.
* I still want to implement the idea of having one punch list with an interactive UI scrollbar and interactive checkboxes as opposed to the five static TMP punch lists I have now.
* I want to do a couple more full rounds of play testing to make sure everything in this version of the project is stable and working as expected.  If it is then I can go ahead and start playing around with learning and trying the new features of the XRIT!
* I can also start following more Justin P. Barnet, Valem Tutorials and VR With Andrew tutorials and I'll have a much easier time implementing the mechanics they show now that I have an updated XRIT that both matches what they show in their videos but also that include methods I need to be able to implement and code those features!  Starting with finishing Justin's climbing and jumping mechanics!  Yay!
* Lastly, I want to create a new branch in my Git Hub repository to house this new updated version!  I think I might be able to muddle through this but I might also need to do some quick research.  But I definitely want to make sure I have version control on this version.  The plan is to use and develop this updated version, moving forward.  The previous 2020 with the older XRIT I'll leave at the point that it is at for historical or demonstration purposes.

[2/9 1:45 AM] Way, Matt - PRE
Some additional thoughts after having worked through this update.  
Upgrading a project mid-way through to a new version is definitely not for the faint of heart.  
In addition to converting the project from 2020.3.23f1 to 2021.3.11f1 I also updated XRIT from version 1.0.0-pre2 to the most recent 2.3 version.  I also updated all other plug-ins with updates while I was at it.

I knew upgrading  would break a lot of things and it was interesting to me exactly what changed or broke.  
Some things that broke were not specific to the XRIT but were layer and other Unity Editor changes that ended up causing major bugs in the project, as a result.

Part of why I wanted to embark on this journey was to be able to continue to build up my demo room project while also being able to utilize and learn about the latest features.  

But another piece was that I also wanted the experience of upgrading so I could better understand and speak about what this process is like.  I feel like I now have a deeper understanding of why it is recommended to not upgrade a major Unity project after having started it and that I can better speak to what the process was like to upgrade, troubleshoot and fix the resulting issues. 

I recommend not upgrading unless you absolutely need to.

Having both version control and a local backup are highly recommended if you feel you need to upgrade.  If all else fails you still have your original project in two other places you can  use as a reference or to revert back to if necessary.   

The first time I updated and started to troubleshoot there were more bugs I had accidentally introduced that I wasn’t happy with.  So I ditched that project folder, made another copy and upgraded again.  
Being aware of my previous pitfalls the second go at this was much easier.  But without a backup and/or multiple backups it would have been easy to get to a place where the project was in shambles. 
I’d never attempt this on my one and only copy.

If you decide you have to upgrade make sure you have plenty of time to troubleshoot and know things are going to break.

Be patient with yourself and keep a level head.

Play test everything in that project and take great notes of any bug (major or minor) that you see.  I also prioritized major bugs to fix first at the top and minor bugs at the bottom of my list.
 
Take that list of bugs and problems to fix one item and one step at a time. 

Having a good understanding of how all the Unity Editor and XRIT components work in your project and having experience troubleshooting is always very helpful.  

These bug fixes weren’t a huge deal having an idea of what most likely it was that was breaking.  And almost all my theories ended up being correct, leaving most of tonight’s troubleshooting and fixes (about 3 and a half hours worth) spent implementing fixes as opposed to troubleshooting.

But I I don’t think the me, a year ago, would have been able to fix all these issues nor would have necessary known what was breaking.  

Without having had experience building and troubleshooting my own creations and those of others and without having known the basics if Git I could see the me of yesteryears having easily having ruined my project or getting to a point of being overwhelmed and giving up.  A year is a great amount of time for learning and personal growth. 

I just wanted to share my experience here in case others who hadn’t ever experienced  updating and breaking a Unity project could see exactly what that process looks like and why updating can be a huge PITA.   :-)

[2/9 11:06 PM] Way, Matt - PRE
Trigger animation for dart gun is still intact. 

Fixed brown notebook text issue.  I needed to add a white background behind each TMP layer and I needed to adjust the background and TMP Y position transform.  Glow oddly works better than black and has a neat effect look to it but it applies to all TMP for the entire scene and I don't yet know a way around that.  I turned off glow for now because that doesn't work for any of the other TMP in the room and isn't the desired effect. 

I fixed the teleport anywhere depth glitch.  I needed to turn off select on hover for both raycasts as that has odd effects when using raycast for teleport (it essentially allows you to point at something and without using the grip button after a set number of seconds it activates the select so long as you continue to also touch the thumbstick.  I also needed to adjust my teleport anywhere plane height and I also discovered it's scale was way too large, allowing players to once again teleport outside the walls. 

I also needed to adjust the no teleport area planes so that it covered the inside of all four walls without any gaps but also so that it wasn't longer than necessary outside the room.  The player should again be confined to the room. 

I made my entire XR structure (with physics hands, character controller, the new XR Origin structure and all my locomotion components) a prefab and I loaded and deleted the old XR Rig (-- XR -- parent) structure and brought in the new -- XR -- from prefab and resaved.  So both my Gym and Peaceful Nowhere now have the new XR Origin too. 

I also had to change the gold glitter reset pedestal and button to the Interaction layer for the same reason - Default no longer allows collision with the pseudo body or physics hands layers.  I'll try not to use Default except for empty parent game objects. 

I also fixed the area rug position and colliders so that photos are no longer clipping through the rug. 

The colliders on the bin are odd and not allowing the darts to fall into the bin.  I need to look at this. 

The physics on the dart gun were weird for one time that I picked it up.  I think when I pick up the gun using distance grabbing that doesn't allow my left hand collider to disengage the same way it does with the direct interactor.  I should look into this more too. 

I haven't done anything with branching Git Hub and committing this new project to the cloud.  I still need to do this. 

But things are looking up.  Everything is working the way it should (and did before with the original project), outside the few minor glitches I mentioned above. 

[6:59 PM] Way, Matt - PRE
So, I did a thing this afternoon.  The rug in my CreateWithVR room can now be set on fire.  It shouldn’t have made me laugh in glee as much as it did but I admit, it is pretty fun!  

This all started in the brown journal (which is another type of tutorial telling you things you can do). In it I tried to use a wry/dry sense of humor outlining the day in the life of the person inhabiting this appartment and at one point in the journal the struggling inhabitant is trying to light the candles but exclaims he almost set the rug on fire, instead.  

Last summer’s students picked up on this and multiple tried to light the rug in fire.  They were disappointed that this didn’t work and insistent that this be a feature.  So, tonight that wish has come true. 

I used a pyro asset that included (amongst many other types of fires) a camp fire asset that containing scripts, particle effects, lighting and sound effects.  I had to fix a bunch of the materials and shaders that didn’t work and that produced either pink or black boxes where the material wasn’t correct and/or where the shader’s clipping wasn’t correct. 

I then renamed this Rug_Fire and I made this a prefab. 

Next came my custom C# script that used an onCollisionEnter collision detection and a tag check to enter the innards of the if statement.  If all checks pass the script instantiates the rug fire in the location where the collision takes place.  

That last piece (where the collision takes place) I had ChatGPT help me with (so I learned something new today) but the idea itself I came up with myself.  I wanted the fire to instantiate because it needed to start the fire where the lighter hit the rug.  This I attached to the rug so that the rug is the only thing they can set on fire.

I then had to troubleshoot why the collision wasn’t occurring and I realized that when the lighter moves the flame also moves which also means the capsule collider for the flame moves.  

When the lighter is fully upside down the flame and collider are also up and towards the player and this was due to a Unity script on that flame object called face the camera.  

I discovered this by moving the lighter and observing the flame move.  I then paused and looked at the scene view (while paused) to expose and see what the collider was also doing).

I could disable this Unity Script (and that keeps my flame’s rotation from changing at all, but in doing so the flame looks very 2D in a 3D world.  Apparently Unity’s methodology of making the flame look 3D was to rotate that flame according to the parent object.  Making a 2D sprite look 3D without this script is on my to-do list now.  So is learning how to make my own flame/fire particle effect with a script that makes that fire spread.

It is the flame that has the lighter tag and it is the lighter tag that allows the candles to be lit (that tag check can only happen when the red-flame game object is an active game object and you can only activate the red flame game object when activating the lighter by pressing the trigger button on the controller.  So in essence you can only light the candles when the flame is showing on the lighter, never without. 

But in the case of the rug, when the face camera script on the flame is active, that collider moves the opposite way and as a result it is the lighter itself that collides with the rug.

So to work around this I wrote a second script that temporarily adds the Lighter tag to the lighter and I assigned the events that this tag be assigned on Activate and unassigned (tag made Unassigned) on Deactivate.  This way the lighter only has the correct tag when the flame is also exposed.

[7:03 PM] Way, Matt - PRE
I also set an OnDestroy on the flames so they extinguish after five seconds.  Same script as with the darts and staples.  But so long as you touch the rug in multiple places you can essentially set the rug ablaze and that’s kind of fun.  Just don’t expect the whole room to catch on fire.   

I think I’ll also change this to a collision tag check with the rug to assign and unassign that tag to the lighter because when the lighter has the Lighter tag assigned hitting the side of the candle with the lighter body lights the candle and that is a pretty unrealistic effect.

[7:25 PM] Way, Matt - PRE
OK, that change has been made and is working well.  The tag is now only set when a collision between the lighter and the floor takes place and it sets that tag back to Unassigned when the lighter has been selected (picked up), deselected (dropped) or whenever the trigger has been deselected (Deactivate), just to make sure that tag doesn't stick around any longer than it needs to -- as it's only function is to make sure the lighter itself can aide in lighting the rug on fire (since the red flame isn't positioned to do so easily when pointed straight down).  

[11:25 PM] Way, Matt - PRE
I ended up changing/optimizing some of my code and running down a bug in my LighterSetTag.cs script, that was causing the lighter to inherit the Lighter tag, when conditions weren't being met and then a second bug that popped up in which the lighter wasn't being set back to Untagged afterwards.   took a chuck out of the evening, but I got it figured out by 10:43 PM and everything is working now. I probably over-engineered that with an OnSelectExit, OnSelectExitLast and onDeactivate all setting that tag back to Untagged.  Basically an event for every occasion.  But it works.  So I'm stepping away. I'm not so sure it's an eloquent solution any more.  I think in the end I can clean up some of that code (I don't think the OnCollisionExit is currently doing what I wanted it to do).  And I think I can also get rid of OnSelectExit as OnSelectExit seems to be doing the job.  But those are minor cleanup pieces.  I'm also getting some nullpointer errors and I'm not sure if that is the Pyro script or memory issues.  The Pyro script is also throwing its own errors about layers being out of bounds but I don't feel like debugging their scripts at the moment.   That'll be something for another day. In the mean time, they can have fun lighting the rug on fire to until their little hearts are content.   Here is the code involved with today's little project: using UnityEngine; public class InstantiateOnCollision : MonoBehaviour
{
    public GameObject prefabToInstantiate;     private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tag match: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Lighter")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Instantiate(prefabToInstantiate, contact.point, Quaternion.identity);
            }
        }
    }
} using UnityEngine; public class LighterSetTag : MonoBehaviour
{
    private bool isActivated = false;     public void Activated()
    {
        //Debug.Log("SetTheTag Method Called");
        isActivated = true;
        //Debug.Log("isActivated = " + isActivated);
    }     public void Deactivated()
    {
        //Debug.Log("UnsetTheTag Method Called");
        isActivated = false;
        //Debug.Log("isActivated = " + isActivated);
    }     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rug")
        {
            //Debug.Log("Tag match: " + collision.gameObject.tag);
            if (isActivated == true)
            {
                gameObject.tag = "Lighter";
            }
        }
    }     private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Rug")
        {
            //Debug.Log("Tag match: " + collision.gameObject.tag);
            gameObject.tag = "Untagged";
        }
    }     public void JustSetTheTag()
    {
        gameObject.tag = "Lighter";
    }     public void JustUnSetTheTag()
    {
        gameObject.tag = "Untagged";
    }
}
@mattdway mattdway committed on Feb 12

02-16-23 v3.0.1 Commit

I noticed in a 02-15-23 playthrough and video recording that the ghost hands were no longer rendering on top of all other objects but behind (per the default). This was a bug introduced in the 2021 and Project Manager plugins update that I missed before.  Tonight I fixed this and because I hadn't properly documented how I set this up before, I'm doing so now so that I have a record of what to do the next time I need to make this custom renderer customization.

[12:06 AM] Way, Matt - PRE
I found another bug playing through last night.  My ghost hands are no longer on top of everything like they were.  So I watched part of the Valem Tutorial video where he set this up, verified everything in mine matches his and I remember that was a tricky one to set up.

Then I looked up ForwardRender in the Unity After Hours Club chat in Teams.  Found this:
[11/17/2022 12:07 AM] Way, Matt - PRE
Dev Log, Devdate 43779.3. 
With only 20 minutes tonight I wasn’t able to get more than the first part of the script written 
- That is supposed to make the ghost physical hands appear whenever the controllers get to be a certain distance away from the VR physics hands that were stopped by hitting a collider. However, while the script has no errors, a link box (per an exposed variable) that has the renderer objects linked - 
Those ghost hands aren’t yet showing up. 

I also got stuck on a ForwardRenderer component I could’t find in my Projects Pane, despite having URP game objects. There is a link in his description to a Brackey video that explains this concept better and a possible other way of doing this. This renderer is meant to always force an object to the forefront. In this case the ghost hands should always be in front and not clipping through the object. 

So I have more homework to do here. 

In this same video will also be code to fix the hand grabbing (which is near impossible currently) by turning off and on the colliders. I don’t have that code typed yet but I plan to add it soon. 

So in the last little bit I fixed the clipping outside the room problem (in which teleporting into an object close to a wall collider can sometimes push you outside that collider and the room, where you then fall. 

By creating no teleport plane that I made the same size as the furniture and plant by the window and by setting it slightly above the teleport anywhere plane by about .01 I was able to create a blocked area where teleportation can’t happen. This is neater and easier than trying to shrink the teleport anywhere plane as there are still areas by the window I want people to be able to get to. 

I also duplicated this no teleport plane and positioned it under the desk and table with the food. Essentially any opportunity to teleport under/into an object and/or an object near s collider wall I want to eliminate as a teleport anywhere area. 

Thus no teleporting outside the room (hopefully). 

I also organized my hands, hands controllers and hand rays into child objects of parent objects for neatness and organization sake. 

[11/17/2022 8:47 PM] Way, Matt - PRE
I'm not all the way through the second physics hand video yet but I did "unlock an achievement" tonight. Rather, a personal goal which was to get the ghost hands working. I also had to watch part of a Brackley video (linked by Valem) to understand how custom shaders and custom renders work in Unity Editor - but once I understood that I was able to use it to override and make my ghost hands always appear on top! Yay!

So while I don't have the solution listed there I guess I'm off to rewatch that Brackley video again.

[12:12 AM] Way, Matt - PRE

Got the ghost hands fixed.  Brackey's videos are so well explained.  I'd love for him to come back and continue doing more modern Unity Editor videos, just because his current videos will soon become out of date and that'd be a shame.  But hopefully he's doing lots of cool stuff.
 
https://www.youtube.com/watch?v=szsWx9IQVDI&t=0s
 
So everything is set up correctly with my CustomForwardRendererData settings under Assets > Settings and all the below settings are still correct in the 2021 version of Unity Editor, so that's great.
 
Filtering:
Opaque Layer Mask: Everything
Transparent Layer Mask: Mixed... (Everything selected and then uncheck Non-Physics Hand Layer).
 
Rendering:
Rendering Path: Forward (default)
    Depth Printing Mode: Disabled (default)
    Depth Texture Mode: After Opaques (default)
 
RenderPass:
Native RenderPass: unchecked (default)
 
Shadows:
Transparent Receive Shadows: checked (default)
 
Post-processing:
Enabled: checked (default)
Data: PostProcessData (Post Process Data) (default)
 
Overrides:
Stencil: unchecked (default)
 
Compatibility:
Intermediate Texture: Always (default)
 
Renderer Features:
 
(Add Renderer Feature button at the bottom of the Inspector window > Renderer Objects (Experimental)
 
Name: HolographicHands (descriptive name I gave)
Event: AfterRenderingOpaques (default)
 
Filters:
Queue: Transparent (I set)
Layer Mask: Non-Physics Hand Layer (I set)
LightMode Tags: List is Empty (default)
 
Overrides:
Material: Holographic Blue (I selected from the selection box -- this is the material used for the ghost hands)
Depth: checked (I checked)
Depth Test: Greater (I selected)
Stencil: unchecked (default)
Camera: unchecked (default)
 
So the part that I needed to change tonight to fix the ghost hands depth (so that these always appear in front of all object and not behind when they appear) came from Brackey's video at the 1:35 mark (https://youtu.be/szsWx9IQVDI?t=95)  Essentially I needed to find the correct Pipeline Asset setting file in Assets > Settings and I needed to set that to my CustomForwardRenderData (Universal Renderer Data) setting file.
 
But what Brackley shows in his video isn't correct for more modern versions of Unity (when he made this video 3 years ago he was using Unity 2019.1.0b9) and he also installed the "Lightweight Pipeline Asset" (where as I am using Unity 2021.3.11f1 and the URP - Universal Renderer Pipeline, at least I had thought -- I'm using the starter files that Unity provided so I didn't set this project up completely from scratch myself).  
 
So I have multiple different PipelineAsset setting files in Assets > Settings:
 
Hight_PipelineAsset
Low_PipelineAsset
Medium_PipelineAsset
Ultra_PipelineAsset
UniversalRenderPipelineAsset
Very High_PipelineAsset
Very Low_PipelineAsset
 
I wasn't sure which to use so I experimented and first set all of these to CustomForwardRenderData (Universal Renderer Data) and tested and the problem was fixed.  
 
I'd guessed that it would be the 
UniversalRenderPipelineAsset that was the correct settings file for my renderer type but I was wrong.  I went back and set these one at a time and tested between each change and it was this way that I discovered it was t ended up being the Ultra_PipelineAsset that needed to be pointed to the CustomForwardRenderData (Universal Renderer Data) renderer setting file in order to enact the correct depth changes.
 
As Brackley explains this removes the Non-Physics Hand Layer from the renderer and then it adds these characters back in using this renderer feature.  We then set a depth and material override (using that Non-Physics Hands layer).  I set the same material (so really no changes there but I could choose a different material/shader if I wanted) and I set the depth to greater to make sure the override makes sure the Non-Physics Hands layer always renders in front of all other layers.
 
Lastly, the specific type of setting the CustomForwardRender is, is that this is a "Universal Render Data" file.  However, when I single right-click on the Settings folder in the Project window and I hover over Create I don't see this type of file creation in any of the contextual menus or sub-menus (including under Create > Rendering..., which is where I would expect to find this).  I don't recall how I came to create my Universal Renderer Data file in the first place (as it's been too long now) but if I were to guess I'd say I maybe duplicated on of the other files that had the name PipelineAsset_ForwardRenderer and then renamed it.
 
But problem solved with the ghost hands rendering behind other objects when they appear.  They again appear in front of everything else and all it took was finding the correct PipelineAsset file and pointing it to my CustomForwardRenderData file again and making sure that my layer information was updated and correct in that file.  Yay!
@mattdway mattdway committed on Feb 16

02-18-23 v3.0.2 Commit
* I fixed the Welcome board's HTC Vive Controller Diagram and Oculus Touch Controller Diagram by moving back the Z axis on the parent Welcome_Controller Diagrams game object and my changing the color's alpha value of each of the individual diagram game objects to 90.  This gave the effect of making the diagrams look like they were one with the main board and not a seperate board in front.  It also allows the window and sunset to be seen through the semi-transparent background of the diagrams rather than being straight black (whereas the rest of the welcome board was already transparent).

I also created empty parent game objects called HTC Vive Controller Diagram and Oculus Touch Controller Diagram.  I moved the individual diagrams into these empty parent and then duplicated twice.  This gave the entire diagram more of a bold look that made it easier to see (especially with the alpha value changed).

I changed the Asset > Settings > CustomForwardRendererData Depth Test (under Overrides) from Greater to Always so that the ghost hands also appear when pushing through the window.  This still acts strangely when pushing through the punch lists (which are UIs) but for everything else in the room the ghost hands appear perfectly in front of everything else.

I played around with different override settings to try and fix the ghost hands appearing behind the punchlists but none of those changes made a difference, so this remains a bug for right now. I had briefly thought maybe it's the sockets my hands collide with that cause this to happen but moving the punch list my ghost hands to render above the wall and socket.  I'm not sure if there is a fix for this or what that might be.

I ran into a bug play testing tonight where continuous motion didn't engage.  But I didn't pay attention to what I had done prior to that bug that might have contributed to this happening.  But I do have video footage I can go back and watch.  When I reset the room this engaged and worked again.  So I'm not sure if it's a one off issue or if there was maybe a sequence of checking other items that didn't engage that turn motion provider.  

I fixed the colliders for the fireplace and I turned off Convex for its mesh collider so that the physics hands no longer clip through either the fireplace nor the pipe. This once again contains the sparks within the fireplace.

The door motor didn't engage at one point but I'm not sure if that was because the door stopped before hitting that collider or if it was a bug.  I'll need to do more play testing to determine.  I trested this some more, I removed the second box collider on this came object, which was in error and I adjusted the position of that collider.  It takes a second to disenage the motors but I believe this is working correctly. I don't know if my code can be optimized to disengage these sooner but I'll take a look at that.  It's a bug for now.

I readjusted the attach transform for my watermelon so that the first bite is directly in front of my face (not on top and slightly behind).  This looks much better now.

The dynamic shadows are looking rough around the remote, game controllers and lamp (which should be marked as static anyway) and those need to be fixed via an update to my light map. 

The bottle clipping through the floor is still an issue and needs to be solved, if at all possible.

That's all for tonight.
@mattdway mattdway committed on Feb 18

04-27-23 v4.0.0 Commit
From Feb 18 to April 27

- Many ascetic material and texture changes to the room
- I added spot lights to the book rack for effect.
- I changed out the coffee table and the four doors of the cabinets with a blue glass material.
- I added multiple blue point lights to the new glass material coffee table and to the inside of the cabinets to give this a cool modern look.
- I changed the wall material to gray.
- I changed the door material to a mustard yellow.
- I changed the chair color, the trunk color and the cabinet door and drawer door color to blue.
- I changed all the cabinet handles to black (the cabinet with the two doors I ended up adding a metalic backing using a 3D cube game object overlay and I did the same thing with the handles only using a black metalic material for the handles.
- I changed the top of the cabinets material to a metalic black. 
- Added the modern book rack (free asset) to the room and I populated these with books and sockets for each book.
- I changed out the rug from the purple and gray (80's style) to the cool gray with the diamond.  I did this by changing not the material but the mesh filter.
- I changed the clock from black to red.  I did this by downloading the working black clock (the black clock asset had serious problems in the 2020 version) from the 2021 starter files on the Learn.Unity.Com Create with VR section and then by changing not the material but the mesh filter.
- I changed the couch texture from white to black and I added in a leather material (I downloaded from free leather chair assets for their texture files and I used those to create my own material for the couch).
- I changed all the room lighting to white to give this a cool, more modern, look.  The yellow lighting was also giving the black and grays in the room (couch, walls) more of a brownish tint at times.  There's still a little bit of yellow light from the sunset (Enviorment Skybox) from outside but all inside lighting is now white). I also rebaked my lightmap (I left the book case light, the coffee table and cabinet lights dynamic because they needed to be to really read as lights -- plus the light bounces dynamically off the glass texture, which is the effect I was going for).
= I created my own fire particle effect from a YouTube tutorial.  This also means that the free fire asset I was using before (that didn't look great and that had multiple layer stop errors) is no longer a part of this project (removed from the Project folder).
- Added the "It's Fine" meme.  
- Got the asset from Thingiverse, converted the STL to OBJ and I brought this in and assembled.  
- I then used 3D object overlays so that I could add material colors (my Blender skills aren't there yet!) and these were single game objects so adding multiple materials weren't possible due to there being only a single mesh filter for the entire object).  
= I then positioned this outside the window
- I added cool creeping fire particle effect from the free Unity particle effect asset and I created and added my own smoke particle effect (from a YouTube tutorial).
= I then wrote a script that activated this game object whenever the rug fire was instantiated and I used a coroutine to keep this visible for 10 seconds (the same amount of time before the rug fire game object is destroyed), before disabling the It's Fine meme again.  This has the effect of having the meme visible until the last flame is extinguished (as the ten second timers is started every time the rug fire is lit).  It also has the effect of adding more and more smoke every time the rug fire is lit (making the meme disapear in smoke if lighting additional rug fires.
- Added the "Legend of Zelda" meme.  
- I got the wood sword and the cave wizard assets from Thingiverse
- I assembled and converted the STL to OBJ and I brought this in and assembled.  
I then used 3D object overlays so that I could add material colors (my Blender skills aren't there yet!) 
- I created my own handle out of Unity 3D cylinders so that I could add the alternating colors via materials, appropiately.  
- I scaled everything appropiately to have this be the correct size when held.  
- I created cave walls with a texture material and a back wall, floor and ceiling with a black texture. 
- I replicated the cave wizard's message from the Legend of Zelda game using TMP canvas, image and TMP components.  
- I added Unity lighting to the fire 3D objects on either side of him.  
- I added an Audio Source to the wooden sword using a downloaded FX used in the original game whenever Link picked up an item.  
- I added collider, rigid body and XR Grab Interactable components to the sword.  
- I linked the audio source to the OnSelect event of the XR Grab Interactable component.  
- I then wrote a script, attached to the cave, that activates the cave around the player for 3 seconds and then deactivates it again after.  
- I linked this to the OnSelect event for the XR Grab Interactable for the sword, as well.  
- I modified and prefabbed the Unity fireball particle effect from the free Unity particle effect asset (changed the size of the partile to only be one fireball, changed the start size for all parent and child elements in the fireball particle effect, I changed the added a collier and rigidbody to this, I changed the size angle from 360 to 9 so that these fireballs would spawn from the tip of the sword and not randomly all around the player)
- I created a new script, and I copied and pasted (reused) the Fire() method from the dart gun to make it so that the sword shoots fire balls (like in the game when Link has full health). This also included creating an empty game object with the transform set appropiately and placed at the sword.
- Improved the rug fire by adding my own fire particle and smoke particle effect
- I made the darts stick to the wall surfaces (anything with a tag of wall).  These darts also unstick after a period of time and sometimes don't stick at all (they are 'suctioncups,' after all :))
- I fixed the tennis racket attach point so that this is held in a natural and authentic position (thanks to my student who helped with this).
- I added art lights to each of the three paintings (made out of scaled cubes with a black metalic material and spot lights).

- I added and worked more on the dart game:
- I added an activation area that starts this with TMP for score, points granted, and a timer along with playing an free retro arcade starting up FX sound effect.
- There are collision and point calculation issues.  I have an idea for a rebuild of my own target (rather than the paper target) -- I just haven't sat down to work on this yet.  Part of the issue is the dart calculating twice when stuck to a collider and another issue is when a dart lands between two colliders.  Creating a dart board with offset layers should fix the second piece.  I added a bool variable check to try and mitigate the first.
- Current version has torus shaped colliders for each ring and individual collision detection and point awarded.
- There is also a GameManager.cs script that manages the overall mini-game.
- There is a count down timer that writes the time remanining to a TMP, using a free retro arcade font.
- Points awarded are written for about 2 seconds to a TMP, using a free retro arcade font and a retro arcade points FX sound effect.
- Overall score is calucated and displayed in another TMP, using a free retro arcade font 
- The timer doesn't yet do anything when time runs out.
- An unknown bug has caused the timer to stop working (isn't starting the count down currently).
- I need to add win and lose screens.

Other things I fixed:
- The front door hinges were no longer allowing the door to open.  Replacing it with the Unity prefab and then readding all my components and materials fixed this.
- The front door handle was no longer grabbable (most likely do to a change I made in the asset parent/child relationship to try and fix a different issue).  Restoring the door from the Unity prefab also put this back the way it was before.
- The Front Door toggle button was no longer working -- fixing the door and relinking assets to my button's script fixed this issue.
- I fixed the rug teleportation, the new game activation teleportation area and front door mat teleportation staying on bug - just needed to add events to my Settings menu for continuous motion to turn the teleportation anchor off for those two teleportation areas.
- Moved the teleporation mats back along the east wall (with the addition of the modern book rack these needed to also be moved back so that the player isn't teleporting uncomfortably close to that book rack).
- I fixed the rug fire not working bug
- I fixed the XR Rig not working in the Peaceful Nowhere scene
- I updated XRIT again and this broke all the References in the XR Origin and children again, so I remapped these appropiately.

- I updated the version number and build date on the Welcome board.

To do next:
I need to decide if I want the gym aesthetics to be the same or different from the main room, I need to add in the correct XR Origin to that scene, I need to create buttons in the main room and in the gym that changes to those scenes as well as adding writing the scripts and adding the climbing mechanics to this scene.

I fixed the lack of .git folder (this project was no longer a git repository) so that I could commit to this GitHub on this date. 

That's all for now.
@mattdway mattdway committed on April 27

04-30-23 v4.0.1 Commit

I replaced the paper target with a new slightly stacked target out of cylinders in order to help avoid collisions between two colliders.
I simplified the code by removing the time constraint before awarding a point but I kept the coroutine and .05 time delay before clearing the points awarded TMP. I changed it so that this happens after updating the score to help try and fix scoring issues. With these changes I am now not seeing the double or high scoring on a single shot.
However, the scoring system is still not working correctly. Sometimes a dart hits a 30pt collider but is registering as 20pt, as an example. Sometimes a dart hits a collider and the points awarded shows a collision but the overall score is not updated. I'll need to come back and figure out why.
The timer still is not counting down. It was initially so I need to figure out why. This is a method in the GameManager.cs script.
I still don't have any code that reacts when the time runs out nor any sort of win or lose screens or reset button attached to that screen. This functionality needs to be built (once the scroring system is in place).
I removed the event link that reset the score when the dart gun is dropped. There is already a bool that prevents reloading while in the mini-game and this is unnecessary and undesired to reset the score when the dart gun is dropped or dropped and picked back up before it drops.
I resized the activate collision zone so that the user can't stand so close to the dart board.
I fixed some bugs...
Door handle on the cabinet with the drawer was streching due to some settings with the XR Grab Interactable. I believe it was the "Throw on release" setting combined with the interaction layer allowing this to interact with the door, that was allowing this to happen. Unchecked that checkbox and I changed the door handle layer from Furntiture to Default and this fixed the issue.
I set an attach point for the decretive record so that this facing the correct way when picked up.
I changed the record player layer to furniture so that my hands don't pass through this.
I discovered my front door collider was deactivated in the Hierarchy. I reactivated this.
I discovered that the front mat was no longer linked in any of the events for the Settings > Continuous Movement, Limited Movement and Teleport Anywhere settings. Thus this wasn't being deactivated or reactivated when those are selected from the settings. This field had been emptied out in all three places.
I changed the modern book rack's layer to Room and the tag to Wall in order to make sure that I couldn't phase through the book rack when leaning forward (this activates the same pushback as seen on the walls and door).
That's it for now. @mattdway mattdway committed on April 30

05/09/23 v4.0.2 Commit

* Added overlay to VR when picking up sword.
* Added a sword swoosh sound based on velocity of the sword object.
* Changed out fireballs for a mini-glowing sword shooting effect
* Set up post processing in my project with a Volume, a post-processing layer, etc. but I couldn't get those post processing glow effect to work.  Ended up adding a point light to the sword to give it a glow like effect, for now, but would like to come back and try and get that post processing effect to work.
* Fixed attach point of sword.
* Fixed Start Point positional transform for sword shooting.
* Recreated the target from polygon shapes (as I had to restore from a backed up copy of this project recently).  Downloaded and * reused the scripts I had modified/created before from my online Git repository.
* Adjuste the height of my dart gun-mini game activation box.  I did this by eye in Scene view (I haven't tested yet in VR and may need to adjust further once I see this in scale, in play mode).
* Added a cube with the Half Life Alyx flick mechanism, following Valem Tutorial's YouTube video.  I applied this script to the cube in the room, only.
* I also added a custom socket to both of my VR hands following the VR With Andrew YouTube XRIT #3 tutorial.  I applied this script to the cube in the room only.
* Added then removed asset script that makes the cube have a white outline.
* I added a custom material (with a metal shader and some decaling to the cube showing power gloves) to indicate what the user should do with this cube.
* I also added a plane with a custom material (with a metal shader and some decaling to the cube showing the Half Life logo), which I placed under the cube, to indicate what the user should do with this cube.
* Still need to work more on the mini-game.  The detection/scoring code is not yet working the way it is supposed to.

That's all for now.
@mattdway mattdway committed on May 09

05/10/23 v4.0.3 Commit

* Re-fixed the front door mat not being in the events for each of the three locomotiion methods.  Thus not being turned on or off.
* Tested and tweaked setting for broken window.  If violent enough the game simply resets.  
* Addeed || OR to code for laptop breakage.  Sword and darts now can break the laptop.
* Added a brick with the text "IN EMERGENCY, BREAK GLASS"  Using it to throw against the window.  Sometimes doesn't break the window.
* Adjusted the Dart Gun Mini Game activation area to make it smaller and further back.
* Set Mesh colliders to convex then on so score activiation works.
* Tested dart gun collision on target extensively.  There are still occasional missed score updates and sometimes odd points awarded.  Hitting the target numbers square on helps but the problem is still there and evident.
* Updated the version number on the board.

That's all for now.
@mattdway mattdway committed on May 10

05/11/23 v4.0.4 Commit
* Improved brick texture by trying to download a free Unity Asset 4K brick texture pack.  Download is failing so I'll try again later.  Changed tiling settings of current material to remove tiling effect and I played with maps to try and get this looking slightly better.
* Made text on the brick look embossed/etched by changing colors, alpha and by adding a material.
* Worked on improving code to get glass sound to play when window is broken.  Haven't yet tested but modeled after another script in which I have sound working.
* Removed frame from broken window so that it's now just a glass pane.  Made into a new prefab and relinked to the three scripts.
@mattdway mattdway committed on May 11

05/17/23 v4.0.5 Commit
* Disabled single collider for the window and I duplicated and made three individual colliders for each section of the window.  This way the script can destroy the collider for just that one section of the broken window while leaving the other in tact, at the time that section of the window has been broken.
* I added a mesh collider to the cross section of the frame so that hands and other game objects collide when interacting with it.
* I added a "Wall" tag" and a "Room" layer to this so that the character controller can not pass through nor lean/clip through that mesh.  Now the player can't jump out the window when it breaks, but the player can throw items through the opening where the glass pane has been broken.
* I fixed the glass break sound issue by realizing that I had the audio source attached to the glass panes, which were being destroyed.  Thus, if I called for the audio clip to be played before the broken window it worked but after did not.  I fixed this by changing where the audio source is played from and not having it attached to the panes being destroyed.
* I changed the logic of the broken laptop so that players can still break the screen if they shoot darts or swords at the screen or drop it on the ground or wall.  But, they can not permenently break it (to where the laptop no longer turns on) until after the rick roll video has been started.  This way, rick rolling the player is still always a posibility.  The user pressing the power button with the broken screen still plays the video but because the screen is broken, they can only hear the audio at this point.
* In play testing I accidently forgot that the windows now break.  So throwing the laptop at the window while the rick roll video was playing broke the pane of glass and the laptop plummetted into infinity below.  However, because the video audio is 2D (not spatial) the audio continued to loop and play indefinitely.  I changed it so that the audio for the video is no longer direct but pointing to an audio source.  I then set that audio source to be spatial.  Now when the laptop plummits the sound gets fainter until it can no longer be heard/stops playing.
* I set up grab hand poses per Valem's two part video series.  I've been troubleshooting this for several days but the posed hand child objects, so far, never reenable in the scene nor does the transition between the VR player's hands and those posed hands ever happen.  I'm still working on troubleshooting why.
* A few assets were found accidently nested inside other folders, when they should have been at the root level.  I moved these back to their proper location.
* I have not yet updated the version number nor date on the welcome board to reflect these changes. I'll do this the next time I am in my project and the next commit will reflect this.
That's all for now.
@mattdway mattdway committed on May 17

06/22/23 v4.0.6 Commit
* Started with restoring a May 17, 2023 commit from GitHub as other changes went wonky including trying to import in packages from the Unity '23 demo scene, which created stop errors with many of those scripts and the transforms of my walls and many other objects somehow being slightly rotated.  Not much substantial had been done since before my summer '23 STEM-X class to this room.
* In this commit I had already restored the Git files needed and I'd replacced the corrupted video files with a local copy.  I still have the original (non-working copy) on my WD HD in case I need anything from that folder.
* I did a quick play test after restoring from the 05/17/23 commit to make sure everything was still working OK.
I moved the reset button from the counter over to the north wall under the settings and welcome menu UI buttons.  Tested and this button still works.
* I adjusted the X and Y position of the canvas parent for the Reset button, as it wasn't centered exactly.  I did this positioning in isometric mode.
* I added more screens to my welcome screen in order to better explain things.
* I redid all the buttons to incorportate showing and hidding the new screens and buttons on the welcome screen.
* I added the text "Tutorial" to the first page of my welcome screen, the Oculus controller screen, to make it more obvious to anyone playing that the screens purpose is to orient you and to explain the controls.
* I edited online the PDFs for the Oculus controllers and the HTC Vive controllers to make the background transparent (the layers for the main background color and the left rectangle were already there, I just had to hide these and then Save As to save a new transparent copy of the PDF back to the correct Assets folder in my project). I then needed to make these a 2D Sprite and to copy the settings as seen in other sprites so that I could select these images as my background on those welcome screen boards.
* By selecting the transparent versions of these images and by turning the alpha all the way back up I was able to have the image appear at full brightness while still having a transparent background).  Because there are three of these images stacked, this is significantly brighter and easier to read in the VR headset (where things don't appear as bright as on a computer monitor).
* I also added an empty parent to group the Oculus controller images and the HTC Vive controller images together.  This way all three could be deactivated or activated, appropiately, via the welcome screen's UI buttons.
* I rearranged the Controlers text header, the Oculus button and the HTC Vive button at the top of the screen under the main controller parent object so that I could disable the parent and also disable the header text and two buttons at the same time, without having to seperately map each to be disabled/enabled seperately, via the click event.
* I added tooltips to my Settings and Welcome wall buttons.  I added colliders (resized) and a XR Simple Interactable to both buttons and I then used its OnHoverEnter and OnHoverExit events to show and hide those tooltips, appropiately.
* I played around with colliders on the tooltips to see if I could get these to not clip through the wall with the verticalbillboard script attached.  In the end I unchechecked to disable that script and the colldiers so that these appear flat at all angles (as those buttons are 2D and against the wall).  The colliders were also killing my FPS and causing huge lag.
* I had to remember to set the XR Simple Interactable's Interactive Layers to Default and Raycast, as I was only able to activate these tooltips on hover if my Jedi Pull was activated before and I wanted these buttons and the OnHoverEnter and OnHoverExit to work even without distance grabbing (Jedi Pull) activated.
* That's it for now.  Later on today I'm going to see if I can hinge the blue chest and make it interactable and I am going to continue to work on making the door lockable (only able to be opened when a key has been inserted and turned and the door handle has been pushed down) via a combination of scripts, configurable joints and sockets.
@mattdway mattdway committed on June 22

06/24/23 v4.1.0 Commit
* Last night I created a testing ground outside the main room with a duplicate XR Rig I can enable (after disabling the original) so that I will spawn in that new area.  It currently contains a floor, the two doors I exported (to only include the actual material, script, texture and prefab dependencies) from the Unity XRIT 2.3.1 demo scene) to study, to get working completely and to learn from so that I can better understand what each script and component is doing to create a working locking door mechanic.
* Tonight I added a digital smart watch with the working digital time.  Tomorrow I'm going to add Valem's wrist menu to this to make a holographic menu that I think I'll add buttons to activate the Welcome Menu, Settings Menu, Interactable Menu and Reset Menus, all from that interface.  Later on I can change this to include somthing better like (maybe) an inventory system of some sort.
* The watch is in place on the left hand and has all the necessary aesthetics needed to make this look like a digital watch with a black leather band and the script has been written and applied that adds the digital time in the hh:mm:ss tt format (tt being AM/PM as the time has been crafted to be 12 hour, not 24 hour time).
* That's it for now.  More tomorrow.  I also need to get back to the hinged blue chest piece and then I'll maybe work on the test doors some more.
@mattdway mattdway committed on June 24

06/25/23 v4.1.1 Commit
* The digital smart watch now has a hand menu that is activated by tapping or by slapping on the watch face with your right hand.  The menu has a small cone of blue light followed by a lit blue holographic (partially opaque) menu with four buttons.  
* The font is an a free arcade font, all capital with horizontal lines running through it.  
* The cone game object and the menu have been carefully positioned to make it appears as though it is being admitted from the watch.
* Both the cone game object, the UI panel and the UI buttons received a custom blue transparent background.
* The cone received it's own blue point light to make this appear as though this was a beam of light. 
* I added a second blue light to this menu, giving it that holographic look and feel as well as that slight flickering. 
* I also added a downloaded Star Wars esq scanlines from this website: https://www.oocities.org/~special_effect/sw_hologram.html
* There is a MENU header at the top.
* The four buttons at the bottoim bring up the: Settings Menu, the Tutorial (Welcome) Menu, the Interactables Menu and the last resets the room.
* For the last one, I set this to directly run the ResetCurrentScreen method of the script rather than bring up the menu.  This makes for a quick way to reset the room if needed (or to reset in case of falling outside the room).
* I added popup tool tips for the Settings button and the Close button for the Welcome Board.
* I added popup tool tips to the close buttons for the Settings menu and the Interaction Menu, to be consistant.
* I updated the version number and the date on the Welcome board.
* Later today or tomorrow I'll work on the hinged blue chest piece.
* That's it for now!
@mattdway mattdway committed on June 25