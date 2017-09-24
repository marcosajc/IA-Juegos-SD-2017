using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : AgentMeta {

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		this.linear = (movement * maxSpeed);
	}

	// Renderización de frames para poder identificar la velocidad del objeto.
	void LateUpdate(){

		print (getVelocity ().sqrMagnitude);

		if (getVelocity ().sqrMagnitude < .5 * maxSpeed)
			this.GetComponent<SpriteRenderer> ().sprite = shipSprite [3];

		else if (getVelocity ().sqrMagnitude >= .5 * maxSpeed && getVelocity ().sqrMagnitude < maxSpeed)
			this.GetComponent<SpriteRenderer> ().sprite = shipSprite [1];

		else
			this.GetComponent<SpriteRenderer> ().sprite = shipSprite [0];

	}

}