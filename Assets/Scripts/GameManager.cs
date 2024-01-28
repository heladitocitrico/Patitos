using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.PSD;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject prompt;

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
        EventManager.CharacterFinishedWalking += SelectRandomJoke;
        EventManager.CharacterFinishedExiting += SelectRandomCharacter;
        SelectRandomCharacter();
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

    void OnActionTaken(Pueblo pueblo, int score)
    {
        prompt.SetActive(false);
    }

    void SelectRandomJoke()
    {
        prompt.SetActive(true);
        var joke = jokesData.chistes[random.Next(0, jokesData.chistes.Length)];
        jokeText.text = joke.texto;
        laughButton.score = GetScoreForCurrentCharacter(joke);
        killButton.score = -GetScoreForCurrentCharacter(joke);
        laughButton.pueblo = PuebloID;
        killButton.pueblo = PuebloID;
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

    void DeactivateSprites()
    {
        PeasantObject.SetActive(false);
        ClergyObject.SetActive(false);
        NobleObject.SetActive(false);
        BuffoonObject.SetActive(false);
    }
}