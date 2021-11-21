using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Vector3 _directionOfShot;
    private float _bulletSpeed;
	private float _explodeForce, _explodeRadius;    


    private MainPlayerMovement charecterControllerComponent;
    private Rigidbody2D _bulletRigidbody2D;
    
    void Awake()
    {
        this._bulletRigidbody2D = this.GetComponent<Rigidbody2D>();
        this._directionOfShot = Vector3.zero;
        this._bulletSpeed = 0f;
    }

    void Start()
    {
        Invoke(nameof(DistroyThis), 10.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.MoveBullet();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.charecterControllerComponent.moveByExplode(this._directionOfShot, _explodeForce, _explodeRadius);
        this.DistroyThis();
    }
    
    
    private void MoveBullet()
    {
        this._bulletRigidbody2D.AddForce(-this._directionOfShot  * this._bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }	
    
    public void StartMoving(Vector3 shotDirection, float speedParam, MainPlayerMovement charecterController,
							float explodeForce, float explodeRadius)
    {
        this._directionOfShot = shotDirection;
        this._bulletSpeed = speedParam;
		this.charecterControllerComponent = charecterController;
		this._explodeForce = explodeForce;
		this._explodeRadius = explodeRadius;
        this.MoveBullet();
        this.charecterControllerComponent.moveByRecoil(-this.transform.right, this._bulletSpeed);
    }

    private void DistroyThis()
    {
        Destroy(this.gameObject);
    }
}
