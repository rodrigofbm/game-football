using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  public static GameManager gameManager;
  [SerializeField] private GameObject ball;
  [SerializeField] private Transform ballStartPos;
  [SerializeField] private bool gameOver = false;
  public int ballsInScene;
  public int coinsWon = 0;
  public bool gameStarted = false;
  public bool playerWin = false;
  public int numBalls = 3;
  public int shoot = 0;

  void Awake() {
    ballStartPos = GameObject.FindGameObjectWithTag("StartPosition").GetComponent<Transform>();

    if (gameManager == null) {
      gameManager = this;
      DontDestroyOnLoad(gameObject);
      DontDestroyOnLoad(ballStartPos);
    } else {
      Destroy(gameObject);
    }

    SceneManager.sceneLoaded += LoadGameManager;
  }

  void LoadGameManager(Scene scene, LoadSceneMode mode) {
    InitState();
  }

  void InitState() {
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    StartGame();

    if (player) {
      Destroy(player.gameObject);
    }
  }

  void Start() {
    InitState();
    ScoreManager.scoreManager.GameStartScore();
    //PlayerPrefs.DeleteAll();
  }

  private void Update() {
    ScoreManager.scoreManager.UpdateScore();
    UIManager.uIManager.UpdateUI();
    SpawnBall();

    GameOver();
  }

  void SpawnBall() {
    if (numBalls > 0 && ballsInScene == 0 && !playerWin && !gameOver) {
      Instantiate(ball, ballStartPos.position, Quaternion.identity);
      ballsInScene += 1;
      numBalls -= 1;
      shoot = 0;
    }
  }

  public void KillPlayer(GameObject palyer) {
    Destroy(palyer);
    ballsInScene = 0;
  }

  void GameOver() {
    if (numBalls <= 0 && ballsInScene == 0) {
      gameOver = true;

      UIManager.uIManager.ShowGameOverUI();
      gameStarted = false;
    }
  }

  public void PlayerWin() {
    int temp = CurrentScene.currentScene.sceneIndex + 1;

    UIManager.uIManager.ShowWinUI();
    playerWin = true;

    PlayerPrefs.SetInt("Level0" + temp, 1);
  }

  public void StartGame() {
    ResetGame();
    gameStarted = true;

    StartCoroutine(UIManager.uIManager.SetPanelsDelay(0.01f));
  }

  public void ResetGame() {
    playerWin = false;
    gameOver = false;
    numBalls = 3;
    ballsInScene = 0;
  }
}
