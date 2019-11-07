using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace CocosSharpGameWnd
{
    public class GameLayer : CCLayerColor
    {

        // Define a label variable
        CCLabel label;
        //Define CCSprite Variable
        CCSprite paddleSprite;
        CCSprite paddleSpriteball;
        //Define boolean variable for image reach to top check

        Boolean reachedtop = false;
        public GameLayer() : base(CCColor4B.White)
        {

            // create and initialize a Label
            label = new CCLabel("Welcome to Shanu CocosSharp Game for Windows", "MarkerFelt", 22, CCLabelFormat.SpriteFont);
            label.Color = CCColor3B.Blue;
            // add the label as a child to this Layer
            AddChild(label);


            paddleSprite = new CCSprite("squre");
            paddleSprite.PositionX = 100;
            paddleSprite.PositionY = 100;

            paddleSpriteball = new CCSprite("ball");
            paddleSpriteball.PositionX = 620;
            paddleSpriteball.PositionY = 620;

            AddChild(paddleSprite);
            AddChild(paddleSpriteball);
          

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;

            // position the label on the center of the screen
          label.Position = bounds.Center;

            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
                if(paddleSprite.PositionY > 620)
                {
                    reachedtop = true;
                }
               else if(paddleSprite.PositionY <100)
                 {
                    reachedtop = false;
                }

                if (reachedtop ==false)
                {
                    if (paddleSprite.PositionY >= 80 && paddleSprite.PositionY <= 620)
                    {
                        paddleSprite.PositionX = paddleSprite.PositionX + 20;
                        paddleSprite.PositionY = paddleSprite.PositionX + 20;


                        paddleSpriteball.PositionX = paddleSpriteball.PositionX - 20;
                        paddleSpriteball.PositionY = paddleSpriteball.PositionX - 20;
                    }
                }
                else
                {
                    paddleSprite.PositionX = paddleSprite.PositionX - 20;
                    paddleSprite.PositionY = paddleSprite.PositionX - 20;


                    paddleSpriteball.PositionX = paddleSpriteball.PositionX + 20;
                    paddleSpriteball.PositionY = paddleSpriteball.PositionX + 20;
                }
               
                
               
            }
        }
    }
}

