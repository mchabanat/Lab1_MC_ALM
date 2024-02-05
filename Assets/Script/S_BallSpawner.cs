using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    [SerializeField] private float spawnTime = 1f;

    private GameObject actualBall;
    private bool isSpawned = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (actualBall == null && !isSpawned)
        {
            StartCoroutine(SpawnBall());
        }
        else if (actualBall != null && actualBall.GetComponent<S_BallShot>().getIsShot() == true)
        {
            actualBall = null;
            isSpawned = false;
        }
    }

    IEnumerator SpawnBall()
    {
        isSpawned = true;
        Debug.Log("En train de spawn ....");
        yield return new WaitForSeconds(spawnTime);
        Debug.Log("Spawned");
        actualBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        
    }
}
