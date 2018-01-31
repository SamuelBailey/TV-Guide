using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Video;

public enum Channel
{
    Shooter,
    Forest,
    Haunted
}

public class ChangeChannel : MonoBehaviour
{
    public Channel currentChannel;
    Channel selectedChannel;
    bool changeChannel;
    bool overrideFindSelectedChannel;
    public bool canChangeChannel;

    public List<GameObject> shooterSceneObjects = new List<GameObject>();
    public List<GameObject> forestSceneObjects = new List<GameObject>();
    public List<GameObject> hauntedSceneObjects = new List<GameObject>();

    // public GameObject staticScreen;

    // public GameObject videoPlayerObject;

    // bool displayStatic;
    public int staticLength = 100;

    public GameObject mainCamera;
    public GameObject staticCamera;

    bool enableMainCamera;  // used as a flag to turn the main camera back after the static video has played

    public AudioSource staticAudioSource;
    public AudioClip staticClip;

    public List<GameObject> disableOnChannelChange;

    public Material skyScraperMat;

    private void Start()
    {
        overrideFindSelectedChannel = false;
        enableMainCamera = false;
        // displayStatic = false;
        currentChannel = Channel.Shooter;
        canChangeChannel = true;
        // videoPlayerObject.SetActive(false);
        // videoPlayerObject.GetComponent<VideoPlayer>().Prepare();
    }

    private void Update()
    {
        if (canChangeChannel)
        {
            // Check if the user has selected a channel to change to
            if (!overrideFindSelectedChannel)
                selectedChannel = findSelectedChannel();
            else // if override == true, set to false
                overrideFindSelectedChannel = false;

            if (changeChannel)
            {
                // Remove items
                if (selectedChannel != currentChannel)
                {
                    foreach (GameObject obj in disableOnChannelChange)
                        obj.SetActive(false);
                }

                DisableCurrentChannel();
                EnableChannel(selectedChannel);
                // Change scene lighting
                gameObject.GetComponent<ToggleLighting>().SetChannelLighting(selectedChannel);

                // Change skybox
                if (selectedChannel == Channel.Haunted)
                    RenderSettings.skybox = skyScraperMat;
                else
                    RenderSettings.skybox = null;

                // Pause music
                gameObject.GetComponent<SetMusic>().PauseAudioSource();

                // Show Static
                ShowStaticCamera(mainCamera, staticCamera, staticLength);
                staticAudioSource.PlayOneShot(staticClip);
            }
        }

        if (enableMainCamera)
        {
            staticCamera.SetActive(false);
            mainCamera.SetActive(true);
            enableMainCamera = false;

            // Resume music for current channel
            gameObject.GetComponent<SetMusic>().PlayAudioSource(selectedChannel);
        }
    }

    public void SelectChannel(Channel channel)
    {
        Debug.Log("Changing channel");
        changeChannel = true;
        overrideFindSelectedChannel = true;
        selectedChannel = channel;
    }

    Channel findSelectedChannel()
    {
        changeChannel = true;
        if (Input.GetButtonDown("Channel 1"))
            return Channel.Shooter;
        else if (Input.GetButtonDown("Channel 2"))
            return Channel.Forest;
        else if (Input.GetButtonDown("Channel 3"))
            return Channel.Haunted;
        else
        {
            changeChannel = false;
            return selectedChannel;
        }
    }

    void DisableCurrentChannel()
    {
        switch (currentChannel)
        {
            case Channel.Shooter:
                foreach (GameObject obj in shooterSceneObjects)
                    obj.SetActive(false);
                break;
            case Channel.Forest:
                foreach (GameObject obj in forestSceneObjects)
                    obj.SetActive(false);
                break;
            case Channel.Haunted:
                foreach (GameObject obj in hauntedSceneObjects)
                    obj.SetActive(false);
                break;
        }
    }

    void EnableChannel(Channel channel)
    {
        currentChannel = channel;
        switch (channel)
        {
            case Channel.Shooter:
                foreach (GameObject obj in shooterSceneObjects)
                    obj.SetActive(true);
                break;
            case Channel.Forest:
                foreach (GameObject obj in forestSceneObjects)
                    obj.SetActive(true);
                break;
            case Channel.Haunted:
                foreach (GameObject obj in hauntedSceneObjects)
                    obj.SetActive(true);
                break;
        }
    }

    // void ShowStatic(int milliseconds)
    // {
    //     // play static video
    //     Debug.Log("Playing Video");
    //     videoPlayerObject.SetActive(true);
    // 
    //     videoPlayerObject.GetComponent<VideoPlayer>().Play();
    // }

    void ShowStaticCamera(GameObject currentCamera, GameObject targetCamera, int milliseconds)
    {
        currentCamera.SetActive(false);
        targetCamera.SetActive(true);

        Timer timer = null;
        timer = new Timer((obj) =>
        {
            enableMainCamera = true;
            timer.Dispose();
        },
            null, milliseconds, Timeout.Infinite);
    }
}
