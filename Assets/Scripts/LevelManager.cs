using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
  [SerializeField]
  private List<Level> listLevel;
  private LevelState lvlState;
  [SerializeField]
  private GameObject button;
  [SerializeField]
  private Transform panelLevels;

  void RenderListLevel() {
    foreach (var level in listLevel) {
      GameObject newButton = Instantiate(button) as GameObject;

      lvlState = newButton.GetComponent<LevelState>();
      lvlState.setText(level.levelTxt);
      lvlState.setButtonState(level.unblocked);

      newButton.transform.SetParent(panelLevels, false);
    }
  }

  void Start() {
    RenderListLevel();
  }

}

[System.Serializable]
public class Level {
  public string levelTxt;
  public bool unblocked;
  public int allowed;
}
