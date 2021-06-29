using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{
    private List<Transform> spawPoints;

    [Header("Spaw Setup")]
    public float startTime = 2f;
    public float repeatTime = 1f;
    public List<Item> spawItems;
    public Item powerUps;

    [Header("Debug")]
    public Difficulty currentDifficulty = Difficulty.Easy;

    public static SpawManager i;

    void Awake()
    {
        i = this;
    }

    void Start()
    {
        spawPoints = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            spawPoints.Add( transform.GetChild(i) );
        }

        InvokeRepeating("Spaw", startTime, repeatTime);
    }

    public void Spaw()
    {
        var r = Random.Range(0, spawPoints.Count);

        foreach (var item in spawItems)
        {
            if (item.items.Count > 0)
            {
                if (item.spawChance > Random.Range(0f, 1f))
                {
                    var rItem = Random.Range(0, item.items.Count);
                    Instantiate(item.items[rItem], spawPoints[r].position, Quaternion.identity);
                    return;
                }                
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
    
    [System.Serializable]
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
    }

    [System.Serializable]
    public struct Item
    {
        public List<GameObject> items;

        [Range(0f, 1f)]
        public float spawChance;
    }
}
