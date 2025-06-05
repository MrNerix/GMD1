# Blog Post #4 - Milestone 2: Replayability
This post describes my process and ad implementation of  the second milestone.
# Enemy
To make the game engaging, I needed more than just a shadow entity that was not seen—the game needed an enemy that actively pursues the player. The approach I took for said enemy was very simple. Reuse the existing obstacle spawner but adjust the spawn rate to be slower, and have the enemy follow the player’s x-axis position.
1.  I duplicated the obstacle prefab and changed its material color to red.
    
2.  I created a `FollowTarget` script that finds the player and interpolates the enemy’s x-position toward the player’s x-position using a lerp.
    
This ensured that the red enemy spawns less frequently than obstacles but always homes in on the player, adding pressure and challenge.

# State Manager Update
The `StateManager` script received several updates to manage different game states: **Running**, **Paused**, and **Shop**. I added a check function to determine the current state at any time.

-   This allows the same buttons to behave appropriately in different contexts, whether in gameplay, the shop, or the game-over screen.
    
-   By disabling certain buttons (for example, the restart button) when the player is in the shop, I prevent accidental restarts during upgrades.
    
-   It also takes care of logic for resetting gameplay and scores when transitioning between states.
    

# Chase System
Simply moving left and right wouldn’t feel satisfying on its own. To add depth, I introduced a special ability: slowing down time. When the player activates this ability to avoid obstacles or evade enemies the chasing shadow closes in faster.

-   I created a `ChaseManager` script to handle this mechanic.
    
-   A UI slider acts as a progress bar, showing how close the shadow is to catching up.
    

Every second the player slows time, the chase meter advances. If the player stays in slow motion too long, the shadow caches them. This tension ties directly into the game’s harsh setting, requiring strategic use of slow motion to survive.

![image](https://github.com/user-attachments/assets/f01e6a81-198f-4432-841e-6ad4c4d5a88a)


# Upgrade System
In order to create some replay value to the game progression of some sort is necessary.
I decided to go with a shop/upgrade system. In order to achieve that a few things had to be implemented:
1. Score
2. Currency
3. Shop Menu
4. Upgrades
	* Add health
	* Score Multiplier
	* Chase Buffer

## Score
A score is essential for an endless runner—players need a metric for competition and self-improvement.
The score is calculated:
runtime * speed * multiplier

This formula rewards players who stay alive longer while also factoring in any score multipliers they’ve purchased.

## Currency
While the score measures performance, I wanted players to earn something tangible each run.
The currency is calculated:
score / 100
This way, every point scored contributes to the player’s progress over multiple runs.

## Shop / Upgrade Menu
I needed a place for players to spend currency and upgrade their stats. I considered two approaches:
1. A selectable menu where players navigate to an upgrade and then press a confirm button.
2. A menu where each button directly corresponds to an upgrade or action.

I chose the second option because it felt more intuitive and engaging. To implement this, I leveraged the updated `StateManager` so that entering the shop state disables gameplay buttons and enables shop buttons. Each button in the menu is mapped to a specific upgrade, plus there’s a dedicated button to toggle the shop menu on or off.

![image](https://github.com/user-attachments/assets/0d31c757-7c8d-4f91-95a2-74e10266b9b0)



# Upgrades
With both currency and a functional shop in place, I needed upgrades that felt meaningful without being overpowered. Given the game’s setting, I settled on three core upgrades:

-   **Add Health** – Increases maximum health, improving survivability.
    
-   **Score Multiplier** – Boosts the score multiplier so that runs feel more rewarding.
    
-   **Chase Buffer** – Expands the slow-motion ability, allowing players to time-warp more freely.

These upgrades give players strategic choices: invest in longevity (health), maximize their score potential (multiplier), or strengthen their ability to evade the shadow (chase buffer).

# Conclusion
Although the visuals are currently minimal, all core features have been implemented, making the game fully playable and replayable. Achieving this objective marks the completion of the second milestone. With this foundation in place, I am confident in moving on to the third and final milestone, which will focus on making the game visually appealing and immersive.
