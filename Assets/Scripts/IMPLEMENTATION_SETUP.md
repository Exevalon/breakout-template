# Scene setup (do in Unity Editor)

After adding the scripts, complete setup in **Level1** as follows.

## Paddle

1. Select the **Paddle** GameObject.
2. Add component **PaddleController** (Scripts/PaddleController).
3. Assign **Ball Rigidbody**: drag the **Ball** GameObject into the "Ball Rigidbody" field.
4. Ensure Paddle's **Rigidbody2D** has **Constraints**: Freeze Position Y (and Z if present) so it only moves horizontally.
5. Set **Tag** to **Paddle** (needed for paddle bounce sound).

## Ball

1. Select the **Ball** GameObject.
2. Add component **BallBounceSound** (Scripts/BallBounceSound) so wall and paddle bounces play sounds (with varied pitch).
3. In the Inspector, set **Tag** to **Ball** (so the death barrier can detect it).

## Walls

1. For wall bounce sounds to play, any GameObjects that act as **walls** (left, right, top) must have a **Collider2D** and their **Tag** set to **Wall**. (The **Wall** tag is in the project; assign it in the Inspector.)

## Death barrier

1. Select the **DeathBarrier** GameObject.
2. Add component **DeathBarrierController** (Scripts/DeathBarrierController).
3. Ensure it has a **Collider2D** (e.g. Box Collider 2D). Enable **Is Trigger** so the ball passes through and triggers the event.

## Lives and Game Over

1. Create an empty GameObject (e.g. **GameManager**). Add component **LivesController** (Scripts/LivesController).
2. On the **same** GameManager, add component **SfxManager** (Scripts/SfxManager). It requires an **AudioSource** (Unity will add it automatically). Assign the clips from **Assets/Audio**:
   - **Block Hit**: `ChosenSelection_v2` (ball hits a block)
   - **Lose Life**: `snd_explosion_1` (player loses a life)
   - **Launch Ball**: `snd_shot_sharp` (player launches the ball)
   - **Wall Bounce**: `Snd1` (ball bounces off walls) — pitch varies each bounce
   - **Paddle Bounce**: `Powerup` (ball bounces off paddle) — pitch varies each bounce
   - **Pitch Min / Pitch Max** (default 0.92–1.08) control how much the bounce pitch varies.
3. Assign **Paddle Controller**: drag the Paddle onto the field.
4. Assign **Heart Images**: drag **Heart1**, **Heart2**, **Heart3** (from Canvas → Lives) into the three slots. They must use **Image** components; set size to 3 in the array.
5. Assign **Heart Full** and **Heart Empty**: from Project **Assets/UI/Sprites**, drag `heart-full` and `heart-empty` into the sprite fields.
6. **Game Over panel (optional):**
   - Under **Canvas**, create a Panel (e.g. **GameOverPanel**). Add Text/TextMeshPro: "Game Over" and "Press R to Restart". Set the Panel to **inactive** (uncheck the checkbox at the top of the Inspector).
   - Assign this Panel to **LivesController** → **Game Over Panel**.

## Build Settings

1. **File → Build Settings**.
2. Add **Level1** (or your gameplay scene) to "Scenes In Build" if it is not already there, so **SceneManager.LoadScene** can reload it on Restart.
