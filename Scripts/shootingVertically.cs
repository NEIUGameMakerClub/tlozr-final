//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingVertically : MonoBehaviour {

    float intervalTime;

    GameObject prefab1;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
        prefab1 = Resources.Load("movementWizardAttack") as GameObject;
    } 

    // Update is called once per frame
    void Update()
    {
        health enemyScript = GetComponent<health>();
        if (enemyScript.stunned <= 0)
        {

            intervalTime -= Time.deltaTime;

            if (intervalTime < 0)
            {
                intervalTime = 1;
                FireBlast();
            }
        }
    }

    void FireBlast()
    {
        GameObject walkBlast = Instantiate(prefab1) as GameObject;
        walkBlast.transform.position = transform.position + new Vector3(0, -.25f, 0);

        projectile projectileScript = walkBlast.GetComponent<projectile>();
        if (Player.transform.position.z > gameObject.transform.position.z)
            projectileScript.direction = 1;
        else//player is either alongside or underneath
            projectileScript.direction = 3;
    }
}
