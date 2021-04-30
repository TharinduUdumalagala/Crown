using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Player : MonoBehaviour
{

    public int coin;
    public int level;
    public int highestLevel;
    public string skin;

    private Material selectedMaterial;
    public Material basketball;
    public Material football;
    public Material football_red;
    public Material volleyball;
    public Material volleyball_yellow;
    public Material bawling;

    private Rigidbody2D _rigid;
    private PlayerSpawn playerSpawn;
    public Transform respawnPosition;
    private ParticleSystem particleSystem;
    private ParticleSystemRenderer psr;
    public SpriteRenderer sr;
    private CircleCollider2D cc;
    public Image playerSkin;

    private float jumpForce = 18.0f;
    private bool _grounded = false;
    private bool _resetJumpNeeded = false;
    private string _top = "Top";

    public int health;
    [SerializeField]
    private Text healthText;
    private float screenHeight;

    void OnEnable()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        psr = GetComponentInChildren<ParticleSystemRenderer>();

        setSkinToRenderer();
        
        level = SceneManager.GetActiveScene().buildIndex;
        if (File.Exists(SaveSystem.path))
        {
            PlayerData data = SaveSystem.LoadData();

            if (data.highestLevel < level)
            {
                skin = data.skin;
                highestLevel = level;
                coin = data.totalCoin;
                SaveSystem.SaveData(this);
            }
            skin = data.skin;

            playerSkin.sprite = Resources.Load<Sprite>("Skins/" + data.skin);
        }
        else
        {
            highestLevel = 1;
        }

        selectMaterial(skin);
        psr.material = new Material(selectedMaterial);


        

    }
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        playerSpawn = GameObject.FindObjectOfType<PlayerSpawn>();
        cc = GetComponent<CircleCollider2D>();
        screenHeight = Screen.height;

        UpdateHealth();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.y < screenHeight/3 && !touch.Equals(null) && _grounded == true)
            {
                _rigid.velocity = Vector2.up * jumpForce;
                _grounded = false;
                _resetJumpNeeded = true;
                health--;
                UpdateHealth();
                StartCoroutine(ResetJumpNeededRoutine());
            }
        }

        RaycastHit2D hitDownInfo = Physics2D.Raycast(transform.position, Vector2.down, .4f, 1 << 6);

        if (hitDownInfo.collider != null)
        {
            if (_resetJumpNeeded == false)
            {
                _grounded = true;
            }
        }
    }
    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }

    void setSkinToRenderer()
    {
        if (File.Exists(SaveSystem.path))
        {
            if (SaveSystem.LoadData().skin == null && SaveSystem.LoadData().skin.Equals(""))
            {
                sr.sprite = Resources.Load<Sprite>("Skins/basketball");
            }
            else
            {
                sr.sprite = Resources.Load<Sprite>("Skins/" + SaveSystem.LoadData().skin);
            }
        }
        else
        {
            sr.sprite = Resources.Load<Sprite>("Skins/basketball");
            skin = sr.sprite.name;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable hit = collision.GetComponent<IDamagable>();

        if (hit != null)
        {
            hit.Damage();
            StartCoroutine(DestroyPlayer());
        }
        if (collision.name == _top)
        {
            StartCoroutine(DestroyPlayer());
        }
        if (collision.name == "Brick")
        {
            StartCoroutine(DestroyPlayer());
        }
        if (collision.name == "Crown")
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyPlayer()
    {
        _rigid.velocity = Vector2.down * 2 * Time.deltaTime;
        sr.enabled = false;
        cc.enabled = false;

        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        particleSystem.Play();
        yield return new WaitForSeconds(particleSystem.main.startLifetime.constantMax);
        
        playerSpawn.Respawn();

    }

    public void UpdateHealth()
    {
        healthText.text = "x "+ health.ToString();
    }

    public void setSkin(Sprite skin)
    {
        sr.sprite = skin;
        this.skin = skin.name;
    }

    void selectMaterial(string skin)
    {
        if (skin == "basketball")
        {
            selectedMaterial = basketball;
        }
        else if (skin == "bawling")
        {
            selectedMaterial = bawling;
        }
        else if (skin == "football")
        {
            selectedMaterial = football;
        }
        else if (skin == "football_red")
        {
            selectedMaterial = football_red;
        }
        else if (skin == "volleyball")
        {
            selectedMaterial = volleyball;
        }
        else if (skin == "volleyball_yellow")
        {
            selectedMaterial = volleyball_yellow;
        }
        else
        {
            return;
        }
    }

}
