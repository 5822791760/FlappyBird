using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 4;
    private PlayerControl pScript;

    // Start is called before the first frame update
    void Start()
    {
        pScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x <= -13)
        {
            Destroy(gameObject);
        }
    }
}
