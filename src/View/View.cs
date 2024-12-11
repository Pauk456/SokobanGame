using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SokobanGame.src.Model;
using SokobanGame.src.GameObjects;
using SokobanGame.src.Presenter;
using Microsoft.Xna.Framework.Input;

namespace SokobanGame.src.View
{
    public class View : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MapData _mapData;

        public delegate void CommandDelegate(Command e);
        public event CommandDelegate CommandEvent;

        private Texture2D _boxTexture;
        private Texture2D _storekeeperTexture;
        private Texture2D _emptySpaceTexture;
        private Texture2D _wallTexture;
        private Texture2D _placeForBoxTexture;

        private KeyboardState previousKeyboardState;

        public View()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();
        }

        public void UpdateMapData(MapData mapData)
        {
            _mapData = mapData;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _boxTexture = Content.Load<Texture2D>("box");  
            _storekeeperTexture = Content.Load<Texture2D>("storekeeper"); 
            _emptySpaceTexture = Content.Load<Texture2D>("emptySpace");     
            _wallTexture = Content.Load<Texture2D>("wall");
            _placeForBoxTexture = Content.Load<Texture2D>("placeForBox");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            HandleInput();

            previousKeyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        private void HandleInput()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.W) && previousKeyboardState.IsKeyUp(Keys.W))
            {
                OnCommandEvent(Command.Top);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.A) && previousKeyboardState.IsKeyUp(Keys.A))
            {
                OnCommandEvent(Command.Left);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.S) && previousKeyboardState.IsKeyUp(Keys.S))
            {
                OnCommandEvent(Command.Bottom);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.D) && previousKeyboardState.IsKeyUp(Keys.D))
            {
                OnCommandEvent(Command.Right);
            }
        }

        private void OnCommandEvent(Command command)
        {
            CommandEvent?.Invoke(command);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (_mapData != null)
            {
                for (int x = 0; x < _mapData.SizeX; x++)
                {
                    for (int y = 0; y < _mapData.SizeY; y++)
                    {
                        var obj = _mapData.Map[x, y];

                        if (obj is EmptySpace)
                        {
                            _spriteBatch.Draw(_emptySpaceTexture, new Vector2(x * 32, y * 32), Color.White);
                        }
                        else if(obj is PlaceForBox)
                        {
                            _spriteBatch.Draw(_placeForBoxTexture, new Vector2(x * 32, y * 32), Color.White);
                        }
                        else if (obj is Box)
                        {
                            _spriteBatch.Draw(_boxTexture, new Vector2(x * 32, y * 32), Color.White);
                        }
                        else if (obj is Storekeeper)
                        {
                            _spriteBatch.Draw(_storekeeperTexture, new Vector2(x * 32, y * 32), Color.White);
                        }
                        else if (obj is Wall)
                        {
                            _spriteBatch.Draw(_wallTexture, new Vector2(x * 32, y * 32), Color.White);
                        }
                    }
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
