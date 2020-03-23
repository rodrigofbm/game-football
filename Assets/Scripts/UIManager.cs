using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
  public static UIManager uIManager;
  public Text numberCoinsUI;
  public Text numberBallsUI;

  void Awake() {
    if (uIManager == null) {
      uIManager = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }

    SceneManager.sceneLoaded += LoadUIManager;
  }

  void LoadUIManager(Scene scene, LoadSceneMode mode) {
    numberCoinsUI = GameObject.FindGameObjectWithTag("NumberCoins").GetComponent<Text>();
    numberBallsUI = GameObject.FindGameObjectWithTag("BallsUI").GetComponent<Text>();
  }

  public void UpdateUI() {
    numberCoinsUI.text = ScoreManager.scoreManager.playerCois.ToString();
    numberBallsUI.text = GameManager.gameManager.numBalls.ToString();
  }
}
