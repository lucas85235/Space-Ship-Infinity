using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    private PostProcessVolume m_Volume;

    public static PostProcessingManager i;

    private void Awake()
    {
        i = this;
        m_Volume = GetComponent<PostProcessVolume>();
    }

    private void Start()
    {
        m_Volume.enabled = ConfigManager.i.PostProcessingSave;
    }

    public void SetPostProcessingActive(bool active)
    {
        m_Volume.enabled = active;
    }
}
