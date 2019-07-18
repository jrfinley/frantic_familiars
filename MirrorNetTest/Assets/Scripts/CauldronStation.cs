using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronStation : MonoBehaviour {

    public IngredientTemplate item1 = null;
    public IngredientTemplate item2 = null;

    public Sprite empty;
    public Sprite full;
    public SpriteRenderer Item1Display;

    public GameObject potionBase;

    SpriteRenderer render;
    // Use this for initialization
    void Start() {
        render = gameObject.GetComponent<SpriteRenderer>();
        render.sprite = empty;
        foreach (ParticleSystem p in gameObject.GetComponentsInChildren<ParticleSystem>())
        {
            p.Stop();

        }
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IngredientType>())
        {
            if (collision.gameObject.GetComponent<IngredientType>().hasBeenThrown) {
                if (item1 == null & collision.gameObject.GetComponent<IngredientType>().hasBeenThrown)
                {
                    item1 = collision.gameObject.GetComponent<IngredientType>().ingredient;
                    render.sprite = full;
                    Item1Display.sprite = item1.image;
                    Destroy(collision.gameObject);
                    foreach (ParticleSystem p in gameObject.GetComponentsInChildren<ParticleSystem>())
                    {
                        if (p.gameObject.name != "LightFlashes")
                        {
                            p.Play();
                        }
                        else
                        {
                            p.Stop();
                        }
                    }
                } else if (item2 == null & collision.gameObject.GetComponent<IngredientType>())
                {

                    item2 = collision.gameObject.GetComponent<IngredientType>().ingredient;
                    foreach (ParticleSystem p in gameObject.GetComponentsInChildren<ParticleSystem>())
                    {
                        if (p.gameObject.name == "LightFlashes")
                        {
                            p.Emit(30);
                        }

                    }
                    render.sprite = empty;
                    foreach (ParticleSystem p in gameObject.GetComponentsInChildren<ParticleSystem>())
                    {
                        p.Stop();

                    }

                    GameObject newPotion = Instantiate(potionBase);
                    newPotion.transform.position = gameObject.transform.position + new Vector3(0, 1.2f, 0);
                    newPotion.transform.parent = null;
                    bool hot = false;
                    bool cold = false;
                    bool magic = false;
                    bool warding = false;
                    bool holy = false;
                    bool evil = false;
                    bool soothing = false;
                    bool frightening = false;
                    bool soft = false;
                    bool hard = false;
                    if (item1.cold | item2.cold)
                    {
                        cold = true;
                    }
                    if (item1.hot | item2.hot)
                    {
                        hot = true;
                    }
                    if (item1.magic | item2.magic)
                    {
                        magic = true;
                    }
                    if (item1.warding | item2.warding)
                    {
                        warding = true;
                    }
                    if (item1.holy | item2.holy)
                    {
                        holy = true;
                    }
                    if (item1.evil | item2.evil)
                    {
                        evil = true;
                    }
                    if (item1.soothing | item2.soothing)
                    {
                        soothing = true;
                    }
                    if (item1.frightening | item2.frightening)
                    {
                        frightening = true;
                    }
                    if (item1.soft | item2.soft)
                    {
                        soft = true;
                    }
                    if (item1.hard | item2.hard)
                    {
                        hard = true;
                    }
                    PotionController pCon = newPotion.GetComponent<PotionController>();
                    pCon.cold = cold;
                    pCon.hot = hot;
                    pCon.magic = magic;
                    pCon.warding = warding;
                    pCon.holy = holy;
                    pCon.evil = evil;
                    pCon.soothing = soothing;
                    pCon.frightening = frightening;
                    pCon.soft = soft;
                    pCon.hard = hard;
                    Destroy(collision.gameObject);
                    item1 = null; item2 = null;
                    Item1Display.sprite = null;

                }
            }
        }
    } 


                 
       
                


        
      }       

