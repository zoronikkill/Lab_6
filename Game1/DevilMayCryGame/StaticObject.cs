using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DevilMayCryGame
{
    public class StaticObject : GameObject
    {
        public StaticObject(Texture2D texture, Vector2 position) : base(texture, position) { }
    }
}
