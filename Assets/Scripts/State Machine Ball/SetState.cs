using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetState : MonoBehaviour
{
    public ParabolicMovement parab;
    public Transform end;
    public Transform start;
    public Transform setpoint;
    public GameObject player;

    private void Update()
    {
        parab.MovimientoParab(start.position, end.position);
    }
    private void OnEnable()
    {
        start.position = setpoint.position;
        if (player.transform.position.x <= 3f)
        {
            end.position = player.transform.position + new Vector3(1f, 1f);
        }
        if (player.transform.position.x > 3f)
        {
            end.position = new Vector2(4.5f, player.transform.position.y + 1f);
        }
    }
}
