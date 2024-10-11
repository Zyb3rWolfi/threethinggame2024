using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameJam;

public class Game1 : Game
{
    private Texture2D playerTexture;
    private Texture2D floorTexture;
    private Vector2 position;
    private float playerSpeed;
    private GameObject player;
    private GameObject floor;
    private const float gravity = 9.8f;
    private const float jumpHeight = 10f;
    private Vector2 floorPosition;
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.IsFullScreen = true;
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

        // TODO: use this.Content to load your game content here
        
        player = new GameObject();
        player.sprite = "player";
        player.name = "player";

        floor = new GameObject();
        floor.sprite = "floor";
        floor.name = "floor";
        floorTexture = Content.Load<Texture2D>(floor.sprite);
        playerTexture = Content.Load<Texture2D>(player.sprite);
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        
        position.Y += gravity;
        
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

        // TODO: Add your drawing code here
        
        
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
        Rectangle playerRectangle = new Rectangle((int)position.X, (int)position.Y, playerTexture.Width * 4, playerTexture.Height * 4);
        _spriteBatch.Draw(playerTexture, playerRectangle, Color.White);
        _spriteBatch.Draw(floorTexture, new Rectangle(0, _graphics.PreferredBackBufferHeight - floorTexture.Height, _graphics.PreferredBackBufferWidth, floorTexture.Height), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}