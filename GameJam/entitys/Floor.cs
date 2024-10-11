using GameJam.core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace GameJam.entitys
{
    internal class Floor
    {

        public GameObject gameObject = new GameObject();

        public Floor(Texture2D sprite, Vector2 position, GraphicsDeviceManager _graphics, List<GameObject> objectsList)
        {
            gameObject.name = "Floor";
            gameObject.hitBox = new Rectangle(0, _graphics.PreferredBackBufferHeight - sprite.Height * 4, _graphics.PreferredBackBufferWidth, sprite.Height * 4);
            objectsList.Add(gameObject);
        }

    }
}
