using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private readonly float minEspera = 1.5f;
    private readonly float maxEspera = 4.5f;

    
    public ChistesData chistesData;
    public TextMeshProUGUI chisteText;

    void Start()
    {
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
}