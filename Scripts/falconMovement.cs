//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falconMovement : MonoBehaviour {

    GameObject Player;

    float movementSpeed = 10f;
    
    float xMovement;
    float zMovement;
    public int direction;
    Vector3 pos;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {

        bool rightHeld = Input.GetButton("right");
        bool leftHeld = Input.GetButton("left");
        bool upHeld = Input.GetButton("up");
        bool downHeld = Input.GetButton("down");

        move playerScript = Player.GetComponent<move>();
        if (playerScript.falconry == true)//this will have the falcon moving continuously until it despawns
        {
            if (playerScript.movement == false)
            {
                if (upHeld && !downHeld/* && !rightHeld && !leftHeld*/)
                {
                    direction = 1;
                }
                else if (downHeld && !upHeld/* && !rightHeld && !leftHeld*/)
                {
                    direction = 3;
                }
                else if (rightHeld && !upHeld && !downHeld && !leftHeld)
                {
                    direction = 2;
                }
                else if (leftHeld && !upHeld && !downHeld && !rightHeld)
                {
                    direction = 4;
                }
            }

                if (direction == 1 || direction == 3)
                    xMovement = 0;
                if (direction == 2 || direction == 4)
                    zMovement = 0;

                if (direction == 1)
                    zMovement = 1.0f;
                else if (direction == 2)
                    xMovement = 1.0f;
                else if (direction == 3)
                    zMovement = -1.0f;
                else if (direction == 4)
                    xMovement = -1.0f;

                Vector3 speed = new Vector3(xMovement * movementSpeed, 0, zMovement * movementSpeed);
                transform.Translate(speed * Time.deltaTime);
        }
        else//this should only happen during glitches
        {
            Destroy(gameObject);
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);

        if (other.GetComponent<move>() != null)
        {
            move playerScript = other.GetComponent<move>();
            playerScript.canFalcon = true;
            endFalcon();
        }
        /*
         *  else if (other.GetComponent<pickUp>() != null)//this is a pickup
         *  {
         *  
         *  if (this actually works)
         *  other.GetComponent<pickUp>().collect();
         *  
         *   pickUp itemScript = other.GetComponent<pickUp>();
         *   itemScript.collect();
         *  } 
        */
        else if (other.GetComponent<health>() != null)//this is an enemy
        {
            health enemyScript = other.GetComponent<health>();
            if (other.name != "Paladin(Clone)")
            {
                if (enemyScript.invincibilityFrames <= 0)
                {
                    enemyScript.HP -= 1;
                    enemyScript.invincibilityFrames = .75f;
                }
            }
            endFalcon();
        }
        else if (other.name == "MovementWallNorth" || other.name == "MovementWallEast" || other.name == "MovementWallSouth" || other.name == "MovementWallWest")

            endFalcon();
    }

    public void endFalcon() {
        move playerScript = Player.GetComponent<move>();
        playerScript.falconry = false;
        Destroy(gameObject);
    }
}
