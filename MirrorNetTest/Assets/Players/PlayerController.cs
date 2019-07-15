using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerTemplate template;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            if (Mathf.Abs(Input.GetAxis("Joy" + template.ControllerNum + "X")) > 0.2 || Mathf.Abs(Input.GetAxis("Joy" + template.ControllerNum + "Y")) > 0.2)
            {
               
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Joy" + template.ControllerNum + "X") * template.speed, -Input.GetAxis("Joy" + template.ControllerNum + "Y") * template.speed));
                
            }
        }
}
