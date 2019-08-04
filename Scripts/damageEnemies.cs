//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEnemies : MonoBehaviour {

    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<health>() != null)
        {
            //Debug.Log(other.name);
            health enemyScript = other.GetComponent<health>();
            if (other.name != "Paladin(Clone)")
            {
                if (!(enemyScript.invincibilityFrames > 0))
                {
                    enemyScript.HP -= damage;
                    enemyScript.invincibilityFrames = .75f;
                }
            }
            if (GetComponent<projectile>() != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
