using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyController : MonoBehaviour
{
    GameObject gameover;
    public float speed;
    PuppyManager puppymanager;
    int life;
    public Vector3 initpos;
    public bool kicked;
    public Vector2 pmax;
    float t;
    float rateVelocity;
    GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        gameover = GameObject.Find("GameOver");
        puppymanager = GameObject.FindObjectOfType<PuppyManager>();
        player = GameObject.Find("Player");
    }
    void Start()
    {
        life = 3;
        initpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(life <= 0)
        {
            puppymanager.puppys.Remove(gameObject);
            puppymanager.distances.Remove(gameObject.transform.position.x);
            puppymanager.mindistance = 20f;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Valla")
        {
            if (tag == "Golpeado")
            {
                Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            else
            {
                puppymanager.puppys.Remove(gameObject);
                puppymanager.distances.Remove(gameObject.transform.position.x);
                puppymanager.mindistance = 20f;
                tag = "Escapando";
            }
        }
        if (collision.name == "Player")
        {
            player.GetComponent<Animator>().SetTrigger("kicking");
            puppymanager.puppys.Remove(gameObject);
            puppymanager.distances.Remove(gameObject.transform.position.x);
            puppymanager.mindistance = 20f;
            tag = "Golpeado";
            life--;
        }
        if (collision.tag == "Spamer")
        {
            if (collision.transform.position == initpos)
            {
                puppymanager.puppys.Add(gameObject);
                puppymanager.distances.Add(gameObject.transform.position.x);
                tag = "EnZona";
            }
        }
        if (collision.tag == "Ataque")
        {
            if (tag == "EnZona")
            {
                puppymanager.puppys.Remove(gameObject);
                puppymanager.distances.Remove(gameObject.transform.position.x);
                puppymanager.mindistance = 20f;
                tag = "Golpeado";
                life--;
                collision.tag = "Golpe";
            }
        }
    }
    void Move()
    {
        if (tag == "EnZona")
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (tag == "Escapando")
        {
            MovimientoRecto(transform.position, gameover.transform.position);
        }
        if (tag == "Golpeado")
        {
            MovimientoParab(transform.position, initpos);
        }
    }
    private void MovimientoRecto(Vector2 a, Vector2 b)
    {
        transform.position = Vector2.MoveTowards(a, b, speed * Time.deltaTime );
    }
    private void MovimientoParab(Vector2 a, Vector2 b)
    {
        pmax = new Vector2((b.x - a.x) / 2 + a.x, b.y * 3);
        rateVelocity = 1f / Vector3.Distance(a, b) * speed;
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
