using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    private string m_audioKey = "Audio";
    private string m_postProcessingKey = "PostProcessing";

    public float AudioSave
    {
        get => PlayerPrefs.GetFloat(m_audioKey);
        private set => PlayerPrefs.SetFloat(m_audioKey, value);
    }

    public bool PostProcessingSave
    {
        get => PlayerPrefs.GetInt(m_postProcessingKey) == 0 ? false : true;
        private set => PlayerPrefs.SetInt(m_postProcessingKey, value == false ? 0 : 1);
    }

    public static ConfigManager i;

    private void Awake()
    {
        i = this;
        InitSaveKeys();
    }

    public void InitSaveKeys()
    {
        if ( !PlayerPrefs.HasKey(m_audioKey) )
            AudioSave = 1f;

        if ( !PlayerPrefs.HasKey(m_postProcessingKey) )
            PostProcessingSave = true;

        PlayerPrefs.Save();
    }

    public void SetAudio(float volume)
    {
        AudioSave = volume;
        AudioListener.volume = volume;
    }

    public void SetPostProcessing(bool active)
    {
        PostProcessingSave = active;
        PostProcessingManager.i.SetPostProcessingActive(active);
    }
}
