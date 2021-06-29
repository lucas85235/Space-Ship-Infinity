using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShipLife : MonoBehaviour
{
    [Header("Life")]
    public int maxLife = 100;
    public Slider lifeBar;
    public bool initLifeBar = true;
    private int currentLife;
    
    [Header("Audio")]
    public AudioClip audioDestroy;
    public AudioClip audioHit;
    private AudioSource m_audioSource;

    [Header("Die Event")]
    public UnityEvent OnDie;
    private List<GameObject> toDisableOnDie;

    [Header("Revive Event")]
    public UnityEvent OnRevive;

    public bool isAlive { get; private set; }

    private DamageLayer isPlayer;
    private Collider2D m_Collider;

    void Start()
    {
        m_Collider = GetComponent<Collider2D>();
        m_audioSource = GetComponent<AudioSource>();

        isPlayer = tag == "Player" ? DamageLayer.Player : DamageLayer.Enemy;
        
        if (isPlayer == DamageLayer.Player)
        {
            toDisableOnDie = new List<GameObject>();

            for (int i = 1; i < transform.childCount; i++)
            {
                toDisableOnDie.Add(transform.GetChild(i).gameObject);
            }            
        }

        if (!initLifeBar) 
            return;

        currentLife = maxLife;

        if (lifeBar != null)
        {
            lifeBar.maxValue = maxLife;
            lifeBar.value = maxLife;            
        }

        isAlive = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shild")
        {
            var damage = other.GetComponent<Damage>();
            SetLife(-damage.damage);

            if (damage.destroy) Destroy(other.gameObject);
        }
        
        else if (other.tag == "Damage")
        {
            var damage = other.GetComponent<Damage>();

            if (damage.damageLayer == isPlayer)
            {
                SetLife(-damage.damage);
            }

            if (damage.destroy) Destroy(other.gameObject);
        }

        else if (other.tag == "Player")
        {
            SetLife(-maxLife);
        }
    }

    public void SetLife(int increment)
    {
        if (!isAlive) return;

        currentLife += increment;

        if (currentLife > maxLife) 
            currentLife = maxLife;

        if (currentLife < 1)
        {
            isAlive = false;
            m_Collider.enabled = false;
            this.enabled = false;
            ToDisableOnDie(false);
            lifeBar.gameObject.SetActive(false);
            OnDie?.Invoke();

            if (isPlayer == DamageLayer.Player)
            {
                GameManager.i.GameOver();
            }
        }
        
        if (audioHit != null && audioDestroy != null && !m_audioSource.isPlaying)
            m_audioSource.PlayOneShot( isAlive ? audioHit : audioDestroy);       

        if (lifeBar != null)
            lifeBar.value = currentLife;
    }

    public void Revive(float time)
    {
        Invoke("Revive", time);
    }

    private void Revive()
    {
        currentLife = maxLife;

        if (lifeBar != null)
        {
            lifeBar.maxValue = maxLife;
            lifeBar.value = maxLife;            
        }

        isAlive = true;
        m_Collider.enabled = true;
        this.enabled = true;
        ToDisableOnDie(true);
        lifeBar.gameObject.SetActive(true);
        OnRevive?.Invoke();
    }

    public void ToDisableOnDie(bool state)
    {
        if (toDisableOnDie == null || toDisableOnDie.Count == 0) 
            return;
        
        foreach (var item in toDisableOnDie)
        {
            item.SetActive(state);
        }
    }

    public void DestroyThis(float time)
    {
        Destroy(this.gameObject, time);
    }
}
