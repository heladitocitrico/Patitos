using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private int Value;

    public enum Pueblo
    {
        Campesino = 0,
        Clerigo = 1,
        Reyes = 2,
        Buffones = 3,
    }

    public void SetValue(Player king, GameMode.Pueblo pueblo, float Value)
    {
        switch (pueblo)
        {
            case Pueblo.Campesino:
                king.CampesinosPercent = king.CampesinosPercent + Value;
                break;
            case Pueblo.Clerigo:
                king.ClerigoPercent = king.ClerigoPercent + Value;
                break;
            case Pueblo.Reyes:
                king.ReyesPercent = king.ReyesPercent + Value;
                break;
            case Pueblo.Buffones:
                king.BuffonesPercent = king.BuffonesPercent + Value;
                break;
            default:
                Debug.LogError("El enum no esta seteado");
                break;
        }
    }
}
