using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 20.0f;

    private void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
