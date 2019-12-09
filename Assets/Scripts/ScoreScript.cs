using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Text scoreText;

    public Slider slider;

    void Start() {
        slider.maxValue = 63;
        slider.minValue = 5;
    }


    // Update is called once per frame
    void Update()
    {
        float num = player.position.z + 1.0f;
        num = num / 10f;
        scoreText.text = num.ToString("0");
        slider.value = num;
    }
}
