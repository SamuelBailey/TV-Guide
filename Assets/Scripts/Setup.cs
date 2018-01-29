using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {
    private void Awake()
    {
        gameObject.GetComponent<SetMusic>().PlayAudioSource(Channel.Shooter);

        Cursor.visible = false;
    }
}
