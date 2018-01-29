using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHelicopter : MonoBehaviour {
    public float moveSpeed = 100;
    public Transform rotationPoint;
    private void Update()
    {
        gameObject.transform.RotateAround(rotationPoint.position, Vector3.up, moveSpeed * Time.deltaTime);
    }
}
