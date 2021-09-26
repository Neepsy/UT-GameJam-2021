using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Collider))]
public class LevelChanger : MonoBehaviour
{
    [Tooltip("Index of next scene to load (Check File -> Build Settings)")]
    public int sceneIndex = 1;

    [Tooltip("A reference to the trash compactor script if one exists on this level")]
    public Compactor comp;

    public enum fadeType
    {
        white,
        black
    }

    public fadeType fadeColor = fadeType.white;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(comp != null)
            {
                comp.stopCompactor();
            }
            GameManager.get().loadScene(sceneIndex, fadeColor == fadeType.white ? true : false);
            GameObject.FindObjectOfType<AudioManager>().Play("Teleport SFX");
        }
    }
}
