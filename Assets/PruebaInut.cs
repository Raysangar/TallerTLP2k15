using UnityEngine;
using System.Collections;

public class PruebaInut : MonoBehaviour {
    public LevelManager levelManager;
    public ScoreController scoreController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.A))
            levelManager.playerDied();
        if (Input.GetKeyDown(KeyCode.S))
            scoreController.addScore(1);
	}
}
