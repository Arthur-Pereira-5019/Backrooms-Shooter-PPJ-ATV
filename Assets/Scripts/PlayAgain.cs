using UnityEngine;
using System.Collections;

public class PlayAgain : MonoBehaviour {

	// responde em caso de colisão
	void OnCollisionEnter(Collision newCollision)
	{
		// se foi atingido por um projétil...
		if (newCollision.gameObject.tag == "Projectile") {
			// chame a função RestartGame do game manager
			print("A");
			GameManager.gm.RestartGame();
		}
	}
}
