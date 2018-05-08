using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Kasper_s_Little_Journey
{
	public class SoundManager
	{
		public SoundEffect shootSound;
		public SoundEffect enemyHitSound;
		public SoundEffect playerHitSound;
		public Song bgMusic;
        public Song menuMusic;
        public Song deathMusic;

		// Constructor
		public SoundManager()
		{
			shootSound = null;
			enemyHitSound = null;
			playerHitSound = null;
			bgMusic = null;
            menuMusic = null;
            deathMusic = null;
		}

		public void LoadContent(ContentManager Content)
		{
			shootSound = Content.Load<SoundEffect>("shootSound");
			enemyHitSound = Content.Load<SoundEffect>("enemyHitSound");
			playerHitSound = Content.Load<SoundEffect>("playerHitSound");
			bgMusic = Content.Load<Song>("theme");
            menuMusic = Content.Load<Song>("ThinkingWheel");
            deathMusic = Content.Load<Song>("BlackHoleNeedingSpace");
		}
	}
}
