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

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, end.position, 2 * Time.deltaTime);
        if (transform.position == end.position)
        {
            
        }
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
