using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour {
    public GameObject pipePrefab;

    public float spawnRate = 1f;
    public float minHeightOffset = -1f;
    public float maxHeightOffset = 1f;
    
    private void OnEnable() {
        InvokeRepeating(nameof(SpawnPipe), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(SpawnPipe));
    }

    private void SpawnPipe() {
        GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipe.transform.position += Vector3.up * Random.Range(minHeightOffset, maxHeightOffset);
    }
}

