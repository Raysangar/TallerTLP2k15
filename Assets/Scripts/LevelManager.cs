using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject respawnTarget;
    public Text guiLives;
    public int lives;
    public CanvasGroup fade;
    public GameObject gameOverText;

    private bool fading;
    private bool fadingOut;
    private float fadingTime;

    private GameObject player;
	// Use this for initialization
	void Start () {
        guiLives.text = lives.ToString();
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnTarget.transform.position;
        fading = true;
        fadingOut = false;
        fadingTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (fading)
        {
            fadingTime += Time.deltaTime;
            fade.alpha = fadingOut ? fadingTime / 1f : 1 - fadingTime / 1f;
            if (fadingTime >= 1)
            {
                fading = false;
                if (fadingOut)
                    StartCoroutine("GameOver");
            }
                
        }
	}

    public void playerDied()
    {
        guiLives.text = (--lives).ToString();
        if (lives == 0)
        {
            fading = true;
            fadingOut = true;
        }
        else
            player.transform.position = respawnTarget.transform.position;
    }

    private IEnumerator GameOver()
    {
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(2);
        Application.LoadLevel("menu");
    }
}
