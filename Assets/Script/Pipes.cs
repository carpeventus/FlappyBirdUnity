using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Start is called before the first frame update
    private float leftEdge;
    public float moveSpeed = 5f;
    void Start() {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    // Update is called once per frame
    void Update() {
        transform.position += (Time.deltaTime * moveSpeed * Vector3.left);
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}
