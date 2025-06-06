# Blog Post #5 - Milestone 3: Visuals and Immersion
Up until now, the main focus has been on gameplay and mechanics, leaving visuals minimal with basic UI and placeholder objects. It’s time to enhance the game’s visual presentation, audio, and overall player immersion. 

## Ground
In most games, the ground is static or stationary. In my game, however, the ground needs to convey a sense of speed.
To achieve this, I applied a grass [texture](https://assetstore.unity.com/packages/2d/textures-materials/floors/outdoor-ground-textures-12555) instead of a solid color. 
Then, I reused the existing movement script to shift the ground texture continuously: when the ground’s position reaches a certain point, I reset it back. This looping movement creates the illusion that the player is running across the terrain.
![image](https://github.com/user-attachments/assets/704fbe8a-3a4a-4d1e-aefd-e568f2d34877)


## Borders
The borders of the playable area should also feel dynamic and convey speed, even though the player doesn’t interact with them directly. To accomplish this, I created a separate spawner for non-interactive background objects.
Using prefabs made from [3d models](https://quaternius.itch.io/stylized-nature-megakit), I spawned trees and bushes along the edges.
![image](https://github.com/user-attachments/assets/d0050018-79e6-4802-b05d-6d3af7ba1926)

Then attached the Movement script as well as creating a SelfDestroy script so it would help with performance by deleting objects that were no longer in view.
Each prefab has the same movement script attached, and I also added a SelfDestroy script so that once an object moves out of view, it is removed to optimize performance.
![image](https://github.com/user-attachments/assets/9d3d4388-94a9-46dc-b6c5-e2f150bd1185)
I randomized each object’s rotation for a more natural look.
![image](https://github.com/user-attachments/assets/0d875d2c-0c5c-4673-8a82-c65088478620)

## Prop Spawner
Clutter while it may seem not as important as other visual aspects at first. It is an essential component in making any game work more lived in and immersive.
I again utilized what I already have - Spawner, Movement Script and the SelfDestroy script. Only selecting different [models](https://quaternius.itch.io/stylized-nature-megakit) for the prefabs and spawning them in the player area. They don't interact with the player because they contain no colliders. Random rotation was added.
![image](https://github.com/user-attachments/assets/6a0d92d6-4bad-4a4f-8f2d-56dede98ff0c)

![image](https://github.com/user-attachments/assets/8ce6cf8c-ca91-442d-83ac-2790225778fd)


## Environment
The game having a darker tone, my aim was to make the environment as dark and as dreary as possible. Opting for more a creepy theme than gore.
### Directional Light
I tuned some some values in the directional light, for the the world to have a purple undertone aswell as make it seem darker. 
![image](https://github.com/user-attachments/assets/d191aeee-002c-4057-8b71-b8d19c5ffa8d)

### Skybox
I added a [skybox](https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-series-free-103633) so it would fit the night / dark theme.
### Fog
[Volumetric Fog](https://github.com/MrNerix/GMD1/blob/main/Blog%20Posts/Blog#1%20-%20Rollaball.md) was added from my rollerball project because it would add clutter as well as convey speed while covering some not so good looking details.

## Obstacles
As before I replaced the one obstacle with a array of obstacle prefabs with [models](https://quaternius.itch.io/stylized-nature-megakit). I did fine tune the different spawn rates and ad a random rotation.

## Enemy
I replaced my Enemy cube with a [monster 3d model](https://assetstore.unity.com/packages/3d/characters/creatures/monster-mutant-7-188552). I used one of the run animations it came with, set it to loop, and deleted all the other animator paths.
![image](https://github.com/user-attachments/assets/09f0c0bb-0ff9-4ce7-adb0-93929cf23d62)


## Start Screen
I create the start screen in a new scene, placed some [models](https://quaternius.itch.io/stylized-nature-megakit) randomly. Added a [rain](https://assetstore.unity.com/packages/p/free-quick-effects-vol-1-304424) effect (Also added it to the main scene), and [fog](https://github.com/MrNerix/GMD1/blob/main/Blog%20Posts/Blog#1%20-%20Rollaball.md). 
In the canvas I added a simple title and a prompt on how to start the game.
![image](https://github.com/user-attachments/assets/6218b72e-4967-428e-aa8d-32456b7f921a)



## Shop Menu
I rebuilt the Shop menu with the same functionality as before but with a more polished look. I also added upgrade counters so players can see their current level for each upgrade.
![image](https://github.com/user-attachments/assets/18078fd8-8f45-42f8-8976-2a7324241a20)


## HUD
HUD was also rebuilt, now with added prompts for what to press:
![image](https://github.com/user-attachments/assets/0ced595c-4869-4cde-8bbd-99b391e47969)


## Soundtrack
Music is important everywhere so I created a SoundtrackManager object with a script with the same name that would not destroy the object when loading a different scene. Added 2 AudioSources - one for the [soundtrack](https://crowshade.itch.io/horror-music-pack), and one for the [rain](https://pixabay.com/sound-effects/rain-sound-188158/) sound. I put them on loop.

## Sound Effects, Chase System
Now this is where I tried to convey a horror setting and make the player immersed.
My main idea was to make the monster sound feel closer the more it caught up with the player.
I tried to achieve it but controlling the pitch and volume along with the chase progress.
Sounds I used for the monsters were - [footseps](https://pixabay.com/sound-effects/monster-footstep-162883/) and a [growl](https://pixabay.com/sound-effects/monster-growl-251374/).

![image](https://github.com/user-attachments/assets/84fdc8fd-734b-463f-88e2-fc0eacad5978)


I also added a [running sound](https://pixabay.com/sound-effects/running-on-gravel-301880/) for the player and a [death sound effect](https://pixabay.com/sound-effects/blade-piercing-body-352462/) if the player got caught.

## Misc
* [Font](https://fonts.google.com/selection?categoryFilters=Feeling:/Expressive/Fancy) that fit better.
* I added a restart possibility mid game.
* There is a bug that sometimes messes with the speed and launches the player, i could not figure it out how to fix so for now I added the restart button in case it happens.
* As a last ditch effort I added a basic raw image in the canvas that covered the entire screen and set it to black colour and made it transparent. To my surprise this worked very well and I kept it.

## Conclusion
The goal for this milestone being visual improvement and better immersion. I believe I was able to achieve it and improve upon the project.
