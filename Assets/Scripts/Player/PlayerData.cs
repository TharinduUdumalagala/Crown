using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int totalCoin;
    public int level;
    public int highestLevel;
    public string skin;

    public PlayerData(Player player)
    {
        totalCoin = player.coin;
        level = player.level;
        highestLevel = player.highestLevel;
        skin = player.skin;
    }

}
