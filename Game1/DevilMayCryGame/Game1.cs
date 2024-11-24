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
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player _dante;
        private Player _vergil;
        private StaticObject _background;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 576;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D danteTexture = Content.Load<Texture2D>("dante");
            Texture2D vergilTexture = Content.Load<Texture2D>("vergil");
            Texture2D backgroundTexture = Content.Load<Texture2D>("location");

            _background = new StaticObject(backgroundTexture, Vector2.Zero);
            _dante = new Player(danteTexture, new Vector2(200, 400), Keys.A, Keys.D, Keys.W, Keys.S);
            _vergil = new Player(vergilTexture, new Vector2(700, 400), Keys.Left, Keys.Right, Keys.Up, Keys.Down);
        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _dante.Update(gameTime);
            _vergil.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _background.Draw(_spriteBatch);
            _dante.Draw(_spriteBatch, scale: 0.5f);
            _vergil.Draw(_spriteBatch, scale: 0.5f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }

    public abstract class GameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position;

        public GameObject(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch, float scale = 1f)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }

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
}
