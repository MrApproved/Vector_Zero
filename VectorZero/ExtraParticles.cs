// Animation.cs
//Using declarations
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
    class ExtraParticles
    {

        // The image representing the collection of images used for animation
        Texture2D spriteStrip;

        // The scale used to display the sprite strip
        float scale;

        // The time since we last updated the frame
        int elapsedTime;

        // The time we display a frame until the next one
        int frameTime;

        // The number of frames that the animation contains
        int frameCount;

        // The index of the current frame we are displaying
        int currentFrame;

        //Timer
        int timer;
        int increaseTimer;
        int timerEnd;

        // The color of the frame we will be displaying
        Color colour;

        // The area of the image strip we want to display
        Rectangle sourceRect = new Rectangle();

        // The area where we want to display the image strip in the game
        Rectangle destinationRect = new Rectangle();

        // Width of a given frame
        public int FrameWidth;

        // Height of a given frame
        public int FrameHeight;

        // The state of the Animation
        public bool Active;

        // Determines if the animation will keep playing or deactivate after one run
        public bool Looping;

        // Width of a given frame
        public Vector2 Position;

        // Type of particle
        int particleType;

        // Alpha Value
        float alphaValue;
        float decreaseAlphaValue;

        // A random number generator
        Random random;

        //Movement
        int Xspeed;
        int Yspeed;

        public void Initialize(Texture2D texture, Vector2 position, int frameWidth, int frameHeight, int frameCount, int frametime, float scale, bool looping, int type)
        {
            // Keep a local copy of the values passed in
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;
            alphaValue = 0f;
            particleType = type;
            timer = 0;
            increaseTimer = 1;
            //Random particles
            random = new Random();
            if (type == 1)
            {
                int timerEndRandom = random.Next(10, 16);
                timerEnd = timerEndRandom;
                int speed = random.Next(-5, 5);
                if (speed == 0) { speed = 1; }
                Xspeed = speed;
                speed = random.Next(-5, 5);
                Yspeed = speed;
                if (speed == 0) { speed = 1; }
                int colourRandom = random.Next(20, 120);
                colour = new Color(255, colourRandom, 20);
            }
            if (type == 10)
            {
                int timerEndRandom = random.Next(15, 26);
                timerEnd = timerEndRandom;
                int speed = random.Next(-3, 3);
                if (speed == 0) { speed = 1; }
                Xspeed = speed;
                speed = random.Next(-3, 3);
                Yspeed = speed;
                if (speed == 0) { speed = 1; }
                int colourRandom = random.Next(100, 200);
                colour = new Color(20, colourRandom, 255);
            }
            if (type == 20)
            {
                int timerEndRandom = random.Next(15, 21);
                timerEnd = timerEndRandom;
                int speed = random.Next(-3, 3);
                if (speed == 0) { speed = 1; }
                Xspeed = speed;
                speed = random.Next(-3, 3);
                Yspeed = speed;
                if (speed == 0) { speed = 1; }
                int colourRandom = random.Next(20, 150);
                colour = new Color(colourRandom, 180, colourRandom);
            }
            if (type == 30)
            {
                int timerEndRandom = random.Next(10, 16);
                timerEnd = timerEndRandom;
                int speed = random.Next(-3, 3);
                if (speed == 0) { speed = 1; }
                Xspeed = speed;
                speed = random.Next(-3, 3);
                Yspeed = speed;
                if (speed == 0) { speed = 1; }
                int colourRandom = random.Next(155, 255);
                colour = new Color(255, colourRandom, 0);
            }
            //Explosion1
            if (type == 100) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = 3; Yspeed = speed; colour = new Color(255, 160, 0); }
            if (type == 101) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 40, 0); }
            if (type == 102) { timerEnd = 30; int speed = 3; Xspeed = speed; speed = -2; Yspeed = speed; colour = new Color(255, 165, 0); }
            if (type == 103) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = -2; Yspeed = speed; colour = new Color(255, 175, 0); }
            if (type == 104) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = 3; Yspeed = speed; colour = new Color(255, 80, 0); }
            if (type == 105) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 210, 0); }
            if (type == 106) { timerEnd = 30; int speed = 3; Xspeed = speed; speed = 3; Yspeed = speed; colour = new Color(255, 50, 0); }
            if (type == 107) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 255, 0); }
            if (type == 108) { timerEnd = 30; int speed = 3; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 120, 0); }
            if (type == 109) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = -2; Yspeed = speed; colour = new Color(255, 20, 0); }
            if (type == 112) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 180, 0); }
            if (type == 111) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 100, 0); }
            if (type == 110) { timerEnd = 30; int speed = 0; Xspeed = speed; speed = 0; Yspeed = speed; colour = new Color(255, 0, 0); }
            //Explosion2
            if (type == 120) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 160, 0); }
            if (type == 121) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 40, 0); }
            if (type == 122) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = 3; Yspeed = speed; colour = new Color(255, 165, 0); }
            if (type == 123) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 175, 0); }
            if (type == 124) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = 3; Yspeed = speed; colour = new Color(255, 80, 0); }
            if (type == 125) { timerEnd = 30; int speed = -2; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 210, 0); }
            if (type == 126) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 50, 0); }
            if (type == 127) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 255, 0); }
            if (type == 128) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 120, 0); }
            if (type == 129) { timerEnd = 30; int speed = 3; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 20, 0); }
            if (type == 132) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 180, 0); }
            if (type == 131) { timerEnd = 30; int speed = -2; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 100, 0); }
            if (type == 130) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = 0; Yspeed = speed; colour = new Color(255, 0, 0); }
            //Explosion3
            if (type == 140) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 160, 0); }
            if (type == 141) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 40, 0); }
            if (type == 142) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 165, 0); }
            if (type == 143) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 175, 0); }
            if (type == 144) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 80, 0); }
            if (type == 145) { timerEnd = 30; int speed = -2; Xspeed = speed; speed = -2; Yspeed = speed; colour = new Color(255, 210, 0); }
            if (type == 146) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 50, 0); }
            if (type == 147) { timerEnd = 30; int speed = -2; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 255, 0); }
            if (type == 148) { timerEnd = 30; int speed = 3; Xspeed = speed; speed = 3; Yspeed = speed; colour = new Color(255, 120, 0); }
            if (type == 149) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 20, 0); }
            if (type == 152) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 180, 0); }
            if (type == 151) { timerEnd = 30; int speed = 0; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 100, 0); }
            if (type == 150) { timerEnd = 30; int speed = 0; Xspeed = speed; speed = 0; Yspeed = speed; colour = new Color(255, 0, 0); }
            //Explosion4
            if (type == 160) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 160, 0); }
            if (type == 161) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 40, 0); }
            if (type == 162) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = -2; Yspeed = speed; colour = new Color(255, 165, 0); }
            if (type == 163) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 175, 0); }
            if (type == 164) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 80, 0); }
            if (type == 165) { timerEnd = 30; int speed = -2; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 210, 0); }
            if (type == 166) { timerEnd = 30; int speed = 3; Xspeed = speed; speed = 3; Yspeed = speed; colour = new Color(255, 50, 0); }
            if (type == 167) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 255, 0); }
            if (type == 168) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = -2; Yspeed = speed; colour = new Color(255, 120, 0); }
            if (type == 169) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 20, 0); }
            if (type == 172) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 180, 0); }
            if (type == 171) { timerEnd = 30; int speed = 0; Xspeed = speed; speed = 0; Yspeed = speed; colour = new Color(255, 100, 0); }
            if (type == 170) { timerEnd = 30; int speed = 0; Xspeed = speed; speed = 0; Yspeed = speed; colour = new Color(255, 0, 0); }
            //Explosion5
            if (type == 180) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 160, 0); }
            if (type == 181) { timerEnd = 30; int speed = -2; Xspeed = speed; speed = 2; Yspeed = speed; colour = new Color(255, 40, 0); }
            if (type == 182) { timerEnd = 30; int speed = 2; Xspeed = speed; speed = -2; Yspeed = speed; colour = new Color(255, 165, 0); }
            if (type == 183) { timerEnd = 30; int speed = -2; Xspeed = speed; speed = -2; Yspeed = speed; colour = new Color(255, 175, 0); }
            if (type == 184) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 80, 0); }
            if (type == 185) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 210, 0); }
            if (type == 186) { timerEnd = 30; int speed = -1; Xspeed = speed; speed = 1; Yspeed = speed; colour = new Color(255, 50, 0); }
            if (type == 187) { timerEnd = 30; int speed = 1; Xspeed = speed; speed = -1; Yspeed = speed; colour = new Color(255, 255, 0); }
            if (type == 188) { timerEnd = 30; int speed = 3; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 120, 0); }
            if (type == 189) { timerEnd = 30; int speed = -3; Xspeed = speed; speed = -3; Yspeed = speed; colour = new Color(255, 20, 0); }
            if (type == 192) { timerEnd = 30; int speed = 0; Xspeed = speed; speed = 0; Yspeed = speed; colour = new Color(255, 180, 0); }
            if (type == 191) { timerEnd = 30; int speed = 0; Xspeed = speed; speed = 0; Yspeed = speed; colour = new Color(255, 100, 0); }
            if (type == 190) { timerEnd = 30; int speed = 0; Xspeed = speed; speed = 0; Yspeed = speed; colour = new Color(255, 0, 0); }

            decreaseAlphaValue = (1f / timerEnd);
            Looping = looping;
            Position = position;
            spriteStrip = texture;

            // Set the time to zero
            elapsedTime = 0;
            currentFrame = 0;

            // Set the Animation to active by default
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            // Do not update the game if we are not active
            if (Active == false)
                return;

            // Update the elapsed time
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Move Particlw
            Position.X += Xspeed;
            Position.Y += Yspeed;

            //Alpha
            alphaValue += decreaseAlphaValue;

            // If the elapsed time is larger than the frame time
            // we need to switch frames
            if (elapsedTime > frameTime)
            {
                // Move to the next frame
                //  currentFrame++;

                //If the currentFrame is equal to frameCount reset currentFrame to zero
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    // If we are not looping deactivate the animation
                    if (Looping == false)
                        Active = false;
                }

                timer += increaseTimer;
                // Reset the elapsed time to zero
                elapsedTime = 0;
                stopParticle();
            }

            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);

            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2,
            (int)Position.Y - (int)(FrameHeight * scale) / 2,
            (int)(FrameWidth * scale),
            (int)(FrameHeight * scale));
        }

        // Draw the Animation Strip
        public void Draw(SpriteBatch spriteBatch)
        {
            // Only draw the animation when we are active
            if (Active)
            {
                spriteBatch.Draw(spriteStrip, destinationRect, Color.Lerp(colour, Color.Transparent, alphaValue));
                //spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, colour);
            }
        }

        public void stopParticle()
        {
            if (timer >= timerEnd)
            {
                Active = false;
            }
        }

        //END----------------------------------------------------------------------------------

    }
}
