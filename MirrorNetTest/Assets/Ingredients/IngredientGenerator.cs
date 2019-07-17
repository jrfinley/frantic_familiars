using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGenerator : MonoBehaviour {
    public GameObject ingredient;
    GameObject itemForm;

    void Start()
    {
        itemForm = Instantiate(ingredient, gameObject.transform.position, new Quaternion(), null);
    }

    // Update is called once per frame
    void Update () {
        if (itemForm == null)
        {
            itemForm = Instantiate(ingredient, gameObject.transform.position, new Quaternion(), null);
        }
	}
}
