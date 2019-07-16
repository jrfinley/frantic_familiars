using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerTemplate : ScriptableObject {
    public int ControllerNum;
    public bool Used;
    public int speed = 5;
}
