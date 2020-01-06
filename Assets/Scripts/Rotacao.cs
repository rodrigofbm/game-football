using UnityEngine;
using UnityEngine.UI;

public class Rotacao : MonoBehaviour {
  [SerializeField] private Image arrow;
  [SerializeField] private Transform startPosition;
  public float arrowAngle = 0;
  public bool allowMoveArrow = false;
  public bool shot = false;

  void Start() {
    ArrowStartPosition();
    BallStartPosition();
  }

  void Update() {
    ArrowRotationLimits();
    ArrowRotation();
    ArrowControlls();
  }

  void ArrowStartPosition() {
    arrow.rectTransform.position = startPosition.position;
  }

  void BallStartPosition() {
    this.gameObject.transform.position = startPosition.position;
  }

  void ArrowRotation() {
    arrow.rectTransform.eulerAngles = new Vector3(0, 0, arrowAngle);
  }

  void ArrowControlls() {
    if (allowMoveArrow) {
      float moveY = Input.GetAxis("Mouse Y");

      if (moveY < 0) {
        arrowAngle += 2.5f;
      }

      if (moveY > 0) {
        arrowAngle -= 2.5f;
      }
    }
  }

  void ArrowRotationLimits() {
    if (arrowAngle <= 0) arrowAngle = 0;
    if (arrowAngle > 90) arrowAngle = 90;
  }

  void OnMouseDown() {
    allowMoveArrow = true;
  }

  void OnMouseUp() {
    allowMoveArrow = false;
    shot = true;
  }
}
