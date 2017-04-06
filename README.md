# FameBot
A bot for Realm of the Mad God designed to automate the process of collecting fame. This bot works by finding clusters of players on the map and following them. The bot moves the player using a WINAPI method which simulates keypresses, so it will still work when the game window is minimized. The bot has customizable settings which allow the user to change the behaviour of the bot as well as the settings of the clustering algorithm.

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

### UI overview
#### Start Bot
Starts the bot.

#### Stop Bot
Stops the bot.

#### Info > Show health bar
Opens a new window which shows the health of the player. Useful for keeping an eye on health while having the game minimized.

#### Info > Show key presses
Opens a new window which shows the keys which are being 'pressed' by the bot.

#### Settings > Open Config Manager
Opens a new window which allows settings to be changed and saved.

### Settings overview
#### Autonexus
Self-explanatory. If you want to disable it and use a better one, set it to 0%.

#### Escape if no targets
If the bot is following a cluster of targets, but that cluster disperses and it can't find another it will go back to the nexus. *I highly recommend you leave this option enabled.*

#### Teleport distance
The max distance in game tiles away from the target the player can be before attempting to teleport.

#### Follow distance
The max distance in game tiles away from the target the player can be before moving towards it. *I recommend watching how the bot behaves before tweaking this.*

#### AutoConnect
If enabled, when the bot enters the nexus it will immediately try to connect to the fullest realm.

#### Find clusters near center
If enabled, the bot will prioritize clusters of players which are closer to the center of the map. *There is a known bug which causes unusual behavior when this is disabled. Unless you are just curious, always leave this enabled.*

#### Max distance between points
The max distance in game tiles two players can be from each other before they are no longer part of the same cluster.

#### Minimum players per cluster
The minimum players required per cluster for the bot to target them.

#### Ticks between cluster scans
The number of ticks (NewTickPacket) which pass before the bot will evaluate player clusters again. *If your CPU isn't very good or KRelay is using a lot of memory with the bot enabled, try turning this up.*

## Contributing
// TODO
