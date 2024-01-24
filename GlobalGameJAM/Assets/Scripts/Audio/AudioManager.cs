using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    private EventInstance musicEventInstance;

    #endregion

    #region Init

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Multiple AudioManagers in scene.");
        }

        instance = this;
    }

    private void Start()
    {
        initaliseMusic();
    }

    #endregion

    #region Core Methods

    public void PlayOneshotSound(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference reference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(reference);
        return eventInstance;
    }

    #endregion

    #region Custom Methods

    private void initaliseMusic()
    {
        musicEventInstance = CreateInstance(FMODEvents.instance.music);
        musicEventInstance.start();
    }

    #endregion
}
