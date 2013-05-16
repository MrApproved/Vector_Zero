using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorZero1
{
    class Projectile
    {

        // Image representing the Projectile
        public Texture2D Texture;
        // Image representing the Projectile
        public Texture2D particleTexture1;

        // Position of the Projectile relative to the upper left side of the screen
        public Vector2 Position;

        // State of the Projectile
        public bool Active;

        // The amount of damage the projectile can inflict to an enemy
        public int damage;

        //other effects
        int otherEffects1;

        // Represents the viewable boundary of the game
        Viewport viewport;
        //bullet type red,blue,green,yellow
        public int bulletType;
        //Colour
        Color colour;
        //Particle
        ExtraParticles particle;
        //Particles
        List<ExtraParticles> particles;
        // A random number generator
        Random random;
        //Timer
        int timer;

        // Get the width of the projectile ship
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the projectile ship
        public int Height
        {
            get { return Texture.Height; }
        }

        // Determines how fast the projectile moves
        float projectileMoveSpeed; //Y
        float projectileMoveSpeed2; //X

        //Extra stuff to happen
        int extraDetail;


        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position, int theBulletType, Texture2D particleTexture, int damageBullet, int detail)
        {
            // Initialize our random number generator
            random = new Random();
            damage = damageBullet;
            particles = new List<ExtraParticles>();
            particle = new ExtraParticles();
            particleTexture1 = particleTexture;
            Texture = texture;
            Position = position;
            this.viewport = viewport;
            bulletType = theBulletType;
            extraDetail = detail;

            Active = true;

            switch (bulletType)
            {
                case 1:
                    bulletType = 1;
                    colour = new Color(255, 20, 20);
                    projectileMoveSpeed = 15f;
                    break;
                case 2:
                    bulletType = 2;
                    switch (extraDetail)
                    {
                        case 0: projectileMoveSpeed = 5; projectileMoveSpeed2 = 0; colour = new Color(0, 0, 255); break;
                        case 1: projectileMoveSpeed = 4; projectileMoveSpeed2 = 2; colour = new Color(0, 50, 255); break;
                        case 2: projectileMoveSpeed = 4; projectileMoveSpeed2 = -2; colour = new Color(0, 50, 255); break;
                        //Level2
                        case 3: projectileMoveSpeed = 3; projectileMoveSpeed2 = 3; colour = new Color(0, 100, 255); break;
                        case 4: projectileMoveSpeed = 3; projectileMoveSpeed2 = -3; colour = new Color(0, 100, 255); break;
                        //level3
                        case 5: projectileMoveSpeed = 2; projectileMoveSpeed2 = 4; colour = new Color(0, 150, 255); break;
                        case 6: projectileMoveSpeed = 2; projectileMoveSpeed2 = -4; colour = new Color(0, 150, 255); break;
                    }
                    break;
                case 3:
                    bulletType = 3;
                    switch (extraDetail)
                    {
                        case 0: projectileMoveSpeed = 3; projectileMoveSpeed2 = 0; colour = new Color(0, 255, 25); otherEffects1 = 0; break;
                        case 1: projectileMoveSpeed = 3; projectileMoveSpeed2 = 0; colour = new Color(0, 255, 25); otherEffects1 = 1; break;
                        //Level2
                        case 2: projectileMoveSpeed = 3; projectileMoveSpeed2 = 0; colour = new Color(0, 255, 50); break;
                        //level3
                        case 3: projectileMoveSpeed = 3; projectileMoveSpeed2 = 0; colour = new Color(0, 255, 50); break;
                    }
                    projectileMoveSpeed = 10f;
                    break;
                case 4:
                    bulletType = 4;
                    colour = Color.Yellow;
                    projectileMoveSpeed = 20f;
                    break;
                //Enemies
                case 100:
                    bulletType = 100;
                    colour = Color.White;
                    projectileMoveSpeed = -20f;
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            // Projectiles always move to the right
            timer += 1;
            switch (bulletType)
            {
                case 1:
                    Position.Y -= projectileMoveSpeed;
                    break;
                case 2:
                    Position.Y -= projectileMoveSpeed;
                    Position.X += projectileMoveSpeed2;
                    break;
                case 3:
                    Position.Y -= projectileMoveSpeed;
                    Position.X += projectileMoveSpeed2;
                    break;
                case 4:
                    Position.Y -= projectileMoveSpeed;
                    break;
                case 100:
                    Position.Y -= projectileMoveSpeed;
                    break;
            }
            spawnParticle();
            //particle.Update(gameTime);
            updateParticles(gameTime);
            // update other effects
            otherEffects();
            // Deactivate the bullet if it goes out of screen
            if (Position.Y + Texture.Height / 2 > viewport.Height)
                Active = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, colour, 0f, new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch);
            }
        }

        public int returnBulletType
        {
            get { return bulletType; }
        }

        public void spawnParticle()
        {
            if (bulletType == 1)
            {
                int spawn = random.Next(0, 2);
                if (spawn == 1)
                {
                    // Create an enemy
                    ExtraParticles addParticle = new ExtraParticles();
                    // Initialize the enemy
                    addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 1);
                    // Add the enemy to the active enemies list
                    particles.Add(addParticle);
                }
            }
            if (bulletType == 2)
            {
                if (timer > 15)
                {
                    int spawn = random.Next(0, 5);
                    if (spawn == 1)
                    {
                        // Create an enemy
                        ExtraParticles addParticle = new ExtraParticles();
                        // Initialize the enemy
                        addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 10);
                        // Add the enemy to the active enemies list
                        particles.Add(addParticle);
                    }
                }
            }
            if (bulletType == 3)
            {
                if (timer > 5)
                {
                    int spawn = random.Next(0, 3);
                    if (spawn == 1)
                    {
                        // Create an enemy
                        ExtraParticles addParticle = new ExtraParticles();
                        // Initialize the enemy
                        addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 20);
                        // Add the enemy to the active enemies list
                        particles.Add(addParticle);
                    }
                }
            }
            if (bulletType == 4)
            {
                if (timer > 0)
                {
                    int spawn = random.Next(0, 3);
                    if (spawn == 1)
                    {
                        // Create an enemy
                        ExtraParticles addParticle = new ExtraParticles();
                        // Initialize the enemy
                        addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 30);
                        // Add the enemy to the active enemies list
                        particles.Add(addParticle);
                    }
                }
            }
        }

        public void updateParticles(GameTime gameTime)
        {
            for (int i = particles.Count - 1; i >= 0; i--)
            {
                particles[i].Update(gameTime);

                if (particles[i].Active == false)
                {
                    // If not active and health <= 0
                    particles.RemoveAt(i);
                }
            }
        }

        public void otherEffects()
        {
            if (bulletType == 3)
            {
                if (extraDetail == 0 || extraDetail == 1)
                {
                    if (otherEffects1 == 0)
                    {
                        projectileMoveSpeed2 += 2;
                        if (projectileMoveSpeed2 >= 10)
                        {
                            otherEffects1 = 1;
                        }
                    }
                    if (otherEffects1 == 1)
                    {
                        projectileMoveSpeed2 -= 2;
                        if (projectileMoveSpeed2 <= -10)
                        {
                            otherEffects1 = 0;
                            Position.X += 10;
                        }
                    }
                }
            }
        }
        //END---------------==---------------------==---------------------==----------------------==
    }
}
