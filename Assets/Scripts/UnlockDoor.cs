using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for allowing the player to pick up the key, which will in turn allow them to open the door.
/// This will call methods from other scripts in order to despawn the key and 
/// </summary>

public class UnlockDoor : MonoBehaviour
{
    public GameObject key;
    public GameObject door;

    bool hasKey = false;

    private void Start()
    {
        // key = GameObject.FindGameObjectWithTag("Key");
        // door = GameObject.FindGameObjectWithTag("Door");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Player entered trigger of " + other.name);
        if (other.tag == "Key")
        {
            DespawnKey();
            hasKey = true;
        }
        if (other.tag == "Door" && hasKey && door.GetComponent<OpenDoor>().isLocked)
        {
            // door.GetComponent<DoorState>().OpenDoor();
            door.GetComponent<OpenDoor>().RotateDoor();
        }
    }

    void DespawnKey()
    {
        key.SetActive(false);
    }
}
