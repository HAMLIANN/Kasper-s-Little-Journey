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
	public class Enemy
	{
		public Texture2D texture, bulletTexture;
		public Rectangle boundingBox;
		public Vector2 position;
		public int health, speed, bulletDelay, currentDiffiultyLevel;
		public bool isVisible;
		public List<Bullet> bulletList;

		//Constructor
		public Enemy(Texture2D newTexture, Vector2 newPosition, Texture2D newbulletTexture)
		{
			texture = newTexture;
			position = newPosition;
			bulletTexture = newbulletTexture;
			bulletList = new List<Bullet>();
			health = 5;
			currentDiffiultyLevel = 1;
			bulletDelay = 40;
			speed = 5;
			isVisible = true;
		}
		//Update
		public void Update(GameTime gameTime)
		{
			//update collision rectangle
			boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

			//update enemy movement
			position.Y += speed;

			// move enemy back to top of screen if it fly's off screen
			if (position.Y >= 950)
			{
				position.Y = -75;
			}

			EnemyShoot();
			UpdateBullet();
		}

		//Draw
		public void Draw(SpriteBatch spriteBatch)
		{
			//Draw enemy
			spriteBatch.Draw(texture, position, Color.White);

			//draw enemy bullets
			foreach (Bullet b in bulletList)
			{
				b.Draw(spriteBatch);
			}
		}

		//Update bullet
		public void UpdateBullet()
		{
			// for each bullet in bulletList: update the movement and if bullet hits the top of the screen, remove it from the list
			foreach (Bullet b in bulletList)
			{

				//boundingBox for every bullet in bulletList
				b.boundingBox = new Rectangle((int)b.posision.X, (int)b.posision.Y, b.texture.Width, b.texture.Height);

				//set movement for bullet
				b.posision.Y += b.speed;

				//if the bullet hits the top of the screen, then make invisible false
				if (b.posision.Y >= 950)
				{
					b.isVisible = false;
				}

			}

			//Iterate through bulletList and see if any of the bullets are not visible, if they arent then remove that bullet from our bullet list
			for (int i = 0; i < bulletList.Count; i++)
			{
				if (!bulletList[i].isVisible)
				{
					bulletList.RemoveAt(i);
					i--;
				}
			}
		}

		//enemy shoot
		public void EnemyShoot()
		{
			//shoot only if bulletDelay resets
			if (bulletDelay >= 0)
			{
				bulletDelay--;
			}

			//create new bullet and position it front and center of enemy 
			if (bulletDelay <= 0)
			{
				Bullet newBullet = new Bullet(bulletTexture);
				newBullet.posision = new Vector2(position.X + texture.Width / 2 - newBullet.texture.Width / 2, position.Y + 30);

				newBullet.isVisible = true;

				if (bulletList.Count() < 20)
				{
					bulletList.Add(newBullet);
				}
			}

			//reset bulletDealy
			if (bulletDelay <= 0)
			{
				bulletDelay = 100;
			}
		}
	}
}
