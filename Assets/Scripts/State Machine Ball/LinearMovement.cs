using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float speed; 
    public void MovimientoRecto(Vector2 a, Vector2 b)
    {
        transform.position = Vector2.MoveTowards(a, b, speed * Time.deltaTime * 50);
    }
}
