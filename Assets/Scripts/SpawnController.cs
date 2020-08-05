using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject asteroid;
    public GameObject powerUpSpeed;    

    void Start() {        
        StartCoroutine(SpawnAsteroid());
        InvokeRepeating("SpawnPowerUp", 1f, 3f);
    }


    void Update() {        
        //if(algoAcontecer == true)
            //StopCoroutine(SpawnAsteroid)
    }    

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

    void SpawnPowerUp()
    {
        if (Random.Range(1, 5).Equals(2))
        {            
            Instantiate(powerUpSpeed,
                        new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), powerUpSpeed.transform.position.z),
                        Quaternion.identity);
            
        }                 
    }    
}
