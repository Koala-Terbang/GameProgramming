using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float jetpackForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private RestartMenu restartMenu;

    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        restartMenu = FindObjectOfType<RestartMenu>();
    }

    void Update()
    {
        if (isDead) return; // Don’t do anything if dead

        // Move forward
        transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);

        // Flying
        bool isFlying = Input.GetButton("Jump");
        if (isFlying)
        {
            rb.AddForce(Vector2.up * jetpackForce);
        }
        else
        {
            rb.AddForce(Vector2.down);
        }

        // Toggle running animation
        anim.enabled = !isFlying;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        // Disable movement
        isDead = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true; // Freeze physics if needed
        
        // Show game over UI
        restartMenu.ShowGameOverUI();
    }
}
