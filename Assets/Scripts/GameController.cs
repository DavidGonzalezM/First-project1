using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text currentTime;
    private float time;

	void Start ()
    {
        time = 0;
        currentTime.text = "";
    }
	
	void Update ()
    {
        time += Time.deltaTime;
        currentTime.text = "Time: " + Mathf.RoundToInt(time).ToString();
    }
}
