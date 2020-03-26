using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentScene : MonoBehaviour {
  public static CurrentScene currentScene;
  [SerializeField]
  GameObject gameManager, uiManager, scoreManager, audioManager;
  public int sceneIndex = -1;

  void Awake() {
    if (currentScene == null) {
      currentScene = this;
      DontDestroyOnLoad(this.gameObject);
    } else {
      Destroy(this.gameObject);
    }

    SceneManager.sceneLoaded += LoadCurrentScene;
  }

  void LoadCurrentScene(Scene scene, LoadSceneMode mode) {
    sceneIndex = SceneManager.GetActiveScene().buildIndex;

    if (sceneIndex != 0) {
      Instantiate(gameManager);
      Instantiate(uiManager);
      Instantiate(scoreManager);
      Instantiate(audioManager);
    }
  }
}