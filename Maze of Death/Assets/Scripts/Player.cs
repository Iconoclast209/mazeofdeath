using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speedModifier = 5f;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            Vector2 newPosition = new Vector2(Input.GetAxis("Horizontal")* speedModifier * Time.deltaTime, 0f);
            rb2d.AddForce(newPosition, ForceMode2D.Impulse);
        }
    }
}
