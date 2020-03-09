using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2 : MonoBehaviour
{
    public Transform start;
    public Vector2 pmax;
    public Transform end;
    float t;
    float rateVelocity;
    public float speed;
    public GameObject player;
    public PuppyManager puppymanager;
    public Transform rebote;
    public Transform setpoint;
    // Start is called before the first frame update
    void Start()
    {
        tag = "Defensa";
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (tag == "Armado")
        {
            MovimientoParab(start.position, end.position);
        }
        if (tag == "Ataque")
        {
            MovimientoRecto(transform.position, puppymanager.objball);
        }
        if (tag == "Golpe")
        {
            MovimientoRecto(transform.position, rebote.position);
        }
        if (tag == "Rebote")
        {
            MovimientoParab(transform.position, end.position);
        }
        if (tag == "Defensa")
        {
            MovimientoParab(transform.position, setpoint.position);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)//Luciano
    {
        if (collision.name == "SetPoint")
        {
            if (tag == "Armado")
            {
                Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            if(tag == "Defensa")
            {
                start.position = transform.position;
                if (player.transform.position.x <= 3f)
                {
                    end.position = player.transform.position + new Vector3(1f, 1f);
                }
                if (player.transform.position.x > 3f)
                {
                    end.position = new Vector2(4.5f, player.transform.position.y + 1f);
                }
                gameObject.tag = "Armado";
            }
        }
        if (collision.name == "Player")
        {
            if (collision.tag == "Atacando")
            {
                player.GetComponent<Animator>().SetTrigger("atacking");
                gameObject.tag = "Ataque";
            }
            if (collision.tag == "Defendiendo")
            {
                player.GetComponent<Animator>().SetTrigger("defending");
                start.position = transform.position;
                gameObject.tag = "Defensa";
                collision.tag = "Atacando";
            }
        }
        if (collision.tag == "EnZona")
        {
            gameObject.tag = "Golpe";
        }
        if (collision.name == "Rebote")
        {
            start.position = transform.position;
            var x = Random.Range(-1.31f, 4.97f);
            var y = Random.Range(1.8f, 5.6f);
            end.position = new Vector2(x, y);
            gameObject.tag = "Rebote";
            player.tag = "Defendiendo";
        }        
    }
    private void MovimientoRecto(Vector2 a, Vector2 b)
    {
        transform.position = Vector2.MoveTowards(a, b, speed * Time.deltaTime * 50);
    }
    private void MovimientoParab(Vector2 a, Vector2 b)
    {
        pmax = new Vector2((b.x - a.x) / 2 + a.x, b.y * 3);
        rateVelocity = 1f / Vector2.Distance(a, b) * speed;
        t += Time.deltaTime * rateVelocity;
        if (t < 1.0f)
        {
            transform.position = Parabola(t, a, pmax, b);
        }
        else
        {
            transform.position = b;
            t = 0;
        }
    }
    private Vector2 Parabola(float t, Vector2 a, Vector2 b, Vector2 c)
    {
        var ab = Vector2.Lerp(a, b, t);
        var bc = Vector2.Lerp(b, c, t);
        return Vector2.Lerp(ab, bc, t);
    }
}
