using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SteeringOutput;

public class Arrive : Behaviour {

	public Arrive () : base ("Arrive") {}

	public override SteeringOutput.SteeringOutput getSteering(){

		SteeringOutput.SteeringOutput steering = new SteeringOutput.SteeringOutput( new Vector2( 0.0f, 0.0f), 0.0f );

		Vector2 direction = Target.getPosition () - Character.getPosition ();
		float distance = direction.sqrMagnitude;

		if (distance < targetRadius)
			return steering;

		var targetSpeed = Character.maxSpeed;

		if (distance <= slowRadius)
			targetSpeed *= distance / slowRadius;

		var targetVelocity = direction.normalized * targetSpeed;

		steering.linear = targetVelocity - Character.getVelocity ();
		steering.linear /= timeToTarget;
	
		steering.angular = 0.0f;
		return steering;

	}

}
