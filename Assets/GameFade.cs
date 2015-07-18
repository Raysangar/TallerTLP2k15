using UnityEngine;
using System.Collections;

public class GameFade : MonoBehaviour {
    private bool fading;
    private bool fadingOut;
    private float fadingTime;
    private CanvasGroup fade;

	// Use this for initialization
	void Start () {
        fade = GetComponent<CanvasGroup>();
        fading = false;
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
}
