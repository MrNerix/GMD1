# **Blog Post #3 – Milestone: Main Gameplay Loop**

In this post, I’ll go over the process of implementing the main gameplay loop for my game, and how I reached my first milestone.

## Movement

The movement system is a slightly modified version of the player controller provided. The player can move left or right using the joystick, and jump by pushing up.

Once I had basic movement working, I had to decide between two approaches:

1. Make the player continuously move forward in the environment.  
2. Keep the player stationary and make the environment move toward them.

I went with the second option—keeping the player mostly stationary (except for left/right movement and jumping) while the environment scrolls toward them. I thought it would be a more interesting fit for the gameplay style I’m aiming for.

## Obstacles & Spawning

I created a cube prefab and added a `Movement` script that moves it toward the player. Then I created a `GameManager` object and attached an `ObstacleSpawner` script. This script takes an obstacle prefab as input and uses Unity’s built-in `InvokeRepeating()` function to regularly instantiate new obstacles at a randomized horizontal position in front of the player.

## Player-Obstacle Interaction

For now, interaction is based on damage and health (though I plan to switch it to use remaining time and speed later). I initially tried using events and the Observer pattern, but ran into issues and decided to put that on hold.

Instead, I went with a more straightforward setup:

- The obstacle prefab has a `Damage` script.
- The player has a `Health` script.
- When an obstacle collides with the player (`OnTriggerEnter()`), it grabs the player’s `Health` component and subtracts the damage amount.

## Game Over Logic

To finish off the core loop, I implemented a game over system and a restart function.

I added a `GameStateManager` script to the `GameManager` object. Inside it, the `StopGame()` function does the following:

- Stops the obstacle spawner.
- Sets the player’s movement speed to 0.
- Displays the game over screen.
- Stops all existing obstacles by finding objects tagged `"Obstacle"` and setting their movement speed to 0.

**Minor roadblock:**  
Originally, I had obstacles destroy themselves after a few seconds. But that caused them to disappear during the game over screen, which looked weird. The fix? I added a collider behind the player that destroys obstacles on collision—this way, during the game over screen, they just sit still, as intended.

## Restarting the Game

The restart function is basically the reverse of `StopGame()` with the addition of a few things:

- Destroys existing obstacles.
- Resets the player’s health.
- Reactivates the spawner and movement.

## Notable Bugs

Here are a few issues I ran into:

1. **Joystick Launch Bug** – If the joystick is already tilted left or right when the game starts, the player launches off at high speed. Still working on a fix.
2. **Player Rotation Issues** – The player would sometimes flip, rotate, or fall over when force was applied. I’ve locked rotation for now but might switch to using `Translate()` instead of force.
3. **Obstacle Collisions** – When the player collided with an obstacle, they would sometimes get knocked off the rails. I fixed this by turning the obstacles into triggers instead of physical colliders.

## Conclusion

The visuals are as bare bones as it gets, but the core gameplay loop is in place. I’ve hit a minimum viable product (MVP) level, and I’m happy with the progress so far. Next up: polish, tweaking, and adding replayability.
