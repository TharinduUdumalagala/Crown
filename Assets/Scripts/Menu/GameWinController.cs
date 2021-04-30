using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinController : MonoBehaviour
{
    private Crown crown;
    public GameObject winUI;
    public Text levelCount;
    private Admob admob;
    private bool a = false;

    private void Start()
    {
        crown = GameObject.FindObjectOfType<Crown>();
        admob = GameObject.FindObjectOfType<Admob>();

    }

    public void Toggle()
    {
        winUI.SetActive(!winUI.activeSelf);     

        if (winUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void Update()
    {
        if (crown.win)
        {
            int x = SceneManager.GetActiveScene().buildIndex;
            levelCount.text = x.ToString();
            winUI.SetActive(true);

            if (a == false)
            {
                a = true;
                showAd();
            }
            
        }
        
    }   

    private void showAd()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index % 2 == 0 && a)
        {
            admob.RequestRewardBaseVideo();
            admob.ShowRewardAd();
        }

    }

    public void Retry()
    {
        Toggle();
        FindObjectOfType<AudioManager>().Play("Background");
        FindObjectOfType<AudioManager>().Stop("Win");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
