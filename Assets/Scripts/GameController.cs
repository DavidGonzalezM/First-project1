using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text currentTime;
    public Text betterTime;
    public Vector3 initialPos;
    public GameObject player;
    private float time;
    private float better;

	void Start ()
    {
        time = 0;
        better = 0;
        currentTime.text = "";
        betterTime.text = "";
    }
	
	void Update ()
    {
        time += Time.deltaTime;
        currentTime.text = "Time: " + Mathf.RoundToInt(time).ToString();
        betterTime.text = "Better Time: " + Mathf.RoundToInt(better).ToString();
    }

    public void EndGame()
    {
        player.transform.position = initialPos;
        if (time < better || better == 0) better = time;
        time = 0;
    }
}
