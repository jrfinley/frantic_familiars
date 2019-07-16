using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour {

    float red = 0;
    float green = 0;
    float blue = 0;

    [Header("Attributes: ")]
    public bool hot;
    public bool cold;
    public bool magic;
    public bool warding;
    public bool holy;
    public bool evil;
    public bool soothing;
    public bool frightening;
    public bool soft;
    public bool hard;
    // Use this for initialization
    void Start () {

        int random255 = Random.Range(0,3);
        print(random255);
        if (random255 == 0)
        {
            red = 1f;
        } else if (random255 == 1)
        {
            green = 1f;
        } else if (random255 == 2)
        {
            blue = 1f;
        }

        int random126 = Random.Range(0, 2);
        if (red != 0)
        {
            if (random126 == 0)
            {
                blue = 0.4941176f;
            } else if (random126 == 1)
            {
                green = 0.4941176f;
            }
        } else if (green != 0)
        {
            if (random126 == 0)
            {
                blue = 0.4941176f;
            }
            else if (random126 == 1)
            {
                red = 0.4941176f;
            }
        } else if (blue != 0)
        {
            if (random126 == 0)
            {
                red = 0.4941176f;
            }
            else if (random126 == 1)
            {
                green = 0.4941176f;
            }
        }

        if (blue != 0 & red != 0)
        {
            green = Random.Range(0.4941176f, 1f);
        } else if (green != 0 & red != 0)
        {
            blue = Random.Range(0.4941176f, 1f);
        } else if (blue != 0 & green != 0)
        {
            red = Random.Range(0.4941176f, 1f);
        }

        foreach (SpriteRenderer r in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
 
            r.color = new Color(red, green, blue, 255);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
