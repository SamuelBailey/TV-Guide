using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLighting : MonoBehaviour
{
    public List<GameObject> shooterLights;
    public List<GameObject> forestLights;
    public List<GameObject> hauntedLights;

    List<GameObject> lightsToEnable;

    public void SetChannelLighting(Channel selectedChannel)
    {
        foreach(GameObject obj in shooterLights)
            obj.SetActive(false);
        foreach (GameObject obj in forestLights)
            obj.SetActive(false);
        foreach (GameObject obj in hauntedLights)
            obj.SetActive(false);

        switch (selectedChannel)
        {
            case Channel.Shooter:
                lightsToEnable = shooterLights;
                break;
            case Channel.Forest:
                lightsToEnable = forestLights;
                break;
            case Channel.Haunted:
                lightsToEnable = hauntedLights;
                break;
        }

        foreach (GameObject obj in lightsToEnable)
            obj.SetActive(true);
    }
}
