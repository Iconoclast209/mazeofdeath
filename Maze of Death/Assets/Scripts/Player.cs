using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speedModifier = 4f;
    Rigidbody2D rb2d;
    Vector2 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            //Determine where the player is going to move to
            Vector2 newPosition = new Vector2(currentPosition.x + (Input.GetAxis("Horizontal") * speedModifier * Time.deltaTime),
                currentPosition.y + (Input.GetAxis("Vertical") * speedModifier * Time.deltaTime));
            //Then move the player
            rb2d.MovePosition(newPosition);
            Debug.Log("Player has moved.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player has entered the tilemap collider.");
        //If the player enters the tilemap collider, then nudge position back to former position.
        rb2d.MovePosition(currentPosition);
    }

}
