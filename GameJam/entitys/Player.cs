using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

namespace GameJam;

class PlayerObj
{
    public GameObject gameObject;

    public PlayerObj(string name, Rectangle box)
    {
        gameObject = new GameObject();
        gameObject.name = name;
        gameObject.hitBox = box;
    }
    
    public void SetPosition(Vector2 newPosition)
    {
        gameObject.position = newPosition;
    }

    public void Update(GameTime gameTime) {
        
            
    }
   }