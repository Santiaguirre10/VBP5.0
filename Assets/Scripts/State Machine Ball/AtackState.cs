using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackState : MonoBehaviour
{
    public ParabolicMovement parab;
    public Transform end;
    public Transform start;
    public PuppyManager puppymanager;
    public StateMachineBall machine;
    public float speed;

    void Update()
    {
        end.position = puppymanager.objball;
        transform.position = Vector2.MoveTowards(transform.position, end.position, speed * Time.deltaTime );
        if (transform.position == end.position)
        {
            machine.ActivateState(machine.hitState);
        }
    }
    private void OnEnable()
    {
        start.position = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puppy"))
        {
            machine.ActivateState(machine.hitState);
        }
    }
}
