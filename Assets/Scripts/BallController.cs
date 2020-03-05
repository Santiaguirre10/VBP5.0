using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform start;
    public Vector2 a;
    public Vector2 b;
    public Vector2 c;
    public Transform end;
    float rateVelocity;
    float t = 0.0f;
    public float speed;
    public GameObject player;
    public Transform objball;
    public Transform rebote;
    public Transform setpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == objball.position)
        {
            tag = "Golpe";
        }
        Move();
    }
    void Move()
    {
        if (tag == "Ataque")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, objball.position, step);
        }
        else if (tag == "Golpe")
        {
            float step = speed * 4 * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, rebote.position, step);
        }
        else if (tag == "Rebote")
        {
            a = start.position;
            b = new Vector2((c.x - a.x) / 2 + a.x, c.y * 3);
            c = end.position;
            rateVelocity = 1f / Vector3.Distance(a, c) * speed;
            t += Time.deltaTime * rateVelocity;
            if (t < 1.0f)
            {
                transform.position = Parabola(t, a, b, c);
            }
            else
            {
                t = 0;
                transform.position = c;
            }
        }
        else if (tag == "Defensa")
        {
            a = start.position;
            b = new Vector2((c.x - a.x) / 2 + a.x, c.y * 3);
            c = end.position;
            rateVelocity = 1f / Vector3.Distance(a, c) * speed;
            t += Time.deltaTime * rateVelocity;
            if (t < 1.0f)
            {
                transform.position = Parabola(t, a, b, c);
            }
            else
            {
                t = 0;
                transform.position = c;
            }
        }
        else if (tag == "Armado")
        {
            a = start.position;
            b = new Vector2((c.x - a.x) / 2 + a.x, c.y * 3);
            c = end.position;
            rateVelocity = 1f / Vector3.Distance(a, c) * speed;
            t += Time.deltaTime * rateVelocity;
            if (t < 1.0f)
            {
                transform.position = Parabola(t, a, b, c);
            }
            else
            {
                t = 0;
                transform.position = c;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "SetPoint")
        {
            start.position = transform.position;
            if (player.transform.position.x <= 3f)
            {
                end.position = player.transform.position + new Vector3(1f, 1f,0);
            }
            if (player.transform.position.x > 3f)
            {
                end.position = new Vector3(4.5f, player.transform.position.y + 1f);
            }
            if(tag == "Armado")
            {
                Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            gameObject.tag = "Armado";
        }
        if (collision.name == "Player")
        {
            if (collision.tag == "Atacando")
            {
                gameObject.tag = "Ataque";
                collision.tag = "Defendiendo";
            }
            else if (collision.tag == "Defendiendo")
            {
                start.position = transform.position;
                end.position = setpoint.position;
                gameObject.tag = "Defensa";
                collision.tag = "Atacando";
            }
        }
        if (collision.tag == "EnZona")
        {
            Debug.Log("funcoina");
            gameObject.tag = "Golpe";
        }
        if (collision.name == "Rebote")
        {
            start.position = transform.position;
            var x = Random.Range(-1.31f, 4.97f);
            var y = Random.Range(1.8f, 5.6f);
            end.position = new Vector3(x, y, 0f);
            gameObject.tag = "Rebote";
        }
        if (collision.tag == "Escapando")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    private Vector2 Parabola(float t, Vector2 a, Vector2 b, Vector2 c)
    {
        var ab = Vector2.Lerp(a, b, t);
        var bc = Vector2.Lerp(b, c, t);
        return Vector2.Lerp(ab, bc, t);
    }
}