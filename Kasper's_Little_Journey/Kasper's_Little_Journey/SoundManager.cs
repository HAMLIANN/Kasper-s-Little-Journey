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
        public SoundEffect hitSound;
        public Song bgMusic;

        // Constructor
        public SoundManager()
        {
            shootSound = null;
            hitSound = null;
            bgMusic = null;
        }

        public void LoadContent(ContentManager Content)
        {
            shootSound = Content.Load<SoundEffect>("shootSound");
            hitSound = Content.Load<SoundEffect>("hitSound");
            bgMusic = Content.Load<Song>("theme");
        }
    }
}
