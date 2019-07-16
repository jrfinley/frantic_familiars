using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronStation : MonoBehaviour {

    public IngredientTemplate item1 = null;
    public IngredientTemplate item2 = null;

    public Sprite empty;
    public Sprite full;
    public SpriteRenderer Item1Display;

    SpriteRenderer render;
	// Use this for initialization
	void Start () {
        render = gameObject.GetComponent<SpriteRenderer>();
        render.sprite = empty;
        foreach (ParticleSystem p in gameObject.GetComponentsInChildren<ParticleSystem>())
        {
            p.Stop();

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IngredientType>())
        {
            if (item1 == null)
            {
                item1 = collision.gameObject.GetComponent<IngredientType>().ingredient;
                render.sprite = full;
                Item1Display.sprite = item1.image;
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
            } else if (item2 == null)
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
                item1 = null; item2 = null;
                Item1Display.sprite = null;
            }
        }
    }
}
