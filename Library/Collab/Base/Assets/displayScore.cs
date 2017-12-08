using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayScore : MonoBehaviour {

	public Text powerups;
	public Text lives;
	public Text final;

	public ModuleController mc;

	private bool done = false;
	
	// Update is called once per frame
	void Update () {
		if(playerController.instance.dead && !done)
		{
			if(playerController.instance.health <= 0)
				playerController.instance.health = 0;
			lives.text = playerController.instance.health.ToString() + " x 1000";
			int powerscore = mc.countPowerUps();
			powerups.text = powerscore.ToString() + " x 250";
			int score = playerController.instance.health*1000 + powerscore*250 + playerController.instance.playerScore;
			final.text = score.ToString();
			done = true;
			Debug.Log(playerController.instance.health);
			Debug.Log(playerController.instance.playerScore);
			Debug.Log(powerscore);
		}
	}
}
