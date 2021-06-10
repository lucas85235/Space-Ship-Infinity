using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBridge : MonoBehaviour
{
    public void AddScore(int i)
    {
        if (GameManager.i != null)
            GameManager.i.AddScore(i);
    }
}
