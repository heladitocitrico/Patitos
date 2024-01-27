using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.PSD;

public class GameManager : MonoBehaviour
{
    private readonly float minEspera = 1.5f;
    private readonly float maxEspera = 4.5f;

    
    public ChistesData chistesData;
    public TextMeshProUGUI chisteText;
    public Player.Pueblo PuebloID;

    public GameObject CampesinoObject;
    public GameObject CleroObject;
    public GameObject NobleObject;
    public GameObject BufonObject;

    void Start()
    {
        SelectRadomharacter();

        StartCoroutine(EntrarPersonaje());
    }

    IEnumerator EntrarPersonaje() {
        Debug.Log("Entrar personaje");
        yield return new WaitForSeconds(Random.Range(minEspera, maxEspera));
        SeleccionarChisteRandom();
    } 

    void SeleccionarChisteRandom() {
        System.Random random = new System.Random();
        var chiste = chistesData.chistes[random.Next(0, chistesData.chistes.Length)];
        chisteText.text = chiste.texto;
    }

    void SelectRadomharacter()
    {
        System.Random r =  new System.Random();
        PuebloID = (Player.Pueblo)r.Next(0, 3);

    DesactivateSprites();
        switch (PuebloID)
        {
            case Player.Pueblo.Campesino :
            CampesinoObject.SetActive(true);
            break;

            case Player.Pueblo.Clerigo :
            CleroObject.SetActive(true);
            break;

            case Player.Pueblo.Noble :
            NobleObject.SetActive(true);
            break;

            case Player.Pueblo.Bufon :
            BufonObject.SetActive(true);
            break;

            default:
            break;
        }
    }

    void DesactivateSprites()
    {
        CampesinoObject.SetActive(false);
        CleroObject.SetActive(false);
        NobleObject.SetActive(false);
        BufonObject.SetActive(false);
    }
}