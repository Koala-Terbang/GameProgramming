using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPhysics : MonoBehaviour
{
    public float Speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
