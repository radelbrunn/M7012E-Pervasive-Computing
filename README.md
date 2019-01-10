# M7012E-Pervasive-Computing

This projects aims to show how virtual reality could be used in education. It provides two types of levels, math and spelling/language. 

## Prerequisites

### Hardware
* A VR headset (tested with HTC Vive pro)
* Leap Motion Controller mounted on the headset

### Software
* Unity 2018.2.16f1
* Orion beta (for integration of leap motion in VR)  

## 3rd-party Assets
Some of the assets in the project has been taken from Unity Asset Store and is placed in the 3rd-party folder. *These are not to be redistributed and are excluded from git.*
* BigFurniturePack
    * Used for the fancy tables seen in game.
* ClassRoom Stuff
    * Some materials and textures used.
* Hover & HoverDemos
    * Used to make the hand menu for the game. 
    * Downloaded from: https://gallery.leapmotion.com/hovercast-vr-interface/
* Leap motion
    * Contains the core assets and interaction engine for leap motion.
    * Downloaded from https://developer.leapmotion.com/unity/#5436356
* SteamVR & SteamVR_Input
    * Used to enable a VR camera for the VR headset. 

## Setup instructions (HTC Vive)
1. Attach your kit  
2. Set up your controller  
3. Explore the Gallery  
4. Start building  
[Further instructions and documentations can be found at leap motions own development guide:](http://leapmotion-developer.squarespace.com/documentation)

## How to run the project

1. Open the project in unity
2. Navigate to Assets/Scenes and select math1 or spell1.
3. Make sure the vr headset and leap motion is connected and ready. 
4. Drag the other scenes into the hierarchy and unload them.
5. Go to File -> Build settings and press "Add open scenes"
6. Put on the headset and press play. You should appear in the middle of the room with both tables in reach and you should see your virtual hand models appear by looking at your hands. 

## How to play
The game revolves around moving cubes from one table to another. Cubes are spawned at the table to the right while looking at the blackboard and should be dropped at the table directly in front of the blackboard. The blackboard provides instructions for each task and provides instant feedback to what has been placed at the answer table. In math levels, the answer table will respond to the total sum of cubes added whereas in spelling/language levels, the answer table will account for the order in which the cubes are placed. 

The cubes will appear on the right table and will respawn if dropped on the floor. For math levels the cubes will receives different integer values and for spelling/language they will have letters and/or complete words. 

When all the tasks have been completed the game will proceed to the next level. By looking at the palm of your left hand, a menu should pop up with four alternatives:

* Start
* Settings 
* Scoreboard
* Exit

By pressing and holding the start button you are able to change between math and spelling levels. The settings menu currently only support a toggle for gravity which will disable gravity for all the cubes. Neither the scoreboard or exit buttons have been implemented. 

## Troubleshooting
Sometimes the htc vive desides to mess up the positioning and you can end up out of place for example bellow the floor or inside the table. This can be solved by doing a recallibration or to simply move entire hand menu object to account for the displacement. 

If some components are not responding like the blackboard not responding to changes. Make sure the controller objects have the correct variables and have references to the necessary game objects.

The **GameController** should have:
* A Game Type
    * Either 'math' or 'spelling'
* A interaction objects reference
    * The interaction objects can be found as a child to the Stage Root.

The **Level Controller** should have either a MathLevel- or SpellLevel component attached to it.

A MathLevel component needs:
* A Sum Component
    * This is the Text component on the blackboard where the sum is displayed. It is found in Stage Root -> Blackboard -> Canvas -> Sum
* Title Component
    * The Text component on the blackboard where the title is displayed. It is found in Stage Root -> Blackboard -> Canvas -> Title
* Description
    * The Text component on the blackboard where the description is displayed. It is found in Stage Root -> Blackboard -> Canvas -> Description
* TC (Timer Component)
    * A component that deals with timing and delays. Should be at the root in the scene heirarchy with a TimerScript attached.
* Controller 
    * A Reference to the GameController at the root. 
* Path To Level
    * A string path to the json file describing the level. The current four levels are found at:
        * Math level 1: ./Assets/Levels/matlevel1.json
        * Math level 2: ./Assets/Levels/matlevel2.json
        * Spell Level 1: ./Assets/Levels/spellevel1.json
        * Spell Level 2: ./Assets/Levels/spellevel2.json


A SpellLevel component needs the same as a MathLevel aswell as:
* BC (Boxcast Collider)
    * The component responsible for sensing the order of the cubes. Should be located at Stage Root -> Stage -> Drop Table -> GameObject -> Boxcast Collider Cube


## How to add more levels
Adding more levels is made easy by having the LevelData class serializable as json. 
1. Create a new json file in Assets/levels with the format seen below.
2. Create a new scene and copy/paste the previous levels scene content (math2 or spell2). 
3. In the LevelController gameObject, update the 'pathToLevel' to match the new json file created. 
4. Change the value of the cubes to match the level. 


### Json format

```json
{
    "lessons": 
        [
            ...
        ],
    "answers":  
        [
            ...
        ],
    "timeLimits": 
        [
            ...
        ]
}
```

## Android VR
Coming soon – the Leap Motion Mobile Platform

# Further information
Further information can be found at:  
https://relaxz.github.io/M7012E-Pervasive-Computing/
