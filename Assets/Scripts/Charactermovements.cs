using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermovements : MonoBehaviour
{

    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("movx", Input.GetAxis("Horizontal"));
        anim.SetFloat("movz", Input.GetAxis("Vertical"));
    }
}
