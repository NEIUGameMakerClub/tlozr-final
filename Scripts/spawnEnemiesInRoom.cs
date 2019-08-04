//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemiesInRoom : MonoBehaviour {

    public bool roomFinnished = false;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject specificEnemy;
    public int count1;
    public int count2;
    public int count3;
    public int count4;

    public int enemiesLeft;

    public int xScreen = 1;
    public int yScreen = 1;

    public float specificXTile;
    public float specificZTile;


    public void Spawn() {
        if (enemy1 != null)
        {
            for (int i = 0; i < count1; i++)
            {
                Instantiate(enemy1);
                enemy1.transform.position = transform.position + new Vector3(Random.Range(0, 14)-6.5f, 0.5f,Random.Range(0,8)-4);
                /*health enemyScript = enemy1.GetComponent<health>();
                //Debug.Log(enemy1 + ",  " + xScreen + " " + yScreen);
                enemyScript.Room = (gameObject);
                enemyScript.xScreen = xScreen;
                enemyScript.yScreen = yScreen;*/

                enemiesLeft++;
            }
        }
        if (enemy2 != null)
        {
            Instantiate(enemy2);
            enemy2.transform.position = transform.position + new Vector3(Random.Range(0, 14) - 6.5f, 0.5f, Random.Range(0, 8) - 4);
            /*health enemyScript = enemy2.GetComponent<health>();
            enemyScript.Room = (gameObject);
            enemyScript.xScreen = xScreen;
            enemyScript.yScreen = yScreen;*/

            enemiesLeft++;
        }
        if (enemy3 != null)
        {
            Instantiate(enemy3);
            enemy3.transform.position = transform.position + new Vector3(Random.Range(0, 14) - 6.5f, 0.5f, Random.Range(0, 8) - 4);
            /*health enemyScript = enemy3.GetComponent<health>();
            enemyScript.Room = (gameObject);
            enemyScript.xScreen = xScreen;
            enemyScript.yScreen = yScreen;*/

            enemiesLeft++;
        }
        if (specificEnemy != null)
        {
            for (int i = 0; i < count4; i++)
            {
                Instantiate(specificEnemy);
                enemiesLeft++;

                specificEnemy.transform.position = transform.position + new Vector3(specificXTile, 0.5f, specificZTile);
                //Debug.Log(specificEnemy.transform.position);
                /*health enemyScript = specificEnemy.GetComponent<health>();
                enemyScript.Room = (gameObject);
                enemyScript.xScreen = xScreen;
                enemyScript.yScreen = yScreen;*/
            }
        }

        //Debug.Log(enemiesLeft);
    }
}
