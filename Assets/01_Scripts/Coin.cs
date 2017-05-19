using UnityEngine;
using System.Collections;


public class Coin : MonoBehaviour{

	
	public int amount;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.GetComponent<Player>()) {
			this.gameObject.SetActive(false);

		}	
	}

	public int coinAmount(){
		return amount;
	}

}