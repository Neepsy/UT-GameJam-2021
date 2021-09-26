using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class LevelChanger : MonoBehaviour
{
    [Tooltip("Index of next scene to load (Check File -> Build Settings)")]
    public int sceneIndex = 1;

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
            GameManager.get().loadScene(sceneIndex, fadeColor == fadeType.white ? true : false);
        }
    }
}
