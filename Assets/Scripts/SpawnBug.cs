using System.Collections;
using UnityEngine;

public class SpawnBug : MonoBehaviour
{
    public GameObject mosquito;
    public Vector3 spawnZone;
    public float spawnTime;

    bool canSpawn = true;

    void Update()
    {
        // Spawn a bug if cooldown is done
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn) StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        // Spawn a bug at a random location within the zone
        canSpawn = false;
        Vector3 position = transform.position + new Vector3(Random.Range(spawnZone.x / 2, -spawnZone.x / 2), Random.Range(spawnZone.y / 2, -spawnZone.y / 2), Random.Range(spawnZone.z / 2, -spawnZone.z / 2));
        Instantiate(mosquito, position, Quaternion.identity);

        // Update stats
        BugStats.SpawnedBug();

        // Spawn cooldown
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }
}
