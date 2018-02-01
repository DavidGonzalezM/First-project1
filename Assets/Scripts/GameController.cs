﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text currentTime;
    public Text betterTime;
    public GameObject player;

    private Vector3 _initialPos;
    private float _time;
    private float _better;

	void Start ()
    {
        _time = 0;
        _better = 0;
        currentTime.text = "";
        betterTime.text = "";
        _initialPos = player.transform.position;
        Cursor.visible = false;
    }
	
	void Update ()
    {
        _time += Time.deltaTime;
        currentTime.text = "Time: " + Mathf.RoundToInt(_time).ToString();
        betterTime.text = "Better Time: " + Mathf.RoundToInt(_better).ToString();
    }

    public void EndGame()
    {
        player.transform.position = _initialPos;
        if (_time < _better || _better == 0) _better = _time;
        _time = 0;
    }
    public void Die()
    {
        player.transform.position = _initialPos;
        _time = 0;
    }
}
