using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseState : MonoBehaviour
{
    public ParabolicMovement parab;
    public Transform end;
    public Transform start;
    public Transform setpoint;
    private void Update()
    {
        parab.MovimientoParab(start.position, end.position);
    }
    private void OnEnable()
    {
        start.position = transform.position;
        end.position = setpoint.position;
    }
}
