using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyGreen, EnemyRed, EnemyPurple, Block1, Block2, Block3;
    public Transform[] EnemyPos;
    public int random;
    public float timeWait;
    void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    
    IEnumerator GenerateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeWait);
            random = Random.Range(0, 5);
            Instantiate(EnemyGreen, EnemyPos[Random.Range(0, 3)].position, Quaternion.identity);
            Instantiate(EnemyRed, EnemyPos[Random.Range(0, 3)].position, Quaternion.identity);
            if (random == 1)
            {
                Instantiate(EnemyPurple, EnemyPos[Random.Range(0, 3)].position, Quaternion.identity);
            }
            if (random == 2)
            {
                Instantiate(Block1, EnemyPos[Random.Range(0, 3)].position, Quaternion.identity);
            }
            if (random == 3)
            {
                Instantiate(Block2, EnemyPos[Random.Range(0, 3)].position, Quaternion.identity);
            }
            if (random == 4)
            {
                Instantiate(Block3, EnemyPos[Random.Range(0, 3)].position, Quaternion.identity);
            }


        }
    }
}
