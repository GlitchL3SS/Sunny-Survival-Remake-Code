using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpAndDownFlip : MonoBehaviour
{
    public float floatStrength = 0.5f;
    public float floatSpeed = 2.0f;
    public Transform checkObject; // Reference to the object that triggers the flip

    private Vector3 startingPos;
    private bool facingRight = false; // Track facing direction
    // Sprite Renderer reference
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingPos = transform.position;
    }

    void Update()
    {
        // Calculate y movement using sine wave
        float yMovement = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = new Vector3(startingPos.x, startingPos.y + yMovement, startingPos.z);

        if (checkObject.transform.position.x < transform.position.x) {
            spriteRenderer.flipX = true;
            transform.rotation = Quaternion.Euler(0, 0, 7.15f);
        }
        else {spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, -7.15f);
        }
    }
}
