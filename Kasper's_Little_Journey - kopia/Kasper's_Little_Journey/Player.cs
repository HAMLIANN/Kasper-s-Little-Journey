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
	public class Player
	{
		public Texture2D texture, bulletTexture, healthTexture;
		public Vector2 position, healthBarPos;
		public int speed, health;
		public float bulletDelay;
		public Rectangle boundingBox, healthRectangle;
		public bool isColliding;
		public List<Bullet> bulletList;
		SoundManager sm = new SoundManager();

		//Constructor
		public Player()
		{
			bulletList = new List<Bullet>();
			texture = null;
			position = new Vector2(300, 300);
			bulletDelay = 1;
			speed = 10;
			isColliding = false;
			health = 200;
			healthBarPos = new Vector2(50, 50);
		}

		//Load content
		public void LoadContent(ContentManager Content)
		{
			texture = Content.Load<Texture2D>("KasperHead");
			bulletTexture = Content.Load<Texture2D>("Pen");
			healthTexture = Content.Load<Texture2D>("HealthBar");
			sm.LoadContent(Content);
		}

		//Draw
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
			spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
			foreach (Bullet b in bulletList)
			{
				b.Draw(spriteBatch);
			}
		}

		//Update
		public void Update(GameTime gameTime)
		{
			//boundingBox for KasperHead
			boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

			//set rectangle for healthbar
			healthRectangle = new Rectangle((int)healthBarPos.X, (int)healthBarPos.Y, health, 25);

			PlayerControler();
			KeepInsideWindow();
		}

		//Shoot Method
		public void Shoot()
		{
			// shoot only if the bullet delay reset
			if (bulletDelay >= 0)
			{
				bulletDelay--;
			}

			// if the bulletdelay is att 0: creat new bullet at player position and add to the list
			if (bulletDelay <= 0)
			{
				sm.shootSound.Play();
				Bullet newBullet = new Bullet(bulletTexture);
				newBullet.posision = new Vector2(position.X + 52 - newBullet.texture.Width / 2, position.Y + 30);

				newBullet.isVisible = true;

				if (bulletList.Count() < 20)
				{
					bulletList.Add(newBullet);
				}

				// reset bulletdelay
				if (bulletDelay <= 0)
				{
					bulletDelay = 12;
				}
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
				b.posision.Y -= b.speed;

				//if the bullet hits the top of the screen, then make invisible false
				if (b.posision.Y <= 0)
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

		//Keep KasperHead inside window
		public void KeepInsideWindow()
		{
			//Keep player inside windows
			if (position.X <= 0)
			{
				position.X = 0;
			}
			if (position.X >= 800 - texture.Width)
			{
				position.X = 800 - texture.Width;
			}
			if (position.Y <= 0)
			{
				position.Y = 0;
			}
			if (position.Y >= 950 - texture.Height)
			{
				position.Y = 950 - texture.Height;
			}
		}
		//Player controler
		public void PlayerControler()
		{
			//Getting Keyboard State
			KeyboardState keyState = Keyboard.GetState();

			//fire bullet
			if (keyState.IsKeyDown(Keys.Space))
			{
				Shoot();
			}

			UpdateBullet();
			//KaperHead controls
			if (keyState.IsKeyDown(Keys.W))
			{
				position.Y -= speed;
			}
			if (keyState.IsKeyDown(Keys.A))
			{
				position.X -= speed;
			}
			if (keyState.IsKeyDown(Keys.S))
			{
				position.Y += speed;
			}
			if (keyState.IsKeyDown(Keys.D))
			{
				position.X += speed;
			}
		}
	}
}
