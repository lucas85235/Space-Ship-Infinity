using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private void Start()
    {
        ConfigManager.i.SetAudio(ConfigManager.i.AudioSave);
    }
}
