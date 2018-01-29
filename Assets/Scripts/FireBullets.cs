using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireBullets : MonoBehaviour {
    bool holdingGun = true;
    bool canFire;

    public Rigidbody bulletPrefab;
    public Transform barrelEnd;

    public GameObject sceneController;

    public int firingDelay = 2000;

    ChangeChannel changeChannel;

    private void Start()
    {
        canFire = true;
        changeChannel = sceneController.GetComponent<ChangeChannel>();
    }

    private void Update()
    {
        // if (Input.GetButtonDown("Fire1") && changeChannel.currentChannel == Channel.Shooter && canFire)
        if (Input.GetButtonDown("Fire1") && canFire)
            {
            // Debug.Log("Firing");
            Rigidbody bulletInstance;
            Quaternion barrelRotation = barrelEnd.rotation;
            barrelRotation = barrelRotation * Quaternion.Euler(new Vector3(90, 0, 0));
            bulletInstance = Instantiate(bulletPrefab, barrelEnd.position, barrelRotation) as Rigidbody;
            DisableFiringForPeriod(firingDelay);
        }
    }

    void DisableFiringForPeriod(int milliseconds)
    {
        DisableFiring();
        Timer timer = null;
        timer = new Timer((obj) =>
        {
            EnableFiring();
            timer.Dispose();
        },
            null, milliseconds, Timeout.Infinite);
    }

    void DisableFiring()
    {
        canFire = false;
    }

    void EnableFiring()
    {
        canFire = true;
    }
}
