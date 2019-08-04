//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : MonoBehaviour {

    public bool northFree = true;
    public bool eastFree = true;
    public bool southFree = true;
    public bool westFree = true;

    int sidesFree;
    int a;
    public bool standing = true;

    //public GameObject enemy;
    Vector3 pos;

    void Start() {
        pos = transform.position;
    }

	// Update is called once per frame
	void Update () {
        health enemyScript = gameObject.GetComponent<health>();
        if (enemyScript.stunned <= 0)
        {
            if (standing)
            {
                if (northFree)
                {
                    if (eastFree)
                    {
                        if (southFree)
                        {
                            if (westFree)//NESW
                            {
                                a = Random.Range(1, 5);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(0, 0, 1);
                                    enemyScript.direction = 1;
                                }
                                else if (a == 2)
                                {
                                    pos = pos + new Vector3(1, 0, 0);
                                    enemyScript.direction = 2;
                                }
                                else if (a == 3)
                                {
                                    pos = pos + new Vector3(0, 0, -1);
                                    enemyScript.direction = 3;
                                }
                                else
                                {
                                    pos = pos + new Vector3(-1, 0, 0);
                                    enemyScript.direction = 4;
                                }
                            }
                            else//NES
                            {
                                a = Random.Range(1, 4);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(0, 0, 1);
                                    enemyScript.direction = 1;
                                }
                                else if (a == 2)
                                {
                                    pos = pos + new Vector3(1, 0, 0);
                                    enemyScript.direction = 2;
                                }
                                else
                                {
                                    pos = pos + new Vector3(0, 0, -1);
                                    enemyScript.direction = 3;
                                }
                            }
                        }
                        else//south not free
                        {
                            if (westFree)//NEW
                            {
                                a = Random.Range(1, 4);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(0, 0, 1);
                                    enemyScript.direction = 1;
                                }
                                else if (a == 2)
                                {
                                    pos = pos + new Vector3(1, 0, 0);
                                    enemyScript.direction = 2;
                                }
                                else
                                {
                                    pos = pos + new Vector3(-1, 0, 0);
                                    enemyScript.direction = 4;
                                }
                            }
                            else//NE
                            {
                                a = Random.Range(1, 3);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(0, 0, 1);
                                    enemyScript.direction = 1;
                                }
                                else
                                {
                                    pos = pos + new Vector3(1, 0, 0);
                                    enemyScript.direction = 2;
                                }
                            }
                        }
                    }
                    else//east not free
                    {
                        if (southFree)
                        {
                            if (westFree)//NSW
                            {
                                a = Random.Range(1, 4);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(0, 0, 1);
                                    enemyScript.direction = 1;
                                }
                                else if (a == 2)
                                {
                                    pos = pos + new Vector3(0, 0, -1);
                                    enemyScript.direction = 3;
                                }
                                else
                                {
                                    pos = pos + new Vector3(-1, 0, 0);
                                    enemyScript.direction = 4;
                                }
                            }
                            else//NS
                            {
                                a = Random.Range(1, 3);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(0, 0, 1);
                                    enemyScript.direction = 1;
                                }
                                else
                                {
                                    pos = pos + new Vector3(0, 0, -1);
                                    enemyScript.direction = 3;
                                }
                            }
                        }
                        else//south not free
                        {
                            if (westFree)//NW
                            {
                                a = Random.Range(1, 3);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(0, 0, 1);
                                    enemyScript.direction = 1;
                                }
                                else
                                {
                                    pos = pos + new Vector3(-1, 0, 0);
                                    enemyScript.direction = 4;
                                }
                            }
                            else//N
                            {
                                pos = pos + new Vector3(0, 0, 1);
                                enemyScript.direction = 1;
                            }
                        }
                    }
                }
                else//north not free
                {
                    if (eastFree)
                    {
                        if (southFree)
                        {
                            if (westFree)//ESW
                            {
                                a = Random.Range(1, 4);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(1, 0, 0);
                                    enemyScript.direction = 2;
                                }
                                else if (a == 2)
                                {
                                    pos = pos + new Vector3(0, 0, -1);
                                    enemyScript.direction = 3;
                                }
                                else
                                {
                                    pos = pos + new Vector3(-1, 0, 0);
                                    enemyScript.direction = 4;
                                }
                            }
                            else//ES
                            {
                                a = Random.Range(1, 3);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(1, 0, 0);
                                    enemyScript.direction = 2;
                                }
                                else
                                {
                                    pos = pos + new Vector3(0, 0, -1);
                                    enemyScript.direction = 3;
                                }
                            }
                        }
                        else//south not free
                        {
                            if (westFree)//EW
                            {
                                a = Random.Range(1, 3);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(1, 0, 0);
                                    enemyScript.direction = 2;
                                }
                                else
                                {
                                    pos = pos + new Vector3(-1, 0, 0);
                                    enemyScript.direction = 4;
                                }
                            }
                            else//E
                            {
                                pos = pos + new Vector3(1, 0, 0);
                                enemyScript.direction = 2;
                            }
                        }
                    }
                    else//east not free
                    {
                        if (southFree)
                        {
                            if (westFree)//SW
                            {
                                a = Random.Range(1, 3);
                                //Debug.Log(a);
                                if (a == 1)
                                {
                                    pos = pos + new Vector3(0, 0, -1);
                                    enemyScript.direction = 3;
                                }
                                else
                                {
                                    pos = pos + new Vector3(-1, 0, 0);
                                    enemyScript.direction = 4;
                                }
                            }
                            else//S
                            {
                                pos = pos + new Vector3(0, 0, -1);
                                enemyScript.direction = 3;
                            }
                        }
                        else//south not free
                        {
                            if (westFree)//W
                            {
                                pos = pos + new Vector3(-1, 0, 0);
                                enemyScript.direction = 4;
                            }
                            //else nothing, this means there are no applicipal spaces available

                        }
                    }
                }
                standing = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 2);
        }
        if (transform.position == pos)
            standing = true;
    }
}
