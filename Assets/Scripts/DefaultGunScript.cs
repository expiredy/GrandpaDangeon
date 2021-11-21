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
    
    [Range(0f, 0.5f)] public float maxRandomizeShootingRange = 0f; 
    
    [SerializeField] public GameObject bulletPrefabObject;
    
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
        this.isShootingIsAvaliable = Input.GetMouseButton(0);
    }
    private void MakeShot()

    {
        if (this.isShootingIsAvaliable && isGunReloaded)
        {
            
            isGunReloaded = false;
            RaycastHit2D hitDetector = Physics2D.Raycast(this.FiringShootPlaceTransform.position,
                                       FiringShootPlaceTransform.TransformDirection(Vector2.right), 50f);
            Debug.DrawLine(this.FiringShootPlaceTransform.position, hitDetector.point, Color.green, 5, false);
            this.createVisualShot(new Vector2(this.FiringShootPlaceTransform.position.x,
                this.FiringShootPlaceTransform.position.y) - hitDetector.point);   
            StartCoroutine(ShotsRecoile());
        }
    }

    private void createVisualShot(Vector2 endShotPoint)
    {
        GameObject currentBullet = Instantiate(bulletPrefabObject);
        currentBullet.transform.position = new Vector3(this.FiringShootPlaceTransform.position.x,
														this.FiringShootPlaceTransform.position.y, 0);
        currentBullet.transform.rotation = this.transform.rotation;
        currentBullet.GetComponent<BulletBehavior>().StartMoving(endShotPoint.normalized,
                                                            this.bulletSpeed, this._playerMovementController,
																 this.explodeForce, this.explodeRadius);

    }

    IEnumerator ShotsRecoile()
    {
        yield return new WaitForSeconds(reloadTime);
        isGunReloaded = true;
    }
}