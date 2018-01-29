using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopChangeChannel : MonoBehaviour
{
    public LayerMask defineStopTeleport;
    public GameObject sceneController;

    ChangeChannel changeChannel;

    private void Start()
    {
        changeChannel = sceneController.GetComponent<ChangeChannel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Player entered trigger");
        if (other.gameObject.tag == "Stop Teleport")
        {
            // Debug.Log("Cannot change channel");
            changeChannel.canChangeChannel = false;
        }
    }
}
