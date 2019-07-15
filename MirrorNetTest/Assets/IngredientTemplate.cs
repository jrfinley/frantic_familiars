using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IngredientTemplate : ScriptableObject {
    [Header("Display: ")]
    public new string name;
    public Sprite image;
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
}
