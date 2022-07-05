using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    //For Different file use


    //For Editor
    [SerializeField] private float speed = 4;

    //For in file Component
    private PlayerControl pScript;

    //For in file variable


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
