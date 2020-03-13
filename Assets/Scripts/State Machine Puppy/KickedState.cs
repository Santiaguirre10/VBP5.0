using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickedState : MonoBehaviour
{
    StateMachinePuppy machine;
    PuppyManager puppymanager;
    Vector3 initpos;
    ParabolicMovement parab;

    // Start is called before the first frame update
    private void Awake()
    {
        puppymanager = GameObject.FindObjectOfType<PuppyManager>();
    }
    void Start()
    {
        initpos = transform.position;
        machine = GetComponent<StateMachinePuppy>();
        parab = GetComponent<ParabolicMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        parab.MovimientoParab(transform.position, initpos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spamer") && transform.position == initpos)
        {
            puppymanager.puppys.Add(gameObject);
            puppymanager.distances.Add(gameObject.transform.position.x);
            machine.ActivateState(machine.zoneState);
            parab.t = 0;
        }
    }
}
