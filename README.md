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

12-31-22 v2.8.2
12-31-22 Commit
Up next to fix:
 
These four clock pieces have been fixed.

1.) The clock socket has been fixed.  This was a combination of the socket's Interaction Layer Mask settings to include the clock, the positioning of the socket on the wall (it needed to come forward away from the wall just a tad) and adjusting the rotation of the socket on the wall (180, 180, 180) so that when the clock did socket it didn't socket to the outside of the wall.  Adjustining these three pieces allowed the clock to socket to the wall without any further issue.

2.) I also adjusted the LeftHand Ray and Righthand Ray Interaction Layer Mask to include the clock and to exclude Art.  This way the art could not be picked up via raycast (I tested and this did cause a lot of distruction when calling for the large painting from across the room -- anything it hit between its original position and my position went flying) and so that I could grab the clock from afar.  

This was also a great reminder to be sure to update these Interaction Layer Masks (as these are not set to Everything) whenever a new item has been added to the room otherwise these won't be able to be picked up via distance grabbing.  I checked and all items that should be able to be grabbed with distance grabbing can be and anything not able to be grabbed by distance grabbing: the doors, the drawer and the art) cannot.

3.) I rebaked my lighting to get rid of the static shadow behind the clock, now that the clock is dynamic and is able to be grabbed.

To do this, I adjusted my lighting to make sure that every light in my room (minus the flashlight) were set to baked.  This includes: Chandellers, Entire_Room_Point_Light (which I had thought was legacy and should be set to real time and disabled but in doing this I found out that most of my room was in shadows, so I changed this back to baked and rebaked my lighting for my room to correct), Outside_Directional_Light, Fireplace_Modern, Lamp_Floor_Double, Lamp_Table_Red and Sconces.  

I also went through and made sure that all of my "-- STATIC --" and all of my "-- STATIC INTERACTIVE --" and that all of my "-- LIGHTS --" game objects were set to "Static" in the inspector, to the right of each game object's name.  Under "-- DYNAMIC --" I also checked that nothing there was set to static with the exception of these items: 

Under "-- DYNAMIC --" > "Cabinets" > the following items were set to static:
"Cabinet With Drawer"
"Left side panel"
"Shelf"
"Top"
"Right side panel"
"Bottom panel"

"Door and "Drawer" do not have the "Static" checkmark, however, since those objects are grabable and are ment to move.

Under "-- DYNAMIC --" > "Cabinets" > "Cabinets With Two Doors" > "Cabinet_Modern_Left" and "Cabinet_Modern_Right" the following items were set to static:
"Cabinet_Body"

"Cabinet_Door_Left" and "Cabinet_Door_Right" and their child object "Handle" do not have the "Static" checkmark, however, since those objects are grabable and are ment to move.

I used the trick of searchingi for t:light in the Hierarchy search bar to expose all the lights, I then used "Ctrl" + "A" to select all, I held down the "Ctrl" key and then single left-clicked on "Lightsource_FLashlight_Yellow_Spot Light" and then in the "Inspector" pane under "Light" I changed the "Mode" parameter from "Realtime" to "Baked."  
Then, under the "Lighting" tab or "Windows" > "Rendering" > "Lighting" I single left-clicked on the "Generate Lighting" button to render a new lightmap.

I made the mistake of under the "Lighting" tab > "Enviorment" > "Skybox Material" of having the "MegaSun" skybox selected.  When baking a lightmap the lightbox light color and reflection colors are included and this gave a very washed out orange tint to everything in my lightmap.  To fix this I had to temporarily change the "Skybox Material" back to "Sky-Default" then rebaking my lightmap again.  After this baked I then changed the "Skybox Material" back to my "MegaSun" skybox, of choice.

4.) I fixed the roation on of the clock when picking it up.  I had to go into "Edit" > "Project Settings" > "Physics" and I had to disable the physics interactions for both "Clock/Clock" and "Clock/Pseudo Body" so that the clock couldn't interact with either.  Once set this object rotated as normal.  I also doublechecked that "Smooth Position" and "Smooth Rotation" were both checked in the "XR Grab Interactable" component settings.  They were.
 
I turned off raycast distance grabbing for all objects of the "Art" layer.  Due to the large size of this art and its collisions this caused too many issues distance grabbing from across the room.  Art must be grabbed using "Direct Interactable", now, only.

I moved the dinning room chairs and the hidden teleportation anchor mats back so that it is easier to climb onto the chairs to climb onto the table to reach the shelf where the record player, record, and books live.  From this vantage point players can also directly reach the clock and the painting, if they so wish.

I moved the "Measuring Stick" game object from static to "-- DYNAMIC --" as this is a grabable object and this is where this should live.  The "Measuring Stick" is a disabled game object used as a quick referene for sizing objects to all be the same.  Yesterday I changed the height of this measuring stick to 0.3048 meters, which is 12 inches.  The same length of a standard ruler. 

I also updated the version number and the commit date on the Welcome Menu screen.

To Fix Next:

Writing a script for the Water Bottle Flip Challenge to detect when there is a floor collision with either the top, sides or bottom and to play a corresponding sound when that happens.

Determine if there is a good solution for the character controller colliding with the cabinet doors when leaning forward. 

Determine why my physics hands can clip through the dinning room table and chairs when at a fast enough speed.  Try and make this work more like the couch or outside colliders.  Test with other furniture to see if anything else in the room allows this to happen.  Compare and contrast to troubleshoot.

Thin items like photos from the polaroid camera and my punch list sheets are still sometimes getting stuck under the floor and I need to troubleshoot that more to try and fix.

Updating the Interactive board and/or punch lists.  I'm running out of room on my punch lists and I have no more room to add additional punch lists, so I'll have to decide how I wish to use these moving forward.  I still love the idea of having bugs and/or future features viewable in VR and I have a lot of future ideas (both from ideas I've come up with and that my students have come up with that could be added).

If I get that working I feel like I have a lot of the bug pieces for all the current items added to my room fixed.  I'll have to go back to my bug list to check to be sure, but off the top of my head there aren't any others that are coming to mind that I need to fix.  At this point I may choose a new feature to add to this room, just to continue my (and my student's) learning.
@mattdway
mattdway committed on Dec 31