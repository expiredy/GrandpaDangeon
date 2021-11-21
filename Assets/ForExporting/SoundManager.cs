using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    public void TurnEffects(bool toogle)
    {
        float value = toogle ? -80f : 0f;
        _mixer.SetFloat("effectsValue", value);
    }

    public void TurnMusic(bool toogle)
    {
        float value = toogle ? -80f : 0f;
        _mixer.SetFloat("musicValue", value);
    }
}
