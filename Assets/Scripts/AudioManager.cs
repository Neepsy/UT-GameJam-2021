using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public Sound[] sounds;
    public static AudioManager instance;

    //private AccessPauseMenu actionMap;
    //private InputAction walkW;

    void Awake()
    {
        //actionMap = new AccessPauseMenu();
        //walkW

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Music");
    }

    private void Footsteps()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Playing footsteps");
            Play("Footstep SFX");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("Stopped footsteps");
            Stop("Footstep SFX");
        }
    }

    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("ERROR Audio: " + name + " not found");
            return;
        }
        if(!s.source.isPlaying)
            s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("ERROR Audio: " + name + " not found");
            return;
        }
        s.source.Stop();
    }
}
