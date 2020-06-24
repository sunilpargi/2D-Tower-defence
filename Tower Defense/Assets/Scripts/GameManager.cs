using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
   
    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int maxEnemiesOnScreen;
    public int totalEnemies;
    public int enemiesPerSpawn;

    private int enemiesOnScreen;
    public float waitTime = 2f;




    private void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (enemiesOnScreen < maxEnemiesOnScreen)
                {
                    Instantiate(enemies[0], spawnPoint.transform.position, Quaternion.identity);

                    enemiesOnScreen++;
                   

                }
            }
            yield return new WaitForSeconds(waitTime);
            StartCoroutine(Spawn());

        }
       
    }
 

   public void removeEnemyFromScreen()
    {
        if(enemiesOnScreen > 0)
        enemiesOnScreen--;
    }
}
