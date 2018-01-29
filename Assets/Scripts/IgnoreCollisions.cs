using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    public LayerMask definePlayer;
    public LayerMask defineBullets;

    private void Start()
    {
        Physics.IgnoreLayerCollision(definePlayer, defineBullets);
    }
}
