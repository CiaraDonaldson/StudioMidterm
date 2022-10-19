using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed = 5;
    public Transform target;
    public PlayerController PlayerController;

    private void Awake() 
    {
        PlayerController = FindObjectOfType<PlayerController>();
        target = PlayerController.transform;
    
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
