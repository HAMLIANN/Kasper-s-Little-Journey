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
	class HUD
	{
		public int playerScore, screenWidth, screenHeight;
		public SpriteFont playerScoreFont;
		public Vector2 playerScorePos;
		public bool showHud;

		//Constructor
		public HUD()
		{
			playerScore = 0;
			showHud = true;
			screenHeight = 950;
			screenWidth = 800;
			playerScoreFont = null;
			playerScorePos = new Vector2(screenWidth / 2, 50);

		}

		//Load content
		public void LoadContent(ContentManager Content)
		{
			playerScoreFont = Content.Load<SpriteFont>("Georgia");
		}

		//Update
		public void Update(GameTime gameTime)
		{
			//get keyboard state
			KeyboardState keyState = Keyboard.GetState();
		}

		//draw
		public void Draw(SpriteBatch spriteBatch)
		{
			//ifwe are showing our Hud)
			if (showHud)
			{
				spriteBatch.DrawString(playerScoreFont, "Score - " + playerScore ,playerScorePos, Color.Red);


			}
		}
	}
}
