//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicalAttack : MonoBehaviour {

	public float attackDuration = .25f;
	public int damage = 1;

    public Vector3 pos;
    public GameObject Player;

    

    private void Start()
    {
        pos = transform.position;
        Player = GameObject.Find("Player");


        move playerScript = Player.GetComponent<move>();
        if (playerScript.direction == 1)
            pos = pos + new Vector3(0, 0, 1);
        else if (playerScript.direction == 2)
            pos = pos + new Vector3(1, 0, 0);
        else if (playerScript.direction == 3)
            pos = pos + new Vector3(0, 0, -1);
        else if (playerScript.direction == 4)
            pos = pos + new Vector3(-1, 0, 0);
    }


    void Update () {


        
        attackDuration = attackDuration - Time.deltaTime;
		if (attackDuration < 0)
			Destroy (gameObject);
        
        

        if (transform.position != pos)
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 15);

    }

	void OnTriggerStay (Collider other)
	{
		GameObject target = other.gameObject;
        move playerScript = Player.GetComponent<move>();
		health enemyScript = target.GetComponent<health>();
        bomb itemScript = target.GetComponent<bomb>();

        if (enemyScript != null)
        {
            if (other.name != "Paladin(Clone)")
            {
                if (!(enemyScript.invincibilityFrames > 0))
                {
                    enemyScript.HP -= damage;
                    enemyScript.invincibilityFrames = .75f;
                }
            }
            else
            {//fighting a paladin

                //Debug.Log("player " + playerScript.direction + ", paladin " + enemyScript.direction + " health remaining " + enemyScript.HP);
                if ((playerScript.direction + 2) % 4 != enemyScript.direction % 4)
                {
                    if (!(enemyScript.invincibilityFrames > 0))
                    {
                        enemyScript.HP -= damage;
                        enemyScript.invincibilityFrames = .75f;
                    }
                }
                //else
                //Debug.Log("shield block");
            }
        }
        else if (itemScript != null)//hitting a bomb
        {
            itemScript.direction = playerScript.direction;
            //itemScript.standing = false;
            itemScript.moveSpaces = 2;
        }
	}
}
