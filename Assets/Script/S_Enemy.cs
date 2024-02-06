using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    public float rotationAmplitude = 15f; // Amplitude de la rotation
    public float rotationSpeed = 1f; // Vitesse de rotation
    private float rotationAngle = 0f;

    private GameObject GameManager;

    private float initialDelay;

    public float forceParachute = 0.5f; // Force du parachute

    private Rigidbody2D rb;

    public Vector2 sizeOfEnemy = new Vector2(0.8f, 1.2f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialDelay = Random.Range(0f, 2f);
        GameManager = GameObject.Find("GameMode");
        float size = Random.Range(sizeOfEnemy.x, sizeOfEnemy.y);
        GetComponent<Transform>().localScale = new Vector3(size, size, 1);
        rotationAmplitude = Random.Range(rotationAmplitude - 5, rotationAmplitude + 5);
        rotationSpeed = Random.Range(rotationSpeed - 0.5f, rotationSpeed + 0.5f);
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        parachute();
    }

    void parachute()
    {
        rotationAngle = Mathf.Sin((Time.time + initialDelay) * rotationSpeed) * rotationAmplitude;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

        //Logique de parachute
        float fallSpeed = Mathf.Abs(rb.velocity.y);


        float force = fallSpeed * Mathf.Abs(rotationAngle) * forceParachute;
        rb.AddForce(Vector2.up * force, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameManager.GetComponent<S_GameMode>().incrementScore();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            GameManager.GetComponent<S_GameMode>().decrementLife();
            Destroy(gameObject);
        }
    }
}
