//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappel : MonoBehaviour {

    GameObject Player;


    bool canJump = true;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<health>() != null)//this is an enemy
        {
            if (other.name != "Paladin(Clone)")
            {
                other.GetComponent<health>().stunned = 2f;
                Destroy(gameObject);
            }
        }
        else if (other.name == "wall")
        {
            canJump = false;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "wall")
        {
            canJump = true;
        }
    }

    public void jump()
    {
        move playerScript = Player.GetComponent<move>();
        
        if (canJump)
        {
            //Debug.Log("can jump");
            //origionalPosition = Player.transform.position;
            playerScript.pos = transform.position;
            playerScript.grappeling = true;
        }

        Destroy(gameObject);
    }
    
}
