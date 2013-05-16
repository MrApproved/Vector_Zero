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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Player Object
        Player player;
        Texture2D playerShip1;
        Texture2D playerShip2;
        Texture2D playerShip3;
        Texture2D playerShip4;
        // A movement speed for the player
        float playerMoveSpeed;
        int score;
        int playerHpSet;
        int playerLives;
        int respawnTimer;
        int respawned;

        // Keyboard states used to determine key presses
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        // Gamepad states used to determine button presses
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        //Background
        // Image used to display the static background
        int menu;
        Background mainMenu;
        Texture2D mainBackground;

        // Parallaxing Layers
        Background bgLayer1;
        Background bgLayer2;

        // Enemies
        Texture2D enemyTexture1;
        Texture2D enemyTexture2;
        Texture2D enemyTexture3;
        //Colour for the Type
        Color colorTypeId;
        int typeID;
        int waveID;
        int waveIdEnemy;
        List<Enemy> enemies;
        List<Projectile> enemyProjectiles;
        List<Explosion> explosions;

        // The rate at which the enemies appear
        int enemySpawnTime;
        int spawnTime;

        //Bullets
        Texture2D projectileTexture1;
        Texture2D projectileTexture2;
        Texture2D projectileTexture3;
        Texture2D projectileTexture4;
        Texture2D projectileTexture5;
        Texture2D particleTexture1;
        Texture2D particleTexture2;
        Texture2D particleTexture3;
        Texture2D particleTexture4;
        Texture2D particleTexture5;
        Texture2D particleTexture6;
        Texture2D bigParticleTexture1;
        Texture2D bigParticleTexture2;
        Texture2D bigParticleTexture3;
        List<Projectile> projectiles;
        int playerBulletType;
        int weaponLevel;
        int bulletWaves;
        // The sound used when the player or an enemy dies
        SoundEffect explosion1Sound;
        SoundEffect explosion2Sound;
        SoundEffect explosion3Sound;

        // The rate of fire of the player shots
        TimeSpan fireTime;
        TimeSpan previousFireTime;

        // A random number generator
        Random random;
        //Font
        SpriteFont Font1;
        //Interface
        Texture2D interfaceTexture;
        Texture2D weaponSelector;
        Vector2 hpDrawLoc;
        Vector2 weaponSelectorDrawLoc;
        Vector2 weaponLevelDrawLoc;
        Vector2 scoreDrawLoc;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Screen
            menu = 1;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            graphics.ApplyChanges();
            //Player
            player = new Player();
            playerHpSet = 2;
            //Background
            mainMenu = new Background();
            bgLayer1 = new Background();
            bgLayer2 = new Background();
            // Initialize our random number generator
            random = new Random();
            //Interface
            hpDrawLoc = new Vector2(20, 567);
            weaponSelectorDrawLoc = new Vector2(192, 559);
            weaponLevelDrawLoc = new Vector2(296, 562);
            scoreDrawLoc = new Vector2(475, 567);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Player
            Vector2 playerPosition = new Vector2(266, 500);
            //Player
            playerShip1 = Content.Load<Texture2D>(@"Textures\Ships\ship1");
            playerShip2 = Content.Load<Texture2D>(@"Textures\Ships\ship5");
            playerShip3 = Content.Load<Texture2D>(@"Textures\Ships\ship6");
            playerShip4 = Content.Load<Texture2D>(@"Textures\Ships\ship7");
            player.Initialize(playerShip1, playerHpSet);
            //Enemies Textures
            enemyTexture1 = Content.Load<Texture2D>(@"Textures\Ships\ship2");
            enemyTexture2 = Content.Load<Texture2D>(@"Textures\Ships\ship3");
            enemyTexture3 = Content.Load<Texture2D>(@"Textures\Ships\ship4");
            //Bullets
            projectileTexture1 = Content.Load<Texture2D>(@"Textures\Bullets\Red\RedBullet");
            projectileTexture2 = Content.Load<Texture2D>(@"Textures\Bullets\Red\Laser1");
            projectileTexture3 = Content.Load<Texture2D>(@"Textures\Bullets\Blue\BlueBullet");
            projectileTexture4 = Content.Load<Texture2D>(@"Textures\Bullets\Green\GreenRing");
            projectileTexture5 = Content.Load<Texture2D>(@"Textures\Bullets\Yellow\YellowLaser1");
            particleTexture1 = Content.Load<Texture2D>(@"Textures\Particles\Particle1");
            particleTexture2 = Content.Load<Texture2D>(@"Textures\Particles\Particle2");
            particleTexture3 = Content.Load<Texture2D>(@"Textures\Particles\Particle3");
            particleTexture4 = Content.Load<Texture2D>(@"Textures\Particles\Particle4");
            particleTexture5 = Content.Load<Texture2D>(@"Textures\Particles\Particle5");
            particleTexture6 = Content.Load<Texture2D>(@"Textures\Particles\Particle6");
            bigParticleTexture1 = Content.Load<Texture2D>(@"Textures\Particles\BigParticle1");
            bigParticleTexture2 = Content.Load<Texture2D>(@"Textures\Particles\BigParticle2");
            bigParticleTexture3 = Content.Load<Texture2D>(@"Textures\Particles\BigParticle3");
            //Sounds
            explosion1Sound = Content.Load<SoundEffect>(@"Sounds\Explosions\Explosion9");
            explosion2Sound = Content.Load<SoundEffect>(@"Sounds\Explosions\Explosion13");
            explosion3Sound = Content.Load<SoundEffect>(@"Sounds\Explosions\Explosion15");
            // Load the parallaxing background
            mainMenu.Initialize(Content, @"Textures\Backgrounds\Menus\MainMenu", GraphicsDevice.Viewport.Height, 0);
            bgLayer1.Initialize(Content, @"Textures\Backgrounds\Outerspace\OuterspaceBG1", GraphicsDevice.Viewport.Height, 1);
            bgLayer2.Initialize(Content, @"Textures\Backgrounds\Outerspace\OuterspaceBG2", GraphicsDevice.Viewport.Height, 2);
            // Fonts
            Font1 = Content.Load<SpriteFont>(@"Fonts\Font1");
            interfaceTexture = Content.Load<Texture2D>(@"Textures\Interface\Interface");
            weaponSelector = Content.Load<Texture2D>(@"Textures\Interface\WeaponSelector");

            mainBackground = Content.Load<Texture2D>(@"Textures\Backgrounds\Background1");

            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit(); ;

            // Save the previous state of the keyboard and game pad so we can determinesingle key/button presses
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            // Read the current state of the keyboard and gamepad and store it
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            //Background
            bgLayer1.Update();
            bgLayer2.Update();
            if (menu == 1)
            {
                mainMenu.Update();
                mainMenuController();
            }

            if (menu == 2)
            {
                //Enemies
                UpdateEnemies(gameTime);

                //Collision
                UpdateCollision();

                //Explosions
                UpdateExplosions(gameTime);

                // Update the projectiles
                UpdateProjectiles(gameTime);

                //Update the player
                UpdatePlayer(gameTime);
                checkForLives();
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            // Start drawing
            spriteBatch.Begin();
            //Main Background
            GraphicsDevice.BlendState = BlendState.NonPremultiplied;
            //spriteBatch.Draw(mainBackground, Vector2.Zero, Color.White);

            //Draw Background
            bgLayer1.Draw(spriteBatch);
            bgLayer2.Draw(spriteBatch);

            if (menu == 1)
            {
                mainMenu.Draw(spriteBatch);
            }

            if (menu == 2)
            {
                //Enemies
                // Draw the Enemies
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Draw(spriteBatch);
                }

                // Draw the Projectiles
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Draw(spriteBatch);
                }

                // Draw the EnemyProjectiles
                for (int i = 0; i < enemyProjectiles.Count; i++)
                {
                    enemyProjectiles[i].Draw(spriteBatch);
                }

                // Draw the Enemies
                for (int i = 0; i < explosions.Count; i++)
                {
                    explosions[i].Draw(spriteBatch);
                }

                // Draw the Player
                player.Draw(spriteBatch);

                //Interface
                //Hp
                displayHealth();
            }

            // Stop drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }

        //Methods

        //Main Menu

        private void mainMenuController()
        {
            if (currentKeyboardState.IsKeyDown(Keys.Space) ||
            currentGamePadState.Buttons.Start == ButtonState.Pressed)
            {
                //Player Values
                playerMoveSpeed = 6.0f;
                playerLives = 1;
                respawnTimer = -1;
                respawned = 30;
                //holds bullet type
                playerBulletType = 1;
                weaponLevel = 1;
                score = 0;
                //Player
                spawnTime = 0;
                // Initialize the enemies list
                enemies = new List<Enemy>();
                // Initialize the explosions list
                explosions = new List<Explosion>();
                // Set the time keepers to zero
                //Bullets
                projectiles = new List<Projectile>();
                //Enemy Bullets
                enemyProjectiles = new List<Projectile>();
                // Set the Firerate
                fireTime = TimeSpan.FromSeconds(.2f);
                menu = 2;
            }
        }

        //Player
        private void UpdatePlayer(GameTime gameTime)
        {
            if (player.returnActive == true)
            {
                // Get Thumbstick Controls
                player.Position.X += currentGamePadState.ThumbSticks.Left.X * playerMoveSpeed;
                player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y * playerMoveSpeed;

                // Use the Keyboard / Dpad
                if (currentKeyboardState.IsKeyDown(Keys.Left) ||
                currentGamePadState.DPad.Left == ButtonState.Pressed)
                {
                    player.Position.X -= playerMoveSpeed;
                }
                if (currentKeyboardState.IsKeyDown(Keys.Right) ||
                currentGamePadState.DPad.Right == ButtonState.Pressed)
                {
                    player.Position.X += playerMoveSpeed;
                }
                if (currentKeyboardState.IsKeyDown(Keys.Up) ||
                currentGamePadState.DPad.Up == ButtonState.Pressed)
                {
                    player.Position.Y -= playerMoveSpeed;
                }
                if (currentKeyboardState.IsKeyDown(Keys.Down) ||
                currentGamePadState.DPad.Down == ButtonState.Pressed)
                {
                    player.Position.Y += playerMoveSpeed;
                }

                if (currentKeyboardState.IsKeyDown(Keys.NumPad1))
                {
                    player.changeSprite(playerShip1);
                }
                if (currentKeyboardState.IsKeyDown(Keys.NumPad2))
                {
                    player.changeSprite(playerShip2);
                }
                if (currentKeyboardState.IsKeyDown(Keys.NumPad3))
                {
                    player.changeSprite(playerShip3);
                }
                if (currentKeyboardState.IsKeyDown(Keys.NumPad4))
                {
                    player.changeSprite(playerShip4);
                }

                if (currentKeyboardState.IsKeyDown(Keys.Q))
                {
                    fireTime = TimeSpan.FromSeconds(.2f);
                    playerBulletType = 1;
                    weaponSelectorDrawLoc = new Vector2(192, 559);
                }
                if (currentKeyboardState.IsKeyDown(Keys.W))
                {
                    fireTime = TimeSpan.FromSeconds(.3f);
                    playerBulletType = 2;
                    weaponSelectorDrawLoc = new Vector2(238, 559);
                }
                if (currentKeyboardState.IsKeyDown(Keys.E))
                {
                    fireTime = TimeSpan.FromSeconds(.2f);
                    playerBulletType = 3;
                    weaponSelectorDrawLoc = new Vector2(316, 559);
                }
                if (currentKeyboardState.IsKeyDown(Keys.R))
                {
                    fireTime = TimeSpan.FromSeconds(.1f);
                    playerBulletType = 4;
                    weaponSelectorDrawLoc = new Vector2(360, 559);
                }

                //Bullets
                // Fire only every interval we set as the fireTime
                if (currentKeyboardState.IsKeyDown(Keys.Space))
                {
                    if (playerBulletType == 1)
                    {
                        if (gameTime.TotalGameTime - previousFireTime > fireTime)
                        {
                            //   Reset our current time
                            previousFireTime = gameTime.TotalGameTime;

                            //   Add the projectile, but add it to the front and center of the player
                            switch (weaponLevel)
                            {
                                case 1:
                                    AddProjectile(player.Position + new Vector2(player.Width / 2, player.Height / 2), projectileTexture1, particleTexture1, 4, 0);
                                    break;
                                case 2:
                                    AddProjectile(player.Position + new Vector2(player.Width / 2 + 16, player.Height / 2), projectileTexture1, particleTexture1, 4, 0);
                                    AddProjectile(player.Position + new Vector2(player.Width / 2 - 16, player.Height / 2), projectileTexture1, particleTexture1, 4, 0);
                                    break;
                                case 3:
                                    AddProjectile(player.Position + new Vector2(player.Width / 2 + 16, player.Height / 2), projectileTexture1, particleTexture1, 4, 0);
                                    AddProjectile(player.Position + new Vector2(player.Width / 2 - 16, player.Height / 2), projectileTexture1, particleTexture1, 4, 0);
                                    AddProjectile(player.Position + new Vector2(player.Width / 2 + 40, player.Height / 2 - 6), projectileTexture2, particleTexture1, 3, 0);
                                    AddProjectile(player.Position + new Vector2(player.Width / 2 - 40, player.Height / 2 - 6), projectileTexture2, particleTexture1, 3, 0);
                                    break;
                            }
                            //Play the laser sound
                            // laserSound.Play();
                        }
                    }
                    if (playerBulletType == 2)
                    {
                        if (gameTime.TotalGameTime - previousFireTime > fireTime)
                        {
                            //   Reset our current time
                            previousFireTime = gameTime.TotalGameTime;
                            switch (weaponLevel)
                            {
                                case 1:
                                    bulletWaves = 2;
                                    break;
                                case 2:
                                    bulletWaves = 4;
                                    break;
                                case 3:
                                    bulletWaves = 6;
                                    break;
                            }
                            //   Add the projectile, but add it to the front and center of the player
                            for (int i = 0; i <= bulletWaves; i++)
                            {
                                AddProjectile(player.Position + new Vector2(player.Width / 2, player.Height / 2), projectileTexture3, particleTexture1, 2, i);
                            }
                            //Play the laser sound
                            // laserSound.Play();
                        }
                    }
                    if (playerBulletType == 3)
                    {
                        if (gameTime.TotalGameTime - previousFireTime > fireTime)
                        {
                            //   Reset our current time
                            previousFireTime = gameTime.TotalGameTime;
                            switch (weaponLevel)
                            {
                                case 1:
                                    bulletWaves = 1;
                                    break;
                                case 2:
                                    bulletWaves = 2;
                                    break;
                                case 3:
                                    bulletWaves = 3;
                                    break;
                            }

                            //   Add the projectile, but add it to the front and center of the player
                            if (weaponLevel == 1)
                            {
                                for (int i = 0; i <= bulletWaves; i++)
                                {
                                    AddProjectile(player.Position + new Vector2(player.Width / 2, player.Height / 2), projectileTexture4, particleTexture2, 2, i);
                                }
                            }
                            if (weaponLevel == 2)
                            {
                                for (int i = 0; i <= bulletWaves; i++)
                                {
                                    AddProjectile(player.Position + new Vector2(player.Width / 2, player.Height / 2), projectileTexture4, particleTexture2, 2, i);
                                }
                            }
                            if (weaponLevel == 3)
                            {
                                for (int i = 0; i <= bulletWaves; i++)
                                {
                                    if (i <= 1)
                                    {
                                        AddProjectile(player.Position + new Vector2(player.Width / 2, player.Height / 2), projectileTexture4, particleTexture2, 2, i);
                                    }
                                    if (i == 2)
                                    {
                                        AddProjectile(player.Position + new Vector2(player.Width / 2 - 14, player.Height / 2), projectileTexture4, particleTexture2, 2, i);
                                    }
                                    if (i == 3)
                                    {
                                        AddProjectile(player.Position + new Vector2(player.Width / 2 + 14, player.Height / 2), projectileTexture4, particleTexture2, 2, i);
                                    }
                                }
                            }

                            //Play the laser sound
                            // laserSound.Play();
                        }
                    }
                    if (playerBulletType == 4)
                    {
                        if (gameTime.TotalGameTime - previousFireTime > fireTime)
                        {
                            //   Reset our current time
                            previousFireTime = gameTime.TotalGameTime;

                            //   Add the projectile, but add it to the front and center of the player
                            if (weaponLevel == 1)
                            {
                                AddProjectile(player.Position + new Vector2(player.Width / 2, player.Height / 2), projectileTexture5, particleTexture3, 2, 0);
                            }
                            if (weaponLevel == 2)
                            {
                                AddProjectile(player.Position + new Vector2(player.Width / 2, player.Height / 2), projectileTexture5, particleTexture3, 2, 0);
                                AddProjectile(player.Position + new Vector2(player.Width / 2 - 16, player.Height / 2 + 8), projectileTexture5, particleTexture3, 2, 0);
                                AddProjectile(player.Position + new Vector2(player.Width / 2 + 16, player.Height / 2 + 8), projectileTexture5, particleTexture3, 2, 0);
                            }
                            if (weaponLevel == 3)
                            {
                                AddProjectile(player.Position + new Vector2(player.Width / 2, player.Height / 2), projectileTexture5, particleTexture3, 2, 0);
                                AddProjectile(player.Position + new Vector2(player.Width / 2 - 16, player.Height / 2 + 8), projectileTexture5, particleTexture3, 2, 0);
                                AddProjectile(player.Position + new Vector2(player.Width / 2 + 16, player.Height / 2 + 8), projectileTexture5, particleTexture3, 2, 0);
                                AddProjectile(player.Position + new Vector2(player.Width / 2 - 32, player.Height / 2 + 16), projectileTexture5, particleTexture3, 2, 0);
                                AddProjectile(player.Position + new Vector2(player.Width / 2 + 32, player.Height / 2 + 16), projectileTexture5, particleTexture3, 2, 0);
                            }
                            //Play the laser sound
                            // laserSound.Play();
                        }
                    }
                }

                // Make sure that the player does not go out of bounds
                player.Position.X = MathHelper.Clamp(player.Position.X, 0, GraphicsDevice.Viewport.Width - player.Width);
                player.Position.Y = MathHelper.Clamp(player.Position.Y, 0, GraphicsDevice.Viewport.Height - player.Height - 50);
            }
        }

        private void checkForLives()
        {
            if (player.returnActive == false)
            {
                respawnTimer += 1;
                if (playerLives > 0 && respawnTimer >= 90)
                {
                    respawned = 0;
                    respawnTimer = 0;
                    playerLives -= 1;
                    player.setActive();
                }
                if (playerLives <= 0 && respawnTimer >= 90)
                {
                    respawned = 0;
                    respawnTimer = 0;
                    player.setActive();
                    menu = 1;
                }
                if (respawnTimer == -1)
                {
                    player.setActive();
                    respawnTimer = 0;
                }
            }
        }

        //Enemies
        private void AddEnemy()
        {
            // Create the animation object
            Animation enemyAnimation = new Animation();

            // Initialize the animation with the correct animation information

            Vector2 position = new Vector2(0, 0);
            Enemy enemy = new Enemy();
            switch (waveID)
            {
                case 1: enemyAnimation.Initialize(enemyTexture1, Vector2.Zero, 60, 60, 1, 30, colorTypeId, 1f, true); break;
                case 2: enemyAnimation.Initialize(enemyTexture2, Vector2.Zero, 60, 60, 1, 30, colorTypeId, 1f, true); break;
            }


            // Randomly generate the position of the enemy
            switch (waveIdEnemy + 1)
            {
                case 2: position = new Vector2(100, -50);
                    enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 3: position = new Vector2(130, -50); enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 4: position = new Vector2(160, -50); enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 5: position = new Vector2(190, -50); enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 6: position = new Vector2(220, -50); enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 7: waveID = 0;
                    break;
                //Wave 2
                case 10: position = new Vector2(100, -50);
                    enemyAnimation.Initialize(enemyTexture2, Vector2.Zero, 60, 60, 1, 30, colorTypeId, 1f, true);
                    enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 11: position = new Vector2(200, -50); enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 12: position = new Vector2(400, -50); enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 13: position = new Vector2(500, -50); enemy.Initialize(enemyAnimation, position, waveIdEnemy, typeID); enemies.Add(enemy);
                    break;
                case 14: waveID = 0;
                    break;
            }
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            // Spawn a new enemy enemy every 1.5 seconds
            if (waveID == 0)
            {
                waveID = random.Next(1, 3);
                typeID = random.Next(1, 5);
                switch (typeID)
                {
                    case 1: colorTypeId = new Color(255, 50, 50); break;
                    case 2: colorTypeId = new Color(50, 50, 255); break;
                    case 3: colorTypeId = new Color(50, 255, 50); break;
                    case 4: colorTypeId = new Color(255, 255, 50); break;
                }

                switch (waveID)
                {
                    case 1:
                        // Used to determine how fast enemy respawns
                        enemySpawnTime = 150;
                        waveIdEnemy = 1;
                        break;
                    case 2:
                        // Used to determine how fast enemy respawns
                        enemySpawnTime = 150;
                        waveIdEnemy = 9;
                        break;
                }
            }
            //TimeSpan.FromSeconds(1.0f);
            if (spawnTime == enemySpawnTime && waveIdEnemy != 0)
            {
                spawnTime = 0;
                // Add an Enemy
                AddEnemy();
                waveIdEnemy += 1;
            }

            // Update the Enemies
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Update(gameTime);

                //Firing
                if (waveIdEnemy == 6)
                {
                    if (enemies[i].spawnTimer == 30)
                    {
                        AddEnemyProjectile(enemies[i].Position, projectileTexture5, particleTexture3, 1, 0, 100);
                        //addExplosion(enemies[i].Position);
                    }
                }

                if (enemies[i].Active == false)
                {
                    // If not active and health <= 0
                    if (enemies[i].Health <= 0)
                    {
                        addExplosion(enemies[i].Position);
                        //AddExplosion(enemies[i].Position);
                        score += 10;
                    }
                    enemies.RemoveAt(i);
                }
            }

            spawnTime += 1;
        }

        //Add Explosion
        private void addExplosion(Vector2 Poistion)
        {
            Explosion addExplosion = new Explosion();
            // Add an explosion
            addExplosion.Initialize(particleTexture1, particleTexture3, particleTexture4, particleTexture5, particleTexture6, bigParticleTexture1, bigParticleTexture2, bigParticleTexture3, Poistion, explosion1Sound, explosion2Sound, explosion3Sound);
            explosions.Add(addExplosion);
        }

        //COLLISION
        private void UpdateCollision()
        {
            // Use the Rectangle's built-in intersect function to 
            // determine if two objects are overlapping
            Rectangle rectangle1;
            Rectangle rectangle2;

            // Only create the rectangle once for the player
            rectangle1 = new Rectangle((int)player.Position.X + 32, (int)player.Position.Y + 32, player.Width, player.Height);

            // Do the collision between the player and the enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                rectangle2 = new Rectangle((int)enemies[i].Position.X, (int)enemies[i].Position.Y, enemies[i].Width, enemies[i].Height);

                // Determine if the two objects collided with each
                // other
                if (rectangle1.Intersects(rectangle2))
                {
                    if (player.returnActive == true && respawned >= 30)
                    {
                        // Subtract the health from the player based on
                        // the enemy damage
                        player.Health -= enemies[i].Damage;

                        // Since the enemy collided with the player
                        // destroy it
                        enemies[i].Health = 0;
                        if (player.Health <= 0)
                        {
                            addExplosion(player.Position);
                        }
                    }

                    // If the player health is less than zero we died
                }

            }

            // Projectile vs Enemy Collision
            for (int i = 0; i < projectiles.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    // Create the rectangles we need to determine if we collided with each other
                    rectangle1 = new Rectangle((int)projectiles[i].Position.X -
                    projectiles[i].Width / 2, (int)projectiles[i].Position.Y -
                    projectiles[i].Height / 2, projectiles[i].Width, projectiles[i].Height);

                    rectangle2 = new Rectangle((int)enemies[j].Position.X - enemies[j].Width / 2,
                    (int)enemies[j].Position.Y - enemies[j].Height / 2,
                    enemies[j].Width, enemies[j].Height);

                    // Determine if the two objects collided with each other
                    if (rectangle1.Intersects(rectangle2))
                    {
                        int damage = projectiles[i].damage;
                        if (projectiles[i].bulletType == 1) { if (enemies[j].type == 1) { damage -= 2; } if (enemies[j].type == 2) { damage += 4; } }
                        if (projectiles[i].bulletType == 2) { if (enemies[j].type == 2) { damage -= 1; } if (enemies[j].type == 3) { damage += 2; } }
                        if (projectiles[i].bulletType == 3) { if (enemies[j].type == 3) { damage -= 1; } if (enemies[j].type == 4) { damage += 2; } }
                        if (projectiles[i].bulletType == 4) { if (enemies[j].type == 4) { damage -= 1; } if (enemies[j].type == 1) { damage += 2; } }
                        enemies[j].Health -= damage;
                        projectiles[i].Active = false;
                    }
                }
            }

            // enemyProjectiles vs Player
            for (int i = 0; i < enemyProjectiles.Count; i++)
            {
                // Create the rectangles we need to determine if we collided with each other
                rectangle1 = new Rectangle((int)enemyProjectiles[i].Position.X -
                enemyProjectiles[i].Width / 2, (int)enemyProjectiles[i].Position.Y -
                enemyProjectiles[i].Height / 2, enemyProjectiles[i].Width, enemyProjectiles[i].Height);

                rectangle2 = new Rectangle((int)player.Position.X - player.Width / 2,
                (int)player.Position.Y - player.Height / 2,
                player.Width, player.Height);

                // Determine if the two objects collided with each other
                if (rectangle1.Intersects(rectangle2))
                {
                    if (player.returnActive == true && respawned >= 30)
                    {
                        player.Health -= enemyProjectiles[i].damage;
                        enemyProjectiles[i].Active = false;
                        if (player.Health <= 0)
                        {
                            addExplosion(player.Position);
                        }
                    }
                }
            }

            if (player.Health <= 0)
            {
                player.Active = false;
            }
            if (respawned < 30)
            {
                respawned += 1;
            }

        }

        //Bullets
        private void AddProjectile(Vector2 position, Texture2D projectileTexture, Texture2D particleTexture, int damage, int detail)
        {
            Projectile projectile = new Projectile();
            projectile.Initialize(GraphicsDevice.Viewport, projectileTexture, position, playerBulletType, particleTexture, damage, detail);
            projectiles.Add(projectile);
        }

        //Enemy Bullets
        private void AddEnemyProjectile(Vector2 position, Texture2D projectileTexture, Texture2D particleTexture, int damage, int detail, int bulletType)
        {
            Projectile projectile = new Projectile();
            projectile.Initialize(GraphicsDevice.Viewport, projectileTexture, position, bulletType, particleTexture, damage, detail);
            enemyProjectiles.Add(projectile);
        }

        private void UpdateProjectiles(GameTime gameTime)
        {
            // Update the Projectiles
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update(gameTime);

                if (projectiles[i].Active == false)
                {
                    projectiles.RemoveAt(i);
                }
            }
            // Update  Enemy the Projectiles
            for (int i = enemyProjectiles.Count - 1; i >= 0; i--)
            {
                enemyProjectiles[i].Update(gameTime);

                if (enemyProjectiles[i].Active == false)
                {
                    enemyProjectiles.RemoveAt(i);
                }
            }
        }

        //Explosions
        private void UpdateExplosions(GameTime gameTime)
        {
            // Update the Projectiles
            for (int i = explosions.Count - 1; i >= 0; i--)
            {
                explosions[i].Update(gameTime);

                if (explosions[i].Active == false)
                {
                    explosions.RemoveAt(i);
                }
            }
        }

        //Interface

        public void displayHealth()
        {
            int hp = player.returnHealth;
            spriteBatch.Draw(interfaceTexture, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(weaponSelector, weaponSelectorDrawLoc, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Font1, "Ships Armour: " + hp.ToString(), hpDrawLoc, Color.White);
            spriteBatch.DrawString(Font1, weaponLevel.ToString(), weaponLevelDrawLoc, Color.White);
            spriteBatch.DrawString(Font1, "Score: " + score.ToString(), scoreDrawLoc, Color.White);
        }


        //END----------------------------------------------------------------------------------------
    }
}
