//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour {

    public int damage;

    int knockbackDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            move playerScript = other.GetComponent<move>();
            if (playerScript.invincibilityFrames <= 0)
            {
                playerScript.health -= damage;
                playerScript.invincibilityFrames = 1f;
                if (playerScript.falconry)
                    playerScript.movement = true;



                //knockback code knockback code knockback code knockback code knockback code knockback code 
                projectile isProjectile = gameObject.GetComponent<projectile>();
                if (isProjectile != null)
                {
                    
                    playerScript.pos = playerScript.transform.position;
                    playerScript.knockbackDirection = isProjectile.direction;
                    playerScript.moveSpaces = 6;
                }
                else//not a projectile
                {
                    //Debug.Log("testing");
                    if (Mathf.Abs(other.transform.position.x - gameObject.transform.position.x) > Mathf.Abs(other.transform.position.z - gameObject.transform.position.z))
                    {//on the side
                        playerScript.pos = playerScript.transform.position;
                        if (other.transform.position.x > gameObject.transform.position.x)
                            playerScript.knockbackDirection = 2;
                        else
                            playerScript.knockbackDirection = 4;
                        playerScript.moveSpaces = 6;
                    }
                    else
                    {//above or below
                        playerScript.pos = playerScript.transform.position;
                        if (other.transform.position.z > gameObject.transform.position.z)
                            playerScript.knockbackDirection = 1;
                        else
                            playerScript.knockbackDirection = 3;
                        playerScript.moveSpaces = 6;
                    }
                }
            }
            if (GetComponent<projectile>() != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
