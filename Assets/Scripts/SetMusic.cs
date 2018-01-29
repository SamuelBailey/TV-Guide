using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusic : MonoBehaviour
{
    public AudioSource actionMovieSource;
    public AudioSource forestSource;
    public AudioSource hauntedSource;

    AudioSource currentAudioSource;

    public void PauseAudioSource()
    {
        if (currentAudioSource != null)
            currentAudioSource.Pause();
    }

    public void PlayAudioSource(Channel selectedChannel)
    {
        switch (selectedChannel)
        {
            case Channel.Shooter:
                currentAudioSource = forestSource;
                break;
            case Channel.Forest:
                currentAudioSource = hauntedSource;
                break;
            case Channel.Haunted:
                currentAudioSource = actionMovieSource;
                break;
        }

        currentAudioSource.UnPause();
        if (!currentAudioSource.isPlaying)
            currentAudioSource.Play();
    }
}
