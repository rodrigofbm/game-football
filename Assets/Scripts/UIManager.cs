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
  private Button btnPause, btnResume, btnPlayAgainPause, btnMenuLevelsPause;
  [SerializeField]
  private Button btnPlayAgainLose, btnMenuLevelsLose;
  [SerializeField]
  private Button btnPlayAgainWin, btnMenuLevelsWin, bentNextLevel;

  void Awake() {
    if (uIManager == null) {
      uIManager = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }

    SceneManager.sceneLoaded += LoadUIManager;
    GetUI();
    StartCoroutine(SetPanelsDelay(0.001f));
  }

  void LoadUIManager(Scene scene, LoadSceneMode mode) {
    GetUI();
  }

  void GetUI() {
    if (CurrentScene.currentScene.sceneIndex != 0) {
      numberCoinsUI = GameObject.FindGameObjectWithTag("NumberCoins").GetComponent<Text>();
      numberBallsUI = GameObject.FindGameObjectWithTag("BallsUI").GetComponent<Text>();
      GetBtnsWin();
      GetBtnsLose();
      GetBtnsPause();
      winPanel = GameObject.FindGameObjectWithTag("WinPanel");
      losePanel = GameObject.FindGameObjectWithTag("LosePanel");
      pausePanel = GameObject.FindGameObjectWithTag("PausePanel");

      btnPause.onClick.AddListener(PauseGame);
      btnResume.onClick.AddListener(ResumeGame);
      btnPlayAgainLose.onClick.AddListener(PlayAgain);
      btnMenuLevelsLose.onClick.AddListener(ShowMenuLevels);
      btnPlayAgainWin.onClick.AddListener(PlayAgain);
      btnMenuLevelsWin.onClick.AddListener(ShowMenuLevels);
      bentNextLevel.onClick.AddListener(GoToNextLevel);
      btnPlayAgainPause.onClick.AddListener(PlayAgain);
      btnMenuLevelsPause.onClick.AddListener(ShowMenuLevels);
    }
  }

  public void UpdateUI() {
    numberCoinsUI.text = ScoreManager.scoreManager.playerCois.ToString();
    numberBallsUI.text = GameManager.gameManager.numBalls.ToString();
  }

  void GetBtnsPause() {
    btnPause = GameObject.FindGameObjectWithTag("BtnPause").GetComponent<Button>();
    btnResume = GameObject.FindGameObjectWithTag("BtnResumeGame").GetComponent<Button>();
    btnPlayAgainPause = GameObject.FindGameObjectWithTag("BtnPlayAgainPause").GetComponent<Button>();
    btnMenuLevelsPause = GameObject.FindGameObjectWithTag("BtnMenuLevelsPause").GetComponent<Button>();
  }

  void GetBtnsLose() {
    btnPlayAgainLose = GameObject.FindGameObjectWithTag("BtnPlayAgainLose").GetComponent<Button>();
    btnMenuLevelsLose = GameObject.FindGameObjectWithTag("BtnMenuLevelsLose").GetComponent<Button>();
  }

  void GetBtnsWin() {
    btnPlayAgainWin = GameObject.FindGameObjectWithTag("BtnPlayAgainWin").GetComponent<Button>();
    btnMenuLevelsWin = GameObject.FindGameObjectWithTag("BtnMenuLevelsWin").GetComponent<Button>();
    bentNextLevel = GameObject.FindGameObjectWithTag("BtnNextLevel").GetComponent<Button>();
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

    if (!GameManager.gameManager.playerWin) {
      scoreManager.RemoveCoins(scoreManager.coinsWon);
      SceneManager.LoadScene(CurrentScene.currentScene.sceneIndex);
    } else {
      SceneManager.LoadScene(CurrentScene.currentScene.sceneIndex);
    }
  }

  void GoToNextLevel() {
    if (GameManager.gameManager.playerWin) {
      int aux = CurrentScene.currentScene.sceneIndex + 1;
      SceneManager.LoadScene(aux);
    }
  }

  void ShowMenuLevels() {
    ScoreManager scoreManager = ScoreManager.scoreManager;

    if (!GameManager.gameManager.playerWin) {
      GameManager.gameManager.ResetGame();
      scoreManager.RemoveCoins(scoreManager.coinsWon);
      SceneManager.LoadScene(0);
    } else {
      GameManager.gameManager.ResetGame();
      SceneManager.LoadScene(0);
    }
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
