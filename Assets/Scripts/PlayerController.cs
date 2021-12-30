using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;

    public event System.Action OnPlayerDeath;

    float screenHalfWidthWorldUnits;

    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthWorldUnits, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
