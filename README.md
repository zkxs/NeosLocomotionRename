# NeosLocomotionRename

A [NeosModLoader](https://github.com/zkxs/NeosModLoader) mod for [Neos VR](https://neos.com/) that makes your locomotion modules derive their names from their slots. This makes it easier to distinguish between multiple installed locomotion modules of the same type, e.g. "Noclip", "Fast Noclip" "6-Axis Noclip". Without the mod your context menu would instead show "Noclip", "Noclip", "Noclip".

This will no longer be needed once https://github.com/Neos-Metaverse/NeosPublic/issues/1653 is resolved.

## Installation
1. Install [NeosModLoader](https://github.com/zkxs/NeosModLoader).
1. Place [NeosLocomotionRename.dll](https://github.com/zkxs/NeosLocomotionRename/releases/latest/download/NeosLocomotionRename.dll) into your `nml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\NeosVR\nml_mods` for a default install. You can create it if it's missing, or if you launch the game once with NeosModLoader installed it will create the folder for you.
1. Start the game. If you want to verify that the mod is working you can check your Neos logs.

## FAQ
### Will this cause any weird behavior?
Yes. You may experience the following:
- Incorrect default locomotion module upon joining worlds
- Items that switch your locomotion module will behave less reliably, and they were *already* unreliable.

### What does this actually do?
Forces Noclip, GrabWorld, Slide, and Teleport locomotion modules to use the slot name as the module name. Physical is specifically exempted because it has a built in mechanism for renaming.
