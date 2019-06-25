# Unity Virtual Reality Projects - The Book #

This repository contains completed projects for each chapter of the Unity Virtual Reality Projects - Second Edition book by Jonathan Linowes.

Available in hardcopy and/or ebook formats, from [Amazon](https://www.amazon.com/Unity-Virtual-Reality-Projects-developing/dp/1788478800/) and [Packtpub](https://www.packtpub.com/game-development/unity-virtual-reality-projects-second-edition)

This repository is a Unity project with completed projects from the book. Each project and main topic is saved as separate scenes, divided by book chapters.

Unity Version: 2019.1.7f1

In some cases, assets that are under separate license are not included here and may be downloaded separately to complete a project. But not required. Some 3rd party assets are included here which are free to redistribute and attribution is given here and in the book.

![Unity Virtual Reality Projects, Second Edition by Jonathan Linowes](SourceFiles/uvrp2book.png)

## Implemented with Unity XR Input ##

This version of the projects uses the current Unity XR SDK, DevicePoseDriver, and XR Input API. That is, this project does not include SDK specific to Oculus, Steam, Daydream etc but will run on any of those devices using Unity device-independent API.

See the files in Assets/UVRP2/XRInput/ folder.

## SourceFiles/ Folder #
These are the source files provided by the publisher with the book, includes asset files needed to get start with each of the chapter projects. And includes final versions of the source code (.cs) scripts developed in the project.

## Scenes included with this project - in Assets/UVRP2/ folder ##

### Ch2-Diorama ###
* 2-1-Diorama

### Ch3-BuildAndRun ###
* 3-1-Diorama-XR

### Ch4-Gaze ###
* 4-1-RandomWalker
* 4-2-LookMoveWalker
* 4-3-LookToKill

### Ch5-Interactables ###
* 5-1-InputTest
* 5-2-BalloonsPolling
* 5-3-BalloonsEvents
* 5-4-BalloonsInHand
* 5-5-BalloonGrenades
* 5-6-GrabAndThrow

### Ch6-UI ###
* 6-1-CanvasUI
* 6-2-DashboardUI
* 6-3-InteractableUI
* 6-4-WristPalette

### Ch7-Locomotion ###
* 7-1-GlideLocomotion
* 7-2-GlideLocomotionComfort
* 7-3-Teleport
* 7-4-SpawnPoints
* 7-5-TeleportNavmesh

### Ch8-Physics ###
* 8-1-BallsFromHeaven
* 8-2-BallsPool
* 8-3-HeadBallGame
* 8-4-PaddleBallGame
* 8-5-ShooterBallGame
* 8-6-FireBallGame
* 8-7-FireBeatGame

### Ch9-Spaces ###
* 9-1-Gallery
* 9-2-GalleryRidethrough

### Ch10-360Media ###
* 10-1-Globes
* 10-2-Photophere
* 10-3-VideoSphere
* 10-4-skybox
* 10-5-VideSkybox

### Ch11-Timeline ###
* 11-1-BlackbirdStory

### Ch12-Multiplayer ###
* N/A
* Note, the UNet Unity Networking components used in this chapter have been deprecated in Unity 2018.x and removed in Unity 2019+

### Ch13-Performance ###
* 13-1-Optimization
* 13-2-StaticBorg
* 13-3-BorgCulling

## Installation and Attribution ##

* First clone this repository to your local PC. [How to clone a repository](https://help.github.com/en/articles/cloning-a-repository)

Because of licensing restrictions you will also need to separately install the following packages from the Asset Store (all free):

**Required**
The following free assets are required to run this project:

* [Unity Standard Assets](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351)

**Optional**
The following free assets are optional but fun to use in these projects:

* [Google Poly Toolkit](https://assetstore.unity.com/packages/templates/systems/poly-toolkit-104464)
* [Nature Starter Kit 1](https://assetstore.unity.com/packages/3d/environments/nature-starter-kit-1-49962)
* [Wispy Skybox](https://assetstore.unity.com/packages/2d/textures-materials/sky/wispy-skybox-21737)
* [Skull Platform](https://assetstore.unity.com/packages/3d/props/skull-platform-105664)

**Credits**
The following free assets are already included in the repository with attribution:

* [Balloon](https://poly.google.com/view/a01Rp51l-L3) Model
* [Third Prototype - Dancefloor](http://ncs.io/DancefloorNS) MP3
* [Unity Beat Detection](https://github.com/allanpichardo/Unity-Beat-Detection) C# Script
* [Tissot_behrmann.png](https://en.wikipedia.org/wiki/Tissot%27s_indicatrix#/media/File:Tissot_behrmann.png)
* ["Blackbird" performed by
Salvatore Manalo](http://mp3freeget4.online/play/the-beatles-paul-mccartney-blackbird-cover/chSrubUUdwc.html) MP3
* [Nest and egg](https://yadi.sk/d/ZQep-K-AMKAc8) Models
* [Living Birds](http://www.dinopunch.com/) Models
* [Sunglasses](https://www.turbosquid.com/3d-models/3ds-sunglasses-blender/764082) Model (royalty free extended use license paid, and converted to compatible FBX format)
* Miscellaneous photos from [unsplash.com](https://unsplash.com/), attributions within the Chapter 9 Gallery project scriptable data objects
* Additional photos and assets courtesy of myself (Jonathan Linowes, the author)


## More Info ##

[Contact the author at Parkerhill](http://www.parkerhill.com/)

Questions, Errata, or Suggestions? [Submit an issue on the GitHub repository](https://github.com/linojon/UVRP2/issues)
