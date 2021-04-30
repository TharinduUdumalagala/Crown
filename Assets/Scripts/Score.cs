using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text coinCount;

    void Update()
    {
        if (File.Exists(SaveSystem.path))
        {
            PlayerData data = SaveSystem.LoadData();
            coinCount.text = data.totalCoin.ToString();
        }
        else
        {
            coinCount.text = "00";
        }
    }
}
