using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam.core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameJam.entitys
{
    internal class Bullet
    {
        public GameObject gameObject = new GameObject();

        public Rigidbody rb;

        public Bullet(IDictionary<string, Texture2D> spriteList, Vector2 _position)
        {
            gameObject.name = "projectile";
            gameObject.sprite = spriteList["bulletSprite"];
            gameObject.position = _position;  
            rb = new Rigidbody(gameObject);
            rb.gravityMultiplier = 0;
            rb.velocity = new Vector2(5, 0);
        }
    }
}
