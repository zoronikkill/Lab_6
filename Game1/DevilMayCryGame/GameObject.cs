using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class GameObject
{
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }

    public GameObject(Texture2D texture, Vector2 position)
    {
        Texture = texture;
        Position = position;
    }

    public virtual void Draw(SpriteBatch spriteBatch, float scale = 1f)
    {
        spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public virtual void Update(GameTime gameTime) { }
}
