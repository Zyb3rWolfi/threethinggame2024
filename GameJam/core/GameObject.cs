using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
<<<<<<< HEAD
using System.Drawing;
using System.Net.Mime;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
=======
>>>>>>> 280af3d92dead4253c11d8f31b65e4190b43aa3c

namespace GameJam;

class GameObject
{
    public Vector2 position = new Vector2(0,0);
    public Texture2D sprite = null; 
    public Rectangle hitBox; 
    public string name = null;
<<<<<<< HEAD
    

=======

    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(sprite, position, Color.White);
    }
>>>>>>> 280af3d92dead4253c11d8f31b65e4190b43aa3c
}