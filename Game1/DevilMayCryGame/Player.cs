using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Player : GameObject
{
    private Keys _moveLeft;
    private Keys _moveRight;
    private Keys _moveUp;
    private Keys _moveDown;

    public Player(Texture2D texture, Vector2 position, Keys moveLeft, Keys moveRight, Keys moveUp, Keys moveDown)
        : base(texture, position)
    {
        _moveLeft = moveLeft;
        _moveRight = moveRight;
        _moveUp = moveUp;
        _moveDown = moveDown;
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardState ks = Keyboard.GetState();

        // Создаём копию позиции
        Vector2 newPosition = Position;

        if (ks.IsKeyDown(_moveLeft)) newPosition.X -= 3;
        if (ks.IsKeyDown(_moveRight)) newPosition.X += 3;
        if (ks.IsKeyDown(_moveUp)) newPosition.Y -= 3;
        if (ks.IsKeyDown(_moveDown)) newPosition.Y += 3;

        float scale = 0.5f;
        float scaledWidth = Texture.Width * scale;
        float scaledHeight = Texture.Height * scale;

        newPosition.X = MathHelper.Clamp(newPosition.X, 0, 1024 - scaledWidth);
        newPosition.Y = MathHelper.Clamp(newPosition.Y, 0, 576 - scaledHeight);

        Position = newPosition;
    }

}
