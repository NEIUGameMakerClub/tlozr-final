//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

    public GameObject Player;
    Vector3 pos;
    public int movingDirection = 0; // 0 means it isn't moving

    private void Start()
    {
        Player = GameObject.Find("Player");
        pos = transform.position;
    }

    void Update()
    {
        move playerScript = Player.GetComponent<move>();

        if (movingDirection == 1)
        {
            playerScript.paused = true;
            playerScript.newScreen = true;
            playerScript.yScreen++;
            playerScript.moveSpaces = 0;
            pos = pos + new Vector3(0, 0, (11));
        }

        if (movingDirection == 2)
        {
            playerScript.paused = true;
            playerScript.newScreen = true;
            playerScript.xScreen++;
            playerScript.moveSpaces = 0;
            pos = pos + new Vector3((16), 0, 0);
        }

        if (movingDirection == 3)
        {
            playerScript.paused = true;
            playerScript.newScreen = true;
            playerScript.yScreen--;
            playerScript.moveSpaces = 0;
            pos = pos + new Vector3(0, 0, (-11));
        }

        if (movingDirection == 4)
        {
            playerScript.paused = true;
            playerScript.newScreen = true;
            playerScript.xScreen--;
            playerScript.moveSpaces = 0;
            pos = pos + new Vector3((-16), 0, 0);
        }

        if (transform.position == pos)
        {   
            playerScript.paused = false;

        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 15);
    }
}
