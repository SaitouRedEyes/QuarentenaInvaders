using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

    public float speed;    
    private int direction;

    private enum Directions
    {
        Foward = 0,
        LeftDiagonal = 1,
        RightDiagonal = 2,
    }

    void Start() {

    }

    void Update() {
        switch (direction)
        {
            case (int)Directions.Foward: transform.Translate(Vector3.up * speed * Time.deltaTime); break;
            case (int)Directions.LeftDiagonal: transform.Translate((Vector3.up + Vector3.left) * speed * Time.deltaTime); break;
            case (int)Directions.RightDiagonal: transform.Translate((Vector3.up + Vector3.right) * speed * Time.deltaTime); break;
        }
    }

    public void LaserBoost(int newDirection)
    {        
        direction = newDirection;
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "asteroid") {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
