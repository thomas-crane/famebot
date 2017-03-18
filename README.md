# FameBot
A bot for Realm of the Mad God designed to automate the process of collecting fame.
## How to use
This is a plugin for KRelay. Make sure you have the latest version of KRelay installed and an swf client which can connect to the proxy server.

### There are 2 options available to get this plugin.
#### Option 1 (easiest)
1. Go to the 'Release' folder of this repo.

2. Download FameBot.dll

3. Place it in the Plugins folder of your KRelay.

4. Start using the FameBot.

#### Option 2
1. Clone this repo to a folder somewhere on your computer.

2. Open FameBot.sln using Visual Studio 2015.

3. Right click on the FameBot project and select build.

4. Right click on the FameBot project and select Open Folder in File Explorer.

5. Depending on the build configuration (default is Debug) open either the Debug or the Release folder.

6. Copy FameBot.dll to the Plugins folder of your KRelay.

7. Start using the FameBot.

#### Make sure the in-game camera angle is set to 0 degrees before using the FameBot.
### Notes
FameBot uses a WINAPI method to send keystrokes directly to the flash player process. If your flash player is called "flash.exe" and is already running when you open KRelay the FameBot will already know which process it is. If the FameBot can't find the process when it starts, use the '/bind' command in game.
