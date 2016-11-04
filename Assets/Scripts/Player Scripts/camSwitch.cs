using UnityEngine;
using System.Collections;

public class camSwitch : MonoBehaviour {
	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	private bool Active1;
	private bool Active2;
	public float timer;

	// Use this for initialization
	void Start () {




		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
	
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

	if (Input.GetKey (KeyCode.Q)) {
			if (timer >= 1f){

			if (cam1.enabled == true) {

				cam1.enabled = false;
				cam2.enabled = true;
				cam3.enabled = true;
				timer = 0f;
			}

			else {
				
				cam2.enabled = false;
				cam1.enabled = true;
				cam3.enabled = false;
				timer = 0f;
			}
		}
    }
}
}
