using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Timer : MonoBehaviour {
    public TextMeshProUGUI timer;
    public TextMeshProUGUI deaths;
    public TextMeshProUGUI saves;
    float timerClock = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timerClock > 0)
        {
            timerClock -= Time.deltaTime;
        }
        timer.text = "Seconds Left: " + timerClock;
        if (timerClock < 0)
        {

            if (int.Parse(saves.text) <= int.Parse(deaths.text)) {
                SceneManager.LoadScene("clinic2");
            }
        }
    }
}
