using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using GameJam.core;

namespace GameJam;

class CursorObj
{
    public GameObject gameObject;

    public CursorObj(string name, Rectangle box)
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