﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : MonoBehaviour
{
    public float speed;
    GameObject gameover;
    StateMachinePuppy machine;

    private void Awake()
    {
        gameover = GameObject.Find("GameOver");
        machine = GetComponent<StateMachinePuppy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, gameover.transform.position, speed * Time.deltaTime );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            machine.ActivateState(machine.kickedState);
        }
    }
}
