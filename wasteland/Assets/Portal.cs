using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform transformTp;
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            if (player.justTeleported == false)
            {
                StartCoroutine(Teleport(player));
            }
            else
            {
                player.justTeleported = false;
            }
        }
    }
    IEnumerator Teleport(PlayerMovement player)
    {
        yield return new WaitForSeconds(1);
        player.justTeleported = true;
        player.transform.position = new Vector3(
            transformTp.transform.position.x - 10,
            transformTp.transform.position.y,
            transformTp.transform.position.z
        );
    }
}
