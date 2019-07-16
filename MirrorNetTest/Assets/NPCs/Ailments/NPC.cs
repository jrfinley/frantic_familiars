using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour {
    public static int maxAilments = 3;
    public NPCDisplay display;
    public Sprite[] possibleAilments;
    public Image[] displaySlots = new Image[maxAilments];
    string[] ailments = new string[maxAilments];
	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < ailments.Length; i++)
        {
            displaySlots[i] = display.slots[i];
            int ailNum = Random.Range(0, possibleAilments.Length);
           
                ailments[i] = possibleAilments[ailNum].name.Replace("Attribute", "");
                displaySlots[i].sprite = possibleAilments[ailNum];
            
        }
        
   
        
    }
	
	// Update is called once per frame
	void Update () {
        if (display.bar.fillAmount <= 0)
        {
            Destroy(display.gameObject);
            Destroy(gameObject);

        }
	}
}
