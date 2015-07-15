using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {
    public CanvasGroup fade;

    private bool fading = false;
    private float time = 0;

    public void startGame()
    {
        fading = true;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (fading)
        {
            time += Time.deltaTime;
            fade.alpha = time/1.5f;
            if (time >= 1.5)
                Application.LoadLevel("Game");
        }
	}
}
