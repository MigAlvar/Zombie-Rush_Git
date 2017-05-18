using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;


	public GameObject Mainmenu;
	public GameObject GameOvermenu;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;
	private Player player;
	private PlatformMovement[] platforms;
	private PlatformObject[] objs;
	private AudioSource music;

	//Accessors
	public bool PlayerActive{
		get {return playerActive;}
	}

	public bool GameOver{
		get {return gameOver;}
	}

	public bool GameStarted {
		get {return gameStarted; }
	}
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource>();

		player = GameObject.FindObjectOfType<Player>();
		platforms = GameObject.FindObjectsOfType<PlatformMovement>();
		objs = GameObject.FindObjectsOfType<PlatformObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Resetting
	public void Reset (bool main)
	{
		gameOver = false;
		GameOvermenu.SetActive (false);
		StopCoroutine (EndScreen ());

		player.Reset ();
		
		foreach (PlatformMovement plat in platforms) {
			plat.OnReset ();
		}
		
		foreach (PlatformObject obj in objs) {
			obj.OnReset ();
		}
		if (main) {
			Mainmenu.SetActive (true);
		} else {
			playerStartedGame();
			GameOn();
		} 
	}
	

	public void playerCollided(){
		gameStarted = false;
		playerActive = false;
		gameOver = true;
		StartCoroutine(EndScreen());
	}

	public void playerStartedGame(){
		playerActive = true;
	}

	public void GameOn ()
	{	
		Mainmenu.SetActive(false);
		music.Play();
		gameStarted = true;
	}

	//Need to create reset state for replay button

	//Need to send back to main menu


	IEnumerator EndScreen(){
		yield return new WaitForSeconds(2f);
		music.Stop();
		GameOvermenu.SetActive(true);
	}

}
