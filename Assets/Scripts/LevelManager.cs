using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
  [SerializeField]
  private List<Level> listLevel;
  private LevelState lvlState;
  [SerializeField]
  private GameObject button;
  [SerializeField]
  private Transform panelLevels;

  void Awake() {
    Destroy(GameObject.Find("GameManager"));
    Destroy(GameObject.Find("UiManager"));
    Destroy(GameObject.FindGameObjectWithTag("Player"));
  }

  void Start() {
    RenderListLevel();
  }

  void RenderListLevel() {
    foreach (var level in listLevel) {
      GameObject newButton = Instantiate(button) as GameObject;

      lvlState = newButton.GetComponent<LevelState>();
      lvlState.setText(level.levelTxt);

      if (PlayerPrefs.GetInt("Level" + level.levelTxt) == 1) {
        level.unblocked = true;
        level.allowed = 1;
      }

      lvlState.setButtonState(level.unblocked);
      lvlState.setAllowed(level.allowed);

      newButton.GetComponent<Button>().onClick.AddListener(() => OpenLevel("Level" + level.levelTxt));
      newButton.transform.SetParent(panelLevels, false);
    }
  }

  void OpenLevel(string level) {
    SceneManager.LoadScene(level);
  }

}

[System.Serializable]
public class Level {
  public string levelTxt;
  public bool unblocked;
  public int allowed;
}
