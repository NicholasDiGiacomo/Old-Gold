
using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;

    [Header("Music")]
    [SerializeField] private AudioClip gameplayMusic;
    [SerializeField] private AudioClip lavaMusic;
    [SerializeField] private AudioClip successMusic;
    [SerializeField] private AudioClip failureMusic;

    private bool endingStarted;

    private void Awake()
    {
        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayTrack(gameplayMusic, true);
    }

    public void PlayLavaMusic()
    {
        // Once an ending starts, lava cannot override its music.
        if (endingStarted)
            return;

        PlayTrack(lavaMusic, true);
    }

    public void PlaySuccessMusic()
    {
        endingStarted = true;
        PlayTrack(successMusic, false);
    }

    public void PlayFailureMusic()
    {
        endingStarted = true;
        PlayTrack(failureMusic, false);
    }

    private void PlayTrack(AudioClip clip, bool loop)
    {
        if (musicSource == null || clip == null)
            return;

        // Don't restart the same track if it's already playing.
        if (musicSource.clip == clip && musicSource.isPlaying)
            return;

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }
}