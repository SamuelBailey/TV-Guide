using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    public float scrollSpeed;

    private void Update()
    {
        gameObject.transform.position = gameObject.transform.position + (Vector3.up * scrollSpeed * Time.deltaTime);
    }
}
