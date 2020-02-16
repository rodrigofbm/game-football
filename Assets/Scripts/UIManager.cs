using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
  public static UIManager uIManager;
  public Text numberCoinsTxt, numberOfBallTxt;
  [SerializeField] private GameObject losePanel;

  void Awake () {
    if (uIManager == null) {
      uIManager = this;
      DontDestroyOnLoad (gameObject);
    } else {
      Destroy (gameObject);
    }

    SceneManager.sceneLoaded += LoadUIManager;
    StartCoroutine (getLosePanelReference ());
  }

  void LoadUIManager (Scene scene, LoadSceneMode mode) {
    numberCoinsTxt = GameObject.FindGameObjectWithTag ("NumberCoins").GetComponent<Text> ();
    numberOfBallTxt = GameObject.FindGameObjectWithTag ("NumberOfBalls").GetComponent<Text> ();
    losePanel = GameObject.FindGameObjectWithTag ("LosePanel");
  }

  public void UpdateUI () {
    numberCoinsTxt.text = ScoreManager.scoreManager.playerCois.ToString ();
    numberOfBallTxt.text = GameManager.gameManager.numBalls.ToString ();
  }

  public void GameOverUI () {
    losePanel.SetActive (true);
  }

  IEnumerator getLosePanelReference () {
    yield return new WaitForSeconds (0.001f);
    losePanel.SetActive (false);
  }
}