using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundState : MonoBehaviour
{
    public ParabolicMovement parab;
    public Transform end;
    public Transform start;
    public Transform rebound;
    public StateMachineBall machine;

    private void Update()
    {
        parab.MovimientoParab(start.position, end.position);
    }
    private void OnEnable()
    {
        start.position = rebound.position;
        var x = Random.Range(2.652f, 4.856f);
        var y = Random.Range(4.207189f, 5.228f);
        end.position = new Vector2(x, y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && collision.GetComponent<PlayerController>().defending == true)
        {
            machine.ActivateState(machine.defenseState);
        }
    }
}
