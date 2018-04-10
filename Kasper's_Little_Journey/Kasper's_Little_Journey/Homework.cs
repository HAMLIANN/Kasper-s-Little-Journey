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
	public class Homework
	{
		public Rectangle boundingBox;
		public Texture2D texture;
		public Vector2 position;
		public Vector2 origin;
		public float rotationAngle;
		public int speed;

		public bool isVisible;
		Random random = new Random();
		public float randX, randY;

		//Constructor
		public Homework(Texture2D newTexture, Vector2 newposition)
		{
			position = newposition;
			texture = newTexture;
			speed = 4;
			isVisible = true;
			randX = random.Next(0, 750);
			randY = random.Next(-600, -50);
		}

		//Load content
		public void LoadContent(ContentManager Content)
		{

		}

		//Draw
		public void Draw(SpriteBatch spriteBatch)
		{
			if (isVisible)
			{
				spriteBatch.Draw(texture, position, /*null,*/ Color.White/*, rotationAngle, origin, 1.0f, SpriteEffects.None, 0f*/);
			}
		}

		//Update
		public void Update(GameTime gameTime)
		{
			//Set Bounding box for collision
			boundingBox = new Rectangle((int)position.X, (int)position.Y, 65, 65);

			//origin.X = texture.Width / 2;
			//origin.Y = texture.Height / 2;

			//Update movement
			position.Y += speed;
			if (position.Y >= 950)
			{
				position.Y = -50;
			}

			////Rotate Homework
			//float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
			//rotationAngle += elapsed;
			//float circle = MathHelper.Pi * 2;
			//rotationAngle = rotationAngle % circle;
		}
	}
}
