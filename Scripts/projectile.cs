//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public int direction;
    public int speed = 5;
    public int duration = 5;
    public bool arrived = true;

    bool hitWall = false;

    Vector3 pos;

	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (arrived)
        {
            if (direction == 1)
                pos = pos + new Vector3(0, 0, 1);
            else if (direction == 2)
                pos = pos + new Vector3(1, 0, 0);
            else if (direction == 3)
                pos = pos + new Vector3(0, 0, -1);
            else if (direction == 4)
                pos = pos + new Vector3(-1, 0, 0);
            duration -= 1;
            arrived = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

        if (duration <= 0)
        {
            if (name != "grappelingHook(Clone)")
                Destroy(gameObject);
            else
            {
                grappel itemScript = GetComponent<grappel>();
                itemScript.jump();
            }
        }

        if (transform.position == pos)
        {
            arrived = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "MovementWallNorth" || other.name == "MovementWallEast" || other.name == "MovementWallSouth" || other.name == "MovementWallWest")
        {
            if (name != "grappelingHook(Clone)")
                Destroy(gameObject);
        }
    }
}
