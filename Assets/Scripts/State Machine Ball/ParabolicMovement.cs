using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{
    Vector2 pmax;
    float rateVelocity;
    public float speed;
    float t;
    public void MovimientoParab(Vector2 a, Vector2 b)
    {
        pmax = new Vector2((b.x - a.x) / 2 + a.x, b.y * 3);
        rateVelocity = 1f / Vector2.Distance(a, b) * speed;
        t += Time.deltaTime * rateVelocity;
        if (t <= 1.0f)
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
