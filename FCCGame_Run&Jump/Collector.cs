using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    string Enemy_tag = "Enemy";
    string Player_tag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        //object with tag<>, destroy object when colliding
        if (other.CompareTag(Enemy_tag) || other.CompareTag(Player_tag))
        {
            Destroy(other.gameObject);
        }
    }
}
