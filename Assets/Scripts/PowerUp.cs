using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {        
        for (float ft = 0; ft <= 1; ft += 0.01f)
        {
            Color c = this.GetComponent<SpriteRenderer>().color;
            c.a = ft + 0.001f;
            this.GetComponent<SpriteRenderer>().color = c;

            yield return null;
        }
    }
}
