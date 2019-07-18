using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<PlayerTemplate> playerTemplates = new List<PlayerTemplate>();
    public GameObject player;
    List<GameObject> players = new List<GameObject>();


	// Use this for initialization
	void Start ()
    {
        foreach (PlayerTemplate p in playerTemplates)
        {
            if (p.Used == true)
            {
               GameObject newPlayer = Instantiate(player,Vector3.zero, new Quaternion(), null);
                newPlayer.GetComponent<PlayerController>().template = p;
                players.Add(newPlayer);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 positions = Vector3.zero;
        for (int i = 0; i < players.Count; i++)
        {
           positions += players[i].transform.position;
        }
        Vector3 middle = (positions) * 0.5f;
            Camera.main.transform.position = new Vector3(
            middle.x,
            middle.y,
             Camera.main.transform.position.z
        );
    }
}
