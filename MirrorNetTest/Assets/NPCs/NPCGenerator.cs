using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour {
    public Canvas canvas;
    public bool running;
    public GameObject npcBase;
    public GameObject npcDisplayBase;
    public Vector3 npcSpawn;
    public float waitTime = 8;
    public int maxNpcs;
    public List<GameObject> npcLine = new List<GameObject>();
    
	// Use this for initialization
	void Start () {
        StartCoroutine(npcConLoop());	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator npcConLoop()
    {
        while (running) { 

        yield return new WaitForSeconds(Random.Range(waitTime, waitTime + (waitTime/2)));
            if (npcLine.Count < maxNpcs)
            {
                foreach (GameObject go in npcLine)
                {
                    StartCoroutine(moveDown(go));
                }
                GameObject newNPC = Instantiate(npcBase,new Vector3(5,0,0) + npcSpawn,new Quaternion(),null);
                GameObject newDisplay = Instantiate(npcDisplayBase, canvas.transform);
                newDisplay.GetComponent<RectTransform>().position = newDisplay.GetComponent<RectTransform>().position + new Vector3(0,npcLine.Count * -100,0);
                newNPC.GetComponent<NPC>().display = newDisplay.GetComponent<NPCDisplay>();
                npcLine.Add(newNPC);
                StartCoroutine(moveToSpawn(newNPC));
                
            }

        }
    }

    IEnumerator moveDown(GameObject npc) {
        for (int i = 0; i < 60; i++)
        {
            npc.transform.position = npc.transform.position - new Vector3(0, 0.02f, 0);
            yield return new WaitForSeconds(.01f);

        }
    }


    IEnumerator moveToSpawn(GameObject npc)
    {
        for (int i = 0; i < 400; i++)
        {
            npc.transform.position = npc.transform.position - new Vector3(.02f, 0, 0);
            yield return new WaitForSeconds(.01f);
        }
       

    }
    

}
