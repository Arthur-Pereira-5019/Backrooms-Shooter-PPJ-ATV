﻿using UnityEngine;
using System.Collections;

public class ComportamentoAlvo2 : MonoBehaviour
{

	// impacto do alvo no jogo
	public int pontuacao = 0;
	public float tempoExtra = 0.0f;

	// explode quando atingido?
	public GameObject prefabExplosao;

	// quando colidir com outro gameObject...
	void OnCollisionEnter (Collision newCollision)
	{
		// não faça nada se houver um game manager e o jogo já acabou
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}

		// Se foi atingido por um projétil...
		if (newCollision.gameObject.tag == "Projectile")
		{
			if (prefabExplosao)
			{
				// Instancia a explosão na posição e rotação do alvo
				Instantiate(prefabExplosao, transform.position, transform.rotation);
			}

			// se o game manager existir, altere o tempo e placar conforme o alvo
			if (GameManager.gm)
			{
				GameManager.gm.targetHit(pontuacao, tempoExtra);
			}

			// destrua o projétil
			Destroy(newCollision.gameObject);

			// autodestrua-se
			Destroy(gameObject);
		}
		else if (newCollision.gameObject.tag == "Player")
		{
			GameManager.gm.currentTime = 0f;
		}
	}
}
