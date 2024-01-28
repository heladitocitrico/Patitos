using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public enum Pueblo
{
    Campesino, Clerigo, Noble, Bufon
}

public class Player : MonoBehaviour
{
    public Image CampesinoSlider;
    public Image ClerigoSlider;
    public Image NoblesSlider;
    public Image BufonesSlider;

    public int CampesinoPercent;
    public int ClerigoPercent;
    public int NoblesPercent;
    public int BufonPercent;

    public GameObject Bufon;

    public GameObject PJ;
    private int positionIncrement = -2;

    void Start()
    {
        SetFillAmount(Pueblo.Campesino);
        SetFillAmount(Pueblo.Clerigo);
        SetFillAmount(Pueblo.Noble);
        SetFillAmount(Pueblo.Bufon);
        EventManager.ActionTaken += OnActionTaken;
    }

    void FixedUpdate()
    {
        if (positionIncrement != 0)
        {
            transform.Translate(positionIncrement, 0, 0);
        }
    }

    private void OnActionTaken(Pueblo pueblo, int value)
    {
        Bufon.SetActive(true);
        SetFillAmount(pueblo, value);
        positionIncrement = 2;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }

    public void SetFillAmount(Pueblo pueblo, int value = 0)
    {
        switch (pueblo)
        {
            case Pueblo.Campesino:
                CampesinoPercent = Math.Clamp(CampesinoPercent + value, -10, 100);
                CampesinoSlider.fillAmount = CampesinoPercent / 100.0f;
                if (CampesinoPercent <= 0) GameOver();
                break;
            case Pueblo.Clerigo:
                ClerigoPercent = Math.Clamp(ClerigoPercent + value, -10, 100);
                ClerigoSlider.fillAmount = ClerigoPercent / 100.0f;
                if (ClerigoPercent <= 0) GameOver();
                break;
            case Pueblo.Noble:
                NoblesPercent = Math.Clamp(NoblesPercent + value, -10, 100);
                NoblesSlider.fillAmount = NoblesPercent / 100.0f;
                if (NoblesPercent <= 0) GameOver();
                break;
            case Pueblo.Bufon:
                BufonPercent = Math.Clamp(BufonPercent + value, -10, 100);
                BufonesSlider.fillAmount = BufonPercent / 100.0f;
                if (BufonPercent <= 0) GameOver();
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            positionIncrement = 0;
            EventManager.OnCharacterFinishedWalking();
            Bufon.SetActive(false);
        }
        else
        {
            EventManager.OnCharacterFinishedExiting();
            positionIncrement = -2;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }   
    void Update(){
        if (CampesinoPercent<=0){
            SceneManager.LoadScene("Muerte por peasant");
        }
        if (ClerigoPercent<=0){
            SceneManager.LoadScene("Muerte por cleric");
        }if (NoblesPercent<=0){
            SceneManager.LoadScene("Muerte por nobles");
        }if (BufonPercent<=0){
            SceneManager.LoadScene("Muerte por bufon");
        }
    }
}
