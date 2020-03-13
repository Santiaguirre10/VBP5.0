using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundState : MonoBehaviour
{
    public ParabolicMovement parab;
    public Transform end;
    public Transform start;
    public Transform rebound;
    private void Update()
    {
        parab.MovimientoParab(start.position, end.position);
    }
    private void OnEnable()
    {
        start.position = rebound.position;
        var x = Random.Range(-1.31f, 4.97f);
        var y = Random.Range(1.8f, 5.6f);
        end.position = new Vector2(x, y); 
    }
}
