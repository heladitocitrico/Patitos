using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public enum Pueblo
    {
        Campesino = 0,
        Clerigo,
        Noble,
        Bufon,
    }

    public Animator GameOverAnim;

    public Image CampesinoSlider;
    public Image ClerigoSlider;
    public Image NoblesSlider;
    public Image BufonesSlider;

    public int CampesinoPercent;
    public int ClerigoPercent;
    public int NoblesPercent;
    public int BufonPercent;

    void Start()
    {
        SetFillAmount(Pueblo.Campesino);
        SetFillAmount(Pueblo.Clerigo);
        SetFillAmount(Pueblo.Noble);
        SetFillAmount(Pueblo.Bufon);

    }

    public void SetFillAmount(Pueblo Type, int Value = 0)
    {
        switch (Type)
        {
            case Pueblo.Campesino:
                CampesinoPercent += Value;
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

            default:
                Debug.Log("Type undifinded");
                break;
        }
    }

    void GameOver()
    {
        GameOverAnim.SetTrigger("GameOver");
    }
}
