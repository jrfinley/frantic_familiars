using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDisplay : MonoBehaviour {

    public Image[] slots;
    public float time;
    public Image bar;
    float currentTime;
    void Update()
    {
        currentTime += Time.deltaTime;
        if (bar.fillAmount > 0) { 
        bar.fillAmount = 1 - currentTime / time;
          }
    }
}
