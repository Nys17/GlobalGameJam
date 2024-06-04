using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    private EventInstance musicEventInstance;
    public EventInstance pipeEventInstance;


    FMOD.Studio.Bus musicBus;
    [SerializeField] [Range(-80f, 10f)] private float musicBusVolume;

    FMOD.Studio.Bus sfxBus;
    [SerializeField][Range(-80f, 10f)] private float sfxBusVolume;

    FMOD.Studio.Bus metalPipeBus;
    [SerializeField][Range(-80f, 10f)] private float metalPipeBusVolume;

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
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        metalPipeBus = FMODUnity.RuntimeManager.GetBus("bus:/MetalPipe");
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

    private void Update()
    {
        musicBus.setVolume(DecibelToLinear(musicBusVolume));
        sfxBus.setVolume(DecibelToLinear(sfxBusVolume));
        metalPipeBus.setVolume(DecibelToLinear(metalPipeBusVolume));
    }

    #endregion

    #region Custom Methods

    private void initaliseMusic()
    {
        musicEventInstance = CreateInstance(FMODEvents.instance.music);
        musicEventInstance.start();
    }

    private void deinitaliseSound()
    {
        musicEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20f);
        return linear;
    }

    #endregion

    #region Destructor

    private void OnDestroy()
    {
        deinitaliseSound();
    }

    private void OnDisable()
    {
        deinitaliseSound();
    }

    #endregion
}
