
#region File Information
//-----------------------------------------------------------------------------
// Graphics2DSample.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System.Globalization;

#endregion

namespace Graphics2DSample3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Graphics2DSampleGame : Microsoft.Xna.Framework.Game
    {
        #region Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Font Variables
        SpriteFont calibri; // For SpriteFont usage sample
        SpriteFont buxton; // For BitmapFont as SpriteFont usage sample
        SpriteFont quadrantFont; // SpriteFont for in-quadrant descriptions

        // Texture Variables
        Texture2D background; // Screen background texture
        Texture2D frame; // Screen frame to make final UI looks like four-quadrant layout
        Texture2D ufo;
        Texture2D asteroid;
        Texture2D ground;

        // Gameplay variables
        Vector2 ufoPosition;
        Vector2 asteroidPosition;
        Vector2 groundPosition;
        Vector2 ufoVelocity;
        float asteroidRotation;
        float asteroidScale;
        bool isGrowing;
        Random random;

        // Animation variables
        Vector2 characterPosition;
        Animation animation;
        #endregion

        #region Initialization
        public Graphics2DSampleGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            graphics.IsFullScreen = true; // Hide system tray for better gameplay experience
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize initial gameplay state and variables
            random = new Random();
            asteroidPosition = new Vector2(600, 100);
            ufoPosition = new Vector2(180, 280);
            asteroidRotation = 0;
            asteroidScale = 1.0f;
            isGrowing = true;
            while (ufoVelocity.X == 0 || ufoVelocity.Y == 0)
                ufoVelocity = new Vector2(random.Next(-1, 2), random.Next(-1, 2));

            base.Initialize();
        }
        #endregion

        #region Load and Unload
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load game content here
            calibri = Content.Load<SpriteFont>("PericlesSpriteFont");
            buxton = Content.Load<SpriteFont>("BuxtonSketchBitmapFont");
            quadrantFont = Content.Load<SpriteFont>("QuadrantFont");
            background = Content.Load<Texture2D>("spaceBG");
            ufo = Content.Load<Texture2D>("UFO");
            asteroid = Content.Load<Texture2D>("asteroid");
            ground = Content.Load<Texture2D>("ground");
            frame = Content.Load<Texture2D>("frame");

            int borderWidth = 1; // A width of the screen border
            groundPosition = new Vector2(GraphicsDevice.Viewport.Width + ground.Width + borderWidth,
                                         GraphicsDevice.Viewport.Height + ground.Height + borderWidth);

            // Load multiple animations form XML definition
            System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Load("Content/AnimationDef.xml");
         //   System.Xml.Linq.XDocument a = System.Xml.Linq.XDocument.Load("Content/AnimationDef1.xml");
           // System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Load("Content/AnimationDef1.xml");
            // Get the first (and only in this case) animation from the XML definition
            var definition = doc.Root.Element("Definition");
           // var def = a.Root.Element("Definition");
            Texture2D texture = Content.Load<Texture2D>(definition.Attribute("SheetName").Value);
          //  Texture2D texture1 = Content.Load<Texture2D>(def.Attribute("SheetName").Value);
            Point frameSize = new Point();
            frameSize.X = int.Parse(definition.Attribute("FrameWidth").Value, NumberStyles.Integer);
            frameSize.Y = int.Parse(definition.Attribute("FrameHeight").Value, NumberStyles.Integer);
         //   frameSize.X = int.Parse(def.Attribute("FrameWidth").Value, NumberStyles.Integer);
         //   frameSize.Y = int.Parse(def.Attribute("FrameHeight").Value, NumberStyles.Integer);
            Point sheetSize = new Point();
            sheetSize.X = int.Parse(definition.Attribute("SheetColumns").Value, NumberStyles.Integer);
            sheetSize.Y = int.Parse(definition.Attribute("SheetRows").Value, NumberStyles.Integer);
        //    sheetSize.X = int.Parse(def.Attribute("SheetColumns").Value, NumberStyles.Integer);
        //    sheetSize.Y = int.Parse(def.Attribute("SheetRows").Value, NumberStyles.Integer);
            TimeSpan frameInterval = TimeSpan.FromSeconds(1.0f / int.Parse(definition.Attribute("Speed").Value, NumberStyles.Integer));
        //    TimeSpan frameInterval = TimeSpan.FromSeconds(1.0f / int.Parse(def.Attribute("Speed").Value, NumberStyles.Integer));

            // Define animation position at the bottom of the screen
            characterPosition = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - frameSize.Y);

            // Define a new Animation instance
            animation = new Animation(texture, frameSize, sheetSize, frameInterval);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        #endregion

        #region Update
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate UFO movement
            UpdateUFO(elapsed);

            // Scale and rotate the asteroid
            UpdateAsteroid();

            // Progress the animation
            bool isProgressed = animation.Update(gameTime);

            // If animation progressed to the next frame change the position accordingly
            if (isProgressed)
            {
                characterPosition.X += animation.frameSize.X / 2;
                if (characterPosition.X > GraphicsDevice.Viewport.Width)
                    characterPosition.X = GraphicsDevice.Viewport.Width / 2;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Update the asteroid position
        /// </summary>
        private void UpdateAsteroid()
        {
            asteroidRotation += 10;
            if (asteroidRotation >= 360)
                asteroidRotation = 0;

            asteroidScale = asteroidScale + (isGrowing ? 0.01f : -0.01f);
            if (asteroidScale > 2.0f)
                isGrowing = false;
            else if (asteroidScale < 0.5f)
                isGrowing = true;
        }

        /// <summary>
        /// Update the UFO position
        /// </summary>
        /// <param name="elapsed"></param>
        private void UpdateUFO(float elapsed)
        {
            ufoPosition += ufoVelocity * 64.0f * elapsed;
            ufoPosition.X = MathHelper.Clamp(ufoPosition.X, 0, GraphicsDevice.Viewport.Width / 2 - ufo.Width);
            if (ufoPosition.X == 0 || ufoPosition.X == GraphicsDevice.Viewport.Width / 2 - ufo.Width)
                ufoVelocity.X = random.Next(-1, 2);

            if (ufoVelocity.X == 0)
                ufoVelocity.X = 1;

            ufoPosition.Y = MathHelper.Clamp(ufoPosition.Y, GraphicsDevice.Viewport.Height / 2, GraphicsDevice.Viewport.Height - ufo.Height);
            if (ufoPosition.Y == GraphicsDevice.Viewport.Height / 2 || ufoPosition.Y == GraphicsDevice.Viewport.Height - ufo.Height)
                ufoVelocity.Y = random.Next(-1, 2);

            if (ufoVelocity.Y == 0)
                ufoVelocity.Y = 1;
        }
        #endregion

        #region Render
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the background texture
            spriteBatch.Begin();
            // Draw a background picture 
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            //Draw asteroid picture - rotated
            DrawTopRightQuadrant();
          //  DrawBottomRightQuadrant();
            // Draw the text
            DrawTopLeftQuadrant();
        //    DrawBottomRightQuadrant();
            // Draw UFO picture
            DrawBottomLeftQuadrant();
         //   DrawBottomRightQuadrant();
            DrawBottomRightQuadrant();

            // Draw the frame
            spriteBatch.Draw(frame, new Vector2(0, 0), Color.Gray);

            spriteBatch.End(); //Don't forget to close it at the end.

            base.Draw(gameTime);
        }

        private void DrawBottomRightQuadrant()
        {//Animated Sprite
            Vector2 textPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 + 10,
                                               GraphicsDevice.Viewport.Height / 2 + 10);
            spriteBatch.DrawString(quadrantFont, "", textPosition, Color.White);

            // Draw the ground
            spriteBatch.Draw(ground, groundPosition, Color.White);

            // Produce animation
            animation.Draw(spriteBatch, characterPosition, SpriteEffects.None);
        }

        private void DrawBottomLeftQuadrant()
        {
            Vector2 textPosition = new Vector2(10, GraphicsDevice.Viewport.Height / 2 + 10);
           /// spriteBatch.DrawString(quadrantFont, "Translation", textPosition, Color.White);

            // Draw the UFO at current location
            spriteBatch.Draw(ufo, ufoPosition, Color.White);
      ///      spriteBatch.Draw(ufo, ufoPosition,
///null, Color.White, MathHelper.ToRadians(asteroidRotation),
///new Vector2(ufo.Width, ufo.Height), asteroidScale,
///SpriteEffects.None, 0);

         //   Copy
 // Process touch events
TouchCollection touchCollection = TouchPanel.GetState();
foreach (TouchLocation tl in touchCollection)
{
    if ((tl.State == TouchLocationState.Pressed)
            || (tl.State == TouchLocationState.Moved))
    {
        spriteBatch.Draw(ufo, ufoPosition,
  null, Color.White, MathHelper.ToRadians(asteroidRotation),
  new Vector2(ufo.Width, ufo.Height), asteroidScale,
  SpriteEffects.None, 0);
        // Draw asteroid
        // Draw asteroid
              spriteBatch.Draw(asteroid, asteroidPosition,
                 null, Color.White, MathHelper.ToRadians(asteroidRotation),
                new Vector2(asteroid.Width, asteroid.Height), asteroidScale,
                 SpriteEffects.None, 0);
              
///        spriteBatch.Draw(asteroid, asteroidPosition,
///          null, Color.White, MathHelper.ToRadians(asteroidRotation),
///          new Vector2(asteroid.Width / 2, asteroid.Height / 2), asteroidScale,
///          SpriteEffects.None, 0);

        // add sparkles based on the touch location
       // sparkles.Add(new Sparkle(tl.Position.X,
        //         tl.Position.Y, ttms));

    }
}


   
         //   Vector2 textPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 + 10,
//                            GraphicsDevice.Viewport.Height / 2 + 10);Animated Sprite
            spriteBatch.DrawString(quadrantFont, "", textPosition, Color.White);

            // Draw the ground
          //  spriteBatch.Draw(ground, groundPosition, Color.White);

            // Produce animation
           // animation.Draw(spriteBatch, characterPosition, SpriteEffects.None);
        
        }

        private void DrawTopLeftQuadrant()
        {//Sprite and Bitmap Fonts
            Vector2 textPosition = new Vector2(10, 10);
            spriteBatch.DrawString(quadrantFont, "", textPosition, Color.White);
             
            // Draw text using Sprite Font
            string text = "";//"Sprite Font";Junt Hoong Chan
            Vector2 size = calibri.MeasureString(text);
            textPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - size.X / 2, 40);
            spriteBatch.DrawString(calibri, text, textPosition, Color.Blue);

            // Draw text using Bitmap Font with primitive shadow effect
            text = "Engineering and Computer Works";//"Bitmap Font";
            size = buxton.MeasureString(text);
            textPosition = new Vector2((GraphicsDevice.Viewport.Width / 2 + 2) - size.X / 2, 104);
            spriteBatch.DrawString(buxton, text, textPosition, Color.Gray);
            spriteBatch.DrawString(buxton, text, textPosition - new Vector2(4, 4), Color.CadetBlue);
        }

        private void DrawTopRightQuadrant()
        {//Scale and Rotate
            Vector2 textPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 + 10, 10);
            spriteBatch.DrawString(quadrantFont, "", textPosition, Color.White);

            // Draw asteroid
     ///       spriteBatch.Draw(asteroid, asteroidPosition,
     ///         null, Color.White, MathHelper.ToRadians(asteroidRotation),
    ///         new Vector2(asteroid.Width, asteroid.Height), asteroidScale,
    ///          SpriteEffects.None, 0);
        ///      

            // Draw asteroid
          spriteBatch.Draw(asteroid, asteroidPosition,
            null, Color.White, MathHelper.ToRadians(asteroidRotation),
            new Vector2(asteroid.Width / 2, asteroid.Height / 2), asteroidScale,
            SpriteEffects.None, 0);
        }

        
        #endregion
    }
}
