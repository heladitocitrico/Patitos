using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.PSD;

public class GameManager : MonoBehaviour
{
    private int minimumWait = 1;
    private int maximumWait = 3;

    public ChistesData jokesData;
    public TextMeshProUGUI jokeText;
    public static Pueblo PuebloID;

    public GameObject PeasantObject;
    public GameObject ClergyObject;
    public GameObject NobleObject;
    public GameObject BuffoonObject;

    public ActionButton laughButton;
    public ActionButton neutralButton;
    public ActionButton killButton;

    private System.Random random = new System.Random();

    public Player PJ; 

    void Start()
    {
        EventManager.ActionTaken += OnActionTaken;
        SelectRandomCharacter();
        StartCoroutine(EntrarPersonaje());
    }

    void OnActionTaken(Pueblo pueblo, int score)
    {
        Debug.Log("Accion tomada con puntaje: " + score);
        StartCoroutine(SalirPersonaje());
    }

    IEnumerator EntrarPersonaje()
    {
        Debug.Log("Entrar personaje");
        yield return new WaitForSeconds(Random.Range(0, 0));
        SelectRandomJoke();
    }

    IEnumerator SalirPersonaje()
    {
        Debug.Log("Salir personaje");
        yield return new WaitForSeconds(Random.Range(minimumWait, maximumWait));
        SelectRandomJoke();
    }

    void SelectRandomJoke()
    {
        var joke = jokesData.chistes[random.Next(0, jokesData.chistes.Length)];

        jokeText.text = joke.texto;
        laughButton.score = GetScoreForCurrentCharacter(joke);
        killButton.score = -GetScoreForCurrentCharacter(joke);
    }

    int GetScoreForCurrentCharacter(ChistesData.ChisteItem joke)
    {
        switch (PuebloID)
        {
            case Pueblo.Campesino:
                return joke.campesinoPuntos;
            case Pueblo.Clerigo:
                return joke.clerigoPuntos;
            case Pueblo.Noble:
                return joke.reyPuntos;
            case Pueblo.Bufon:
                return joke.bufonPuntos;
            default:
                throw new System.Exception("Pueblo no reconocido");
        }
    }

    void SelectRandomCharacter()
    {
        PuebloID = (Pueblo)random.Next(0, 3);
        DeactivateSprites();
        switch (PuebloID)
        {
            case Pueblo.Campesino:
                PeasantObject.SetActive(true);
                break;
            case Pueblo.Clerigo:
                ClergyObject.SetActive(true);
                break;
            case Pueblo.Noble:
                NobleObject.SetActive(true);
                break;
            case Pueblo.Bufon:
                BuffoonObject.SetActive(true);
                break;
        }
    }

    void DeactivateSprites()
    {
        PeasantObject.SetActive(false);
        ClergyObject.SetActive(false);
        NobleObject.SetActive(false);
        BuffoonObject.SetActive(false);
    }
}