using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotacao : MonoBehaviour {
  [SerializeField] private Image arrow;
  [SerializeField] private Transform startPosition;
  public float arrowAngle = 0;

  void Start() {
    ArrowStartPosition();
    BallStartPosition();
  }

  void Update() {
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
    if (Input.GetKey(KeyCode.UpArrow)) {
      arrowAngle += 2.5f;
    }

    if (Input.GetKey(KeyCode.DownArrow)) {
      arrowAngle -= 2.5f;
    }
  }
}
