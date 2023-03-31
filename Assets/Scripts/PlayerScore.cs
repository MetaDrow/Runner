using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore
{
    public int HightScore;
    public int Coin;

    public PlayerScore(CountManager countManager)
    {
        HightScore = countManager.hightScore;
    }
}
