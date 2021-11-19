using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGunScript : MonoBehaviour
{
    public GameObject playerParentObject;
    private MainPlayerMovement _playerMovementController;

    private bool isShootingIsAvaliable;
    
    void Start()
    {
        this._playerMovementController = this.playerParentObject.GetComponent<MainPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        this.RotateForAiming();
        this.ShotInputChecker();
    }

    void FixedUpdate()
    {
        this.MakeShot();
    }

    private void RotateForAiming()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0,
            this._playerMovementController.GetAngleForAiming()));
    }

    private ShotInputChecker()
    {
        this.isShootingIsAvaliable = Input.GetButtonDown("Fire1");
    }

    private MakeShot()
    {
        
    }

}
