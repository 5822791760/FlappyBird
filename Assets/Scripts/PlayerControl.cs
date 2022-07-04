using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rg;
    public float jumpPow = 3;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            transform.rotation *= Quaternion.Euler(0, 0, -15);
        }
    }

    public void Jump()
    {
        if (isGameOver == false)
        {
            rg.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && isGameOver == false)
        {
            isGameOver = true;
            rg.velocity = new Vector2(1, 10);
            rg.gravityScale = 5;
        }
    }
}
