using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentScene : MonoBehaviour {
  public static CurrentScene currentScene;
  public int sceneIndex;

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
  }
}