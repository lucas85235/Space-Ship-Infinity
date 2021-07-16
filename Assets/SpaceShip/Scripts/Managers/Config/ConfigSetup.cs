using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigSetup : MonoBehaviour
{
    [Header("UI Components")]
    public Slider audioUI;
    public Toggle postProcessingUI;

    void Start()
    {
        if (audioUI != null)
        {
            audioUI.maxValue = 1f;
            audioUI.value = ConfigManager.i.AudioSave;
        }
        if (postProcessingUI != null)
        {
            postProcessingUI.isOn = ConfigManager.i.PostProcessingSave;
            ConfigManager.i.SetPostProcessing(ConfigManager.i.PostProcessingSave);
        }

    }

    void Update()
    {
        if (audioUI.value != ConfigManager.i.AudioSave)
        {
            ConfigManager.i.SetAudio(audioUI.value);
        }
        if (postProcessingUI.isOn != ConfigManager.i.PostProcessingSave)
        {
            ConfigManager.i.SetPostProcessing(postProcessingUI.isOn);
        }
    }
}
