using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Header("Settings")]
    public float destroyTiming = 2f;

    void Start()
    {
        Destroy(this.gameObject, destroyTiming);
    }
}
