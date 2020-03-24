using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseiAnimation : MonoBehaviour
{
    public Animator sensei;
    // Start is called before the first frame update
    void Start()
    {
        sensei.SetTrigger("Set");
    }

    // Update is called once per frame
    void Update()
    {
        sensei.SetTrigger("Smoking");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball" && collision.GetComponent<DefenseState>().enabled == true)
        {
            sensei.SetTrigger("Set");
        }
        else
        {
            sensei.SetTrigger("Smoking");
        }
    }
}
