using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameJam.core;
using GameJam.entitys;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace GameJam;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private CursorObj _Cursor;
    private MouseState _MouseState;
    private List<Rigidbody> _rigidbodyBatch = new List<Rigidbody>();
    private IDictionary<string, Texture2D> _spriteList = new Dictionary<string, Texture2D>();
    bool shoot_pressed = false;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _Cursor = new CursorObj("Cursor", new Rectangle(1, 1, 1, 1));

        _Cursor.gameObject.sprite = Content.Load<Texture2D>("TestSprite");
        _spriteList.Add("bulletSprite", Content.Load<Texture2D>("bullet"));
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (!shoot_pressed && Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            shoot_pressed = true;
        }

        if (Keyboard.GetState().IsKeyUp(Keys.Space))
        {
            shoot_pressed = false;
        }

        foreach (var rigidbody in _rigidbodyBatch) rigidbody.PhysicsUpdate();

        _MouseState = Mouse.GetState();
        _Cursor.SetPosition(_MouseState.Position.ToVector2());


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _Cursor.gameObject.Draw(_spriteBatch);

        if (shoot_pressed == true)
        {
            // Draw bullet sprite
        }
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}