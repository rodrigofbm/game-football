using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcaBola : MonoBehaviour {
  [SerializeField] private Rotacao rotacao;
  [SerializeField] private Image imgArrowGreen;
  private Rigidbody2D ball;
  public float force = 0;

  void Start() {
    ball = GetComponent<Rigidbody2D>();
    rotacao = GetComponent<Rotacao>();
  }

  void Update() {
    ApplyForce();
    FillArrow();
  }

  void ApplyForce() {
    float angX = Mathf.Cos(rotacao.arrowAngle * Mathf.Deg2Rad);
    float angY = Mathf.Sin(rotacao.arrowAngle * Mathf.Deg2Rad);

    if (rotacao.shot) {
      ball.AddForce(new Vector2(angX, angY) * force);
      rotacao.shot = false;
    }
  }

  void FillArrow() {
    if (rotacao.allowMoveArrow) {
      float moveX = Input.GetAxis("Mouse X");

      if (moveX < 0) {
        imgArrowGreen.fillAmount += Time.deltaTime;
        force = imgArrowGreen.fillAmount * 1000;
      }

      if (moveX > 0) {
        imgArrowGreen.fillAmount -= Time.deltaTime;
        force = imgArrowGreen.fillAmount * 1000;
      }
    }
  }
}
