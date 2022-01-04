<h1 align='center'>
<img src='/ReadmeAssets/AMAZEINGTitle.png' alt='AMAZEING'/>
</h1>

<h3 align='center'>
Console labyrinth project for school
</h3>

<p align='center'>
<img src='/ReadmeAssets/AMAZEINGScreenshot.png'/>
</p>

# Summary
* [Requirements](#requirements)
* [Quickstart](#quickstart)
* [Project overview](#projectOverview)
* [Project features](#projectFeatures)
* [Remarks](#remarks)
* [Play Recommendations](#playRecommandations)


## <a name='requirements'>Requirements</a>
C# version 9.0

*Note: This is the version that I used at default, it may run on lower one.*

## <a name='quickstart'>Quickstart</a>

command:

```bash
$ git clone "https://github.com/LeoKaiser2000/Console-Maze-Game.git"
```
Clone the project, build sln with your favorite compiler or IDE.

## <a name='projectOverview'>Project overview</a>

This project is a labyrinth console app game for school.

You can play by solving maze or generate your own.

The game is composed of 4 scenes:

### Main menu scene
The main menu is used to select maze resolve or generation.
```
What would you like to do ?
1) Play
2) Generate a level
3) Leave Game
```

### Level selection scene
The level selection display all levels, which are ".txt" file on the folder "LevelFiles".
```
Witch level would you like to play ?
1) level1
2) level2
3) level3
```

### Maze resolve scene
The game itself, showing rooms connected to player location while any end is reached.
```
You arrived in room: Hall_Of_Infinity.
In front of you, a panel, showing the connected rooms.

Which room would you like to enter ?
1) Entry_Of_Labyrinth
2) Room_Of_Echos
3) Dinning_Of_King
4) Swamp_Of_Solitude
```

### Maze generation scene
The maze generation is made by a bunch of question.

*Note: You can choose to have several end in maze*

At the end og generation, you can show the solution.

```
Enter the name of new level:
> WorldTravel     
Enter the name of evey rooms, separated by spaces:
> Croatia England UnatedStates Germany Brazil France China Congo Canada Australia Russia SouthAfrica
Enter the name of starting room:
> France
Enter the name of evey ends, separated by spaces:
> Croatia Brazil
Enter random link rate (number from 0 to 100):
> 16
Do you want to show minimal move number or solution ?
1) Do not show
2) Show only minimal move number
3) Show minimal move number and solution
> 3
Maze can be solved in 2 moves : France => UnatedStates => Croatia
```

## <a name='projectFeatures'>Project features</a>

### Mandatory

* Labyrinth Game (1.5 points)
  * Handling user input ✓
  * Player spawns in a point ✓
  * Player move to all connection points ✓
  * Player's location show each turn ✓
  * Minimal step calculation ✓
  * When player is at the end
    * Congratulation message ✓
    * Number of step took ✓
    * Minimal number of step ✓
    * Level Selection Menu ✓

* Level (1 point)
  * Written in a file on a disk ✓
  * Own data structure ✓
  * Self made parser ✓
  * Level composition
    * Starting point ✓
    * End point ✓
    * Points connections ✓

* Level Select (0.5 point)
  * Level screen to display level ✓
  * All level files in a specific folder ✓
  * Minimum 3 levels ✓

### Bonus

* Teacher can't end game

*Note: As teacher did not already play, I can't be sure of anything. But I did a nightmare one.*
*Note: Because of level generator, game can be infinite*

### Other features that wasn't asked

* Level Generator
  * Rooms name input ✓
  * Room start input ✓
  * Room Ends input ✓
  * Random additional link probability input ✓

* Multi end handling ✓

## <a name='remarks'>Remarks</a>

*Note: I made it on a Linux platform, but check compilation on windows too.*

*If you have any trouble, please contact me.*

## <a name='playRecommandations'>Play Recommendations</a>

### Create your own maze

Do not underestimate power of easy create new maze. Try new with location, spaceships or political figures.

### Nightmare maze

Do not try the level names "levelNightmare" - except if you are the grader ^^.
