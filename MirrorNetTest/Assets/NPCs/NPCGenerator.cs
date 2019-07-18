using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour {
    public Canvas canvas;
    public bool running;
    public GameObject npcBase;
    public GameObject npcDisplayBase;
    public Vector3 npcSpawn;
    public Sprite npcHappy;
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

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PotionController>())
        {
          
            PotionController pCon = collision.gameObject.GetComponent<PotionController>();
            bool alreadyCured = false;
            for (int i = 0; i < npcLine.Count; i++)
            {
                
               if (npcLine[i] != null & alreadyCured == false)
               {
                    int correct = 0;
                    for (int x = 0; x < npcLine[i].GetComponent<NPC>().ailments.Length; x++)
                    {
                        
                        
                        if (npcLine[i] != null)
                        {
                            if ((bool)pCon.GetType().GetField(npcLine[i].GetComponent<NPC>().ailments[x].ToLower()).GetValue(pCon))
                            {

                                correct++;
                                print(correct);
                            }
                        }
                        if (correct >= 3)
                        {
                            Destroy(collision.gameObject);
                            StartCoroutine(moveToBack(npcLine[i]));
                            npcLine[i].GetComponent<SpriteRenderer>().sprite = npcHappy;
                            npcLine[i].GetComponent<NPC>().enabled = false;
                            Destroy(npcLine[i].GetComponent<NPC>().display.gameObject);
                            npcLine[i] = null;
                            alreadyCured = true;

                        }
                    }
                }



            }
        }
    }


    IEnumerator npcConLoop()
    {
        while (running) {

            for (int i = 0; i < npcLine.Count; i++)
            {
                if (npcLine[i] == null)
                {
                    npcLine[i] = null;
                }
            }

        yield return new WaitForSeconds(Random.Range(waitTime, waitTime + (waitTime/2)));
            if (npcLine.Count < maxNpcs | npcLine.Contains(null))
            {
                foreach (GameObject go in npcLine)
                {
                    StartCoroutine(moveDown(go));
                }
                GameObject newNPC = Instantiate(npcBase,new Vector3(5,0,0) + npcSpawn,new Quaternion(),null);
                GameObject newDisplay = Instantiate(npcDisplayBase, canvas.transform);
                
                newNPC.GetComponent<NPC>().display = newDisplay.GetComponent<NPCDisplay>();

                for (int i = 0; i < npcLine.Count; i++)
                {
                    if (npcLine[i] == null & !npcLine.Contains(newNPC))
                    {
                        npcLine[i] = newNPC;
                        newDisplay.GetComponent<RectTransform>().position = newDisplay.GetComponent<RectTransform>().position + new Vector3(0, i * -100, 0);
                    }
                }
                if (!npcLine.Contains(newNPC)) {
                    newDisplay.GetComponent<RectTransform>().position = newDisplay.GetComponent<RectTransform>().position + new Vector3(0, npcLine.Count * -100, 0);
                    npcLine.Add(newNPC);
                    
                }
                StartCoroutine(moveToSpawn(newNPC));
                
            }

        }
    }

    IEnumerator moveDown(GameObject npc) {
        for (int i = 0; i < 120; i++)
        {
            if (npc !=null) {
                npc.transform.position = npc.transform.position - new Vector3(0, 0.02f, 0);
                yield return new WaitForSeconds(.01f);
            }

        }
    }


    IEnumerator moveToSpawn(GameObject npc)
    {
        for (int i = 0; i < 400; i++)
        {
            if (npc != null)
            {
                npc.transform.position = npc.transform.position - new Vector3(.02f, 0, 0);
                yield return new WaitForSeconds(.01f);
            }
        }
       

    }

    IEnumerator moveToBack(GameObject npc)
    {
        StopCoroutine(moveToSpawn(npc));
        npc.GetComponent<ParticleSystem>().Play();
        for (int i = 0; i < 400; i++)
        {
            if (npc != null)
            {
                npc.transform.position = npc.transform.position + new Vector3(.02f, 0, 0);
                yield return new WaitForSeconds(.01f);
            }
        }
        
        Destroy(npc);


    }



}
