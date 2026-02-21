# Scene setup (do in Unity Editor)

After adding the scripts, complete setup in **Level1** as follows.

## Paddle

1. Select the **Paddle** GameObject.
2. Add component **PaddleController** (Scripts/PaddleController).
3. Assign **Ball Rigidbody**: drag the **Ball** GameObject into the "Ball Rigidbody" field.
4. Ensure Paddle's **Rigidbody2D** has **Constraints**: Freeze Position Y (and Z if present) so it only moves horizontally.

## Ball

1. Select the **Ball** GameObject.
2. In the Inspector, set **Tag** to **Ball** (so the death barrier can detect it).

## Death barrier

1. Select the **DeathBarrier** GameObject.
2. Add component **DeathBarrierController** (Scripts/DeathBarrierController).
3. Ensure it has a **Collider2D** (e.g. Box Collider 2D). Enable **Is Trigger** so the ball passes through and triggers the event.

## Lives and Game Over

1. Create an empty GameObject (e.g. **GameManager**). Add component **LivesController** (Scripts/LivesController).
2. Assign **Paddle Controller**: drag the Paddle onto the field.
3. Assign **Heart Images**: drag **Heart1**, **Heart2**, **Heart3** (from Canvas → Lives) into the three slots. They must use **Image** components; set size to 3 in the array.
4. Assign **Heart Full** and **Heart Empty**: from Project **Assets/UI/Sprites**, drag `heart-full` and `heart-empty` into the sprite fields.
5. **Game Over panel (optional):**
   - Under **Canvas**, create a Panel (e.g. **GameOverPanel**). Add Text/TextMeshPro: "Game Over" and "Press R to Restart". Set the Panel to **inactive** (uncheck the checkbox at the top of the Inspector).
   - Assign this Panel to **LivesController** → **Game Over Panel**.

## Build Settings

1. **File → Build Settings**.
2. Add **Level1** (or your gameplay scene) to "Scenes In Build" if it is not already there, so **SceneManager.LoadScene** can reload it on Restart.
