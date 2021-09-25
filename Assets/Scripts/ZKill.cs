using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ZKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 respawn = GameManager.get().getRespawnPoint();            Debug.Log(other.gameObject.name);
            Physics.SyncTransforms();
            other.transform.position = new Vector3(respawn.x, respawn.y, respawn.z);
        }
    }
}
