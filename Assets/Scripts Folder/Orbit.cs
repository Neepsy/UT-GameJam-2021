using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;

    public float speed;

    public void Update()
    {
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);

    }
}