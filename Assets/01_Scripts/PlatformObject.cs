using UnityEngine;
using System.Collections;

public class PlatformObject : PlatformMovement {

	public float speed;

	public Vector3 topPosition;
	public Vector3 bottomPosition;
	public float switchTime;


	//[SerializeField] private bool Rotateable = false;
	//[SerializeField] private float rotSpeed = 2.0f;
	//private Vector3 rotary;
	//[SerializeField] private bool moveableObject = false;

	// Use this for initialization

	protected override void Start ()
	{
			StartCoroutine (AutonomousMovement (bottomPosition));
			base.Start();	
			//rotary = new Vector3 (0,1,0);
	}

	public override void Update ()
	{
		base.Update ();
		/*if (Rotateable) {
				rotary.y += rotSpeed * Time.deltaTime;
			transform.eulerAngles = rotary;
		}*/
	}

	IEnumerator AutonomousMovement (Vector3 target)
	{
		while (Mathf.Abs((target - transform.localPosition).y) > 0.2f){
			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * Time.deltaTime * speed;
			yield return null;
		}

		yield return new WaitForSeconds(switchTime);
		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;
		StartCoroutine(AutonomousMovement(newTarget));
	}


}
