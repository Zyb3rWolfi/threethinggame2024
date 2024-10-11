using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameJam.core;
using GameJam.entitys;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameJam;

public class Game1 : Game
{
    private float playerSpeed;
    private Player player;
    private Floor floor;
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private CursorObj _Cursor;
    private MouseState _MouseState;
    private List<GameObject> _objects;
    private List<Rigidbody> _rigidbodyBatch = new List<Rigidbody>();
    private IDictionary<string, Texture2D> _spriteList = new Dictionary<string, Texture2D>();

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
        
        base.Initialize();

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _Cursor = new CursorObj("Cursor", new Rectangle(1, 1, 1, 1));

        _Cursor.gameObject.sprite = Content.Load<Texture2D>("TestSprite");
        _spriteList.Add("bulletSprite", Content.Load<Texture2D>("bullet"));

        // TODO: use this.Content to load your game content here
        
        _spriteList.Add("playerSprite", Content.Load<Texture2D>("player"));
        player = new Player("player", _rigidbodyBatch, _objects, _spriteList["player"]);

        _spriteList.Add("FloorSprite", Content.Load<Texture2D>("floor"));
        floor = new Floor(_spriteList["FloorSprite"], new Vector2(0,0), _graphics, _objects);
       
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        foreach (var rigidbody in _rigidbodyBatch)
        {
            rigidbody.PhysicsUpdate(_objects);
        };

        player.Update(gameTime);

        _MouseState = Mouse.GetState();
        _Cursor.SetPosition(_MouseState.Position.ToVector2());

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
        player.gameObject.Draw(_spriteBatch);
        floor.gameObject.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}