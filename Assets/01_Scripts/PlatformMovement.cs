using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	//[SerializeField] private 
	public float platformSpeed = 1f;
	//private Platform[] platforms;
	[SerializeField] private float RestartPos = -64f;
	[SerializeField] private float ResetPos = 24.2f;

	// Use this for initialization
	void Start () {
		//platforms = FindObjectsOfType<Platform>();

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
	}
}
