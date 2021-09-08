using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VoiceWav : MonoBehaviour
{
    [SerializeField]private AudioClip audioClip;
    [SerializeField]private TextMeshProUGUI title;


    public void SetTitle(string name)
    {
        title.text = name;
    }

    public void OnPlay()
    {
        transform.Find("IsPlaying").gameObject.GetComponent<Toggle>().isOn = true;
    }

    public void SetAudioClip(AudioClip clip)
    {
        audioClip = clip;

    }
    public AudioClip GetAudioClip()
    {
        return audioClip;
    }
}
