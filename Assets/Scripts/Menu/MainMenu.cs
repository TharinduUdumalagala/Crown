using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectorUi;
    public GameObject skinSelectorUi;
    public GameObject mainMenuUi;
    private Admob admob;


    private void Start()
    {
        admob = GameObject.FindObjectOfType<Admob>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            admob.RequestBanner();
            admob.ShowBannerAD();
        }
    }

    public void playGame()
    {
        if (File.Exists(SaveSystem.path))
        {
            PlayerData data = SaveSystem.LoadData();
            Debug.Log("Highest Level : " + data.highestLevel);
            SceneManager.LoadScene(data.highestLevel);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }        
    }

    public void selectLevel()
    {
        mainMenuUi.SetActive(false);
        levelSelectorUi.SetActive(true);
    }

    public void selectSkin()
    {
        mainMenuUi.SetActive(false);
        skinSelectorUi.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void LevelToMenu()
    {
        levelSelectorUi.SetActive(false);
        mainMenuUi.SetActive(true);
    }

    public void SkinToMenu()
    {
        skinSelectorUi.SetActive(false);
        mainMenuUi.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
