using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {

	public float Speed = 100f; //Speed at which the reticle moves
	public float Range = 10f; //Range the reticle can move from the origin(player)
	private Vector3 defaultPos;
	private Vector3 newPos;
	
	void Start() {
		defaultPos = gameObject.transform.localPosition;
		newPos = gameObject.transform.localPosition;
	}
	
	void Update() {
		//Get RIGHT STICK control inputs
		newPos.x += Input.GetAxis("RJoystickX") * Speed * Time.deltaTime;
		newPos.y += Input.GetAxis("RJoystickY") * Speed * Time.deltaTime;

		gameObject.transform.localPosition = newPos;

		//Creates a Square clamp range
		newPos.x = Mathf.Clamp(newPos.x, -Range, Range);
		newPos.y = Mathf.Clamp(newPos.y, -Range, Range);

		//Creates a circle clamp range
		transform.position = Vector3.ClampMagnitude(new Vector3(defaultPos.x + newPos.x, defaultPos.y + newPos.y, defaultPos.y + newPos.y), Range);
	}
	
}
