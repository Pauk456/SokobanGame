using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SokobanGame.src.Presenter;
using Microsoft.Xna.Framework.Input;

namespace SokobanGame.src.View
{
    public class View : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameObjectDraw[,] map;

        public delegate void CommandDelegate(Command e);
        public event CommandDelegate CommandEvent;

        private Texture2D _boxTexture;
        private Texture2D _storekeeperTexture;
        private Texture2D _emptySpaceTexture;
        private Texture2D _wallTexture;
        private Texture2D _placeForBoxTexture;
        private Texture2D _pressedBoxTexture;

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

        public void UpdateMapData(GameObjectDraw[,] map)
        {
            this.map = map;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _boxTexture = Content.Load<Texture2D>("box_");
            _pressedBoxTexture = Content.Load<Texture2D>("pressedBox");
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

            if (map != null)
            {
                var sizeX = map.GetLength(0);
                var sizeY = map.GetLength(1);

                int mapWidth = sizeX * 34;
                int mapHeight = sizeY * 34;

                int screenWidth = _graphics.PreferredBackBufferWidth;
                int screenHeight = _graphics.PreferredBackBufferHeight;

                int offsetX = (screenWidth - mapWidth) / 2;
                int offsetY = (screenHeight - mapHeight) / 2;

                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        var obj = map[x, y];
                        Vector2 position = new Vector2(offsetX + x * 34, offsetY + y * 34);

                        switch (obj)
                        {
                            case GameObjectDraw.EmptySpace:
                                _spriteBatch.Draw(_emptySpaceTexture, position, Color.White);
                                break;
                            case GameObjectDraw.PlaceForBox:
                                _spriteBatch.Draw(_placeForBoxTexture, position, Color.White);
                                break;
                            case GameObjectDraw.BoxOnPlaceForBox:
                                _spriteBatch.Draw(_pressedBoxTexture, position, Color.White);
                                break;
                            case GameObjectDraw.Wall:
                                _spriteBatch.Draw(_wallTexture, position, Color.White);
                                break;
                            case GameObjectDraw.Storekeeper:
                                _spriteBatch.Draw(_storekeeperTexture, position, Color.White);
                                break;
                            case GameObjectDraw.Box:
                                _spriteBatch.Draw(_boxTexture, position, Color.White);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
