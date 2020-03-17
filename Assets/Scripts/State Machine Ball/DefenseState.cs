using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseState : MonoBehaviour
{
    public ParabolicMovement parab;
    public Transform end;
    public Transform start;
    public Transform setpoint;
    public StateMachineBall machine;

    private void Update()
    {
        parab.MovimientoParab(start.position, end.position);
    }
    private void OnEnable()
    {
        start.position = transform.position;
        end.position = setpoint.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "SetPoint" && gameObject.GetComponent<DefenseState>().enabled == true)
        {
            machine.ActivateState(machine.setState);
        }
    }
}
