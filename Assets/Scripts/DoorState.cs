using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState : MonoBehaviour
{
    public bool isLocked;

    private void Start()
    {
        isLocked = true;
    }

    public void OpenDoor()
    {
        isLocked = false;
    }
}
