using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {
    // public Scene winScene;
    private void OnTriggerEnter(Collider other)
    {
        //if (winScene == null)
        //    throw new System.NullReferenceException("Attach the win scene to the WinGame script");
        if (other.tag == "Win")
            SceneManager.LoadScene("WinScene");
    }
}
