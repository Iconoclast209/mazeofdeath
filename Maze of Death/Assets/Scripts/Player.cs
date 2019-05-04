using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region FIELDS
    [SerializeField]
    float speedModifier = 0.1f;
    Rigidbody2D rb2d;
    Vector2 moveDestination = new Vector2(0,0);
    #endregion

    #region METHODS
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveDestination = new Vector2(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, moveDestination, speedModifier);
        rb2d.MovePosition(p);

        if ((Vector2)transform.position == moveDestination)
        {
            if (Input.GetAxis("Vertical") > 0 && ValidMovementDirection(Vector2.up))
                moveDestination = (Vector2)transform.position + Vector2.up;
            if (Input.GetAxis("Horizontal") > 0 && ValidMovementDirection(Vector2.right))
                moveDestination = (Vector2)transform.position + Vector2.right;
            if (Input.GetAxis("Vertical") < 0 && ValidMovementDirection(Vector2.down))
                moveDestination = (Vector2)transform.position - Vector2.up;
            if (Input.GetAxis("Horizontal") < 0 && ValidMovementDirection(Vector2.left))
                moveDestination = (Vector2)transform.position - Vector2.right;
        }
    }

    bool ValidMovementDirection(Vector2 dir)
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Linecast(currentPosition + dir, currentPosition);
        return (hit.collider == GetComponent<Collider2D>());
    }
    #endregion
}
