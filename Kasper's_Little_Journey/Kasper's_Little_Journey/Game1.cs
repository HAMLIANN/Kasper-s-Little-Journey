using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kasper_s_Little_Journey
{
	//Main
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		Random random = new Random();
		public int enemyBulletDamage;

		// list
		List<Homework> homeworkList = new List<Homework>();
		List<Enemy> enemyList = new List<Enemy>();

		Player p = new Player();
		Background bg = new Background();
		HUD hud = new HUD();


		public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
			graphics.IsFullScreen = false;
			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 950;
			this.Window.Title = "Kasper´s Little Journey";
            Content.RootDirectory = "Content";
			enemyBulletDamage = 10;
        }

		//Initialize
        protected override void Initialize()
        {
            base.Initialize();
        }

		//LoadContent
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

			p.LoadContent(Content);
			bg.LoadContent(Content);
			hud.LoadContent(Content);
        }
		
		//UnloadContent
        protected override void UnloadContent()
        {
            
        }

		//Update
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			//updating enemy
			foreach (Enemy e in enemyList)
			{
				//check if enemyship is colliding with player
				if (e.boundingBox.Intersects(p.boundingBox))
				{
					p.health -= 40;
					e.isVisible = false;
				}

				//check enemy bullet collision with player ship
				for (int i = 0; i < e.bulletList.Count; i++)
				{
					if (p.boundingBox.Intersects(e.bulletList[i].boundingBox))
					{
						p.health -= enemyBulletDamage;
						e.bulletList[i].isVisible = false;
					}
				}

				//check player bullet collision to enemy 
				for (int i = 0; i < p.bulletList.Count; i++)
				{
					if (p.bulletList[i].boundingBox.Intersects(e.boundingBox))
					{
						p.bulletList[i].isVisible = false;
						e.isVisible = false;
						hud.playerScore += 20;
					}
				}

				e.Update(gameTime);
			}

			//for each homework in homeworkList, update it and check for collisions
			foreach (Homework h in homeworkList)
			{

				//check if homework is colliding with KasperHead, if they are... set isVisible to false(remove them from homerworkList
				if (h.boundingBox.Intersects(p.boundingBox))
				{
					p.health -= 20;
					h.isVisible = false;
				}

				//Iterate through our bulletList if any  homework come in contacts with these bullet, destroyed bullet and homework
				for (int i = 0; i < p.bulletList.Count; i++)
				{
					if (h.boundingBox.Intersects(p.bulletList[i].boundingBox))
					{
						hud.playerScore += 5;
						h.isVisible = false;
						p.bulletList.ElementAt(i).isVisible = false;
					}
				}

				h.Update(gameTime);
			}
			p.Update(gameTime);
			bg.Update(gameTime);
			//hud.Update(gameTime);
			LoadHomeWork();
			LoadEnemies();

			base.Update(gameTime);
        }

		//Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			bg.Draw(spriteBatch);
			p.Draw(spriteBatch);
			hud.Draw(spriteBatch);
			foreach (Homework h in homeworkList)
			{
				h.Draw(spriteBatch);
			}

			foreach (Enemy e in enemyList)
			{
				e.Draw(spriteBatch);
			}
			spriteBatch.End();

            base.Draw(gameTime);
        }

		//Load homework
		public void LoadHomeWork()
		{
			//Create random variables for X and Y axis of HomeWork
			int randY = random.Next(-600, -50);
			int randX = random.Next(0, 700);

			//if there are less than 5 homework on the screen, then create more untill there is 5 again
			if (homeworkList.Count() < 5)
			{
				homeworkList.Add(new Homework(Content.Load<Texture2D>("HomeWork"), new Vector2(randX, randY)));
			}

			// if any of the homeworks in the list were destroyed(or invisible), then remove them from the list
			for (int i = 0; i < homeworkList.Count; i++)
			{
				if (!homeworkList[i].isVisible)
				{
					homeworkList.RemoveAt(i);
					i--;
				}
			}
		}

		//Load enemies
		public void LoadEnemies()
		{
			//Create random variables for X and Y axis of Enemies
			int randY = random.Next(-600, -50);
			int randX = random.Next(0, 700);

			//if there are less than 3 enemies on the screen, then create more untill there is 5 again
			if (enemyList.Count() < 3)
			{
				enemyList.Add(new Enemy(Content.Load<Texture2D>("EliasHead"), new Vector2(randX, randY), Content.Load<Texture2D>("EnemyPen")));
			}

			if(hud.playerScore >= 500 && hud.playerScore <= 550)
			{
				enemyList.Add(new Enemy(Content.Load<Texture2D>("VendelaHead"), new Vector2(randX, randY), Content.Load<Texture2D>("EnemyPen")));
			}

			// if any of the Enemy in the list were destroyed(or invisible), then remove them from the list
			for (int i = 0; i < enemyList.Count; i++)
			{
				if (!enemyList[i].isVisible)
				{
					enemyList.RemoveAt(i);
					i--;
				}
			}
		}
	}
}
