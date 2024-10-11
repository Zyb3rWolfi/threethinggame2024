using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.Net.Mime;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameJam;

class GameObject
{
    public Vector2 position = new Vector2(0,0);
    public string sprite = null; 
    public Rectangle hitBox; 
    public string name = null;
    

}