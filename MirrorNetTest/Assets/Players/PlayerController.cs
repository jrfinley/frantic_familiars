using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerTemplate template;
    public GameObject heldObject = null;

    Vector2 lastDirection;

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
                    lastDirection = new Vector2(Input.GetAxis("Joy" + template.ControllerNum + "X"), -Input.GetAxis("Joy" + template.ControllerNum + "Y"));
            }
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + (template.ControllerNum + 1) + "Button1")))
        {
            if (heldObject != null)
            {
                if (heldObject.GetComponent<Rigidbody2D>())
                {
                    heldObject.GetComponent<Rigidbody2D>().simulated = true;

                    heldObject.transform.parent = null;
                    heldObject.GetComponent<Rigidbody2D>().AddForce(lastDirection * 500);
                    print(lastDirection * 50);
                    heldObject = null;
                }
            }

        }
    }
    

    void OnTriggerStay2D(Collider2D other)
    {
     
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + (template.ControllerNum + 1) + "Button0")))
        {
            if (other.GetComponent<IngredientType>())
            {
                if (other.GetComponent<Rigidbody2D>())
                {
                    other.GetComponent<Rigidbody2D>().simulated = false;
                }
                heldObject = other.gameObject;
                other.transform.parent = transform;
                heldObject.transform.localPosition = new Vector3(0, .2f, 0);
            }
        }

    }
}
