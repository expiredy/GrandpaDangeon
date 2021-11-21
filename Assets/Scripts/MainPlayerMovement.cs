using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{

	[SerializeField] Camera mainUsingCamera;

	[SerializeField] LayerMask groundLayer;

	//Aiming and looking variables 
	private Vector2 mouseAimingVector;
	private float angleForAiming;

	private bool _isOnGround;

	//movement params
	private const int _totalCountOfImpulses = 2;
	private const float _impulseIterationForce = 0.5f;
	private const float _impuleseDefaultForceMultiplayer = 1f;
	private const float _recoilImpulseMultiplayer = 0.2f;

	//Components links
	private Rigidbody2D _playerRigidbody2DComponent;

	void Awake()
	{
		this._playerRigidbody2DComponent = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		this.MouseInputDetection();
	}

	void FixedUpdate()
	{
		this.CounterMovement();
	}


	private void OnCollisionEnter2D(Collision2D other)
    {
	    int layerIndex = other.gameObject.layer;
	    _isOnGround = groundLayer == (groundLayer | (1 << layerIndex));

    }

    private void OnCollisionExit2D(Collision2D other)
    {
	    int layerIndex = other.gameObject.layer;
	    _isOnGround = groundLayer != (groundLayer | (1 << layerIndex));
    }
	
	private void MouseInputDetection(){
		this.mouseAimingVector = mainUsingCamera.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
		
	}

	public float GetAngleForAiming(){
		return Vector2.SignedAngle(Vector2.right, this.mouseAimingVector);
	}
	
	public void moveByRecoil(Vector3 targetPositionOfBullet, float bulletSpeed){
		this._playerRigidbody2DComponent.AddForce((targetPositionOfBullet.normalized * bulletSpeed * _recoilImpulseMultiplayer),
			ForceMode2D.Impulse);
	}
	
	public void moveByExplode(Vector3 positionOfForceApplication, float explosionForce, float explosionRadius){
		float wearoff = 1 - (positionOfForceApplication.magnitude / explosionRadius);
        for (int myltiplayerOfForces = 0; myltiplayerOfForces < _totalCountOfImpulses; myltiplayerOfForces++){
	        this._playerRigidbody2DComponent.AddForce((positionOfForceApplication.normalized * explosionForce * wearoff) *
	                                                  (_impuleseDefaultForceMultiplayer + _impulseIterationForce * 
													   myltiplayerOfForces), ForceMode2D.Impulse);
        }
    }
	 
	private void CounterMovement(){
		
	}
}