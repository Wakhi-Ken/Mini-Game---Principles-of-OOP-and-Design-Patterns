# Zombie Run - Mini Game
<img width="1154" height="651" alt="image" src="https://github.com/user-attachments/assets/ee5e03b8-f0aa-469a-8017-3a7715d904f3" />


A Unity mini game demonstrating **OOP principles**, **design patterns**, and **algorithms**.

---

## Features
- Player movement with WASD and mouse look
- Fast and tank zombies with different behaviors
- Health, medkit, and speed power-up system
- Game over and replay functionality
- UI shows health, medkits collected, and survival time

---

## How to Play
- **Objective:** Survive as long as possible and collect medkits
- **Controls:**  
  - W/A/S/D → Move  
  - Mouse → Look around  
- **Gameplay:**  
  - Collect medkits to heal  
  - Collect speed power-ups to move faster  
  - Avoid zombies, they reduce health  
- **Game Over:** Health reaches 0 → Game Over screen shows time and medkits collected  
  - Options: Replay, Main Menu, Quit  

---

## OOP Principles
- **Encapsulation:** Player health is private, changed only via `TakeDamage()` or `Heal()`.  
- **Abstraction:** Abstract `Enemy` class hides movement/collision logic.  
- **Inheritance:** `ZombieFast` and `ZombieTank` inherit from `Enemy`.  
- **Polymorphism:** `Move()` behaves differently for each enemy type.  

---

## Design Patterns
- **Singleton:** `GameManager` ensures only one instance exists.  
- **Factory:** `EnemyFactory` creates different enemy types.  
- **Observer:** `GameManager` listens to player health changes to update UI automatically.  

---

## Algorithms
1. **Enemy Spawning:** Spawns zombies at random positions with decreasing intervals for difficulty.  
2. **Player Health Observer:** Updates health UI automatically when the player takes damage or heals.  

---

## Setup Instructions
1. Clone the repo:  
   ```bash
   https://github.com/Wakhi-Ken/Mini-Game---Principles-of-OOP-and-Design-Patterns
