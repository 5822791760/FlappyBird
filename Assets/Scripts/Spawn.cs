using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //For Different file use

    //For Editor
    [SerializeField] private GameObject pipe;

    //For in file Component
    private PlayerControl pScript;

    //For in file variable


    void Start()
    {
        InvokeRepeating("Spawner", 1, 2.5f);
        pScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawner()
    {
        if (pScript.isGameOver == false)
        {
            Instantiate(pipe, new Vector3(10, Random.Range(-1, 1) * 2.5f, 0), Quaternion.identity);
        }
    }
}
