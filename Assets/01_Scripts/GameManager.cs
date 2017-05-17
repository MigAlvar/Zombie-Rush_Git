using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;


	[SerializeField] private GameObject Mainmenu;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playerCollided(){
		gameOver =true;
	}

	public void playerStartedGame(){
		playerActive = true;
	}
	public void GameOn ()
	{	
		Mainmenu.SetActive(false);
		gameStarted = true;
	}
}
