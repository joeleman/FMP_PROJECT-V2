using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound 
{

    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 0.5f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
