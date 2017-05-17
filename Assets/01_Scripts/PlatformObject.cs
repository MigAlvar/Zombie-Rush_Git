using UnityEngine;
using System.Collections;

public class PlatformObject : PlatformMovement {

	public float speed;

	public Vector3 topPosition;
	public Vector3 bottomPosition;
	public float switchTime;

	//[SerializeField] private bool moveableObject = false;

	// Use this for initialization

	void Start ()
	{
			StartCoroutine (AutonomousMovement (bottomPosition));

		
	}

	public override void Update ()
	{
		base.Update();
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
