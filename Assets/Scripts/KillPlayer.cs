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
        if (other.gameObject.tag == "Die" || other.gameObject.tag == "Enemy")
        {
            // Comment out one of the below lines depending if you want to completely restart or just move the player.

            // RespawnPlayer();
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
