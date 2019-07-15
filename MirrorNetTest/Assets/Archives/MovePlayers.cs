using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayers : MonoBehaviour {

    public GameObject[] players;
    public float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < players.Length; i++)
        {
            if (Mathf.Abs(Input.GetAxis("Joy" + i + "X")) > 0.2 || Mathf.Abs(Input.GetAxis("Joy" + i + "Y")) > 0.2)              
            {
                if (players[i] != null) {
                    players[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Joy" + i + "X") * speed, -Input.GetAxis("Joy" + i + "Y") * speed));
                }
            }
        }
    }
}
