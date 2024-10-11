using GameJam.entitys;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GameJam.core
{
    internal class Rigidbody
    {
        private const float _gravityIntensity = 1f;
        private const float _terminalVerlocity = 10f;

        public float gravityMultiplier = 1.0f;
        private GameObject _gameObject;
        public Vector2 velocity = new Vector2(0,0);

        public Rigidbody(GameObject gameObject)
        {
            _gameObject = gameObject;
        }



        public void PhysicsUpdate(List<GameObject> entitys)
        {
            
            velocity.Y += _gravityIntensity * gravityMultiplier;
            if (velocity.Y > _terminalVerlocity)
            {
                velocity.Y = _terminalVerlocity;
            }


            _gameObject.position += velocity;
            _gameObject.hitBox = new Rectangle((int)_gameObject.position.X, (int)_gameObject.position.Y, _gameObject.sprite.Width * 4, _gameObject.sprite.Height * 4);
        
            
            Vector2 directionVector = new Vector2(0,0);
            Vector2 xa = new Vector2(0,0);
            Vector2 ya = new Vector2(0,0);
            Vector2 tempVel = velocity;

            foreach (var entity in entitys)
            {
                tempVel = velocity;

                directionVector = new Vector2(0, 0);

                xa = new Vector2(_gameObject.hitBox.X + _gameObject.hitBox.Y) + new Vector2(-(_gameObject.hitBox.Height / 2), _gameObject.hitBox.Width / 2);
                ya = new Vector2(entity.hitBox.X + entity.hitBox.Y) + new Vector2(-(entity.hitBox.Height / 2), entity.hitBox.Width / 2);
                if (xa.Y < ya.Y)
                {
                    directionVector.Y = 1;
                }
                else
                {
                    directionVector.Y = -1;
                }
                if (xa.X < ya.X)
                {
                    directionVector.X = 1;
                }
                else { 
                    directionVector.X = -1;
                }

                tempVel = velocity * directionVector;

                if (tempVel.Y > tempVel.X && directionVector.Y == 1)
                {
                    _gameObject.hitBox.Y  = (int)Math.Round( ya.Y - (entity.hitBox.Height / 2));
                }
                else if (tempVel.Y > tempVel.X && directionVector.Y == -1)
                {
                    _gameObject.hitBox.Y = (int)Math.Round(ya.Y + (entity.hitBox.Height / 2));
                }
                else if (tempVel.X > tempVel.Y && directionVector.X == 1)
                {
                    _gameObject.hitBox.X = (int)Math.Round(ya.X - (entity.hitBox.Width / 2));
                }
                else if (tempVel.X > tempVel.Y && directionVector.X == -1)
                {
                    _gameObject.hitBox.X = (int)Math.Round(ya.X + (entity.hitBox.Width / 2));
                }

            }
        
        }
    }
}
