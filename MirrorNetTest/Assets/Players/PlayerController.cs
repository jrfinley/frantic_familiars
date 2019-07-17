using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerTemplate template;
    public GameObject heldObject = null;
    GameObject heldObject2 = null;
    public string characterType = "Cat";


    Vector2 lastDirection;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (characterType == "Cat" | characterType == "Golem" | characterType == "Toad") {
            if (Mathf.Abs(Input.GetAxis("Joy" + template.ControllerNum + "X")) > 0.2 || Mathf.Abs(Input.GetAxis("Joy" + template.ControllerNum + "Y")) > 0.2)
            {
                if (characterType == "Cat" | characterType == "Golem")
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Joy" + template.ControllerNum + "X") * template.speed, -Input.GetAxis("Joy" + template.ControllerNum + "Y") * template.speed));
                }
                lastDirection = new Vector2(Input.GetAxis("Joy" + template.ControllerNum + "X"), -Input.GetAxis("Joy" + template.ControllerNum + "Y"));
            }
        }
        if (characterType == "Toad")
        {
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + (template.ControllerNum + 1) + "Button2")))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(lastDirection * template.speed * 100);
            }
        }

        if (heldObject == null & heldObject2 != null)
            {
                heldObject = heldObject2;
                heldObject2 = null;
                heldObject.transform.localPosition = new Vector3(0, .2f, 0);

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
                
                    heldObject = null;
                }
            }

        }
    }
    

    void OnTriggerStay2D(Collider2D other)
    {

        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + (template.ControllerNum + 1) + "Button0")) & heldObject == null)
        {
            if (other.GetComponent<IngredientType>() | other.GetComponent<PotionController>())
            {
                if (other.GetComponent<Rigidbody2D>())
                {
                    other.GetComponent<Rigidbody2D>().simulated = false;
                    heldObject = other.gameObject;
                    other.transform.parent = transform;
                    heldObject.transform.localPosition = new Vector3(0, .2f, 0);
                }

            }
        } else if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + (template.ControllerNum + 1) + "Button0")) & heldObject2 == null & characterType == "Golem")
        {
            if (other.GetComponent<IngredientType>() | other.GetComponent<PotionController>())
            {
                if (other.GetComponent<Rigidbody2D>())
                {
                    other.GetComponent<Rigidbody2D>().simulated = false;
                    heldObject2 = other.gameObject;
                    other.transform.parent = transform;
                    heldObject2.transform.localPosition = new Vector3(0, .4f, 0);
                }

            }

        }

    }
}
