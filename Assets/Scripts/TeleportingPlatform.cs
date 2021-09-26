using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingPlatform : MonoBehaviour
{

    [Tooltip("Min delay before teleporting")]
    public float minInterval = 10.0f;
    [Tooltip("Maximum delay before teleporting")]
    public float maxInterval = 10.0f;

    [Tooltip("Radius around starting point that teleports are allowed")]
    public float radius;

    [Tooltip("Only teleport once on awake, ignores interval")]
    public bool singleTP;

    private Vector3 startPoint;
    private bool isPlaying = false;

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.green;
        if (isPlaying)
        {
            UnityEditor.Handles.DrawWireDisc(startPoint, new Vector3(0, 1, 0), radius);
        }
        else
        {
            UnityEditor.Handles.DrawWireDisc(transform.position, new Vector3(0, 1, 0), radius);
        }
        
    }
    #endif

    void Awake()
    {
        isPlaying = true;
        startPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        float interval = singleTP ? .1f : Mathf.Round(Random.Range(minInterval, maxInterval) * 100) / 100;

        StartCoroutine(Delay(interval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delay(float time)
    {
        // Wait for the specified time
        yield return new WaitForSecondsRealtime(time);

        
        // only teleport if not too close to player
        if(GameManager.get().insideAntiTeleportBubble(transform.position) == false)
        {
            Vector2 newPos = Random.insideUnitCircle * radius;
            transform.position = new Vector3(newPos.x + startPoint.x, transform.position.y, newPos.y + startPoint.z);
        }

        if (!singleTP)
        {
           StartCoroutine(Delay(Mathf.Round(Random.Range(minInterval, maxInterval) * 100) / 100));
        }
        

        yield return null;
    }
}
