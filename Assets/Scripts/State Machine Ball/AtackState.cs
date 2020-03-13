using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackState : MonoBehaviour
{
    public LinearMovement linear;
    public Transform end;
    public Transform start;
    public PuppyManager puppymanager;
    void Update()
    {
        linear.MovimientoRecto(start.position, end.position);
    }
    private void OnEnable()
    {
        start.position = transform.position;
        end.position = puppymanager.objball;
    }
}
