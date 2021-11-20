using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{

	[SerializeField] Camera mainUsingCamera;
	//Aiming and looking variables 
    private Vector2 mouseAimingVector;
	private float angleForAiming;
	
	//movement params
	private const int _totalCountOfImpulses = 2;
	private const float _impulseIterationForce = 0.5f;
	private const float _impuleseDefaultForceMultiplayer = 1f;

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
    
    void OnCollisionEnter2D(Collision2D collision)
    {
	    print(collision.gameObject);
    }
	
	private void MouseInputDetection(){
		this.mouseAimingVector = mainUsingCamera.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
		
	}

	public float GetAngleForAiming(){
		return Vector2.SignedAngle(Vector2.right, this.mouseAimingVector);
	}
		
	public void moveByRecoil(Vector3 targetPositionOfBullet, float bulletSpeed){
		
	}
	
	public void moveByExplode(Vector3 positionOfForceApplication, float explosionForce, float explosionRadius){
        Vector2 directoryOfExplode = (this.transform.position - positionOfForceApplication);
        float wearoff = 1 - (directoryOfExplode.magnitude / explosionRadius);
		for (int myltiplayerOfForces = 0; myltiplayerOfForces < _totalCountOfImpulses; myltiplayerOfForces++){
        	this._playerRigidbody2DComponent.AddForce((directoryOfExplode.normalized * explosionForce * wearoff) *
													  (_impuleseDefaultForceMultiplayer + _impulseIterationForce * myltiplayerOfForces), ForceMode2D.Impulse);
		}
    }
	 
	private void CounterMovement(){
		
	}
}