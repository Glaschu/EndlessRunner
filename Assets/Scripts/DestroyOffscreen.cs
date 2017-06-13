using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour {

	public float offset=16f;
	private bool offScreen;
	private float offScreenX=0;
	private Rigidbody2D body2d;
	// Use this for initialization
	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		offScreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits)/2+offset;
	}
	
	// Update is called once per frame
	void Update () {
		var posX = transform.position.x;
		var dirX = body2d.velocity.x;

		if (Mathf.Abs (posX) > offScreenX) {
			if (dirX < 0 && posX < -offScreenX) {
				offScreen = true;
			
			} else if (dirX > 0 && posX > offScreenX) {
				offScreen = true;
			}
		
		} else {
			offScreen = false;
		}

		if (offScreen) {
		
			OnOutOfBounds ();
		}
	}

	public void OnOutOfBounds (){

		offScreen = false;
		GameObjectUtil.Destroy (gameObject);
	
	}
}
