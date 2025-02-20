using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBug : MonoBehaviour
{
    public GameObject mosquito;
    public Vector3 spawnZone;
    public float spawnTime;
    bool canSpawn = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn) StartCoroutine(Spawn());
    }

    // Coroutine to spawn a mosquito
    IEnumerator Spawn()
    {
        canSpawn = false;
        Vector3 position = transform.position + new Vector3(Random.Range(spawnZone.x / 2, -spawnZone.x / 2), Random.Range(spawnZone.y / 2, -spawnZone.y / 2), Random.Range(spawnZone.z / 2, -spawnZone.z / 2));
        Instantiate(mosquito, position, Quaternion.identity);
        BugStats.SpawnedBug();

        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }

    // Visualize spawn zone
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new(1, 1, 1, 0.5f);
        Gizmos.DrawCube(transform.position, spawnZone);
    }
}
