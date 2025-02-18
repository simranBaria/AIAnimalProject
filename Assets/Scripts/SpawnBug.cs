using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBug : MonoBehaviour
{
    public GameObject mosquito;
    public Vector3 spawnZone;
    public float spawnTime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeCycle.isNight)
        {
            if (timer <= 0)
            {
                Vector3 position = transform.position + new Vector3(Random.Range(spawnZone.x / 2, -spawnZone.x / 2), Random.Range(spawnZone.y / 2, -spawnZone.y / 2), Random.Range(spawnZone.z / 2, -spawnZone.z / 2));
                Instantiate(mosquito, position, Quaternion.identity);
                timer = spawnTime;
            }
            else timer -= Time.deltaTime;
        }
    }

    // Visualize spawn zone
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new(1, 1, 1, 0.5f);
        Gizmos.DrawCube(transform.position, spawnZone);
    }
}
