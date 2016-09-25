using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallsManager : MonoBehaviour {

    public Text text;
    public int balls;
    void Awake()
    {
        text = GetComponent<Text>();
        balls = 10;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Balls: " + balls;
    }
}
