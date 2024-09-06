# ITProject 🍕 Emotional Pizzeria
![image](https://github.com/user-attachments/assets/d22ce700-e910-40eb-b831-e7cfff9c15eb)

## Table Of Contents

- [About](#about)
  * [Contributors](#the-team)
  * [The game: Emotional Pizzeria🍕](#the-game)
- [Deployment Procedure](#deployment-procedure)
  * [iPhone](#deployment-to-iphone)
  * [Windows](#deployment-to-a-windows-desktop)

## About
### The Team 
```C#
System.Console.WriteLine("Hello there!");
System.Console.WriteLine("We are team ✍️#TODO:create-team-name!");
```
We are currently collaborating with Masters of Software Engineering for this project - the Masters students produce an ‘application hub’ of sorts and our team has been tasked with developing a game that will integrate well with this hub!

Here's on how to reach our team members!

- Jiwon Bae 1229059 baejb@student.unimelb.edu.au
- Shanaia Chen 1214289 chenso@student.unimelb.edu.au
- Sammi Li 1271851 tingxin@student.unimelb.edu.au
- Bernhard Andersson 1168897 bandersson@student.unimelb.edu.au
- Rimon Ismail 1269285 rcismail@student.unimelb.edu.au

### The Game
#### Emotional Pizzeria 🍕
For our IT Project, we created a game via Unity that aims to increase the 'emotional granularity' of autistic individuals. 

<p align="center">
<img src="https://github.com/user-attachments/assets/373964f5-6bcd-4cdf-81dd-7586869105d0"/>
</p>
<p align="center">
Player's general perspective
</p>

**Core Concept**: 

A *“papa’s pizzeria”* style game which involves the player having to serve customers the right order within a specific time limit. Instead of the traditional game where customers order food, the customers will tell the player about a situation they experienced, and the player will have to decide which emotion is closest to what they must be feeling. If they get it correct, they receive a certain number of hearts.

**Genre:** 

Children’s game, restaurant management game 

**Target Audience:** 

The game will be designed for a diverse audience that includes neurotypical and autistic individuals.

**Progression:** 

There are 3 levels, each level having an increase in scenarios that are more complex (level 1: 3 scenarios, level 2: 6 scenarios, level 3: 9 scenarios). Complexity may entail more difficult emotions. The player cannot “lose” the game, however there is a hearts system in place to reward correct answers (level 1: 10 hearts, level 2: 30 hearts, level 3: 60 hearts). Player will collect emotions in their “cookbook”.

## Deployment Procedure

Our game is meant to be played on an iphone, but it is also useful to test on a desktop. Therefore, we have included instructions on how to deploy the game to both iphone and a Windows desktop.

### Deployment to iPhone

This will result in a .ipa file. These steps assume you don’t have a 'Build' folder in the provided codebase. If you do, skip to step 7.

1. Download Unity at Download, making sure to install the latest editor version

2. Clone the project at https://github.com/baejb1229059/-TODO-Create-team-name.git
```bash
git clone https://github.com/baejb1229059/-TODO-Create-team-name.git
```

4. Through Unity, open the project by opening the Emotional Pizzeria file

5. Go to File → Build Settings

6. Choose IOS as the platform, and click the Switch Platform button if not already done

7. Click the Build button, name the destination folder ‘Build’ and place it in the Emotional Pizzeria folder

8. Copy the Build folder to another location on your desktop and rename it to 'EmotionalPizzeria.app'

9. Create a new folder called ‘Payload’, and move EmotionalPizzeria.app to that.

10. Send the ‘Payload’ folder to a zipped folder

11. Rename the zipped folder to 'EmotionalPizzeria.ipa'

### Deployment to a Windows desktop

This will result in a .exe file. These steps assume you don’t have a 'Build' folder in the provided codebase. If you do, skip to step 7.

1. Download Unity at Download, making sure to install the latest editor version

2. Clone the project at https://github.com/baejb1229059/-TODO-Create-team-name.git
```bash
git clone https://github.com/baejb1229059/-TODO-Create-team-name.git
```

3. Through Unity, open the project by opening the Emotional Pizzeria file

4. Go to File → Build Settings

5. Choose 'PC, Mac, and Linux Standalone' as the platform, and click the Switch Platform button if not already done

6. Click the Build button, name the destination folder ‘Build’ and place it in the Emotional Pizzeria folder

7. Inside the Build folder, you will find the executable 'EmotionalPizzeria.exe'

