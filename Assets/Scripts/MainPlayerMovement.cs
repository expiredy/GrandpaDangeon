using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{

	[SerializeField] Camera mainUsingCamera;
	//Aiming and looking variables 
    private Vector2 mouseAimingVector;
	private float angleForAiming;
	
	//Components links
	private Rigidbody2D playerRigidbodyComponent;
	
	// Start is called before the first frame update
    void Avake()
    {
    	this.playerRigidbodyComponent = this.GetComponent<Rigidbody2D>();    
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
	
	public void moveByExplode(){

	}
}
