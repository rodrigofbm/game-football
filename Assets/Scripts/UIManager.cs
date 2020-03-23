using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
  public static UIManager uIManager;
  public Text numberCoinsUI;
  public Text numberBallsUI;
  public GameObject winPanel;
  public GameObject losePanel;
  public GameObject pausePanel;

  void Awake() {
    if (uIManager == null) {
      uIManager = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }

    SceneManager.sceneLoaded += LoadUIManager;
    StartCoroutine(GetLosePanelDelay(0.001f));
  }

  void LoadUIManager(Scene scene, LoadSceneMode mode) {
    numberCoinsUI = GameObject.FindGameObjectWithTag("NumberCoins").GetComponent<Text>();
    numberBallsUI = GameObject.FindGameObjectWithTag("BallsUI").GetComponent<Text>();
    winPanel = GameObject.FindGameObjectWithTag("WinPanel");
    losePanel = GameObject.FindGameObjectWithTag("LosePanel");
    pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
  }

  public void UpdateUI() {
    numberCoinsUI.text = ScoreManager.scoreManager.playerCois.ToString();
    numberBallsUI.text = GameManager.gameManager.numBalls.ToString();
  }

  public void ShowWinUI() {
    winPanel.SetActive(true);
  }

  public void ShowGameOverUI() {
    losePanel.SetActive(true);
  }

  public void ShowPauseUI() {
    pausePanel.SetActive(true);
  }

  IEnumerator GetLosePanelDelay(float waitTime) {
    yield return new WaitForSeconds(waitTime);
    winPanel.SetActive(false);
    losePanel.SetActive(false);
    pausePanel.SetActive(false);
  }
}
