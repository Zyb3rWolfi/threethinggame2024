using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameJam.core;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameJam;

public class Game1 : Game
{
    private Texture2D playerTexture;
    private Vector2 position;
    private float playerSpeed;
    private GameObject player;
    private GameObject floor;
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private CursorObj _Cursor;
    private MouseState _MouseState;
    private List<Rigidbody> _rigidbodyBatch = new List<Rigidbody>();
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.PreferMultiSampling = false;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        
        playerSpeed = 200f;
        base.Initialize();

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _Cursor = new CursorObj("Cursor", new Rectangle(1, 1, 1, 1));


        // TODO: use this.Content to load your game content here
        
        player = new GameObject();
        player.sprite = Content.Load<Texture2D>("player");
        player.name = "player";
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        foreach (var rigidbody in _rigidbodyBatch) rigidbody.PhysicsUpdate();

        _MouseState = Mouse.GetState();
        _Cursor.SetPosition(_MouseState.Position.ToVector2());

        // TODO: Add your update logic here
        
        float updatedPlayerSpeed = playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        var keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.D))
        {
            position.X += updatedPlayerSpeed;
        }
        if (keyboardState.IsKeyDown(Keys.A))
        {
            position.X -= updatedPlayerSpeed;
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _spriteBatch.End();
        // TODO: Add your drawing code here
        
        
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
         Rectangle playerRectangle = new Rectangle((int)position.X, (int)position.Y, player.sprite.Width * 4, player.sprite.Height * 4);
        _spriteBatch.Draw(player.sprite, playerRectangle, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}