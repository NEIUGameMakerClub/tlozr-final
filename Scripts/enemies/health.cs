//geoff's code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

	public int HP;
    public float invincibilityFrames;
    public int direction;

    int xScreen;
    int yScreen;

    public float stunned;

    public GameObject Player;
    public GameObject Room;
    
    private void Start()
    {
        Player = GameObject.Find("Player");

        move playerScript = Player.GetComponent<move>();
        xScreen = playerScript.xScreen;
        yScreen = playerScript.yScreen;
        Room = playerScript.currentScreen;
        //Debug.Log(xScreen + " " + yScreen);
    }

    
    void Update () {

        if (stunned > 0)
            stunned -= Time.deltaTime;

        move playerScript = Player.GetComponent<move>();
        spawnEnemiesInRoom levelScript = Room.GetComponent<spawnEnemiesInRoom>();

        if (invincibilityFrames > 0)
            invincibilityFrames -= Time.deltaTime;

        if (HP <= 0) {
            if (levelScript.enemiesLeft == 1)
                levelScript.roomFinnished = true;
            //there is more then 1 enemy left.
            levelScript.enemiesLeft--;
            Destroy (gameObject);
		}

        if ((playerScript.xScreen != xScreen || playerScript.yScreen != yScreen) && (xScreen != 0 && yScreen != 0))
        {
            levelScript.enemiesLeft--;
            Destroy(gameObject);
        }
	}
}
