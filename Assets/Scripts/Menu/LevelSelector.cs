using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] buttons;

    public GameObject scrollRect;
    public GameObject scrollRect2;
    public GameObject scrollRect3;
    public GameObject scrollRect4;
   
    public void SelectLevel(string scene)
    {
        fader.FadeTo(scene);
    }

    private void Start()
    {
        if (File.Exists(SaveSystem.path))
        {
            PlayerData data = SaveSystem.LoadData();
            for (int i = 9; i >= data.highestLevel; i--)
            {
                buttons[i].interactable = false;
            }
        }
        else
        {
            for (int i = 19; i >= 1; i--)
            {
                buttons[i].interactable = false;
            }
        }
        
    }
    
    public void Next()
    {
        
        if (scrollRect.active == true)
        {
            scrollRect.active = false;
            scrollRect2.active = true;
        }
        else if (scrollRect2.active == true)
        {
            scrollRect2.active = false;
            scrollRect3.active = true;
        }
        else if (scrollRect3.active == true)
        {
            scrollRect3.active = false;
            scrollRect4.active = true;
        }

    }
    public void Back()
    {
        if (scrollRect4.active == true)
        {
            scrollRect4.active = false;
            scrollRect3.active = true;
        }
        else if (scrollRect3.active == true)
        {
            scrollRect3.active = false;
            scrollRect2.active = true;
        }
        if (scrollRect2.active == true)
        {
            scrollRect2.active = false;
            scrollRect.active = true;
        }
    }

}
