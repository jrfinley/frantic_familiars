using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientType : MonoBehaviour {
    public IngredientTemplate ingredient;
    public Sprite[] icons;
    public GameObject attributeDisplay;
    public bool hasBeenThrown;

    void Start()
    {
        GameObject attributes = Instantiate(attributeDisplay,transform);
        attributes.transform.localScale = attributes.transform.InverseTransformVector( new Vector3(1,1,1));
        attributes.transform.localPosition = new Vector3(-1.5f, 0, 0);
        if (ingredient.hot)
        {
            attributes.transform.Find("HotAttribute").gameObject.SetActive(true);
        }
        if (ingredient.cold)
        {
            attributes.transform.Find("ColdAttribute").gameObject.SetActive(true);
        }
        if (ingredient.magic)
        {
            attributes.transform.Find("MagicAttribute").gameObject.SetActive(true);
        }
        if (ingredient.warding)
        {
            attributes.transform.Find("WardingAttribute").gameObject.SetActive(true);
        }
        if (ingredient.holy)
        {
            attributes.transform.Find("HolyAttribute").gameObject.SetActive(true);
        }
        if (ingredient.evil)
        {
            attributes.transform.Find("EvilAttribute").gameObject.SetActive(true);
        }
        if (ingredient.soft)
        {
            attributes.transform.Find("SoftAttribute").gameObject.SetActive(true);
        }
        if (ingredient.hard)
        {
            attributes.transform.Find("HardAttribute").gameObject.SetActive(true);
        }
    }


}
