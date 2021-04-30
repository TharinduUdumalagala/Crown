using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    public Player player;
    [SerializeField]
    private GameObject skinButton;
    [SerializeField]
    private GameObject skinContainer;

    private void Start()
    {
        LoadSkins();
    }

    void LoadSkins()
    {
        Sprite[] skins = Resources.LoadAll<Sprite>("Skins");

        foreach (Sprite skin in skins)
        {
            GameObject container = Instantiate(skinButton) as GameObject;
            Image cloneImage = container.GetComponent<Image>();
            cloneImage.sprite = skin;
            container.transform.SetParent(skinContainer.transform, false);
            cloneImage.type = Image.Type.Simple;
            cloneImage.preserveAspect = true;

            Button button = container.GetComponent<Button>();
            button.onClick.AddListener(delegate { selectSkin(skin); });
        }
    }

    public void selectSkin(Sprite skin)
    {
        PlayerData data = SaveSystem.LoadData();
        player.setSkin(skin);
        player.level = data.level;
        player.coin = data.totalCoin;
        player.highestLevel = data.highestLevel;
        SaveSystem.SaveData(player);
    }

}
