using Battlehub.Dispatcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public float speed;
    private float xMax = 9;
    private float yMax = 5;
    public GameObject laser;
    public GameObject laserReference;
    public int lives = 3;
    public Text livesText;
    private bool puTripleShoot = false;    
    private int tripleShootCooldown = 3;
    private int tripleShootCoolDownMaxTime = 0;
    private bool puSpeed = false;
    private int speedCooldown = 3;
    private int speedCoolDownMaxTime = 0;

    void Start() {

    }

    void Update() {
        Moviment();
        Shoot();
        CheckLives();

        if (puTripleShoot) {
            TripleShootCoolDown();
        }
        if(puSpeed) {
            SpeedCoolDown();
        }
    }

    void Moviment() {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        if (transform.position.x > xMax) {
            transform.position = new Vector3(-xMax, transform.position.y);
        } else if (transform.position.x < -xMax) {
            transform.position = new Vector3(xMax, transform.position.y);
        } else if (transform.position.y > yMax) {
            transform.position = new Vector3(transform.position.x, -yMax);
        } else if (transform.position.y < -yMax) {
            transform.position = new Vector3(transform.position.x, yMax);
        }
    }

    void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
            Instantiate(laser, laserReference.transform.position, Quaternion.identity).GetComponent<LaserBehaviour>().LaserBoost(0);

            if (puTripleShoot) {
                Instantiate(laser, laserReference.transform.position, Quaternion.identity).GetComponent<LaserBehaviour>().LaserBoost(1);
                Instantiate(laser, laserReference.transform.position, Quaternion.identity).GetComponent<LaserBehaviour>().LaserBoost(2);
            }            
        }
    }

    void CheckLives() {
        Dispatcher.Current.BeginInvoke(() => {
            livesText.text = lives.ToString();
        });
        if (lives <= 0) {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void TripleShootCoolDown()
    {
        if ((int)Time.time >= tripleShootCoolDownMaxTime) {
            puTripleShoot = false;
        }                        
    }

    private void SpeedCoolDown()
    {
        if ((int)Time.time >= speedCoolDownMaxTime) {

            speed -= 5;

            if (speed == 5) {
                puSpeed = false;                
            }
            else {                
                speedCoolDownMaxTime = (int)Time.time + speedCooldown;                
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "asteroid") {
            Destroy(collision.gameObject);
            lives--;
        }
        else if(collision.tag == "pu_speed") {
            Destroy(collision.gameObject);
            speed += 5;
            puSpeed = true;
            speedCoolDownMaxTime = (int)Time.time + speedCooldown;
        }
        else if (collision.tag == "pu_triple_shoot") {
            Destroy(collision.gameObject);
            puTripleShoot = true;
            tripleShootCoolDownMaxTime = (int)Time.time + tripleShootCooldown;            
        }
        else if (collision.tag == "life")
        {
            Destroy(collision.gameObject);
            lives += 1;
        }
    }
}
