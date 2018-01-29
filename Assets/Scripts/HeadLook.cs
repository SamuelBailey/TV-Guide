using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLook : MonoBehaviour {

    public float lookSpeed = 6.0f;
    public float maxLookRotation = 85.0f;
    public float minLookRotation = 85.0f;

    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;
    private void Update()
    {
        verticalRotation = -Input.GetAxis("Mouse Y");
        verticalRotation *= lookSpeed;
        horizontalRotation = Input.GetAxis("Mouse X");
        horizontalRotation *= lookSpeed;

        if (maxLookRotation >= 180 || maxLookRotation <= 0)
            throw new System.ArgumentOutOfRangeException("maxLookRotation must be between 0 and 180");
        if (minLookRotation >= 180 || minLookRotation <= 0)
            throw new System.ArgumentOutOfRangeException("minLookRotation must be between 0 and 180");

        gameObject.transform.Rotate(new Vector3(verticalRotation, 0, 0));

        if (gameObject.transform.rotation.eulerAngles.x > 180.0f)
        // player is looking up
        {
            if (gameObject.transform.rotation.eulerAngles.x < 360 - maxLookRotation)
                gameObject.transform.localRotation = Quaternion.Euler(new Vector3(360 - maxLookRotation, 0, 0));
        }
        else
        // player is looking down
        {
            if (gameObject.transform.rotation.eulerAngles.x > minLookRotation)
                gameObject.transform.localRotation = Quaternion.Euler(new Vector3(minLookRotation, 0, 0));
        }

        // setting horizontal rotation
        gameObject.transform.parent.gameObject.transform.Rotate(new Vector3(0, horizontalRotation, 0));
    }
}
