using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCreator : MonoBehaviour {
    int i = 0;
    int[] players = new int[4];

    public Sprite MenuReady;
    public Sprite MenuNotReady;

    public SpriteRenderer[] icons;
    public PlayerTemplate[] playerStorage;
    public bool[] Ready;
    public string GameSceneName = "GameLevel";

    bool OneUsed = false;
    bool TwoUsed = false;
    bool ThreeUsed = false;
    bool FourUsed = false;
    // Use this for initialization
    void Start () {
     
        players[0] = -1; players[1] = -1; players[2] = -1; players[3] = -1;
        playerStorage[0].Used = false; playerStorage[1].Used = false; playerStorage[2].Used = false; playerStorage[3].Used = false;
    }
	
	// Update is called once per frame
	void Update () {

    

            if (OneUsed | TwoUsed | ThreeUsed | FourUsed)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {

                    switchActiveState(0);
                    // icons[i].gameObject.SetActive(true);


                }
                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                {
                    switchActiveState(1);

                    //   icons[i].gameObject.SetActive(true);

                }
                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                {
                    switchActiveState(2);

                    //  icons[i].gameObject.SetActive(true);

                }
                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                {
                    switchActiveState(3);

                    // icons[i].gameObject.SetActive(true);

                }


            }

        if (i < players.Length)
        {


            if (Input.GetKeyDown(KeyCode.Joystick1Button0) && OneUsed == false)
            {
                OneUsed = true;
                players[i] = 0;
                playerStorage[i].ControllerNum = 0;
                playerStorage[i].Used = true;
                icons[i].gameObject.SetActive(true);
                i++;
                
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0) && TwoUsed == false)
            {
                TwoUsed = true;
                players[i] = 1;
                playerStorage[i].ControllerNum = 1;
                playerStorage[i].Used = true;
                icons[i].gameObject.SetActive(true);
                i++;
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button0) && ThreeUsed == false)
            {
                ThreeUsed = true;
                players[i] = 2;
                playerStorage[i].ControllerNum = 2;
                playerStorage[i].Used = true;
                icons[i].gameObject.SetActive(true);
                i++;
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button0) && FourUsed == false)
            {
                FourUsed = true;
                players[i] = 3;
                playerStorage[i].ControllerNum = 3;
                playerStorage[i].Used = true;
                icons[i].gameObject.SetActive(true);
                i++;
            }

            

        }
    }

    void switchActiveState(int conNum)
    {

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == conNum)
            {
                if (Ready[i] == false)
                {
                    Ready[i] = true;
                    icons[i].gameObject.GetComponent<SpriteRenderer>().sprite = MenuReady;

                }
                else if (Ready[i] == true)
                {
                    Ready[i] = false;
                    icons[i].gameObject.GetComponent<SpriteRenderer>().sprite = MenuNotReady;
                }

            }
        }

        int readies = 0;
        for (int i = 0; i < Ready.Length; i++)
        {
           
            if (Ready[i])
            {
                readies++;

            }

        }
        int playerNum = 0;
        for (int i = 0; i < players.Length; i++)
        {

            if (players[i] != -1)
            {
                playerNum++;

            }

        }

        if (readies >= playerNum)
        {
            print("Entering Next Level");
            SceneManager.LoadScene(GameSceneName);
        }
    }
}
