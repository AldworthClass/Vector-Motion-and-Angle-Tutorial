using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Vector_Motion_and_Angle_Tutorial
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tankTexture;
        Rectangle tankRect;
        Vector2 tankSpeed;

        List<Fireball> fireballs;

        Rectangle window;

        Texture2D fireballTexture;
        Rectangle fireballRect;
        Vector2 fireballSpeed;

        Texture2D hitBoxTexture;
        Rectangle hitBoxRect;

        MouseState mouseState, prevMouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            tankRect = new Rectangle(350, 250, 75, 75);
            fireballs = new List<Fireball>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fireballTexture = Content.Load<Texture2D>("fireball");
            tankTexture = Content.Load<Texture2D>("tank");
            hitBoxTexture = Content.Load <Texture2D>("rectangle");
        }

        protected override void Update(GameTime gameTime)
        {
            Window.Title = fireballs.Count + "";
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                fireballs.Add(new Fireball(fireballTexture, tankRect.Center.ToVector2(), mouseState.Position.ToVector2()));
            }

            for (int i = 0; i < fireballs.Count; i++)
            {
                fireballs[i].Update();
                if (!window.Intersects(fireballs[i].Rect)) // removes fireballs after they leave the window
                {
                    fireballs.RemoveAt(i);
                    i--;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(hitBoxTexture, tankRect, Color.White);
            _spriteBatch.Draw(tankTexture, tankRect, Color.White);

            foreach (Fireball fireball in fireballs)
                fireball.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}