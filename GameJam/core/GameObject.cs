using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace GameJam.core;

class GameObject
{
    public Vector2 position = new Vector2(0,0);
    public Texture2D sprite = null; 
    public Rectangle hitBox; 
    public string name = null;
    


    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(sprite, position, Color.White);
    }
}