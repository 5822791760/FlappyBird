using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rg;
    public float jumpPow = 3;
    public bool isGameOver = false;
    public AudioSource jumpSound;
    public AudioSource crashSound;
    public AudioSource fallSound;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -8.75f || transform.position.y >= 8.75)
        {
            isGameOver = true;
        }

        if (isGameOver == true)
        {
            transform.rotation *= Quaternion.Euler(0, 0, -15);
        }
    }

    public void Jump()
    {
        if (isGameOver == false)
        {
            jumpSound.Play();
            rg.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && isGameOver == false)
        {
            crashSound.Play();
            isGameOver = true;
            rg.velocity = new Vector2(1, 10);
            rg.gravityScale = 5;
            fallSound.Play();
        }
    }
}
