//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {

    public float fuse = 2;

    public bool northFree = true;
    public bool eastFree = true;
    public bool southFree = true;
    public bool westFree = true;
    public int direction = 0;
    public int moveSpaces;
    bool standing = true;

    GameObject explosion; 
    Vector3 pos;
    private void Start()
    {
        explosion = Resources.Load("explosion") as GameObject;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update () {

        if (direction != 0 && (standing))
        {
            if (moveSpaces > 0)
            {
                if (direction == 1)
                {
                    if (northFree)
                    {
                        pos = pos + new Vector3(0, 0, 1);
                    }
                    direction = 0;
                }
                else if (direction == 2)
                {
                    if (eastFree)
                    {
                        pos = pos + new Vector3(1, 0, 0);
                    }
                    direction = 0;
                }
                else if (direction == 3)
                {
                    if (southFree)
                    {
                        pos = pos + new Vector3(0, 0, -1);
                    }
                    direction = 0;
                }
                else //direction == 4
                {
                    if (westFree)
                    {
                        pos = pos + new Vector3(-1, 0, 0);
                    }
                    direction = 0;
                }
                moveSpaces -= 1;
            }
            standing = false;
        }

        if (transform.position == pos)
            standing = true;

        //Debug.Log(pos);
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 15);

        if (fuse < 0)
        {
            explode();
        }
        fuse -= Time.deltaTime;
	}

    void explode()
    {
        GameObject item = Instantiate(explosion) as GameObject;
        item.transform.position = transform.position + new Vector3(0, .2f, 0); ;

        Destroy(gameObject);
    }
}
