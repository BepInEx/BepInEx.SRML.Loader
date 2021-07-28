# BepInEx.SRML.Loader
SRML mod loader plugin for BepInEx

This plugin is a bootstrap for SRML to launch instead of requiring it to be installed into Slime Rancher's game files. Many components (like logging) have been altered to use BepInEx's internal systems instead of writing directly to a file.

Why is this better than what SRML already does?

- It does not edit any game files
    - There's no need for an installer. Installing is just drag and dropping into the game directory, and uninstalling is just deleting whatever you have copied into the game folder
    - It's immune from breaking because of game updates, and integrity checks (for example from Steam).
- You are able to use more powerful modding tools
    - Because of the way BepInEx initializes into the game process, certain tools like Mono.Cecil can be used in-memory for patching game code. This allows for things like adding entirely new methods to classes, patching static constructors, and adding values to enums, which can't be done with Harmony. (Except for enum patching, but that's very difficult to do)

### Installation instructions

1. Download the latest BepInEx v5 x64 version from [here](https://github.com/BepInEx/BepInEx/releases), and [extract it into your Slime Rancher game folder](https://docs.bepinex.dev/master/articles/user_guide/installation/unity_mono.html) 
2. Download the latest release of this plugin, and extract it into the game folder as well
3. You're done!

To uninstall, delete the BepInEx folder.

### Credits

Uses code from [SRML](https://github.com/veesusmikelheir/SRML) under the GPL v3.0 license.