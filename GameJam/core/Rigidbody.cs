using Microsoft.Xna.Framework;

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

        public void PhysicsUpdate()
        {
            _gameObject.position += velocity;


        }
    }
}
