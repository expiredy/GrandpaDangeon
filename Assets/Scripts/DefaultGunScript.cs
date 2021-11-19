using UnityEngine;

public class DefaultGunScript : MonoBehaviour
{
    public GameObject playerParentObject;
    public Transform FiringShootPlaceTransform;
    
    private bool isShootingIsAvaliable;
    
    private MainPlayerMovement _playerMovementController;

    public float explodeForce, explodeRadius;
    
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

    private void ShotInputChecker()
    {
        this.isShootingIsAvaliable = Input.GetMouseButtonDown(0);
    }

    private void MakeShot()
    {
        if (this.isShootingIsAvaliable)
        {
            RaycastHit2D hitDetector = Physics2D.Raycast(this.FiringShootPlaceTransform.position,
                FiringShootPlaceTransform.TransformDirection(Vector2.right), 50f);
            this._playerMovementController.moveByExplode(hitDetector.point, explodeForce, explodeRadius);
        }
    }
}