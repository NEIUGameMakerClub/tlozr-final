//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {


    public int health;
    public int maxhealth = 3;
    public float invincibilityFrames = 0;

    public int itemSelected = 0;

	public bool paused = false;
	public bool movement = true;
	float xMovement;
	float zMovement;
	public float playerspeed = 7.0f;
	public int direction = 3;
	public float attackTime;
    public bool falconry = false;
    public bool canFalcon = true;
    public bool grappeling = false;

    public bool northFree = true;
    public bool eastFree = true;
    public bool southFree = true;
    public bool westFree = true;

    public Vector3 pos;

    public int knockbackDirection;
    public int moveSpaces;
    public bool standing = true;

    public int xScreen;
    public int yScreen;
    public bool newScreen = false;

    public GameObject currentScreen;
    GameObject prefab1;//sword
    GameObject prefab2;//current item

	void Start () 
	{
        health = maxhealth;
        xScreen = 1;
        yScreen = 1;
        currentScreen = GameObject.Find("1,1");
        prefab1 = Resources.Load ("spear") as GameObject;
	}

	// Update is called once per frame
	void Update () {
		bool rightHeld = Input.GetButton ("right");
		bool leftHeld = Input.GetButton ("left");
		bool upHeld = Input.GetButton ("up");
		bool downHeld = Input.GetButton ("down");
		bool z = Input.GetButtonDown ("z");
        bool x = Input.GetButtonDown("x");

        if (health <= 0)
            Debug.Log("Game Over");
        if (invincibilityFrames > 0)
            invincibilityFrames -= Time.deltaTime;

        if (paused == false)
        {
            if (!grappeling)
            {
                if (standing)
                {
                    if (movement)
                    {

                        if (z)//attacking
                        {
                            movement = false;
                            attackTime = .25f;
                            GameObject spear = Instantiate(prefab1) as GameObject;
                            spear.transform.position = transform.position + new Vector3(0, -.5f, 0); // try to add the directional bit /*+ Camera.main.transform.forward * 2*/;
                        }

                        if (x)//using item
                        {
                            movement = false;
                            attackTime = .25f;
                            useItem();
                        }


                        if ((upHeld || downHeld) && transform.position.x % .5f != 0)
                        {
                            pos = transform.position;
                            if (transform.position.x % .5f <= .25)//round down
                                pos = pos - new Vector3((transform.position.x % .5f), 0, 0);
                            else// if (transform.position.x % .5f > .25)//round up
                                pos = pos + new Vector3((.5f - transform.position.x % .5f), 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * playerspeed);
                        }

                        if ((rightHeld || leftHeld) && transform.position.z % .5 != 0 && !(upHeld || downHeld))
                        {
                            pos = transform.position;
                            if (transform.position.z % .5f <= .25)//round down
                                pos = pos - new Vector3(0, 0, (transform.position.z % .5f));
                            else// if (transform.position.z % .5f > .25)//round up
                                pos = pos + new Vector3(0, 0, (.5f - transform.position.z % .5f));
                            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * playerspeed);
                        }

                        if (upHeld && !downHeld && northFree && transform.position.x % .5f == 0)
                        {
                            zMovement = 1.0f;
                            direction = 1;
                        }
                        else if (downHeld && !upHeld && southFree && transform.position.x % .5f == 0)
                        {
                            zMovement = -1.0f;
                            direction = 3;
                        }
                        else
                            zMovement = 0.0f;

                        if (rightHeld && !upHeld && !downHeld && !leftHeld && eastFree && transform.position.z % .5 == 0)
                        {
                            xMovement = 1.0f;
                            direction = 2;
                        }
                        else if (leftHeld && !upHeld && !downHeld && !rightHeld && westFree && transform.position.z % .5 == 0)
                        {
                            xMovement = -1.0f;
                            direction = 4;
                        }
                        else
                            xMovement = 0.0f;


                        if (upHeld && !downHeld)
                            direction = 1;
                        else if (downHeld && !upHeld)
                            direction = 3;
                        else if (rightHeld && !upHeld && !downHeld && !leftHeld)
                            direction = 2;
                        else if (leftHeld && !upHeld && !downHeld && !rightHeld)
                            direction = 4;

                    }
                    else
                    {//currently attacking
                        xMovement = 0.0f;
                        zMovement = 0.0f;
                        if (!falconry)
                            attackTime = attackTime - Time.deltaTime;
                        if (attackTime < 0)
                            movement = true;
                    }

                    Vector3 speed = new Vector3(xMovement * playerspeed, 0, zMovement * playerspeed);
                    transform.Translate(speed * Time.deltaTime);
                }

                //knockback code knockback code knockback code knockback code knockback code knockback code knockback code knockback code 

                if (moveSpaces > 0 && standing)//need to move
                {
                    standing = false;
                    if (knockbackDirection == 1)
                    {
                        if (northFree)
                        {
                            pos = pos + new Vector3(0, 0, .25f);
                        }
                    }
                    else if (knockbackDirection == 2)
                    {
                        if (eastFree)
                        {
                            pos = pos + new Vector3(.25f, 0, 0);
                        }
                    }
                    else if (knockbackDirection == 3)
                    {
                        if (southFree)
                        {
                            pos = pos + new Vector3(0, 0, -.25f);
                        }
                    }
                    else if (knockbackDirection == 4)
                    {
                        if (westFree)
                        {
                            pos = pos + new Vector3(-.25f, 0, 0);
                        }
                    }
                    //Debug.Log(pos);
                    moveSpaces -= 1;
                }
            }


            if (moveSpaces > 0 || !standing || grappeling)
                transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 15);
            if (transform.position == pos)
            {
                standing = true;
                grappeling = false;
            }

            //changing screen changing screen changing screen changing screen changing screen changing screen changing screen changing screen 
            if (newScreen)
            {
                if (xScreen == 1)
                {
                    if (yScreen == 1)
                        currentScreen = GameObject.Find("1,1");
                    if (yScreen == 2)
                        currentScreen = GameObject.Find("1,2");
                    if (yScreen == 3)
                        currentScreen = GameObject.Find("1,3");
                }
                else if (xScreen == 2)
                {
                    if (yScreen == 1)
                        currentScreen = GameObject.Find("2,1");
                    if (yScreen == 2)
                        currentScreen = GameObject.Find("2,2");
                    if (yScreen == 3)
                        currentScreen = GameObject.Find("2,3");
                }
                else if (xScreen == 3)
                {
                    if (yScreen == 1)
                        currentScreen = GameObject.Find("3,1");
                    if (yScreen == 2)
                        currentScreen = GameObject.Find("3,2");
                    if (yScreen == 3)
                        currentScreen = GameObject.Find("3,3");
                }

                spawnEnemiesInRoom levelScript = currentScreen.GetComponent<spawnEnemiesInRoom>();
                if (!levelScript.roomFinnished)
                    levelScript.Spawn();
                newScreen = false;

                canFalcon = true;
            }
        }
	}


    //using items using items using items using items using items using items using items using items using items using items using items 
    void useItem()
    {
        if (itemSelected < 4)
        {
            if (itemSelected < 2)
            {
                if (itemSelected == 0)
                {//throwing knives
                    prefab2 = Resources.Load("throwingKnife") as GameObject;

                }
                else if (itemSelected == 1)
                {//bombs
                    prefab2 = Resources.Load("bomb") as GameObject;
                }
            }
            else//itemSelected >=2 && <4
            {
                if (itemSelected == 2)
                {
                    prefab2 = Resources.Load("torch") as GameObject;
                }
                else if (itemSelected == 3)
                {
                    prefab2 = Resources.Load("falcon") as GameObject;
                    if (canFalcon)
                        falconry = true;
                }
            }
        }
        else//itemSelected >= 4
        {
            if (itemSelected < 6)
            {
                if (itemSelected == 4)
                {
                    prefab2 = Resources.Load("grappelingHook") as GameObject;
                }
                else if (itemSelected == 5)
                {
                    prefab2 = Resources.Load("throwingKnife") as GameObject;
                }
            }
            else//itemSelected >=6 && <8
            {
                if (itemSelected == 6)
                {
                    prefab2 = Resources.Load("throwingKnife") as GameObject;
                }
                else if (itemSelected == 7)
                {
                    prefab2 = Resources.Load("throwingKnife") as GameObject;
                }
            }
        }

        if (itemSelected != 3)//all items aside from the falcon
        {
            GameObject item = Instantiate(prefab2) as GameObject;

            if (itemSelected == 0 || itemSelected == 4/* || other projectile item*/)
            {
                if (itemSelected == 0)
                    item.transform.position = transform.position + new Vector3(0, -.1f, 0);
                else if (itemSelected == 4)
                    item.transform.position = transform.position + new Vector3(0, 0, 0);
                projectile projectileScript = item.GetComponent<projectile>();
                projectileScript.direction = direction;
            }
            else if (itemSelected == 1 || itemSelected == 2)//bomb or torch
            {
                if (direction % 2 == 0)//horizontal
                {
                    if (direction == 2)
                    {
                        item.transform.position = transform.position + new Vector3(1, -.1f, 0);
                    }
                    else//if (direction == 4)
                    {
                        item.transform.position = transform.position + new Vector3(-1, -.1f, 0);
                    }
                }
                else//vertical
                {
                    if (direction == 1)
                    {
                        item.transform.position = transform.position + new Vector3(0, -.1f, 1);
                    }
                    else//if (direction == 3)
                    {
                        item.transform.position = transform.position + new Vector3(0, -.1f, -1);
                    }
                }
            }
        }
        else if (itemSelected == 3 && canFalcon)//falcon
        {
            GameObject item = Instantiate(prefab2) as GameObject;

            canFalcon = false;
            if (direction % 2 == 0)//horizontal
            {
                if (direction == 2)
                {
                    item.transform.position = transform.position + new Vector3(1, .1f, 0);
                    item.GetComponent<falconMovement>().direction = 2;

                }
                else//if (direction == 4)
                {
                    item.transform.position = transform.position + new Vector3(-1, .1f, 0);
                    item.GetComponent<falconMovement>().direction = 4;
                }
            }
            else//vertical
            {
                if (direction == 1)
                {
                    item.transform.position = transform.position + new Vector3(0, .1f, 1);
                    item.GetComponent<falconMovement>().direction = 1;
                }
                else//if (direction == 3)
                {
                    item.transform.position = transform.position + new Vector3(0, .1f, -1);
                    item.GetComponent<falconMovement>().direction = 3;
                }
            }
        }

        //throwing knives
        //bombs
        //torch             //purchase          //blue torch    //6ish
        //falcon            //2ish              //energy falcon //7ish
        //grappeling hook   //3ish
        //magic bow         //4ish
        //cleric tome       //5ish
        //jar               //questing
        //ghost tome        //8?
        //Debug.Log("GOT ITEM");
    }

/*
things i still need to implement

    enemy knockback
    i feel like the player knockback is a bit off
    make some sort of code to change the items easily
    the grappel code needs to stop if it hits an impassible wall (of which i havent bothered to code in yet)
    also, grappeling acrossed walls tends to make that one screen moving glitch happen more than it should
    rest of the items

*/
}