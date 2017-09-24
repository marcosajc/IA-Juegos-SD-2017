using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AgentMeta : MonoBehaviour {

	protected Sprite[] shipSprite;	// Sprites de las naves para la presentación

	protected Vector2 position; 	// Posición del objeto.
	protected float orientation; 	// Orientación del objeto.
	protected Vector2 velocity; 	// Velocidad lineal del objeto.
	protected float rotation;		// Velocidad de rotación del objeto.

	protected Vector2 linear;		// Aceleración lineal
	protected float angular;		// Aceleración angular

	public float maxSpeed;			// Maxima velocidad
	public float maxAcceleration;	// Maxima aceleración
	public float maxRotation;		// Máxima velocidad angular
	public float maxAngularAcceleration;	// Máxima aceleración angular

	public AgentMeta () {}

	public AgentMeta ( Vector2 Position ) {

		position = Position;

	}

	void Awake(){

		shipSprite = Resources.LoadAll<Sprite> ("Sprites/Spaceship");	// Cargamos las imagenes para ser usadas

	}

	void Start(){

		//character = GetComponent<GameObject> ();

		position = transform.position;
		orientation = transform.eulerAngles.z;
		fullStop();

	}

	void Update(){

		// Determina la posición/orientación de acuerdo a la velocidad en el momento.
		position += velocity * Time.deltaTime;
		orientation += rotation * Time.deltaTime;

		// Determina la velocidad linear/angular de acuerdo a la aceleración.
		velocity += linear * Time.deltaTime;
		rotation += angular * Time.deltaTime;

		// Determino el angulo de la orientación.
		orientation %= 360.0f;

		// Si de acuerdo al calculo supero la máxima velocidad, normalizo a la máxima velocidad
		if( velocity.sqrMagnitude > maxSpeed )
			velocity = velocity.normalized * maxSpeed;

		// Idem. para aceleración lineal
		if ( linear.sqrMagnitude > maxAcceleration )
			linear = linear.normalized * maxAcceleration;

		// Idem. para aceleración angular
		if  (angular > maxAngularAcceleration )
			angular = maxAngularAcceleration;

		// Cálculo éstetico para suavizar el movimiento del facing del agente.
		Vector2 dir = velocity;
		float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.position = position;

	}

	public void stop(){

		velocity = new Vector2 (0.0f, 0.0f);
		rotation = 0.0f;

	}

	public void fullStop(){

		stop ();
		linear = new Vector2 (0.0f, 0.0f);
		angular = 0.0f;

	}

	// Sets de las variables.

//	public void setPosition( Vector2 newPosition ){
//
//		position = newPosition;
//
//	}
//
//	public void setVelocity( Vector2 newVelocity ){
//
//		velocity = newVelocity;
//
//	}
//
//	public void setLinear( Vector2 newLinear ){
//
//		linear = newLinear;
//
//	}
//
//	public void setOrientation( float newOrientation ){
//
//		orientation = newOrientation;
//
//	}
//
//	public void setRotation( float newRotation ){
//
//		rotation = newRotation;
//
//	}
//
//	public void setAngular( float newAngular ){
//
//		angular = newAngular;
//
//	}

	// Gets de las variables.

	public Vector2 getPosition(){

		return position;

	}

	public Vector2 getVelocity(){

		return velocity;

	}

	public Vector2 getLinear(){

		return linear;

	}

	public float getOrientation(){

		return orientation;

	}

	public float getRotation(){

		return rotation;

	}

	public float setAngular(){

		return angular;

	}
		
}