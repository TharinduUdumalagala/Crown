using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameOverController : MonoBehaviour
{

    private GameObject playerObject;
    public Transform respawnPosition;
    private Player player;
    private Crown crown;
    public GameObject gameOverUi;
    private Admob admob;
    [SerializeField]
    private Button extraBall;

    public bool gameOver = false;
    private bool a = false;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        crown = GameObject.FindObjectOfType<Crown>();
        admob = GameObject.FindObjectOfType<Admob>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(CheckInternetConnection());
    }

    private void Update()
    {
        if (crown.win)
        {
            return;
        }
        else
        {
            if (player.health == 0 && player.sr.enabled == false)
            {
                gameOverUi.SetActive(true);
                if (a == false)
                {
                    a = true;
                    ShowAd();
                }
                
                if (gameOver == false)
                {
                    gameOver = true;
                    FindObjectOfType<AudioManager>().Play("Lost");
                    FindObjectOfType<AudioManager>().Stop("Background");
                }
            }
        }
    }

    private void ShowAd()
    {
        if (a)
        {
            admob.RequestBanner();
            admob.ShowBannerAD();
        }
    }

    public void Retry()
    {
        FindObjectOfType<AudioManager>().Play("Background");
        FindObjectOfType<AudioManager>().Stop("Lost");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExtraBall()
    {
        player.sr.enabled = true;
        gameOverUi.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Background");
        FindObjectOfType<AudioManager>().Stop("Lost");
        player.health++;
        player.UpdateHealth();
    }

    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("https://google.com");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            extraBall.interactable = true;
        }
        else
        {
            extraBall.interactable = false;
        }
    }
}
