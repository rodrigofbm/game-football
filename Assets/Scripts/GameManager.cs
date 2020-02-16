using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager gameManager;
  [SerializeField] private GameObject ball;
  [SerializeField] private Transform ballStartPos;
  [SerializeField] private bool gameOver = false;
  public int numBalls = 1;
  public int ballsInScene;
  public int shoot = 0;

  void Awake () {
    if (gameManager == null) {
      gameManager = this;
      DontDestroyOnLoad (gameObject);
    } else {
      Destroy (gameObject);
    }
  }

  void Start () {
    ScoreManager.scoreManager.GameStartScore ();
  }

  private void Update () {
    ScoreManager.scoreManager.UpdateScore ();
    UIManager.uIManager.UpdateUI ();
    SpawnBall ();
    GameOver ();
  }

  void SpawnBall () {
    if (numBalls > 0 && ballsInScene == 0) {
      Instantiate (ball, ballStartPos.position, Quaternion.identity);
      ballsInScene += 1;
      numBalls -= 1;
      shoot = 0;
    }
  }

  void GameOver () {
    if (numBalls < 0) UIManager.uIManager.GameOverUI ();
  }

}