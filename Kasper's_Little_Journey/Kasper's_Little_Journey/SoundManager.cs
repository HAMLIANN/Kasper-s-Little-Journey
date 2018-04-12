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
        public Song bgMusic;

        // Constructor
        public SoundManager()
        {
            bgMusic = null;
        }

        public void LoadContent(ContentManager Content)
        {
            bgMusic = Content.Load<Song>("theme");
        }
    }
}
