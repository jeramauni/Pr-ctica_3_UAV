using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovRandom1 : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float MovX; //test
    public float MovY; //test
    public float V;

    void Start() {
        MovX = Random.Range(1, 3);
        MovY = Random.Range(1, 3);
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Vector2 mov = new Vector2(MovX, MovY);
		rb2d.velocity = (mov)*V;
    }

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "TopeV") {
			MovX = -MovX;
		} 
		else if (other.tag == "TopeH") {
			MovY = -MovY;
		}
			
	}
}
