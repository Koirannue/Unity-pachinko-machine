using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public Text text;
    public int high;
    public int score;
    public int balls;
    public int maxballs;
	void Awake () {
        text = GetComponent<Text>();
        score = 0;
        balls = maxballs;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Highscore: " + high + "\nScore: " + score + "\r\nBalls left: " + ((balls >= 0) ? balls : 0);
	}
}
