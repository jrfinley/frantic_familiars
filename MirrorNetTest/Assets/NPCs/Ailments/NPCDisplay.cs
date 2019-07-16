using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDisplay : MonoBehaviour {

    public Image[] slots;
    public float time;
    public Image bar;
    float currentTime;

    [Header("Colors")]
    public Color Good;
    public Color Ok;
    public Color Bad;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (bar.fillAmount > 0) { 
        bar.fillAmount = 1 - currentTime / time;
         }

        if (bar.fillAmount < .196f)
        {
            bar.color = Bad;
        }
        else if (bar.fillAmount < .485f)
        {
            bar.color = Ok;
        }
    }
}
