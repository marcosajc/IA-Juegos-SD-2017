using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SteeringOutput;

public class Pursue : Behaviour {

	public Pursue () : base ("Pursue") {}
	public Pursue ( float MaxPrediction ) : base ( "Pursue", MaxPrediction) {}

	public override SteeringOutput.SteeringOutput getSteering(){

		Vector2 direction = Target.getPosition () - Character.getPosition ();
		float distance = direction.sqrMagnitude;

		float speed = Character.getVelocity ().sqrMagnitude;

		float prediction;
		if (speed <= distance / maxPrediction)
			prediction = maxPrediction;
		else
			prediction = distance / maxPrediction;

		AgentMeta dummy = new AgentMeta ( new Vector2( 0.0f, 0.0f) + Target.getVelocity() * prediction );

		Behaviour seek = new Seek( dummy, Character);
		SteeringOutput.SteeringOutput steering = seek.getSteering();
		
		return steering;

	}

}
