# AI-Assisted Game Dev Workshop
### February 21, 2026

Welcome to the **AI-Assisted Game Dev Workshop**! This repository is the project template you will use throughout the workshop.

---

## Prerequisites

### Unity

You will need **Unity 6000.3.8f1** to open this project. Download and install it from the official release page:
[Unity 6000.3.8f1 — What's New & Installs](https://unity.com/releases/editor/whats-new/6000.3.8f1#installs)

### This Template

Get the template using one of the following methods:

- **Clone** this repository, or
- **Download the zip** from the [Releases](../../releases) section of this repo, then unzip it.

### Cursor

You will use Cursor as your AI-assisted code editor during the workshop.

- Download Cursor: [https://cursor.com](https://cursor.com)
- Sign up for a **free account** to get started.
- If you'd like to explore Cursor further after the workshop, consider trying the **Pro plan** for a month.

---

## Opening the Project in Unity

**If you use Unity Hub:**

1. Open **Unity Hub**.
2. Click **Add** (or "Add project from disk").
3. Select the **project root folder** — the folder that contains `Assets` and `ProjectSettings`.
4. Open the project and wait for Unity to finish importing.

**If you don't have Unity Hub:**

Open the Unity Editor application directly from what you downloaded, then use **File → Open Project** (or the equivalent option) and select the project root folder. Wait for Unity to finish importing.

> If you downloaded the zip, make sure you unzip it first and then open that unzipped folder.

---

## Workshop Exercises

Work through the exercises below at your own pace. These are designed to be completed by **chatting with the AI in Cursor** using the techniques covered in the workshop.

> **Tip:** If you're unsure what to do inside the Unity editor at any point, ask the AI to give you a **step-by-step list of actions to take manually in the editor**.

---

### Easy

- **Paddle controller** — Create a script that moves the paddle left and right based on player input. Use the new **Unity Input System**.

- **Ball launch** — Hide the ball by default. When the player presses an input (e.g. Space), launch the ball from the center of the paddle at a random angle to the left or right. Only allow a launch when the ball is not currently in play.

- **Ball speed** — Increase the ball's speed slightly every time it hits a block.

---

### Medium

- **Lives** — Lose a life when the ball hits the death barrier. Update the **hearts sprite** in the UI to show empty hearts for each life lost, then reset gameplay so the player can launch the ball again.

- **Paddle bounce angle** — Change the ball's bounce angle based on where it hits the paddle. Hitting near the far left or right should produce a low angle from horizontal; hitting near the center should produce a higher angle. Try asking the AI to achieve this **without changing from the box collider**.

---

### Challenge

- **Score UI** — Add a score display and increase the score each time a block is destroyed. Use different point values depending on the block type (e.g. 100 for bronze, 200 for silver, 300 for gold).

- **Audio** — Head to Itch.io to download [free sound effects](https://itch.io/game-assets/free/tag-sound-effects) and [free music](https://itch.io/game-assets/free/tag-music), then add the following to the game:
  - Background music
  - Sound effect when the ball hits the paddle, a wall, or a block
  - Sound effect when a block is destroyed
  - Sound effect or music stinger when the ball hits the death barrier

- **Block physics** — When a block is hit, make it **fall** instead of simply disappearing. Add gravity, disable its collider, and destroy it when it goes off-screen. For an extra challenge, apply force to the block in the direction it was hit and update its sprite sorting layer so it always renders above blocks that haven't been hit yet.

---

Thanks so much for being a part of this workshop — enjoy building and experimenting with AI! 🎮
