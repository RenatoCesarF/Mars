using Microsoft.Xna.Framework;

namespace Mars.Collider
{
    public class Object
    {
        public Vector2 position; // struct with 3 floats for x, y, z or i + j + k
        public Vector2 velocity;
        public Vector2 force;
        public float mass;

        public Collider collider;
        public Transform transform;
    }
}