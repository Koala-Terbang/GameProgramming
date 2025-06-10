using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float jetpackForce = 3f;
    private Rigidbody2D rb;
    private Animator anim;
    private RestartMenu restartMenu;
    private bool isDead = false;
    private AudioSource jetpackAudio;
    private float maxFuel = 100f;
    private float fuelRechargeRate = 10f;
    private float fuelConsumptionRate = 45f;
    private float currentFuel;
    public Slider fuelBar;
    private bool isFlying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        restartMenu = FindObjectOfType<RestartMenu>();
        jetpackAudio = GetComponent<AudioSource>();
        currentFuel = maxFuel;
        fuelBar.maxValue = maxFuel;
        fuelBar.value = currentFuel;
    }

    void Update()
    {
        if (isDead) return;

        transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);

        isFlying = Input.GetButton("Jump") && currentFuel > 15f;

        if (isFlying)
        {
            currentFuel -= fuelConsumptionRate * Time.deltaTime;
            currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);

            if (!jetpackAudio.isPlaying)
            {
                jetpackAudio.Play();
            }
        }
        else
        {
            currentFuel += fuelRechargeRate * Time.deltaTime;
            currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);

            if (jetpackAudio.isPlaying)
            {
                jetpackAudio.Stop();
            }
        }

        anim.enabled = !isFlying;
        fuelBar.value = currentFuel;
    }

    void FixedUpdate()
    {
        if (isDead) return;

        if (isFlying)
        {
            rb.AddForce(Vector2.up * jetpackForce, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.down, ForceMode2D.Force);
        }
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
        jetpackAudio.Stop();
        restartMenu.ShowGameOverUI();
    }
}
