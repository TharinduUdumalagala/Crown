using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViewLevel : MonoBehaviour
{

    [SerializeField]
    private Text level;


    private void Start()
    {
        int levelNo = SceneManager.GetActiveScene().buildIndex;
        level.text = levelNo.ToString();
    }
}
