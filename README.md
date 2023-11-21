# Project _NAME_

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

_REPLACE OR REMOVE EVERYTING BETWEEN "\_"_

### Student Info

-   Name: _Sebastian Garcia Montejo_
-   Section: _04_

## Simulation Design

_Bees wandering around the scene looking for nectar. Player can interact with the scene by placing flowers and bears, which will change the behavior of the bees.
They will be attracted to the flowers, and will run away from the bear. The bear will attack the hives of the bees, and if he is successful in destroying the hive, all the bees on screen will attack the bear._

### Controls

-   _Left Click - Place Flower (Bees will be attracted to it)_
-   _Right Click - Place Bear (Will attack hives)_

## _Bee_

_The bee is spawned in by the AgentManager, which will wander around the scene seeking flowers and separating from other bees._

### _Passive_

**Objective:** _Wander around the screen._

#### Steering Behaviors

- _Wander, Flee_
- Obstacles - _Bounds, Bear_
- Seperation - _Bee_
   
#### State Transistions

- _When there are no Bears or Flowers_
   
### _Working_

**Objective:** _Collecting Flowers for the hive._

#### Steering Behaviors

- _Seek, Flee_
- Obstacles - _Bounds, Bear_
- Seperation - _Bee_
   
#### State Transistions

- _Player places a Flower on screen_

### _Attack_

**Objective:** _Attack the Bear._

#### Steering Behaviors

- _Seek_
- Obstacles - _Bounds_
- Seperation - _Bee_
   
#### State Transistions

- _Player places a Bear on screen_

## _Bear_

_Can be placed on screen, will attack hives._

### _Passive_

**Objective:** _Bear will walk around the scene peacefully_

#### Steering Behaviors

- _Wander_
- Obstacles - _Bounds_
- Seperation - _Bear_
   
#### State Transistions

- _No hives on screen_
   
### _Attack_

**Objective:** _Bear will attack the nearest hive._

#### Steering Behaviors

- _Seek_
- Obstacles - _Bounds_
- Seperation - _Bear_
   
#### State Transistions

- _Targets the nearest hive on screen_

## Sources

-   _https://www.flaticon.com/free-icon/bee_1328765_
-   _If an asset is from the Unity store, include a link to the page and the author’s name_

## Make it Your Own

- _Player will be able to left click to add flowers, and right click to add bears. Both of which will change the behavior of the bees._

## Known Issues

_List any errors, lack of error checking, or specific information that I need to know to run your program_

### Requirements not completed

_If you did not complete a project requirement, notate that here_

