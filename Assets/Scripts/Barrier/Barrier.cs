using UnityEngine;

public abstract class Barrier : MonoBehaviour
{

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Transform pointA;
    [SerializeField]
    protected Transform pointB;

    public bool isTriggerWithPlayer = false;

    public abstract void Update();

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") 
        {
            isTriggerWithPlayer = true;
        }
    }
}
