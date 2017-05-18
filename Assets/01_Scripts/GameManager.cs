using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;


	[SerializeField] private GameObject Mainmenu;
	[SerializeField] private GameObject GameOvermenu;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;
	private Player player;
	private PlatformMovement[] platforms;
	private PlatformObject[] objs;

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
		player = GameObject.FindObjectOfType<Player>();
		platforms = GameObject.FindObjectsOfType<PlatformMovement>();
		objs = GameObject.FindObjectsOfType<PlatformObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset(){
		gameOver = false;
		GameOvermenu.SetActive(false);
		StopCoroutine(EndScreen());
		Mainmenu.SetActive(true);
		player.Reset();
		
		foreach(PlatformMovement plat in platforms){
			plat.OnReset();
		}
		
		foreach(PlatformObject obj in objs){
			obj.OnReset();
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
		gameStarted = true;
	}

	//Need to create reset state for replay button

	//Need to send back to main menu


	IEnumerator EndScreen(){
		yield return new WaitForSeconds(2f);
		GameOvermenu.SetActive(true);
	}

}
