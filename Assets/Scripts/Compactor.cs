using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Compactor : MonoBehaviour
{

    public enum compactorAxis
    {
        onXAxis,
        onZAxis
    };

    [Tooltip("First side of the compactor")]
    public Transform firstSide;
    [Tooltip("Second side of the compactor")]
    public Transform otherSide;

    public Transform centerPoint;

    [Tooltip("Direction in which the compactor closes it")]
    public compactorAxis direction = compactorAxis.onXAxis;

    [Tooltip("Time in seconds it takes for the compactor to fully crush")]
    public float time = 30.0f;
    private float timeElapsed = 0f;

    [Tooltip("Time in seconds before compaction begins")]
    public float delay = 5f;

    private Vector3 firstSideStart;
    private Vector3 otherSideStart;
    private Vector3 firstSideTarget;
    private Vector3 otherSideTarget;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * While the two sides should have the same target, still calculate the target
         * for both. This is just in case the two side's centers are not perfectly aligned.
         */
        firstSideStart = firstSide.position;
        otherSideStart = otherSide.position;

        if(direction == compactorAxis.onXAxis)
        {
            firstSideTarget = new Vector3(centerPoint.position.x, firstSide.position.y, firstSide.position.z);
            otherSideTarget = new Vector3(centerPoint.position.x, otherSide.position.y, otherSide.position.z);

            //We want the target to be where the edges of the blocks (not the centers) meet;
            firstSideTarget = Vector3.MoveTowards(firstSideTarget, firstSide.position, firstSide.localScale.x / 2);
            otherSideTarget = Vector3.MoveTowards(otherSideTarget, otherSide.position, otherSide.localScale.x / 2);

        }
        else
        {
            firstSideTarget = new Vector3(firstSide.position.x, firstSide.position.y, centerPoint.position.z);
            otherSideTarget = new Vector3(otherSide.position.x, otherSide.position.y, centerPoint.position.z);
            firstSideTarget = Vector3.MoveTowards(firstSideTarget, firstSide.position, firstSide.localScale.z / 2);
            otherSideTarget = Vector3.MoveTowards(otherSideTarget, otherSide.position, otherSide.localScale.z / 2);
        }

        
        StartCoroutine(compactDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (started)
        {
            // We want blocks to move a bit slower. Game ends when the contact, not when they fully overlap.
            firstSide.transform.position = Vector3.Lerp(firstSideStart, firstSideTarget, timeElapsed / time);
            otherSide.transform.position = Vector3.Lerp(otherSideStart, otherSideTarget, timeElapsed / time);

            timeElapsed += Time.deltaTime;

            if(timeElapsed >= time)
            {
                started = false;
                GameManager.get().loadScene(SceneManager.GetActiveScene().buildIndex, false);
            }
        }
    }

    IEnumerator compactDelay()
    {
        //Time delay before starting
        yield return new WaitForSecondsRealtime(delay);
        started = true;
    }

    public void stopCompactor()
    {
        started = false;
    }
}
