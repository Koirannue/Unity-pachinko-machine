using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    public GameObject Plane;
    public GameObject ball;
    public int rot_mult;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Plane.GetComponent<New_game>().reset ||
            Plane.GetComponent<New_game>().newgame ||
            ball.GetComponent<Control>().gameover)
        {
            transform.position = new Vector3(0, 23, -40);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(2 * rot_mult * Input.GetAxis("Vertical"), 0, rot_mult * Input.GetAxis("Horizontal"));
            transform.position = ball.transform.position + new Vector3(0, 20 * Mathf.Tan(2 * rot_mult * Input.GetAxis("Vertical") * Mathf.PI/180), -20);
        }
    }
}
