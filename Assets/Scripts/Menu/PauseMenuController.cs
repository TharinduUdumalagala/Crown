using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        SceneManager.LoadScene("MainMenu");
        
    }

}
