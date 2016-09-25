using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Control : MonoBehaviour {
    public GameObject Launcher;
    public float speed;
    private Rigidbody rb;
    public Text Score;
    public Text Gameover;
    public bool gameover = false;
    public AudioSource launch;
    public AudioSource hit;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate()
    {
        if (gameover == false && Mathf.Sqrt(
                       Mathf.Pow(Launcher.transform.position.x - transform.position.x, 2)
                     + Mathf.Pow(Launcher.transform.position.y - transform.position.y, 2)
                      ) < 1.2 && Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector3(0.0f, 2000, 0.0f));
            launch.Play();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        rb.AddForce(movement * speed);
	}
    void OnCollisionEnter(Collision Other)
    {
        if (Other.collider.name != "WallSilent" && Other.collider.name != "launcher" && Other.collider.name != "Plane")
        {
            hit.Play();
        }
    }
    IEnumerator OnCollisionStay(Collision Other)
    {
        if (Other.collider.name != "Wall")
        {
            Debug.Log(Other.collider.name);
        }
        if (Other.collider.name == "Fail" ||
            Other.collider.name == "Okay" ||
            Other.collider.name == "Good" ||
            Other.collider.name == "Great")
        {
            ScoreManager ScoreScript = Score.GetComponent<ScoreManager>();
            if (Other.collider.name == "Okay")
            {
                ScoreScript.score += 50;
            }
            else if (Other.collider.name == "Good")
            {
                ScoreScript.score += 100;
            }
            else if (Other.collider.name == "Great")
            {
                ScoreScript.score += 500;
                ScoreScript.balls += 1;
            }
            transform.position = Launcher.transform.position;
            ScoreScript.balls -= 1;
            if (ScoreScript.balls < 0)
            {
                gameover = true;
                Debug.Log("Game over!");
                Gameover.text = "GAMEOVER";
                yield return new WaitForSecondsRealtime(3);
                Gameover.text = "Final score: " + ScoreScript.score;
                if (ScoreScript.score > ScoreScript.high)
                {
                    yield return new WaitForSecondsRealtime(2);
                    ScoreScript.high = ScoreScript.score;
                    Gameover.text += "\nNew Highscore!";
                    yield return new WaitForSecondsRealtime(2);
                }
                else
                {
                    yield return new WaitForSecondsRealtime(4);
                }
                Gameover.text = "Resetting...";
                yield return new WaitForSecondsRealtime(2);
                Gameover.text = " ";
                New_game gameboard = GameObject.Find("Plane").GetComponent<New_game>();
                gameboard.reset = true;
                ScoreScript.balls = ScoreScript.maxballs;
                ScoreScript.score = 0;
                gameover = false;
            }
        }
    }
}
