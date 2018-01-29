using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    PlayerModel _playerModel;
    PlayerView _playerView;

    void Start()
    {
        _playerModel = Application.ModelRoot.GetComponent<PlayerModel>();
        _playerView = 
            Application.ViewRoot.GetComponentInChildren<PlayerView>();
    }

    public void ProcessFire()
    {
        if (!_playerModel.CanShoot) return;

        _playerModel.CanShoot = false;
        
        Invoke("SetCanShootToTrue", _playerModel.Cooldown);
        
        FireFromMuzzle(_playerModel.Muzzle1);
        FireFromMuzzle(_playerModel.Muzzle2);
    }

    private void SetCanShootToTrue()
    {
        _playerModel.CanShoot = true;
    }

    private void FireFromMuzzle(Transform muzzle)
    {
        Instantiate(
            _playerModel.BulletPrefab,
            muzzle.position,
            muzzle.rotation);
    }

    public void ProcessMovement(bool isMovingUp)
    {
        Vector3 deltaPos = Vector3.zero;
        deltaPos.y += 
            _playerModel.PlayerSpeed *
            Time.deltaTime *
            (isMovingUp ? -1 : 1);
        
        _playerModel.Position += _playerModel.Rotation * deltaPos;
        _playerView.UpdateView();
    }

    public void ProcessRotation(bool isRotatingLeft)
    {
        float deltaRotation = _playerModel.Rotation.eulerAngles.z;

        if (Input.GetAxis("Horizontal") > 0)
        {
            deltaRotation -= _playerModel.RotationSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            deltaRotation += _playerModel.RotationSpeed * Time.deltaTime;
        }

        _playerModel.Rotation = Quaternion.Euler(0, 0, deltaRotation);
        _playerView.UpdateView();
    }
}
