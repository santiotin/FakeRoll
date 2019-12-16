using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    //public Text scoreText;

    public Slider slider;

    public Text percText;

    void Start() {
        slider.maxValue = 58;
        slider.minValue = 4.5f;
    }


    // Update is called once per frame
    void Update()
    {
        float num = player.position.z + 1.0f;
        num = num / 10f;
        //scoreText.text = num.ToString("0");
        slider.value = num;

        if (num >= 5) {
            float perc = (num-5) * 100 / 58;
            if(perc < 100) percText.text = perc.ToString("0") + "%"; 
        }
    }
}
