using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    private Vector3 direction;
    public float flyForce = 5f;
    public float maxAngle = 40;

    private Rigidbody2D rb;
    private GameManager gm;

    private Vector3 initPosition;

    private void Awake() {
        initPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gm = GetComponent<GameManager>();
    }

    private void OnEnable() {
        transform.position = initPosition;
    }
    
    // Update is called once per frame
    void Update() {
        Vector3 angle = transform.eulerAngles;
        angle.z += rb.velocity.y;
        angle.z = Mathf.Clamp(FixAngle(angle.z), - maxAngle, maxAngle);
        transform.eulerAngles = angle;
    }

    public void OnInputFly(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            rb.velocity = new Vector2(0, flyForce);
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Obstacle")) {
            gm.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Score")) {
            gm.IncreaseScore();
        }
    }

    private float FixAngle(float z) {
        float angleZ = z - 180;
        if (angleZ > 0) {
            angleZ -= 180;
        }
        else {
            angleZ += 180;
        }

        return angleZ;
    }
    
}