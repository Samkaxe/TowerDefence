using System;
using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField][Range(0.1f , 30f)] float spawnTimer = 1f;
    [SerializeField][Range(0.1f , 50f)] int poolSize = 5;

    private GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }
    

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectinPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectinPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
    
}
