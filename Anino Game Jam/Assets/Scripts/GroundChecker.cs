using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private CharacterController player;

    void OnTriggerStay2D(Collider2D col)
    {
        if (player != null)
        {
            player.IsPlayerGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (player != null)
        {
            player.IsPlayerGrounded = false;
        }
    }
}
