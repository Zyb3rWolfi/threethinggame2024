using GameJam.core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam.entitys
{
    internal class Player
    {
        public GameObject gameObject = new GameObject();
        public Rigidbody rb;
        public float movementspeed = 100f;

        public Player(string name, List<Rigidbody> rigidbodies, List<GameObject> objectList, Texture2D sprite) {

            rb = new Rigidbody(gameObject);
            rigidbodies.Add(rb);
            gameObject.hitBox = new Rectangle((int)gameObject.position.X, (int)gameObject.position.Y, gameObject.sprite.Width * 4, gameObject.sprite.Height * 4);
            objectList.Add(gameObject);
            gameObject.sprite = sprite;
        }

        private void UpdateMovement(GameTime gt)
        {
            float updatedPlayerSpeed = movementspeed * (float)gt.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.D))
            {
                rb.velocity.X += updatedPlayerSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                rb.velocity.X -= updatedPlayerSpeed;
            }
        }
        public void Update(GameTime gt) {

            UpdateMovement(gt);

        }

    }
}
