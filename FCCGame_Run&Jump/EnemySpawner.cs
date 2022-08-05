using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] EnemyReference;        //Creat array of enemy

    GameObject spawnedEnemy;

    [SerializeField]
    Transform leftPos, rightPos;        //spawn from left or right

    int RandomIndex;                    //spwan with random number
    int RandomSide;                     //spawn from random side


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }


    //coroutine run with duartion
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            RandomIndex = Random.Range(0, EnemyReference.Length);                   //maxmium is number of array
            RandomSide = Random.Range(0, 2);                                        //inclusive, exclusive
            spawnedEnemy = Instantiate(EnemyReference[RandomIndex]);                //Clone object

            //left side
            if (RandomSide == 0)
            {
                spawnedEnemy.transform.position = leftPos.position;                 //spawn on left
                spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(5, 10);    //set speed to random
            }
            //right side
            else
            {
                spawnedEnemy.transform.position = rightPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(5, 10);   //"-" because moving to negative side
                spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

}
