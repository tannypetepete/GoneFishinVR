using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Fish;
    public Transform Spawner;
    public int spawnRateMin, spawnRateMax;

    // Start is called before the first frame update
    void Start()
    {
        Spawner = gameObject.transform;
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator waiter()
    {
        int wait_time = Random.Range(spawnRateMin, spawnRateMax);
        yield return new WaitForSeconds(wait_time);
        Instantiate(Fish, Spawner.transform.position, Spawner.transform.rotation);
        StartCoroutine(waiter());
    }
}
