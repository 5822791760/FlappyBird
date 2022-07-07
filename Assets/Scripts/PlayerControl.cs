using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    //For Different file use
    public bool isGameOver = false;
    public int score = 0;

    //For Editor
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource crashSound;
    [SerializeField] private AudioSource fallSound;
    [SerializeField] private AudioSource scoreSound;

    //For Infile Component
    private Rigidbody2D rg;
    private TextMeshProUGUI text;
    private TextMeshProUGUI Htext;

    //For Infile variable
    private float jumpPow = 45;


    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        text = GameObject.Find("Scoreboard").GetComponent<TextMeshProUGUI>();
        Htext = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        Htext.SetText("High Score: " + PlayerPrefs.GetInt("Highscore", 0).ToString());
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, 0, -5) * Time.deltaTime * 8, Space.Self);

        if (transform.position.y <= -8.75f || transform.position.y >= 8.75)
        {
            isGameOver = true;
        }

        if (isGameOver == true)
        {
            transform.rotation *= Quaternion.Euler(0, 0, -15);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isGameOver == false)
            {
                jumpSound.Play();
                rg.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
                transform.Rotate(new Vector3(0, 0, 25), Space.Self);
            }
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

        if (other.CompareTag("Score") && isGameOver == false)
        {
            score++;
            text.SetText(score.ToString());
            scoreSound.Play();
            if (score > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", score);
                Htext.SetText("High Score: " + score.ToString());
            }
        }

    }
}
