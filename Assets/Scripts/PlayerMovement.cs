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
        if (isDead) return;

        transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);

        bool isFlying = Input.GetButton("Jump");
        if (isFlying)
        {
            rb.AddForce(Vector2.up * jetpackForce);
        }
        else
        {
            rb.AddForce(Vector2.down);
        }

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
        isDead = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        restartMenu.ShowGameOverUI();
    }
}
