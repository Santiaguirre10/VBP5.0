using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        tag = "Atacando";
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LimitedArea();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            animator.SetTrigger("running");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            animator.SetTrigger("running");
        } 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetTrigger("running");
            sprite.flipX = true;
        } 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetTrigger("running");
            sprite.flipX = false;
        }
        else
        {
            animator.SetTrigger("idle");
        }
    }
    void LimitedArea()
    {
        if (transform.position.x <= -1.61f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-1.6f, transform.position.y), step);
        } 
        if (transform.position.x >= 4.66f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(4.6f, transform.position.y), step);
        }
        /*if (transform.position.y <= 2f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 2.1f), step);
        }
        if (transform.position.y >= 5.72f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 5.7f), step);
        }*/
    }
}
