using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace VectorZero1
{
    class Explosion
    {
        //Particles
        List<ExtraParticles> particlesExplode;
        //Locations
        Vector2 Position;
        //particle images
        Texture2D particleTexture1;
        Texture2D particleTexture2;
        Texture2D particleTexture3;
        Texture2D particleTexture4;
        Texture2D particleTexture5;
        Texture2D particleTexture6;
        Texture2D particleTexture7;
        Texture2D particleTexture8;
        int preset;
        SoundEffect sfxSound1;
        SoundEffect sfxSound2;
        SoundEffect sfxSound3;
        // boolean
        public bool Active;
        // A random number generator
        Random random;


        //initialize
        public void Initialize(Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4, Texture2D texture5, Texture2D texture6, Texture2D texture7, Texture2D texture8, Vector2 poistionLocation, SoundEffect sfx1, SoundEffect sfx2, SoundEffect sfx3)
        {
            particlesExplode = new List<ExtraParticles>();
            particleTexture1 = texture1;
            particleTexture2 = texture2;
            particleTexture3 = texture3;
            particleTexture4 = texture4;
            particleTexture5 = texture5;
            particleTexture6 = texture6;
            particleTexture7 = texture7;
            particleTexture8 = texture8;
            Position = poistionLocation;
            sfxSound1 = sfx1;
            sfxSound2 = sfx2;
            sfxSound3 = sfx3;
            random = new Random();
            int randomNumber = random.Next(0, 5);
            preset = randomNumber;
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            spawnParticle();
            updateParticles(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < particlesExplode.Count; i++)
            {
                particlesExplode[i].Draw(spriteBatch);
            }
        }

        public void spawnParticle()
        {

            ExtraParticles addParticle = new ExtraParticles();
            ExtraParticles addParticle1 = new ExtraParticles();
            ExtraParticles addParticle2 = new ExtraParticles();
            ExtraParticles addParticle3 = new ExtraParticles();
            ExtraParticles addParticle4 = new ExtraParticles();
            ExtraParticles addParticle5 = new ExtraParticles();
            ExtraParticles addParticle6 = new ExtraParticles();
            ExtraParticles addParticle7 = new ExtraParticles();
            ExtraParticles addParticle8 = new ExtraParticles();
            ExtraParticles addParticle9 = new ExtraParticles();
            ExtraParticles addParticle10 = new ExtraParticles();
            ExtraParticles addParticle11 = new ExtraParticles();
            ExtraParticles addParticle12 = new ExtraParticles();

            switch (preset)
            {
                case 0:
                    addParticle10.Initialize(particleTexture6, Position, 100, 100, 1, 30, 1f, true, 110);
                    particlesExplode.Add(addParticle10);
                    addParticle11.Initialize(particleTexture7, Position, 65, 65, 1, 30, 1f, true, 111);
                    particlesExplode.Add(addParticle11);
                    addParticle12.Initialize(particleTexture8, Position, 45, 45, 1, 30, 1f, true, 112);
                    particlesExplode.Add(addParticle12);
                    addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 100);
                    particlesExplode.Add(addParticle);
                    addParticle1.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 101);
                    particlesExplode.Add(addParticle1);
                    addParticle2.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 102);
                    particlesExplode.Add(addParticle2);
                    addParticle3.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 103);
                    particlesExplode.Add(addParticle3);
                    addParticle4.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 104);
                    particlesExplode.Add(addParticle4);
                    addParticle5.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 105);
                    particlesExplode.Add(addParticle5);
                    addParticle6.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 106);
                    particlesExplode.Add(addParticle6);
                    addParticle7.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 107);
                    particlesExplode.Add(addParticle7);
                    addParticle8.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 108);
                    particlesExplode.Add(addParticle8);
                    addParticle9.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 109);
                    particlesExplode.Add(addParticle9);
                    sfxSound1.Play();
                    preset = 10;
                    break;
                case 1:
                    addParticle10.Initialize(particleTexture6, Position, 100, 100, 1, 30, 1f, true, 130);
                    particlesExplode.Add(addParticle10);
                    addParticle11.Initialize(particleTexture7, Position, 65, 65, 1, 30, 1f, true, 131);
                    particlesExplode.Add(addParticle11);
                    addParticle12.Initialize(particleTexture8, Position, 45, 45, 1, 30, 1f, true, 132);
                    particlesExplode.Add(addParticle12);
                    addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 120);
                    particlesExplode.Add(addParticle);
                    addParticle1.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 121);
                    particlesExplode.Add(addParticle1);
                    addParticle2.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 122);
                    particlesExplode.Add(addParticle2);
                    addParticle3.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 123);
                    particlesExplode.Add(addParticle3);
                    addParticle4.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 124);
                    particlesExplode.Add(addParticle4);
                    addParticle5.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 125);
                    particlesExplode.Add(addParticle5);
                    addParticle6.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 126);
                    particlesExplode.Add(addParticle6);
                    addParticle7.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 127);
                    particlesExplode.Add(addParticle7);
                    addParticle8.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 128);
                    particlesExplode.Add(addParticle8);
                    addParticle9.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 129);
                    particlesExplode.Add(addParticle9);
                    sfxSound2.Play();
                    preset = 10;
                    break;
                case 2:
                    addParticle10.Initialize(particleTexture6, Position, 100, 100, 1, 30, 1f, true, 150);
                    particlesExplode.Add(addParticle10);
                    addParticle11.Initialize(particleTexture7, Position, 65, 65, 1, 30, 1f, true, 151);
                    particlesExplode.Add(addParticle11);
                    addParticle12.Initialize(particleTexture8, Position, 45, 45, 1, 30, 1f, true, 152);
                    particlesExplode.Add(addParticle12);
                    addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 140);
                    particlesExplode.Add(addParticle);
                    addParticle1.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 141);
                    particlesExplode.Add(addParticle1);
                    addParticle2.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 142);
                    particlesExplode.Add(addParticle2);
                    addParticle3.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 143);
                    particlesExplode.Add(addParticle3);
                    addParticle4.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 144);
                    particlesExplode.Add(addParticle4);
                    addParticle5.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 145);
                    particlesExplode.Add(addParticle5);
                    addParticle6.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 146);
                    particlesExplode.Add(addParticle6);
                    addParticle7.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 147);
                    particlesExplode.Add(addParticle7);
                    addParticle8.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 148);
                    particlesExplode.Add(addParticle8);
                    addParticle9.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 149);
                    particlesExplode.Add(addParticle9);
                    sfxSound3.Play();
                    preset = 10;
                    break;
                case 3:
                    addParticle10.Initialize(particleTexture6, Position, 100, 100, 1, 30, 1f, true, 170);
                    particlesExplode.Add(addParticle10);
                    addParticle11.Initialize(particleTexture7, Position, 65, 65, 1, 30, 1f, true, 171);
                    particlesExplode.Add(addParticle11);
                    addParticle12.Initialize(particleTexture8, Position, 45, 45, 1, 30, 1f, true, 172);
                    particlesExplode.Add(addParticle12);
                    addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 160);
                    particlesExplode.Add(addParticle);
                    addParticle1.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 161);
                    particlesExplode.Add(addParticle1);
                    addParticle2.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 162);
                    particlesExplode.Add(addParticle2);
                    addParticle3.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 163);
                    particlesExplode.Add(addParticle3);
                    addParticle4.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 164);
                    particlesExplode.Add(addParticle4);
                    addParticle5.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 165);
                    particlesExplode.Add(addParticle5);
                    addParticle6.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 166);
                    particlesExplode.Add(addParticle6);
                    addParticle7.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 167);
                    particlesExplode.Add(addParticle7);
                    addParticle8.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 168);
                    particlesExplode.Add(addParticle8);
                    addParticle9.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 169);
                    particlesExplode.Add(addParticle9);
                    sfxSound1.Play();
                    preset = 10;
                    break;
                case 4:
                    addParticle10.Initialize(particleTexture6, Position, 100, 100, 1, 30, 1f, true, 190);
                    particlesExplode.Add(addParticle10);
                    addParticle11.Initialize(particleTexture7, Position, 65, 65, 1, 30, 1f, true, 191);
                    particlesExplode.Add(addParticle11);
                    addParticle12.Initialize(particleTexture8, Position, 45, 45, 1, 30, 1f, true, 192);
                    particlesExplode.Add(addParticle12);
                    addParticle.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 180);
                    particlesExplode.Add(addParticle);
                    addParticle1.Initialize(particleTexture1, Position, 12, 12, 1, 30, 1f, true, 181);
                    particlesExplode.Add(addParticle1);
                    addParticle2.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 182);
                    particlesExplode.Add(addParticle2);
                    addParticle3.Initialize(particleTexture2, Position, 12, 12, 1, 30, 1f, true, 183);
                    particlesExplode.Add(addParticle3);
                    addParticle4.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 184);
                    particlesExplode.Add(addParticle4);
                    addParticle5.Initialize(particleTexture3, Position, 12, 12, 1, 30, 1f, true, 185);
                    particlesExplode.Add(addParticle5);
                    addParticle6.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 186);
                    particlesExplode.Add(addParticle6);
                    addParticle7.Initialize(particleTexture4, Position, 12, 12, 1, 30, 1f, true, 187);
                    particlesExplode.Add(addParticle7);
                    addParticle8.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 188);
                    particlesExplode.Add(addParticle8);
                    addParticle9.Initialize(particleTexture5, Position, 12, 12, 1, 30, 1f, true, 189);
                    particlesExplode.Add(addParticle9);
                    sfxSound3.Play();
                    preset = 10;
                    break;
            }
        }

        public void updateParticles(GameTime gameTime)
        {
            for (int i = particlesExplode.Count - 1; i >= 0; i--)
            {
                particlesExplode[i].Update(gameTime);

                if (particlesExplode[i].Active == false)
                {
                    // If not active and health <= 0
                    particlesExplode.RemoveAt(i);
                }
            }
        }

    }
}
