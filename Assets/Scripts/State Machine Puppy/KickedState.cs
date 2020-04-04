using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickedState : MonoBehaviour
{
    StateMachinePuppy machine;
    PuppyManager puppymanager;
    ParabolicMovement parab;

    // Start is called before the first frame update
    private void Awake()
    {
        puppymanager = GameObject.FindObjectOfType<PuppyManager>();
    }
    void Start()
    {
        machine = GetComponent<StateMachinePuppy>();
        parab = GetComponent<ParabolicMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        parab.MovimientoParab(transform.position, machine.initpos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spamer") && transform.position == machine.initpos)
        {
            puppymanager.puppys.Add(gameObject);
            puppymanager.distances.Add(gameObject.transform.position.x);
            machine.ActivateState(machine.zoneState);
            parab.t = 0;
        }
    }
}
