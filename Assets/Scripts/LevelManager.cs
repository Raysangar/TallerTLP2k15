using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject respawnTarget;
    public Text guiLives;
    public int lives;
    public CanvasGroup fadeOut;

    private GameObject player;
	// Use this for initialization
	void Start () {
        guiLives.text = lives.ToString();
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnTarget.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playerDied()
    {
        guiLives.text = (--lives).ToString();
        if (lives == 0)
            StartCoroutine("GameOver");
        else
            player.transform.position = respawnTarget.transform.position;
    }

    private IEnumerator GameOver()
    {
        fadeOut.alpha = 1;
        yield return new WaitForSeconds(2);
        Application.LoadLevel("menu");
    }
}
