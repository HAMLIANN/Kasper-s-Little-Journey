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
	public class Bullet
	{
		public Rectangle boundingBox;
		public Texture2D texture;
		public Vector2 origin;
		public Vector2 posision;
		public bool isVisible;
		public float speed;

		//Constructor
		public Bullet(Texture2D newTexture)
		{
			speed = 10;
			texture = newTexture;
			isVisible = false;
		}

		//Draw
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, posision, Color.White);
		}
	}
}
