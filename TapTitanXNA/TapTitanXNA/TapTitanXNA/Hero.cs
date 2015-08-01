using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA
{
    public class Hero
    {
        #region Properties

        Vector2 playerPositionIdle;
        Vector2 playerPositionAttack;

        ContentManager content;
        Level level;

        Texture2D idle;
        Animation idleAnimation;

        Texture2D attackFast;
        Animation attackFastAnimation;

        AnimationPlayer spritePlayer;

        bool isAttacking;
        float attackTime;

        #endregion

        public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }

        public void LoadContent()
        {
            idle = content.Load<Texture2D>("HeroSprite/taptitanspritesheet2");
            attackFast = content.Load<Texture2D>("HeroSprite/attackfast1");

            idleAnimation = new Animation(idle, 0.1f, true, 13);
            attackFastAnimation = new Animation(attackFast, 0.1f, false, 6);

            int positionX = (Level.windowWidth / 2) - (idleAnimation.FrameWidth / 4);
            int positionY = (Level.windowHeight / 2) - (idleAnimation.FrameHeight / 4);
            positionY = positionY + 20;
            playerPositionIdle = new Vector2((float)positionX, (float)positionY);

            int positionAX = (Level.windowWidth / 2) - (attackFastAnimation.FrameWidth / 4);
            int positionAY = (Level.windowHeight / 2) - (attackFastAnimation.FrameHeight / 4);

            positionAX = positionAX + 5;
            playerPositionAttack = new Vector2((float)positionAX, (float)positionAY);

            spritePlayer.PlayAnimation(idleAnimation);

            isAttacking = false;
        }

        public void Update(GameTime gameTime)
        {
            //if (level.mouseState.LeftButton == ButtonState.Pressed &&
            //    level.oldMouseState.LeftButton == ButtonState.Released)
            //{
                spritePlayer.PlayAnimation(attackFastAnimation);
            //}
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (spritePlayer.Animation == idleAnimation)
            {

                spritePlayer.Draw(gameTime, spriteBatch,
                    playerPositionIdle, SpriteEffects.None);
            }
            else
            {

                spritePlayer.Draw(gameTime, spriteBatch,
                    playerPositionAttack, SpriteEffects.None);
            }
        }
    }
}
