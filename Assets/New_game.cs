using UnityEngine;
using System.Collections;

public class New_game : MonoBehaviour {

    public int spacing;
    public GameObject[] Pegs;
    private int nPegs = 0;
    public bool reset = true;
    public bool newgame = true;
    private int Pegged = 0;
	void Start () {
        while (true)
        {
            if (GameObject.Find("Peg") != null)
            {
                nPegs++;
                GameObject.Find("Peg").name = "Peg"+(nPegs-1);
            }
            else
            {
                break;
            }
        }
        Pegs = new GameObject[nPegs];
        for (int i = 0; i < nPegs; i++)
        {
            Pegs[i] = GameObject.Find("Peg" + i);
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        if (newgame)
        {
            float randX = Random.Range(-8.0f, 8.0f);
            float randY = 13.0f;
            bool overlap = true;
            if (Pegged > 0)
            {
                while (overlap)
                {
                    for (int j = 0; j < Pegged; j++)
                    {
                        if (Mathf.Sqrt(
                                        Mathf.Pow(Pegs[j].transform.position.x - randX, 2)
                                      + Mathf.Pow(Pegs[j].transform.position.y - randY, 2)
                                      ) < spacing) //Distance between two pegs are less than spacing
                        {
                            randY = randY + 0.1f;
                            if (randY > 42)
                            {
                                randY = 13.0f;
                                randX = Random.Range(-8.0f, 8.0f);
                            }
                            break;
                        }
                        if (j == Pegged - 1)
                        {
                            overlap = false;
                        }
                    }
                }
            }
            Pegs[Pegged].transform.position = new Vector3(randX, randY, 0);
            Pegged++;
            if (Pegged >= Pegs.Length)
            {
                newgame = false;
            }
        }
        if (reset)
        {
            for (int i = 0; i < nPegs; i++)
            {
                Pegs[i].transform.position = new Vector3(0, -10, 0);
            }
            newgame = true;
            reset = false;
            Pegged = 0;
        }
	}
}
