using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneState : MonoBehaviour
{
    public float speed;
    StateMachinePuppy machine;
    ZoneState zonestate;

    private void Awake()
    {
        machine = GetComponent<StateMachinePuppy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        zonestate = GetComponent<ZoneState>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Valla" && zonestate.enabled == true)
        {
            machine.ActivateState(machine.escapeState);
        }
        if (collision.name == "Ball" && zonestate.enabled == true)
        {
            machine.ActivateState(machine.kickedState);
        }
    }
}
