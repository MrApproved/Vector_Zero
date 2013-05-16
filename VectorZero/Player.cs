using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace VectorZero1
{
    class Player
    {
        // Animation representing the player
        public Texture2D PlayerTexture;
        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position;
        // State of the player
        public bool Active;
        // Amount of hit points that player has
        public int Health;
        int hpTotal;


        //Initialize
        public void Initialize(Texture2D texture, int hp)
        {
            // Set the players texture
            PlayerTexture = texture;
            // Set the starting position of the player around the middle of the screen and to the back
            Position = new Vector2(266, 500);
            // Set the player to be active
            Active = true;
            // Set the player health
            Health = hp;
            hpTotal = hp;
        }


        //Update
        public void Update()
        {

        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active == true)
            {
                spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }

        public void setActive()
        {
            Active = true;
            Health = hpTotal;
            Position.X = 266;
            Position.Y = 500;
        }

        // Get the width of the player ship
        public int Width
        {
            get { return PlayerTexture.Width; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return PlayerTexture.Height; }
        }

        //Change Texture
        public void changeSprite(Texture2D texture)
        {
            PlayerTexture = texture;
        }

        public int returnHealth
        {
            get { return Health; }
        }

        public bool returnActive
        {
            get { return Active; }
        }

    }
}
