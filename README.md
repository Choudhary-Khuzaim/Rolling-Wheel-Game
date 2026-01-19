# 🛞 Rolling Wheel Game (Endless Runner)

![Unity Version](https://img.shields.io/badge/Unity-2022.3%2B-black?style=for-the-badge&logo=unity)
![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp)
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Mac%20%7C%20WebGL-blue?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-orange?style=for-the-badge)

> **A high-octane 3D survival game developed in Unity.** > Test your reflexes in an infinitely generated environment where speed is your only enemy.

---

## 📑 Table of Contents
- [Demo & Gameplay](#-demo--gameplay)
- [Key Features](#-key-features)
- [Technical Architecture](#-technical-architecture)
- [Installation & Setup](#-installation--setup)
- [Future Roadmap](#-future-roadmap)
- [Author](#-author)

---

## 📸 Demo & Gameplay

*Experience the thrill of high-speed dodging mechanics.*

| **Main Menu** | **Gameplay Action** |
|:---:|:---:|
| <img src="Screenshots/menu.png" alt="Main Menu" width="100%"/> | <img src="Screenshots/gameplay.png" alt="Gameplay" width="100%"/> |
| *Clean UI with Start/Quit options* | *Real-time physics and collision handling* |

| **Game Over Screen** | **High Score** |
|:---:|:---:|
| <img src="Screenshots/gameover.png" alt="Game Over" width="100%"/> | <img src="Screenshots/score.png" alt="Score" width="100%"/> |
| *Restart mechanics triggered on collision* | *Dynamic score calculation based on distance* |

---

## ✨ Key Features

- **Infinite Procedural Generation:** The level extends indefinitely, ensuring no two runs are exactly the same.
- **Physics-Based Movement:** Utilizes Unity's `Rigidbody` physics engine for smooth forces and gravity simulation.
- **Dynamic Camera System:** A `FollowPlayer` script ensures the camera smoothly tracks the player without jitter.
- **Collision Detection:** Precise hitboxes trigger immediate "Game Over" states upon impact with obstacles.
- **Progressive Difficulty:** The game speed and obstacle density challenge the player as they progress.

---

## ⚙️ Technical Architecture

This project follows a component-based architecture standard in Unity development.

### 📂 Core Scripts
* `PlayerMovement.cs`: Handles physics forces (`AddForce`) for forward movement and lateral strafing.
* `PlayerCollision.cs`: Listens for `OnCollisionEnter` events to detect obstacles and disable movement.
* `GameManager.cs`: Controls the game loop, manages scenes (Restart/Level Complete), and handles UI states.
* `Score.cs`: Tracks the player's `transform.position.z` to update the UI text in real-time.
* `FollowPlayer.cs`: A camera script that offsets the camera position relative to the player to create a third-person view.

---

## 🚀 Installation & Setup

Follow these steps to run the project locally on your machine.

### Prerequisites
* Unity Hub
* Unity Editor (Version 2021.3 LTS or higher recommended)

### Steps
1.  **Clone the Repository**
    ```bash
    git clone [https://github.com/Choudhary-Khuzaim/Rolling-Wheel-Game.git](https://github.com/Choudhary-Khuzaim/Rolling-Wheel-Game.git)
    ```
2.  **Open Project**
    * Open Unity Hub.
    * Click **Add** and select the cloned folder `Rolling-Wheel-Game`.
    * Click on the project name to launch the Unity Editor.
3.  **Play**
    * Navigate to `Assets/Scenes`.
    * Double-click `MainLevel` (or your primary scene).
    * Press the ▶️ **Play** button at the top of the editor.

---

## 🛣️ Future Roadmap

Planned improvements for upcoming versions:

- [ ] **Mobile Support:** Adding touch controls (Swipe Left/Right).
- [ ] **Power-ups:** Speed boosts and shield invulnerability.
- [ ] **Shop System:** Use collected coins to buy new player skins.
- [ ] **Audio Manager:** Adding background music and SFX for collisions.

---

## 👤 Author

**Khuzaim**
- Software Engineering Student (7th Semester)
- Connect with me: [GitHub Profile](https://github.com/Choudhary-Khuzaim)

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details. 
