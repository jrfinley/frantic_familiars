using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<PlayerTemplate> playerTemplates = new List<PlayerTemplate>();
    public GameObject player;


	// Use this for initialization
	void Start ()
    {
        foreach (PlayerTemplate p in playerTemplates)
        {
            if (p.Used == true)
            {
               GameObject newPlayer = Instantiate(player,Vector3.zero, new Quaternion(), null);
                newPlayer.GetComponent<PlayerController>().template = p;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
