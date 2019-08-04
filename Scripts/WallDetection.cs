//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    public GameObject Character;
    public int side;

    void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;

        if (Character.name == "Player")
        {
            if (target.name == "wall")
            {
                move playerScript = Character.GetComponent<move>();

                if (side == 1)
                {
                    playerScript.northFree = false;
                }
                if (side == 2)
                {
                    playerScript.eastFree = false;
                }
                if (side == 3)
                {
                    playerScript.southFree = false;
                }
                if (side == 4)
                {
                    playerScript.westFree = false;
                }
            }
        }
        else//Character.name != player (i.e. this is an enemy)
        {
            if (target.name == "wall" || target.name == "invisableFence")
            {
                wander enemyScript = Character.GetComponent<wander>();
                if (enemyScript != null)
                {
                    //Debug.Log("hitting the wall");

                    if (side == 1)
                    {
                        enemyScript.northFree = false;
                    }
                    if (side == 2)
                    {
                        enemyScript.eastFree = false;
                    }
                    if (side == 3)
                    {
                        enemyScript.southFree = false;
                    }
                    if (side == 4)
                    {
                        enemyScript.westFree = false;
                    }
                }
                bomb itemScript = Character.GetComponent<bomb>();
                if (itemScript != null)
                {
                    if (side == 1)
                    {
                        itemScript.northFree = false;
                    }
                    if (side == 2)
                    {
                        itemScript.eastFree = false;
                    }
                    if (side == 3)
                    {
                        itemScript.southFree = false;
                    }
                    if (side == 4)
                    {
                        itemScript.westFree = false;
                    }
                }
                toAndFro bounce = Character.GetComponent<toAndFro>();
                if (bounce != null)
                {
                    if (side == 2)
                        bounce.wallOnRight = true;
                    if (side == 4)
                        bounce.wallOnLeft = true;
                }


            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject target = other.gameObject;

        if (Character.name == "Player")
        {

            if (target.name == "wall")
            {
                move playerScript = Character.GetComponent<move>();

                if (side == 1)
                {
                    playerScript.northFree = true;
                }
                if (side == 2)
                {
                    playerScript.eastFree = true;
                }
                if (side == 3)
                {
                    playerScript.southFree = true;
                }
                if (side == 4)
                {
                    playerScript.westFree = true;
                }
            }
        }
        else//Character.name != player (i.e. this is an enemy)
        {
            if (target.name == "wall" || target.name == "invisableFence")
            {
                wander enemyScript = Character.GetComponent<wander>();
                if (enemyScript != null)
                {
                    //Debug.Log("hitting the wall");

                    if (side == 1)
                    {
                        enemyScript.northFree = true;
                    }
                    if (side == 2)
                    {
                        enemyScript.eastFree = true;
                    }
                    if (side == 3)
                    {
                        enemyScript.southFree = true;
                    }
                    if (side == 4)
                    {
                        enemyScript.westFree = true;
                    }
                }
                bomb itemScript = Character.GetComponent<bomb>();
                if (itemScript != null)
                {
                    if (side == 1)
                    {
                        itemScript.northFree = true;
                    }
                    if (side == 2)
                    {
                        itemScript.eastFree = true;
                    }
                    if (side == 3)
                    {
                        itemScript.southFree = true;
                    }
                    if (side == 4)
                    {
                        itemScript.westFree = true;
                    }
                }
                toAndFro bounce = Character.GetComponent<toAndFro>();
                if (bounce != null)
                {
                    if (side == 2)
                        bounce.wallOnRight = false;
                    if (side == 4)
                        bounce.wallOnLeft = false;
                }
            }
        }
    }
}