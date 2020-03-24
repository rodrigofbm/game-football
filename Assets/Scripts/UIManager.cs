using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
  public static UIManager uIManager;
  public Text numberCoinsUI;
  public Text numberBallsUI;
  public GameObject winPanel, losePanel, pausePanel;
  [SerializeField]
  private Button btnPause, btnResume, btnPlayAgainLose, btnMenuLevels;

  void Awake() {
    if (uIManager == null) {
      uIManager = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }

    SceneManager.sceneLoaded += LoadUIManager;
    StartCoroutine(SetPanelsDelay(0.001f));
  }

  void LoadUIManager(Scene scene, LoadSceneMode mode) {
    numberCoinsUI = GameObject.FindGameObjectWithTag("NumberCoins").GetComponent<Text>();
    numberBallsUI = GameObject.FindGameObjectWithTag("BallsUI").GetComponent<Text>();
    btnPlayAgainLose = GameObject.FindGameObjectWithTag("BtnPlayAgainLose").GetComponent<Button>();
    //btnMenuLevels = GameObject.FindGameObjectWithTag("BtnMenuLevels").GetComponent<Button>();
    btnPause = GameObject.FindGameObjectWithTag("BtnPause").GetComponent<Button>();
    btnResume = GameObject.FindGameObjectWithTag("BtnResumeGame").GetComponent<Button>();
    winPanel = GameObject.FindGameObjectWithTag("WinPanel");
    losePanel = GameObject.FindGameObjectWithTag("LosePanel");
    pausePanel = GameObject.FindGameObjectWithTag("PausePanel");

    btnPause.onClick.AddListener(PauseGame);
    btnResume.onClick.AddListener(ResumeGame);
    btnPlayAgainLose.onClick.AddListener(PlayAgain);
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

  void PauseGame() {
    pausePanel.SetActive(true);
    pausePanel.GetComponent<Animator>().Play("MoveUI_Pause");
    Time.timeScale = 0.0f;
  }

  void ResumeGame() {
    pausePanel.GetComponent<Animator>().Play("MoveUI_Pause_Back");
    Time.timeScale = 1.0f;
    StartCoroutine(ResumeGameDelay(0.5f));
  }

  void PlayAgain() {
    ScoreManager scoreManager = ScoreManager.scoreManager;

    SceneManager.LoadScene(GameManager.gameManager.currentScene);
    scoreManager.RemoveCoins(scoreManager.coinsWon);
  }

  public IEnumerator SetPanelsDelay(float waitTime) {
    yield return new WaitForSeconds(waitTime);
    winPanel.SetActive(false);
    losePanel.SetActive(false);
    pausePanel.SetActive(false);
  }

  IEnumerator ResumeGameDelay(float waitTime) {
    yield return new WaitForSeconds(waitTime);
    pausePanel.SetActive(false);
  }
}
