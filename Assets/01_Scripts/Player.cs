using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[SerializeField] private float jumpForce = 100f;
	[SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDeath;
	[SerializeField] private AudioClip sfxCoinUp;

	public Text scoreBoard;

	private Animator anim;
	private Rigidbody body;
	private bool jump = false;
	private float xPos, yPos, zPos,xRot,yRot,zRot;
	private AudioSource playerSnd;
	private int CoinCollect, TotalCoins;
	
	// Use this for initialization
	void Start ()
	{
		//PlayerObject
		anim = GetComponent<Animator> ();
		body = GetComponent<Rigidbody> ();
		//Sound
		playerSnd = GetComponent<AudioSource> ();
		//position
		xPos = GetComponent<Transform> ().localPosition.x;
		yPos = GetComponent<Transform> ().localPosition.y;
		zPos = 9.087905f;
		//rotation
		xRot = 0;
		yRot = -73.9f;
		zRot = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
			if (Input.GetMouseButtonDown (0)) {
				GameManager.instance.playerStartedGame();
				body.isKinematic = false;
				anim.Play ("Jump");
				playerSnd.PlayOneShot (sfxJump);
				body.useGravity = true;
				jump = true;
			}
		}
	}

	void FixedUpdate ()
	{
		if (jump) {
			jump = false;
			body.velocity = new Vector2(0,0);
			body.AddForce (new Vector2(0,jumpForce), ForceMode.Impulse);
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.GetComponentInParent<PlatformObject> ()) {
			body.AddForce (new Vector3 (50, 20, -10), ForceMode.Impulse);
			body.detectCollisions = false;
			playerSnd.PlayOneShot (sfxDeath);
			GameManager.instance.playerCollided ();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		Coin coin = other.gameObject.GetComponent<Coin> ();

		if (coin) {
			playerSnd.PlayOneShot(sfxCoinUp);
			CoinCollect += coin.coinAmount();
			//print("Coins Collected: " + CoinCollect);
		}

	}

	public void Reset(){
		body.useGravity = false;
		body.isKinematic  = true;
		transform.localPosition = new Vector3(xPos,yPos,zPos);
		transform.eulerAngles =  new Vector3(xRot,yRot,zRot);
		body.detectCollisions = true;
	}

	public void SessionScore(){
		scoreBoard.text= CoinCollect.ToString();
	}
}
