using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {

	private PlayerModel _playerModel;
    private PlayerController _playerController;

	// Use this for initialization
	void Start () {
		_playerModel = Application.ModelRoot.GetComponent<PlayerModel> ();
        _playerController = Application.ControllerRoot.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessMovement();
        ProcessFire();
	}

    private void ProcessFire()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _playerController.ProcessFire();
        }
    }

	void ProcessMovement()
	{
        if (Input.GetAxis("Horizontal") > 0)
        {
            _playerController.ProcessRotation(true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _playerController.ProcessRotation(true);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            _playerController.ProcessMovement(true);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            _playerController.ProcessMovement(false);
        }
	}

    public void UpdateView()
    {
        transform.position = _playerModel.Position;
        transform.rotation = _playerModel.Rotation;
    }
}
