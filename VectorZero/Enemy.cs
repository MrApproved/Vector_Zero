using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorZero1
{
    class Enemy
    {

        // Animation representing the enemy
        public Animation EnemyAnimation;

        // The position of the enemy ship relative to the top left corner of thescreen
        public Vector2 Position;

        // The state of the Enemy Ship
        public bool Active;

        // The hit points of the enemy, if this goes to zero the enemy dies
        public int Health;

        // The amount of damage the enemy inflicts on the player ship
        public int Damage;

        // The amount of score the enemy will give to the player
        public int Value;

        //Wave Details
        public int waveDetail;

        public int type;

        // Get the width of the enemy ship
        public int Width
        {
            get { return EnemyAnimation.FrameWidth; }
        }

        // Get the height of the enemy ship
        public int Height
        {
            get { return EnemyAnimation.FrameHeight; }
        }

        // The speed at which the enemy moves
        float enemyMoveSpeedY;
        // The speed at which the enemy moves
        float enemyMoveSpeedX;
        // How long the ship has been spawned for
        public int spawnTimer;

        public void Initialize(Animation animation, Vector2 position, int waveDetails, int enemyType)
        {
            // Load the enemy ship texture
            EnemyAnimation = animation;

            // Type of ship I.E. colour
            type = enemyType;

            // Set the position of the enemy
            Position = position;

            // We initialize the enemy to be active so it will be update in the game
            Active = true;

            waveDetail = waveDetails;

            // Set the health of the enemy
            if (waveDetail >= 1 && waveDetail <= 20) { Health = 10; enemyMoveSpeedY = 1f; }

            // Set the amount of damage the enemy can do
            Damage = 1;




            // Set how fast the enemy moves
            enemyMoveSpeedX = 0f;

            // Set the score value of the enemy
            Value = 100;

            spawnTimer = 0;

        }

        public void Update(GameTime gameTime)
        {
            // The enemy always moves to the left so decrement it's xposition
            updateTimer();
            //if (spawnTimer >= 100)
            //{
            //    enemyMoveSpeedY += 0.15f;
            //}
            Position.Y += enemyMoveSpeedY;
            //Position.X += enemyMoveSpeedX;

            // Update the position of the Animation
            EnemyAnimation.Position = Position;

            // Update Animation
            EnemyAnimation.Update(gameTime);

            // If the enemy is past the screen or its health reaches 0 then deactivateit
            if (Position.Y > 650 || Health <= 0)
            {
                // By setting the Active flag to false, the game will remove this objet fromthe 
                // active game list
                Active = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the animation
            EnemyAnimation.Draw(spriteBatch);
        }

        public int spawnTimerValue
        {
            get { return spawnTimer; }
        }

        private void updateTimer()
        {
            spawnTimer += 1;
        }

    }
}
