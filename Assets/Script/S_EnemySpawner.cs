using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemyPrefab;
    public Vector2 spawnRateBorn = new Vector2(1, 5);
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            Debug.Log("Entrain de spawn ...");
            yield return new WaitForSeconds(Random.Range(spawnRateBorn.x, spawnRateBorn.y));
            // prendre une position aléatoire sur la surface de l'objet
            Vector2 spawnPosition = new Vector2(Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2), transform.position.y);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Enemy spawned");
        }
    }
}
