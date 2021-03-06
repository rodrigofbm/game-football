﻿using UnityEngine;

public class CoinsControll : MonoBehaviour {
  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      ScoreManager.scoreManager.coinsWon += ScoreManager.scoreManager.AddCoins(30);
      AudioManager.audioManager.PlayClipFX(1);
      Destroy(gameObject);
    }
  }
}
