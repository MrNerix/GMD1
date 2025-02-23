Blog #1: Rollaball

The tutorial:
This tutorial provided a valuable refresher on Unity. Although I have used Unity in the past, I had most recently been working with Godot. It’s impressive to see how much the tutorial has evolved since I first attempted it a few years ago. The updated version delves deeper into various topics and introduces new mechanics, such as the updated input system.

However, while following the tutorial, I encountered a few issues:

1. Obstacle Parenting Deformation Issue
Problem:
When instructed to add obstacles by creating a ramp and making the obstacles children of the ground plane object, the ramp becomes deformed due to the scaling of the ground plane.

Solution:
Create an empty GameObject and make both the ground plane and the obstacles its children. Then, remove the NavMesh Surface component from the ground plane and add it to the new empty parent object and bake.

2. Enemy Collision with Player Issue
Problem:
The enemy fails to destroy the player if the player remains stationary, resulting in clipping through the player.

Solution:
In the PlayerController.cs file, add the following line at the end of the Start function:
rb.AddForce(new Vector3(1.0f, 0.0f, 0.0f));
This introduces a slight force to the player at the start of the game, which is subtle enough not to be noticeable but effective in preventing the clipping issue.

3. Camera Script Error When Player is Destroyed
Problem:
An error occurs in the camera script when the player is destroyed, as the script attempts to reference a missing player.

Solution:
Include a null check in the camera script by adding an if statement such as:
if (player != null) {
    transform.position = player.transform.position + offset;
}
This simple condition prevents the script from executing code that references a non-existent player, thereby resolving the error.

Overall, despite these minor issues, the tutorial remains a solid resource for refreshing your Unity skills and exploring its new features.
