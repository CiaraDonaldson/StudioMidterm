using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public PlayerController PlayerController;

    public float detectRange = 15; // this gets multiplied by itself to compare to a sqr magnitude check (instead of distance)
    public bool inRange = false;
    public float moveSpeed = 6f; // you can adjust this, of course.
    Rigidbody2D rb;  // cached the reference, so you can avoid GetComponent calls in Update/FixedUpdate.


    private void Awake() 
    {
        PlayerController = FindObjectOfType<PlayerController>();
        target = PlayerController.transform;

        rb = GetComponent<Rigidbody2D>();
        detectRange *= detectRange;
    }

    void Update()
    {
        // a little cheaper than 'distance'.. deleted the code to create a position from the player values.
        float distsqr = (target.position - transform.position).sqrMagnitude;

        if (distsqr <= detectRange)
        {
            inRange = true;
            // get a velocity based on the normalized direction, multiplied by move speed.
            Vector2 velocity = (target.position - transform.position).normalized * moveSpeed;
            rb.velocity = velocity;
        }
        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
}
