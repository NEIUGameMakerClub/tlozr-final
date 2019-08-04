//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toAndFro : MonoBehaviour {
    public bool movingRight;
    public bool wallOnRight = false;
    public bool wallOnLeft = false;
    public float speed = 2f;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        if (Random.Range(1, 3) > 1)
            movingRight = true;
        else
            movingRight = false;
    }

    void Update()
    {
        health enemyScript = GetComponent<health>();
        if (enemyScript.stunned <= 0)
        {
            if (movingRight && wallOnRight)
            {
                pos = transform.position;
                movingRight = false;
            }
            if (!movingRight && wallOnLeft)
            {
                pos = transform.position;
                movingRight = true;
            }

            if (movingRight)
                pos = pos + new Vector3(1, 0, 0);
            else
                pos = pos + new Vector3(-1, 0, 0);

            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }
    }
}
