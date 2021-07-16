using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyPrefab : MonoBehaviour
{
    [Header("Set")]
    public int spawIndex;
    public List<PrefabSave> saveList;

    private SpawManager spawManager;

    void Start()
    {
        spawManager = GetComponent<SpawManager>();
        SetPrefab();
    }

    public void SetPrefab()
    {
        // for (int i = 0; i < saveList.Count; i++)
        // {
        //     if (saveList[i].difficulty == SpawManager.i.currentDifficulty)
        //     {
        //         spawManager.spawItems[spawIndex].items[i] = saveList[i].prefab;
        //     }
        // }
    }

    [System.Serializable]
    public struct PrefabSave
    {
        public GameObject prefab;
        public SpawManager.Difficulty difficulty;
    }
}
