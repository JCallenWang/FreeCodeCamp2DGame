using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    public Vector3 tempPos;            //Current position
    [SerializeField]
    float minX, maxX;

    GameObject PlayerCharacter;
    bool PlayerBool;
    string Died_animation = "IsDied";


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        PlayerCharacter = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        //
        if (!player)
        {
            return;
        }
        else
        {
            PlayerBool = PlayerCharacter.GetComponent<Animator>().GetBool(Died_animation);
        }
    }

    void LateUpdate()
    {
        //(player) = (player != null)
        //(!player) = (player == null)
        if(!player)                             //player don't have a reference
            return;                             //break; will not run below function

        //transform.postion = Vector(x,y,z)
        tempPos = transform.position;           //to store position data
        //tempPos.x = player.position.x;        //set equal to player.position.x

        //if PlayerIsDead camera won't follow player
        if (PlayerBool)
        {
            return;
        }
        else
        {
            tempPos.x = player.position.x;
        }
        

        if (tempPos.x < minX)               //temPos.x minmun will allways >= minX
            tempPos.x = minX;
        if (tempPos.x > maxX)               //temPos.x maximun will allways <= maxX
            tempPos.x = maxX;
        
        transform.position = tempPos;       //change position
    }
}
