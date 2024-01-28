using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public Pueblo pueblo;
    public int score;

    public void OnClick()
    {
        EventManager.OnActionTaken(pueblo, score);
    }
}
