using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMusicControl : MonoBehaviour
{
    private PlayerControl pScript;
    [SerializeField] private AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        pScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pScript.isGameOver == true)
        {
            bgm.Stop();
        }
    }
}
