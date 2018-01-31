using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class JumpScare : MonoBehaviour {
    public GameObject sceneController;

    public int scareLength = 400;
    public GameObject skeleton;

    bool shouldRestart;


    private void Start()
    {
        shouldRestart = false;
    }

    private void Update()
    {
        if (shouldRestart)
            gameObject.GetComponent<KillPlayer>().RestartGame();
    }

    public void JumpScareDeath()
    {
        //change the channel
        sceneController.GetComponent<ChangeChannel>().SelectChannel(Channel.Forest);
        skeleton.SetActive(true);

        //then restart the game after set time
        Timer timer = null;
        timer = new Timer((obj) =>
        {
            //RestartGame();
            shouldRestart = true;
            timer.Dispose();
        },
            null, scareLength, Timeout.Infinite);
    }
}
