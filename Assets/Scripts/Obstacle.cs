using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IRecycle {

	public Sprite[] sprites;
	public Vector2 coliderOffset= Vector2.zero;

	// Use this for initialization
	public void Restart () {
		var renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites [Random.Range (0, sprites.Length)];

		var collider = GetComponent<BoxCollider2D> ();
		var size = renderer.bounds.size;
		size.y += coliderOffset.y;
		collider.size = size;
		collider.offset = new Vector2 (-coliderOffset.x, collider.size.y / 2 - coliderOffset.y);


	}
	
	// Update is called once per frame
	public void ShutDown () {
		
	}
}
