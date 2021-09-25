using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("Bubble projected around player that prevents platforms from teleporting")]
    public SphereCollider antiTeleportBubble;

    private Vector3 checkpoint;
    private GameObject player;

    public static GameManager INSTANCE;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        Debug.Log("Game Manager Woke Up");
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindGameObjectWithTag("Player");
        setRespawnPoint(player.transform);
        if (antiTeleportBubble == null)
        {
            antiTeleportBubble = player.GetComponent<SphereCollider>();
        }
    }

    public static GameManager get()
    {
        if (INSTANCE == null)
        {
            INSTANCE = GameObject.FindObjectOfType<GameManager>();

            // GameManager not added to the scene, make a new one
            if (INSTANCE == null)
            {
                GameObject dummy = new GameObject("Game Manager");
                INSTANCE = dummy.AddComponent<GameManager>();
            }
        }

        return INSTANCE;
    }



    public void setRespawnPoint(Transform position)
    {
        checkpoint = position.position;
    }

    public Vector3 getRespawnPoint()
    {
        return checkpoint;
    }

    // Returns if point is inside bubble around player in which platforms cannot teleport.
    public bool insideAntiTeleportBubble(Vector3 pos)
    {
        if(antiTeleportBubble != null)
        {
            return antiTeleportBubble.bounds.Contains(pos);
        }

        Debug.LogWarning("Make sure GameManager's Anti Teleport Bubble is assigned, and that a sphere collider is on the player!");
        return false;
    }
}
