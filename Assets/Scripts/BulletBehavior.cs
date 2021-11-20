using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Vector3 _targetEndPoint;
    private float _bulletSpeed;
	private float _explodeForce, _explodeRadius;    


    private MainPlayerMovement charecterControllerComponent;
    
    void Awake()
    {
        this._targetEndPoint = Vector3.zero;
        this._bulletSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += this._targetEndPoint * this._bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		print("aa");
		this.charecterControllerComponent.moveByExplode(this.transform.position, _explodeForce, _explodeRadius);
        this.charecterControllerComponent.moveByRecoil(this.transform.position);
        Destroy(this.gameObject);
    }
    
    public void StartMoving(Vector3 endPoint, float speedParam, MainPlayerMovement charecterController,
							float explodeForce, float explodeRadius)
    {
        this._targetEndPoint = endPoint;
        this._bulletSpeed = speedParam;
		this.charecterControllerComponent = charecterController;
		this._explodeForce = explodeForce;
		this._explodeRadius = explodeRadius;
       
    }
}
