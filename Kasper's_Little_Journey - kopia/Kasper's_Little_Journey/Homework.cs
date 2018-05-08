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
				spriteBatch.Draw(texture, position,Color.White);
			}
		}

		//Update
		public void Update(GameTime gameTime)
		{
			//Create random variables for X and Y axis of HomeWork
			int randomY = random.Next(-600, -50);
			int randomX = random.Next(0, 700);

			//Set Bounding box for collision
			boundingBox = new Rectangle((int)position.X, (int)position.Y, 65, 65);

			//Update movement
			position.Y += speed;
			if (position.Y >= 950)
			{
				position = new Vector2(randomX, randomY);
			}
		}
	}
}
