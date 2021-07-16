using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager i;
    
    public void Awake()
    {
        i = this;
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
