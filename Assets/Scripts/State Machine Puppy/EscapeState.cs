using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : MonoBehaviour
{
    public float speed;
    GameObject gameover;
    StateMachinePuppy machine;
    PuppyManager puppymanager;
    EscapeState escapestate;

    private void Awake()
    {
        gameover = GameObject.Find("GameOver");
        puppymanager = GameObject.FindObjectOfType<PuppyManager>();
        machine = GetComponent<StateMachinePuppy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        escapestate = GetComponent<EscapeState>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, gameover.transform.position, speed * Time.deltaTime );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            puppymanager.puppys.Remove(gameObject);
            puppymanager.distances.Remove(gameObject.transform.position.x);
            puppymanager.mindistance = 20f;
            machine.life--;
            machine.ActivateState(machine.kickedState);
        }
    }
}
