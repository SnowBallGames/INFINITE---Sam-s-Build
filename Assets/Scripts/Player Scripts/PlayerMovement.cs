using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public GameObject Trails;
	public GameObject raySpawn;
	private bool jump;
	private bool falling;
	private bool sprinting;
	public bool grounded;
	public bool fire;
	private float inputSpeed;
	public float grounddistance;
	public float run = 2;
	public float jumpPower = 100;
	public float movementspeed = 100; 

	Animator animator;
	Collider FootCollider;





	void Start ()
	
	{
			//Gets Animator Component 
			animator = GetComponent<Animator>();

	}








	void Update () {

		RaycastHit Hit;
		Debug.DrawRay(transform.position, Vector3.down, Color.blue);
		if (Physics.Raycast (raySpawn.transform.position, -transform.up, out Hit, 1f)) 
		{

		
		}


		 if (Physics.Raycast (raySpawn.transform.position, -transform.up, out Hit, grounddistance)) {
		
		//grounded
			grounded = true;
			animator.SetBool ("grounded", grounded);
		animator.SetBool ("jump", !grounded); 
		
		
	} 
	
		if (!Physics.Raycast (raySpawn.transform.position, -transform.up, out Hit, 0.7f)) 
	{
		animator.SetBool ("grounded", grounded);
		//Un-Grounded
		grounded = false;
		
	}



			//if sprinting Set Animator Bool as true
		{if (Input.GetKeyDown(KeyCode.LeftShift)){

				animator.SetBool ("sprinting", !sprinting);
				Trails.SetActive(true);}
		
			{if (Input.GetKeyUp(KeyCode.LeftShift)){
				
					animator.SetBool ("sprinting", sprinting); 
					Trails.SetActive(false);}

				{
					float h = Input.GetAxis ("Horizontal");
					float v = Input.GetAxis ("Vertical");

					animator.SetFloat("Speed", h*h+v*v);
					animator.SetFloat("Horizontal", h);
					animator.SetFloat("Vertical", v);
				}

	
		{

					if(jump ==true)
					{grounded = false;}

		

		
					if (Input.GetKey (KeyCode.A)) 
						transform.Translate (Vector3.left * movementspeed * Time.deltaTime);	
		
					if (Input.GetKey (KeyCode.D))
						transform.Translate (Vector3.right * movementspeed * Time.deltaTime);
	
					if (Input.GetKey (KeyCode.W))		
						transform.Translate (Vector3.forward * movementspeed * Time.deltaTime);
		
					if (Input.GetKey (KeyCode.S)) 
						transform.Translate (-Vector3.forward * movementspeed * Time.deltaTime);		
		
					if (Input.GetKey (KeyCode.W)) {
						if (Input.GetKey (KeyCode.LeftShift))
							transform.Translate (Vector3.forward * run * Time.deltaTime);}

					if(Input.GetKey(KeyCode.Mouse0)){
							fire = true;
							Debug.Log("Attacking");
							animator.SetBool("Attacking", fire);}
						
					else
					{
							
						fire = false;

					}
					{
				//jumping script ( If hes grounded add force of (JumpPower Varibale) upwards 
					if (grounded == true) {
					if (Input.GetKeyDown (KeyCode.Space)){
						rigidbody.AddForce (0, jumpPower * 100, 0); }}
					{
				//if player hits space bar sets the animator bool to jumping
						if(grounded == true){
						if(Input.GetKeyDown(KeyCode.Space))
						{ animator.SetBool ("jump", grounded);
						
								}
			     
							}
		     
						}
	     
					}
      
				}
	
			}

		}
	}
}
