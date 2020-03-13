using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : MonoBehaviour
{
    public LinearMovement linear;
    public Transform end;
    public Transform start;
    public Transform rebound;
    void Update()
    {
        linear.MovimientoRecto(start.position, end.position);
    }
    private void OnEnable()
    {
        start.position = transform.position;
        end.position = rebound.position;
    }
}
