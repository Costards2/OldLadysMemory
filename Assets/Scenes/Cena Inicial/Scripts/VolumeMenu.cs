using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
    [SerializeField] private AudioSource volumeMenuBack;

    public void VolumeInicio(float value)
    {
        volumeMenuBack.volume = value;
    }
}
