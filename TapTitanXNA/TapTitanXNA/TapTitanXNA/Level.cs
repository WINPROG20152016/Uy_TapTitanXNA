using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA
{
    public class Level
    {
        // ADDED
        // added comment

        public static int windowWidth = 400;
        public static int windowHeight = 500;

        #region Properties
        ContentManager content;

        Texture2D background;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        Hero hero;

        SpriteFont damageStringFont;
        int damageNumber = 0;

        Button playButton;
        Button attackButton;

        #endregion

        public Level(ContentManager content)
        {
            this.content = content;

            hero = new Hero(content, this);
        }

        public void LoadContent()
        {
            background = content.Load<Texture2D>("bg");
            damageStringFont = content.Load<SpriteFont>("Font");

            playButton = new Button(content, "Button/button_play", Vector2.Zero);
            attackButton = new Button(content, "Button/button_attack", new Vector2(0, 350));

            hero.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;

            

            oldMouseState = mouseState;

            if (attackButton.Update(gameTime, mouseX, mouseY,
                mpressed, prev_mpressed))
            {
                hero.Update(gameTime);
                damageNumber += 1;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background,Vector2.Zero,null,Color.White,0.0f,
                Vector2.Zero,0.8f,SpriteEffects.None,0.0f);
            hero.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(damageStringFont, 
                damageNumber + " Damage!", Vector2.Zero, Color.White);

            //playButton.Draw(gameTime, spriteBatch);
            attackButton.Draw(gameTime, spriteBatch);
        }
    }
}
