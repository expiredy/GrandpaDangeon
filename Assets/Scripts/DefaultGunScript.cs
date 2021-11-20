using System.Collections;
using UnityEngine;

public class DefaultGunScript : MonoBehaviour
{
    public GameObject playerParentObject;
    public Transform FiringShootPlaceTransform;
    
    private bool isShootingIsAvaliable, isGunReloaded=true;
    
    private MainPlayerMovement _playerMovementController;

    [SerializeField] public float explodeForce, explodeRadius;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public float reloadTime;

    [SerializeField] public GameObject bulletPrefab;
    
    void Start()
    {
        this._playerMovementController = this.playerParentObject.GetComponent<MainPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        this.RotateForAiming();
        this.ShotInputChecker();
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
        if (this.isShootingIsAvaliable && isGunReloaded)
        {
            isGunReloaded = false;
            RaycastHit2D hitDetector = Physics2D.Raycast(this.FiringShootPlaceTransform.position,
                                       FiringShootPlaceTransform.TransformDirection(Vector2.right), 50f);
            this._playerMovementController.moveByExplode(hitDetector.point, explodeForce, explodeRadius);
            StartCoroutine(ShotsRecoile());
        }
    }

    IEnumerator ShotsRecoile()
    {
        yield return new WaitForSeconds(reloadTime);
        isGunReloaded = true;
    }
}