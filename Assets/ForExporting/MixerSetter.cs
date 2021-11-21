using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MixerSetter : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [Header ("0 - music, 1 - effects")]
    [SerializeField] bool type;
    void Start()
    {
        if (!type)
        {
            audioMixer.GetFloat("musicValue", out var value);
            GetComponent<Toggle>().isOn = value == -80f ? true : false;
        }
        else
        {
            audioMixer.GetFloat("effectsValue", out var value);
            GetComponent<Toggle>().isOn = value == -80f ? true : false;
        }
    }
}
