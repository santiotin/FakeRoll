using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadPanel : MonoBehaviour
{
    // Start is called before the first frame update

    public Text perc;

    public Text deadPerc;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deadPerc.text = perc.text;
    }
}
