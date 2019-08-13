using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoSpawner : MonoBehaviour {

   
    public float timeBetweenSpawns;

    public float spawnDistance;

    public Lego[] legoPrefabs;
    float timeSinceLastSpawn;

	void FixedUpdate () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= timeBetweenSpawns) {
			timeSinceLastSpawn -= timeBetweenSpawns;
			SpawnLego();
		}
    }
    void SpawnLego()
    {
       Lego prefab = legoPrefabs[Random.Range(0, legoPrefabs.Length)];
       Lego spawn = Instantiate<Lego>(prefab);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }
}
