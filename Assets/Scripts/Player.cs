using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public Image CampesinoSlider;
    public Image ClerigoSlider;
    public Image NoblesSlider;
    public Image BufonesSlider;

    public float CampesinoPercent;
    public float ClerigoPercent;
    public float NoblesPercent;
    public float BufonPercent;

    void Update()
    {

        if (CampesinoSlider)
        {
            CampesinoSlider.fillAmount = CampesinoPercent / 100;
            ClerigoSlider.fillAmount = ClerigoPercent / 100;
            NoblesSlider.fillAmount = NoblesPercent / 100;
            BufonesSlider.fillAmount = BufonPercent / 100;
        }
    }
}
