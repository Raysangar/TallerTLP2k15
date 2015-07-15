using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

    public Text textScore;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}

    public void addScore(int score)
    {
        this.score += score;
        textScore.text = this.score.ToString();
    }
}
