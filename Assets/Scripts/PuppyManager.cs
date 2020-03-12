using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyManager : MonoBehaviour
{
    public GameObject puppy1;
    public GameObject[] puppyspamer;
    public GameObject puppyspamer1;
    public GameObject puppyspamer2;
    public GameObject puppyspamer3;
    public List<GameObject> puppys;
    public List<float> distances;
    public float mindistance;
    public GameObject valla;
    public Vector2 objball;

    // Start is called before the first frame update
    void Awake()
    {
        puppyspamer1 = GameObject.Find("PuppySpammer");
        puppyspamer2 = GameObject.Find("PuppySpammer (1)");
        puppyspamer3 = GameObject.Find("PuppySpammer (2)");
        puppyspamer[0] = puppyspamer1;
        puppyspamer[1] = puppyspamer2;
        puppyspamer[2] = puppyspamer3;
    }
    void Start()
    {
        InvokeRepeating("PuppyCreator", 3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCalculator();
    }
    void PuppyCreator()
    {
        int rdm = Random.Range(0 , 3);
        Instantiate(puppy1, puppyspamer[rdm].transform.position , Quaternion.identity);
    }
    void DistanceCalculator()
    {
        for (int i = 0; i < puppys.Count; i++)
        {
            distances[i] = puppys[i].transform.position.x;
        }
        for (int i = 0; i < distances.Count; i++)
        {
            if (mindistance > distances[i])
            {
                mindistance = distances[i];
            }
        }
        for (int i = 0; i < puppys.Count; i++)
        {
            if (mindistance == puppys[i].transform.position.x)
            {
                objball = new Vector2(puppys[i].transform.position.x, puppys[i].transform.position.y);
            }
        }
    }
}
