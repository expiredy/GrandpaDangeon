using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{

	[SerializeField] Camera mainUsingCamera;
	//Aiming and looking variables 
    private Vector2 mouseAimingVector;
	private float angleForAiming;
	
	//Components links
	private Rigidbody2D _playerRigidbody2DComponent;
	
	// Start is called before the first frame update
    void Awake()
    {
    	this._playerRigidbody2DComponent = this.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
 		this.MouseInputDetection();       
    }

	void FixedUpdate(){
		
	}
	
	private void MouseInputDetection(){
		this.mouseAimingVector = mainUsingCamera.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
		
	}

	public float GetAngleForAiming(){
		return Vector2.SignedAngle(Vector2.right, this.mouseAimingVector);
	}
		
	public void moveByRecoil(){
	
	}
	
	public void moveByExplode(Vector3 positionOfForceApplication, float explosionForce, float explosionRadius){
        Vector2 directoryOfExplode = (this.transform.position - positionOfForceApplication);
        float wearoff = 1 - (directoryOfExplode.magnitude / explosionRadius);
        this._playerRigidbody2DComponent.AddForce(directoryOfExplode.normalized * explosionForce * wearoff, ForceMode2D.Impulse);
		print(directoryOfExplode.normalized * explosionForce * wearoff);
    }
}
