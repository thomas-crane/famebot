# FameBot
A bot for Realm of the Mad God designed to automate the process of collecting fame. This bot works by finding clusters of players on the map and following them. The bot moves the player using a WINAPI method which simulates keypresses, so it will still work when the game window is minimized. The bot has customizable settings which allow the user to change the behaviour of the bot as well as the settings of the clustering algorithm.

For more info read the [FAQ](#frequently-asked-questions-and-common-problems), or have a look at the [project's Wiki.](https://github.com/thomas-crane/famebot/wiki)

## Installation
This is a plugin for KRelay. Make sure you have the latest version of KRelay installed and an swf client which can connect to the proxy server.

[Here is a video demonstrating the installation and some footage of the bot in action.](http://www.youtube.com/watch?v=https://youtu.be/xYY3iSDlibw)

### There are 2 options available to get this plugin.
#### Option 1 (easiest)
1. Download the repo and open the 'Release' folder

2. Copy FameBot.dll

3. Paste it in (or move it to) the Plugins folder of your KRelay.

4. Start using the FameBot.

#### Option 2
1. Clone this repo to a folder somewhere on your computer.

2. Open FameBot.sln using Visual Studio 2015.

3. Right click on the FameBot project and select build.

4. Right click on the Solution and select Open Folder in File Explorer.

5. Open the 'Release' folder.

6. Copy FameBot.dll to the Plugins folder of your KRelay.

7. Start using the FameBot.

## Usage
#### Make sure the in-game camera angle is set to 0 degrees before using the FameBot.
1. Open your game and make sure the proxy server is selected.

2. Open KRelay and check the event log of the FameBot. If you see the message "Automatically bound to client" you can go to step 4.

3. If there was no "Automatically bound to client" message, go to the nexus and type "/bind".

4. Start using the bot.

For a more in-depth look at some of the settings and how to use them, look at the wiki page [Usage guide.](https://github.com/thomas-crane/famebot/wiki/Usage-guide)
### UI overview
#### Start Bot
 + Starts the bot.

#### Stop Bot
 + Stops the bot.

#### Info > Show health bar
 + Opens a new window which shows the health of the player. Useful for keeping an eye on health while having the game minimised.

#### Info > Show key presses
 + Opens a new window which shows the keys which are being 'pressed' by the bot.

#### Settings > Open Config Manager
 + Opens a new window which allows settings to be changed and saved.

### Settings overview
#### Autonexus
 + Self-explanatory. If you want to disable it and use a better one, set it to 0%.

#### Escape if no targets
 + If the bot is following a cluster of targets, but that cluster disperses and it can't find another it will go back to the nexus. *I highly recommend you leave this option enabled.*

#### Teleport distance
 + The max distance in game tiles away from the target the player can be before attempting to teleport.

#### Follow distance
 + The max distance in game tiles away from the target the player can be before moving towards it. *I recommend watching how the bot behaves before tweaking this.*

#### AutoConnect
 + If enabled, when the bot enters the nexus it will immediately try to connect to the fullest realm.

#### Find clusters near centre
 + If enabled, the bot will prioritise clusters of players which are closer to the center of the map. *There is a known bug which causes unusual behaviour when this is disabled. Unless you are just curious, always leave this enabled.*

#### Max distance between points
 + The max distance in game tiles two players can be from each other before they are no longer part of the same cluster.

#### Minimum players per cluster
 + The minimum players required per cluster for the bot to target them.

#### Ticks between cluster scans
 + The number of ticks (NewTickPacket) which pass before the bot will evaluate player clusters again. *If your CPU isn't very good or KRelay is using a lot of memory with the bot enabled, try turning this up.*

## Frequently Asked Questions and Common Problems
Read through these questions before creating a new issue to see if there is already a solution to a problem.

#### _The bot doesn't do anything when I press start_
Make sure the bot is bound to the flash player. You can do this by typing `/bind` in game. The GUI will also display the current process which the bot is bound to. If this process is 'flash' or 'Adobe Flash Player' or something similar, it is probably correct.

#### _The bot just spams 'No valid clusters', what do I do?_
'No valid clusters' simply means the bot cannot find a suitable cluster of players to follow. Try turning the minimum players per cluster down, or the max distance between points up.

#### _The bot just walks to the top left corner of the nexus_
Make sure the camera angle is set to 0 degrees. If the camera is already on 0 degrees it is likely that the nexus has updated and the bot is using old location values. Submit an issue along the lines of 'Nexus positions need updating' for a fast response.


## Contributing
#### Guidlines for contributing:
Read through the wiki page [How the software works](https://github.com/thomas-crane/famebot/wiki/How-the-software-works) to get a better understanding of what each piece of code does.
When you make a pull request, try to add only one feature in each pull request. If you have two features you want to add, make two pull requests.

Try to make your commits more granular. This means that instead of saying something like:
```
Commit A: Added enemy avoidance
```
Say something like:
```
Commit A: Added math class for enemy avoidance
Commit B: Added enemy detection to Plugin.cs
Commit C: Added list and custom data type to keep track of enemies
Commit D: Finished enemy avoidance feature
```
