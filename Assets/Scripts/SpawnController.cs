using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject asteroid;
    public GameObject powerUpSpeed;
    public GameObject powerUpTripleShoot;
    public GameObject life;

    void Start() {        
        StartCoroutine(SpawnAsteroid());
        InvokeRepeating("SpawnPowerUp", 1f, 3f);
    }


    void Update() {
        //if (bossFight == true)
           // StopCoroutine(SpawnAsteroid());
    }    

    IEnumerator SpawnAsteroid() {        
        while(true) {
            Vector3 position = new Vector3(Random.Range(-7, 7), transform.position.y);
            Instantiate(asteroid, position, Quaternion.identity);

            int random = Random.Range(1, 5);
            yield return new WaitForSeconds(random);
        }        
    }    

    void SpawnPowerUp() {
        if (Random.Range(0, 3).Equals(2)) { //aleatorizando a possibilidade de spawn power up
            GameObject powerUp;

            switch(Random.Range(0f, 3f)) {
                case 0: powerUp = powerUpSpeed; break;
                case 1: powerUp = powerUpTripleShoot; break;
                case 2: powerUp = life; break;
                default: powerUp = new GameObject(); break;
            }                        

            Instantiate(powerUp,
                        new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), powerUp.transform.position.z),
                        Quaternion.identity);
            
        }                 
    }    
}
