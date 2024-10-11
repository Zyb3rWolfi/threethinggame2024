namespace GameJam.core
{
    internal class Rigidbody
    {
        private const float _gravityIntensity = 1f;
        private const float _terminalVerlocity = 10f;

        public float gravityMultiplier = 1.0f;
        private GameObject _gameObject;
        public float velocity;

        public Rigidbody(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void PhysicsUpdate()
        {



        }
    }
}
