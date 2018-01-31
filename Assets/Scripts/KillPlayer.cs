using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public int stopMovementTime = 500;

    Vector3 startPosition;
    Quaternion startRotation;
    PlayerMovement playerMovement;

    bool playerShouldMove;

    public GameObject sceneController;

    private void Start()
    {
        startPosition = gameObject.GetComponent<Transform>().position;
        startRotation = gameObject.GetComponent<Transform>().rotation;
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerShouldMove = true;
    }

    private void Update()
    {
        if (playerMovement.enabled != playerShouldMove)
            playerMovement.enabled = playerShouldMove;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Die")
        {
            // Comment out one of the below lines depending if you want to completely restart or just move the player.

            // RespawnPlayer();
            RestartGame();
        }
        else if (other.gameObject.tag == "Enemy")
        {
            if (sceneController.GetComponent<ChangeChannel>().currentChannel != Channel.Forest)
            {
                // disable the skeleton so that there aren't 2 instances of it when including the one in front of the player's face
                other.gameObject.SetActive(false);
                gameObject.GetComponent<JumpScare>().JumpScareDeath();
            }
            else
                RestartGame();
        }
    }

    public void RestartGame()
    {
        if (sceneController == null)
            throw new System.NullReferenceException("Drop the sceneController gameObejct onto the Kill Player script in the editor");
        sceneController.GetComponent<LevelManager>().ReloadLevel();
    }

    public void RespawnPlayer()
    {
        gameObject.transform.position = startPosition;
        gameObject.transform.rotation = startRotation;
        playerMovement.moveDirection = Vector3.zero;
        DisableMovementForDelay(stopMovementTime);
    }

    void DisableMovementForDelay(int milliseconds)
    {
        DisableMovement();
        Timer timer = null;
        timer = new Timer((obj) =>
            {
                EnableMovement();
                timer.Dispose();
            },
            null, milliseconds, Timeout.Infinite);
    }

    void DisableMovement()
    {
        playerShouldMove = false;
    }

    void EnableMovement()
    {
        playerShouldMove = true;
    }
}
