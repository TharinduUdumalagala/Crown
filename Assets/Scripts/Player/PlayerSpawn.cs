using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    //public GameObject playerRespawn;
    private Player player;
    private CircleCollider2D collider;
    private SpriteRenderer renderer;


    void Start()
    {   
        player = GameObject.FindObjectOfType<Player>();
        collider = GetComponent<CircleCollider2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();    
    }

    public void Respawn()
    {
        collider.enabled = true;
        this.gameObject.transform.position = player.respawnPosition.position;
        renderer.enabled = true;

        if (player.health == 0)
        {
            renderer.enabled = false;
            //Destroy(this.gameObject);
        }
    }
}
