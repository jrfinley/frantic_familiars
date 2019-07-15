using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour {
    int i = 0;
    int[] players = new int[4];

    public SpriteRenderer[] icons;
    public PlayerTemplate[] playerStorage;

    bool OneUsed = false;
    bool TwoUsed = false;
    bool ThreeUsed = false;
    bool FourUsed = false;
    // Use this for initialization
    void Start () {
        players[0] = -1; players[1] = -1; players[2] = -1; players[3] = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if (i < players.Length) {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) && OneUsed == false)
            {
                OneUsed = true;
                players[i] = 0;
                icons[i].gameObject.SetActive(true);
                i++;
                
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0) && TwoUsed == false)
            {
                TwoUsed = true;
                players[i] = 1;
                icons[i].gameObject.SetActive(true);
                i++;
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button0) && ThreeUsed == false)
            {
                ThreeUsed = true;
                players[i] = 2;
                icons[i].gameObject.SetActive(true);
                i++;
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button0) && FourUsed == false)
            {
                FourUsed = true;
                players[i] = 3;
                icons[i].gameObject.SetActive(true);
                i++;
            }
        }
    }
}
