using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] unit;
    private GameObject Clone;
    private float spawnRate=60;

   
    public EnemyType[] type;
   // enemyHp count;
    public static int enemys=0;
    public int gunners;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(EnemyHp.killCount);
        spawnRate--;
        
     
        if (enemys <= 100)
        {
            if (spawnRate <= 0 && (EnemyHp.killCount <40|| EnemyHp.killCount>80))
            {
                if (type[0] == EnemyType.meele)
                {
                    enemys++;
                    Clone = Instantiate(unit[0], transform.position, Quaternion.identity) as GameObject;
                    int x = 0;

                    if (x <= 50)
                    {
                        x++;
                    }
                    spawnRate = 60-x;
                    // count.enemyCount++;

                }

            }






        }
    }
    public enum EnemyType
    {
        meele,
        tank,
        boss,
        gunner
    }
}
