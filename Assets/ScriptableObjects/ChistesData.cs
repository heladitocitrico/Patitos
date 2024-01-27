using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChistesData", menuName = "Data/ChistesData", order = 1)]
public class ChistesData : ScriptableObject
{
    [System.Serializable]
    public class ChisteItem
    {
        public string texto;
        public int campesinoPuntos;
        public int clerigoPuntos;
        public int reyPuntos;
        public int bufonPuntos;
    }

    public ChisteItem[] chistes;
}
