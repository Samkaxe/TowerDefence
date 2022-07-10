using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitpoints = 5;
    [Tooltip("Adds amount to maxHitPoint when enemy dies")]
    [SerializeField] private int DifficultyRamp = 1;
    [SerializeField] int currentHitPoints = 0;

    private Enemy enemy;

     void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = maxHitpoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        processHit();

    }

    void processHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
           
            gameObject.SetActive(false);
            maxHitpoints += DifficultyRamp;
            enemy.RewardGold();
        }
    }
}
