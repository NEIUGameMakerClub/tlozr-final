//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunEnemy : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<health>() != null)//this is an enemy
        {
            if (other.name != "Paladin(Clone)")
            Debug.Log(other.name);
            other.GetComponent<health>().stunned = 2f;
            Destroy(gameObject);
        }
    }
}
