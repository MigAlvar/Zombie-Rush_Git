﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private float jumpForce = 100f;
	[SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDeath;
	private Animator anim;
	private Rigidbody body;
	private bool jump = false;

	private AudioSource playerSnd;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		body = GetComponent<Rigidbody>();
		playerSnd = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
			if (Input.GetMouseButtonDown (0)) {
				GameManager.instance.playerStartedGame();
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
		if (other.gameObject.tag == "Obstacle") {
			body.AddForce(new Vector3(50,20,-10), ForceMode.Impulse);
			body.detectCollisions = false;
			playerSnd.PlayOneShot(sfxDeath);
			GameManager.instance.playerCollided();
		}
	}
}
