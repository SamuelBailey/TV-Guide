using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool isLocked;

    public float openingAngle = 90.0f;

    public float rotateSpeed = 20.0f;

    bool shouldRotate;
    Quaternion startRotation;
    Quaternion targetRotation;
    private void Start()
    {
        isLocked = true;
        shouldRotate = false;
        startRotation = gameObject.transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(0, -openingAngle, 0);
    }

    public void RotateDoor()
    {
        // gameObject.transform.rotation = targetRotation;
        shouldRotate = true;
        isLocked = false;
    }

    private void Update()
    {
        if (shouldRotate)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed*Time.deltaTime);
            if (transform.rotation == Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed))
                shouldRotate = false;
        }
    }

    // For testing if the door will open properly.
    // Don't use, because it doesn't check if player has key.
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Player")
    //         RotateDoor();
    // }
}
