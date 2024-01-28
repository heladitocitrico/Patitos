using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntroductionsData", menuName = "Data/IntroductionsData", order = 1)]
public class IntroductionsData : ScriptableObject
{
    [System.Serializable]
    public class IntroductionItem
    {
        public Pueblo pueblo;
        public string text;
    }

    public IntroductionItem[] Introductions;
}