using System.Numerics;

namespace GameObject;

class GameObject
{
    public Vector2 position;
    public string sprite; 

    public GameObject(Vector2 pos, string sprite)
    {
        this.position = pos;
        this.sprite = sprite;

    }

}