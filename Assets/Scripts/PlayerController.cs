using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        tag = "Atacando";
    }

    // Update is called once per frame
    void Update()
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
            if (transform.rotation.y == 0)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetTrigger("running");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.rotation.y == 180)
            {
                transform.Rotate(0f, 1f, 0f);
                Debug.Log("func");
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetTrigger("running");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if ( tag == "Atacando")
            {
                animator.SetBool("running", false);
                animator.SetBool("kicking", false);
                animator.SetBool("defending", false);
                animator.SetBool("atacking", true);
            }
            else
            {
                animator.SetBool("running", false);
                animator.SetBool("kicking", false);
                animator.SetBool("defending", true);
                animator.SetBool("atacking", false);
            }

        }
        LimitedArea();
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
