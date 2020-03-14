using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachinePuppy : MonoBehaviour
{
    public MonoBehaviour kickedState;
    public MonoBehaviour escapeState;
    public MonoBehaviour zoneState;
    public MonoBehaviour initialState;
    private MonoBehaviour actualState;

    PuppyManager puppymanager;
    int life;

    private void Awake()
    {
        puppymanager = GameObject.FindObjectOfType<PuppyManager>();
        zoneState = GetComponent<ZoneState>();
        escapeState = GetComponent<EscapeState>();
        kickedState = GetComponent<KickedState>();
        initialState = GetComponent<KickedState>();
    }
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        actualState = initialState;
        ActivateState(initialState);
    }
    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            puppymanager.puppys.Remove(gameObject);
            puppymanager.distances.Remove(gameObject.transform.position.x);
            puppymanager.mindistance = 20f;
            Destroy(gameObject);
        }
    }
    public void ActivateState(MonoBehaviour newState)
    {
        if (actualState != null)
        {
            actualState.enabled = false;
            actualState = newState;
            actualState.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && escapeState.enabled == true)
        {
            puppymanager.puppys.Remove(gameObject);
            puppymanager.distances.Remove(gameObject.transform.position.x);
            puppymanager.mindistance = 20f;
            life--;
        }
        if (collision.name == "Ball" && zoneState.enabled == true)
        {
            puppymanager.puppys.Remove(gameObject);
            puppymanager.distances.Remove(gameObject.transform.position.x);
            puppymanager.mindistance = 20f;
            life--;
        }
    }
}
