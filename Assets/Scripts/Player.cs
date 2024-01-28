using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using System;

public enum Pueblo
{
    Campesino, Clerigo, Noble, Bufon
}

public class Player : MonoBehaviour
{
    public Animator GameOverAnim;

     public Animator PeaseantAnimator;

    public Image CampesinoSlider;
    public Image ClerigoSlider;
    public Image NoblesSlider;
    public Image BufonesSlider;

    public int CampesinoPercent;
    public int ClerigoPercent;
    public int NoblesPercent;
    public int BufonPercent;

    public GameObject PJ;
    private bool bMove=true;

    void Start()
    {
        SetFillAmount(Pueblo.Campesino);
        SetFillAmount(Pueblo.Clerigo);
        SetFillAmount(Pueblo.Noble);
        SetFillAmount(Pueblo.Bufon);
        EventManager.ActionTaken += SetFillAmount;
    }


    void FixedUpdate()
    {
        if(bMove)
        {
            transform.Translate(-2, 0, 0);
        }
         
    }
    public void SetFillAmount(Pueblo Type, int Value = 0)
    {
        switch (Type)
        {
            case Pueblo.Campesino:
                CampesinoPercent = Math.Clamp(CampesinoPercent += Value, -10, 100);
                CampesinoSlider.fillAmount = CampesinoPercent / 100.0f;
                if (CampesinoPercent <= 0) GameOver();
                break;
            case Pueblo.Clerigo:
                ClerigoPercent += Value;
                ClerigoSlider.fillAmount = ClerigoPercent / 100.0f;
                if (ClerigoPercent <= 0) GameOver();
                break;
            case Pueblo.Noble:
                NoblesPercent += Value;
                NoblesSlider.fillAmount = NoblesPercent / 100.0f;
                if (NoblesPercent <= 0) GameOver();
                break;
            case Pueblo.Bufon:
                BufonPercent += Value;
                BufonesSlider.fillAmount = BufonPercent / 100.0f;
                if (BufonPercent <= 0) GameOver();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bMove = false;
    }


    void GameOver()
    {
        GameOverAnim.SetTrigger("GameOver");
    }
}
