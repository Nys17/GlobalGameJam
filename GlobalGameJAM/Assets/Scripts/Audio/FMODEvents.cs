using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    #region Variables

    [field: Header("Music & Ambience")]
    [field: SerializeField] public EventReference music { get; private set; }

    [field: Header("Player Sound Effects")]
    [field: SerializeField] public EventReference playerFootsteps { get; private set; }
    [field: SerializeField] public EventReference metalPipe { get; private set; }

    #endregion


    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Multiple FMODEvents in scene.");
        }

        instance = this;
    }
}
