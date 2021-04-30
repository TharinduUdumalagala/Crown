using System.IO;
using UnityEngine;

public class Crown : MonoBehaviour
{
    [SerializeField]
    private int coin;
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    private Player player;
    public bool win = false;
    public float crownSpeed;

    private Vector3 targetPosition;


    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            targetPosition = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            targetPosition = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, crownSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Win");
            FindObjectOfType<AudioManager>().Stop("Background");
            if (File.Exists(SaveSystem.path))
            {
                PlayerData data = SaveSystem.LoadData();
                player.coin = data.totalCoin + coin;
                player.highestLevel = data.highestLevel;
                player.skin = data.skin;
            }
            else
            {
                player.coin = coin;
            }
            SaveSystem.SaveData(player);
            Destroy(this.gameObject);
            win = true;
        }
    }
}
