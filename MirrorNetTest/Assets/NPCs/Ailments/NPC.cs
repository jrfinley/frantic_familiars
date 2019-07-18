using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour {
    public static int maxAilments = 3;
    public NPCDisplay display;
    public Sprite[] possibleAilments;
    public Image[] displaySlots = new Image[maxAilments];
    public string[] ailments = new string[maxAilments];
	// Use this for initialization
	void Start () {

        if (gameObject.GetComponent<ParticleSystem>())
        {
            gameObject.GetComponent<ParticleSystem>().Stop();

        }


        string ailmentString = "";
        for (int i = 0; i < ailments.Length; i++)
        {
            displaySlots[i] = display.slots[i];
            int ailNum = Random.Range(0, possibleAilments.Length);
           
                ailments[i] = possibleAilments[ailNum].name.Replace("Attribute", "");
            
            if (!ailmentString.Contains(ailments[i]))
            {
                
                displaySlots[i].sprite = possibleAilments[ailNum];
            }
            else
            {
                displaySlots[i].sprite = null;
                displaySlots[i].color = new Color(0, 0, 0, 0);
            }
            ailmentString = ailmentString + ailments[i];


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
