using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	//[SerializeField] private 
	public float platformSpeed = 1f;
	//private Platform[] platforms;
	[SerializeField] private float RestartPos = -64f;
	[SerializeField] private float ResetPos = 24.2f;

	private float xPos, yPos,zPos;

	[SerializeField] private bool Rotateable = false;
	[SerializeField] private float rotSpeed = 2.0f;
	private float rotary;

	// Use this for initialization
	protected virtual void Start () {
		//platforms = FindObjectsOfType<Platform>();
		xPos = GetComponent<Transform>().localPosition.x;
		yPos = GetComponent<Transform>().localPosition.y;
		zPos = GetComponent<Transform>().localPosition.z;

		//rotary = GetComponent<Transform>();

	}

	// Update is called once per frame
	public virtual void Update ()
	{	
		if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
			transform.Translate (Vector3.left * -platformSpeed * Time.deltaTime);
			if (transform.localPosition.x >= ResetPos) {
				//print("Sent to back");
				transform.position = new Vector3 (RestartPos, transform.position.y, transform.position.z);
			}
		}

		if (Rotateable) {

				rotary += 1 + (rotSpeed*Time.deltaTime);
				transform.localRotation = Quaternion.Euler(0,rotary,0);
		}
	}

	public void OnReset ()
	{
		transform.localPosition = new Vector3(xPos,yPos,zPos);	
	}	

}
