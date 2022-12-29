using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightScript : MonoBehaviour
{
    public GameManager gameManager;
    public Transform roof;
    private Rigidbody2D rb;
    public float velocity = 1.4f;
    public float tiltFactor = 15f;
    public float deathTiltSpeed = 5;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    } // end Start

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.hit) {
            if (Input.GetMouseButtonDown(0) && rb.position.y < roof.position.y) 
            {
                gameManager.PlayFlap();
                rb.velocity = Vector2.up * velocity;
            }
            transform.eulerAngles = new Vector3(0, 0 , rb.velocity.y * tiltFactor);
        } else 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler (0, 0, -90), deathTiltSpeed * Time.deltaTime);        
        }
    } // end Update

    private void OnCollisionEnter2D(Collision2D col)
    {
        gameManager.GameOver();
    } // end onCollisionEnter2D

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enviroment")) 
        {
            if (!GameManager.hit) 
            { 
                gameManager.HitEnviroment();
            }
        } else {
            gameManager.AddScore();
        }
    } // end OnTriggerEnter2D
} // end class FlightScript
