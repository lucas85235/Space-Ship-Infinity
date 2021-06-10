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
    private int currentLife;
    
    [Header("Die Event")]
    public UnityEvent OnDie;
    private List<GameObject> toDisableOnDie;

    [Header("Revive Event")]
    public UnityEvent OnRevive;

    private DamageLayer isPlayer;

    void Start()
    {
        isPlayer = tag == "Player" ? DamageLayer.Player : DamageLayer.Enemy;
        
        if (isPlayer == DamageLayer.Player)
        {
            toDisableOnDie = new List<GameObject>();

            for (int i = 1; i < transform.childCount; i++)
            {
                toDisableOnDie.Add(transform.GetChild(i).gameObject);
            }            
        }

        if (OnDie == null)
            OnDie = new UnityEvent();

        if (OnRevive == null)
            OnRevive = new UnityEvent();

        currentLife = maxLife;

        if (lifeBar != null)
        {
            lifeBar.maxValue = maxLife;
            lifeBar.value = maxLife;            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shild")
        {
            var damage = other.GetComponent<Damage>();
            SetLife(-damage.damage);

            if (damage.canDestroy)
                Destroy(other.gameObject);
        }
        
        else if (other.tag == "Damage")
        {
            var damage = other.GetComponent<Damage>();

            if (damage.damageLayer == isPlayer)
            {
                SetLife(-damage.damage);

                if (damage.canDestroy)
                    Destroy(other.gameObject);
            }
        }

        else if (other.tag == "Player")
        {
            SetLife(-maxLife);
        }
    }

    public void SetLife(int increment)
    {
        currentLife += increment;

        if (currentLife > maxLife) 
            currentLife = maxLife;

        if (currentLife < 1)
        {
            this.enabled = false;
            ToDisableOnDie(false);
            OnDie.Invoke();
        }

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

        this.enabled = true;
        ToDisableOnDie(true);
        OnRevive.Invoke();
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
