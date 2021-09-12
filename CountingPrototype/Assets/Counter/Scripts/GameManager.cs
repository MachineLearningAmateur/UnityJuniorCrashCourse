using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> bases;
    [SerializeField] Material black;
    private int totalPoints;
    private int check;
    [SerializeField] Text score;
    // Start is called before the first frame update
    void Start()
    {
        List<int> rand = new List<int>(new int[3]);
        for (int i = 0; i < 3; i++)
        {
            check = Random.Range(0, bases.Count);
            while(rand.IndexOf(check) != -1)
            {
                check = Random.Range(0, bases.Count);
                Debug.Log(check);   
            }
            rand[i] = check;
        }
     
        foreach(int i in rand)
        {
            bases[i].GetComponent<MeshRenderer>().material = black;
            bases[i].GetComponent<Counter>().toggle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + totalPoints;
    }

   /* void GetPoints()
    {
        foreach (GameObject b in bases)
        {
            totalPoints += b.GetComponent<Counter>().Points();
        }
    }*/

    public void Add(int point)
    {
        totalPoints += point;
    }
}
