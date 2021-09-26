using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checkpoint set");
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.get().setRespawnPoint(transform);
        }
        GameObject.FindObjectOfType<AudioManager>().Play("Teleport SFX");
    }
}
