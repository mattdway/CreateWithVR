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