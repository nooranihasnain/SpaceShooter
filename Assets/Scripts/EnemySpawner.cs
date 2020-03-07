using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private BoxCollider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        InvokeRepeating("SpawnEnemy", 0f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 RandomPos;
        RandomPos = new Vector2(Random.Range(-3f, 3f), 0f);
        RandomPos = transform.TransformPoint(RandomPos * 0.5f);
        Instantiate(EnemyPrefab, RandomPos, Quaternion.identity);
    }
}
