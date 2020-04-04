using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : MonoBehaviour
{
    public Transform end;
    public Transform start;
    public Transform rebound;
    public StateMachineBall machine;
    public PlayerController player;
    public float speed;
    HitState hitstate;

    private void Start()
    {
        hitstate = GetComponent<HitState>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, end.position, speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        player.GetComponent<PlayerController>().atacking = false;
        player.GetComponent<PlayerController>().defending = true;
        start.position = transform.position;
        end.position = rebound.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Rebote")
        {
            machine.ActivateState(machine.reboundState);
        }
    }
}
