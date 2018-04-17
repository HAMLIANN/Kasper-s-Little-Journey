using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Kasper_s_Little_Journey
{
	public class Explosion
	{
		public Texture2D texture;
		public Vector2 position;
		public float timer;
		public float interval;
		public Vector2 origin;
		public int curFrame, spriteWidth, spriteHeight;
		public Rectangle sourceRec;
		public bool isVisible;

		//Constructer
		public Explosion(Texture2D newTexture, Vector2 newPosition)
		{
			position = newPosition;
			texture = newTexture;
			timer = 0f;
			interval = 50f;
			curFrame = 1;
			spriteWidth = 128;
			spriteHeight = 128;
			isVisible = true;
		}

		//loadContent
		public void LoadContent(ContentManager Content)
		{

		}

		//Update
		public void Update(GameTime gameTime)
		{
			//increase the timer by number of milliSecund
			timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			//Check the timer is more thsn the chosen interval
			if (timer > interval)
			{
				//Show next frame
				curFrame++;

				//reset timer
				timer = 0f;
			}

			//if were on the last frame, reset back to the one before the first frame
			if (curFrame == 8)
			{
				isVisible = false;
				curFrame = 1;
			}

			sourceRec = new Rectangle(curFrame * spriteWidth, 0, spriteWidth, spriteHeight);
			origin = new Vector2(sourceRec.Width / 2, sourceRec.Height / 2);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			//if visible then draw
			if (isVisible == true)
			{
				spriteBatch.Draw(texture, position, sourceRec, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
			}
		}
	}
}

