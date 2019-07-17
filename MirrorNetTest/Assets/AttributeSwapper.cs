using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSwapper : MonoBehaviour
{
    public string trueField;
    public string falseField;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PotionController>())
        {
            collision.gameObject.GetComponent<PotionController>().GetType().GetField(trueField).SetValue(collision.gameObject.GetComponent<PotionController>(), true);
            collision.gameObject.GetComponent<PotionController>().GetType().GetField(falseField).SetValue(collision.gameObject.GetComponent<PotionController>(), false);
        }
    }
}
