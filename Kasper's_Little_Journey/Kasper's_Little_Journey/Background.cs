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
	//Main
	public class Background
	{
		public Texture2D texture;
		public Vector2 bgPos1, bgPos2;
		public int speed;

		//Constructor
		public Background()
		{
			texture = null;
			bgPos1 = new Vector2(0, 0);
			bgPos2 = new Vector2(0, -950);
			speed = 5;
		}
		//Load content
		public void LoadContent(ContentManager Content)
		{
			texture = Content.Load<Texture2D>("StarField");
		}

		//Draw
		public void Draw(SpriteBatch spriteBatch)
		{

            spriteBatch.Draw(texture, bgPos1, Color.White);
            spriteBatch.Draw(texture, bgPos2, Color.White);

        }

		//Update
		public void Update(GameTime gameTime)
		{
			//setting speed for background
			bgPos1.Y += speed;
			bgPos2.Y += speed;

			//Scolling background {Repeating}
			if (bgPos1.Y >= 950)
			{
				bgPos1.Y = 0;
				bgPos2.Y = -950;
			}
		}
	}
}



