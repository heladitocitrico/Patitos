using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public Slider CampesinoSlide;
    public Slider ClerigoSlide;
    public Slider ReySlide;
    public Slider BuffonesSlide;

    public float CampesinosPercent = 0.5f;
    public float ClerigoPercent = 0.5f;
    public float ReyesPercent = 0.5f;
    public float BuffonesPercent = 0.5f;

    void Update()
    {
        if (CampesinoSlide)
        {
<<<<<<< Updated upstream
            CampesinoSlide.value = CampesinosPercent;
            ReySlide.value = ReyesPercent;
            ClerigoSlide.value = ClerigoPercent;
            BuffonesSlide.value = BuffonesPercent;
        }
    }
=======
            SliderCampesino.fillAmount = CampesinoPercent / 100;
            SliderClerigo.fillAmount = ClerigoPercent / 100;
            SliderNobles.fillAmount = NoblesPercent / 100;
            SliderBufones.fillAmount = BufonPercent / 100;
        }
    }

    public Image SliderCampesino;
    public Image SliderClerigo;
    public Image SliderNobles;
    public Image SliderBufones;

    public float CampesinoPercent;
    public float ClerigoPercent;
    public float NoblesPercent;
    public float BufonPercent;
>>>>>>> Stashed changes
}
