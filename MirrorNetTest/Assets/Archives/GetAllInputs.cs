using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllInputs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
       
        for (int i = 0; i < 4; i++)
        {
            if (Mathf.Abs(Input.GetAxis("Joy" + i + "X")) > 0.2 ||
                Mathf.Abs(Input.GetAxis("Joy" + i + "Y")) > 0.2)
            {
                Debug.Log("Controller: " + i + " was moved");
            }
        }


    }
}
