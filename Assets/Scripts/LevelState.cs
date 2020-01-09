using UnityEngine;
using UnityEngine.UI;

public class LevelState : MonoBehaviour {
  [SerializeField]
  private Text txtState;
  [SerializeField]
  private Button btnState;

  void Start() {
    txtState = GetComponent<Text>();
    btnState = GetComponent<Button>();
  }

  public void setText(string value) {
    this.txtState.text = value;
  }

  public Text getText(string value) {
    return this.txtState;
  }

  public void setButtonState(bool value) {
    btnState.interactable = value;
  }

  public Button getButton(string value) {
    return this.btnState;
  }
}
