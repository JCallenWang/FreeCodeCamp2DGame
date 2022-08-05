using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    Rigidbody2D myBody2D;
    
    void Awake()
    {
        myBody2D = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        myBody2D.velocity = new Vector2(speed, myBody2D.velocity.y);
    }
}
