using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    SpriteRenderer sprite;
    public UIManager uimanager;
    public bool atacking;
    public bool defending;
    public FloatingJoystick joystick;
    public float h;
    public float v;

    // Start is called before the first frame update
    void Start()
    {
        atacking = true;
        defending = false;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uimanager.count <= 0)
        {
            Move();
            LimitedArea();
            animator.enabled = true;
        }
        else
        {
            
        }
        h = joystick.Horizontal;
        v = joystick.Vertical;
    }
    void Move()
    {
        if (v > 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            animator.SetTrigger("running");
        }
        if (v < 0)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            animator.SetTrigger("running");
        } 
        if (h < 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetTrigger("running");
            sprite.flipX = true;
        } 
        if (h > 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetTrigger("running");
            sprite.flipX = false;
        }
            animator.SetTrigger("idle");
        
    }
    void LimitedArea()
    {
        if (transform.position.x <= 0.728f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0.73f, transform.position.y), step);
        } 
        if (transform.position.x >= 4.15f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(4.14f, transform.position.y), step);
        }
        if (transform.position.y <= -3.98f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -3.97f), step);
        }
        /*if (transform.position.y >= -1.981f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -1.982f), step);
        }*/
    }
}
