using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermovements : MonoBehaviour
{

    Animator anim;
    public float velocidad_andar = 4.0F;
    public float velocidad_andar_lado = 4.0F;
    public float velocidad_correr = 2.0F;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = velocidad_andar;
        anim.SetFloat("movx", Input.GetAxis("Horizontal"));
        anim.SetFloat("movz", Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical") != 0 && !Input.GetKey(KeyCode.LeftShift))
            anim.speed = velocidad_andar;
        else if (Input.GetAxis("Horizontal") != 0)
            anim.speed = velocidad_andar_lado;
        else if (Input.GetAxis("Vertical") != 0 && !Input.GetKey(KeyCode.LeftShift))
            anim.speed = velocidad_correr;
        else
            anim.speed = 1.0F;
        if (Input.GetKeyDown(KeyCode.H))
            anim.SetBool("Dance", true);
        else if (Input.GetKeyUp(KeyCode.H))
            anim.SetBool("Dance", false);

    }
}
