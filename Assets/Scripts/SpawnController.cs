using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject asteroid;
    public GameObject powerUpSpeed;    

    void Start() {
        //InvokeRepeating("SpawnAsteroid", 1f, 2f);
        StartCoroutine(SpawnAsteroid());
    }


    void Update() {
        //SpawnPowerUpSpeed();
        StartCoroutine(SpawnPowerUpSpeed());   

        //if(algoAcontecer == true)
            //StopCoroutine(SpawnAsteroid)
    }

    /*void SpawnAsteroid() {
        Vector3 position = new Vector3(Random.Range(-7, 7), transform.position.y);
        Instantiate(asteroid, position, Quaternion.identity);
    }*/

    IEnumerator SpawnAsteroid()
    {        
        while(true)
        {
            Vector3 position = new Vector3(Random.Range(-7, 7), transform.position.y);
            Instantiate(asteroid, position, Quaternion.identity);

            int random = Random.Range(1, 5);
            yield return new WaitForSeconds(random);
        }        
    }

    /*void SpawnPowerUpSpeed()
    {
        if (powerUpSpeed.GetComponent<SpriteRenderer>().color.a <= 0)
        {
            powerUpSpeed = Instantiate(powerUpSpeed, powerUpSpeed.transform.position, Quaternion.identity);
        }

        for (float ft = 0; ft <= 1; ft += 0.001f)
        {
            Color c = powerUpSpeed.GetComponent<SpriteRenderer>().color;
            c.a = ft + 0.001f;
            powerUpSpeed.GetComponent<SpriteRenderer>().color = c;            
        }
    }*/

    IEnumerator SpawnPowerUpSpeed()
    {        
        if(powerUpSpeed.GetComponent<SpriteRenderer>().color.a <= 0)
        {
            powerUpSpeed = Instantiate(powerUpSpeed, powerUpSpeed.transform.position, Quaternion.identity);            
        }
        
        for (float ft = 0; ft <= 1; ft += 0.001f)
        {
            Color c = powerUpSpeed.GetComponent<SpriteRenderer>().color;
            c.a = ft + 0.001f;
            powerUpSpeed.GetComponent<SpriteRenderer>().color = c;
            
            yield return null;
        }                
    }
}
