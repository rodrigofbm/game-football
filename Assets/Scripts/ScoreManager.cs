using UnityEngine;

public class ScoreManager : MonoBehaviour {
  public static ScoreManager scoreManager;
  public int playerCois;
  public int coinsWon = 0;

  void Awake() {
    if (scoreManager == null) {
      scoreManager = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  public void GameStartScore() {
    if (PlayerPrefs.HasKey("PlayerCoins")) {
      playerCois = PlayerPrefs.GetInt("PlayerCoins");
    } else {
      playerCois = 0;
      PlayerPrefs.SetInt("PlayerCoins", playerCois);
    }
  }

  public void UpdateScore() {
    playerCois = PlayerPrefs.GetInt("PlayerCoins");
  }

  public int AddCoins(int coin) {
    playerCois += coin;
    SaveCoins(playerCois);

    return coin;
  }

  public void RemoveCoins(int coin) {
    playerCois -= coin;
    SaveCoins(playerCois);
  }

  public void SaveCoins(int coin) {
    PlayerPrefs.SetInt("PlayerCoins", coin);
  }

}
