using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [Header("Setup")]
    public List<Sprite> sprites;

    private SpriteRenderer sRenderer;

    public void Start()
    {
        if (sprites.Count > 0)
        {
            sRenderer = GetComponent<SpriteRenderer>();
            sRenderer.sprite = sprites[ Random.Range(0, sprites.Count) ];
        }
    }
}
