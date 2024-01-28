using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.PSD;

public class GameManager : MonoBehaviour
{
    static public int JokePoints;

    public ChistesData chistesData;
    public TextMeshProUGUI chisteText;
    static public Player.Pueblo PuebloID;

    public GameObject CampesinoObject;
    public GameObject CleroObject;
    public GameObject NobleObject;
    public GameObject BufonObject;

    void Start()
    {
        EventManager.ActionTaken += ActionTaken;
        SelectRadomharacter();
        StartCoroutine(EntrarPersonaje());
    }

    void AccionTomada(int score)
    {
        Debug.Log("Accion tomada con puntaje: " + score);
        StartCoroutine(SalirPersonaje());
    }

    IEnumerator EntrarPersonaje()
    {
        Debug.Log("Entrar personaje");
        yield return new WaitForSeconds(Random.Range(0, 0));
        SeleccionarChisteRandom();
    }

    IEnumerator SalirPersonaje()
    {
        Debug.Log("Salir personaje");
        yield return new WaitForSeconds(Random.Range(minEspera, maxEspera));
        SeleccionarChisteRandom();
    }

    void SeleccionarChisteRandom()
    {
        System.Random random = new System.Random();
        var chiste = chistesData.chistes[random.Next(0, chistesData.chistes.Length)];
        chisteText.text = chiste.texto;

        switch (PuebloID)
        {
            case Player.Pueblo.Campesino:
                JokePoints = chiste.campesinoPuntos;
                break;

            case Player.Pueblo.Clerigo:
                JokePoints = chiste.clerigoPuntos;
                break;

            case Player.Pueblo.Noble:
                JokePoints = chiste.reyPuntos;
                break;

            case Player.Pueblo.Bufon:
                JokePoints = chiste.bufonPuntos;
                break;
        }
    }

    void SelectRadomharacter()
    {
        System.Random r = new System.Random();
        PuebloID = (Player.Pueblo)r.Next(0, 3);

        DesactivateSprites();
        switch (PuebloID)
        {
            case Player.Pueblo.Campesino:
                CampesinoObject.SetActive(true);
                break;
            case Player.Pueblo.Clerigo:
                CleroObject.SetActive(true);
                break;
            case Player.Pueblo.Noble:
                NobleObject.SetActive(true);
                break;
            case Player.Pueblo.Bufon:
                BufonObject.SetActive(true);
                break;
        }
    }

    void DeactivateSprites()
    {
        CampesinoObject.SetActive(false);
        CleroObject.SetActive(false);
        NobleObject.SetActive(false);
        BufonObject.SetActive(false);
    }
}