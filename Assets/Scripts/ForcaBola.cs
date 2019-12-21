using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcaBola : MonoBehaviour {
  [SerializeField] private Rotacao rotacao;
  private Rigidbody2D ball;
  public float force = 600;

  void Start() {
    ball = GetComponent<Rigidbody2D>();
    rotacao = GetComponent<Rotacao>();
  }

  void Update() {
    ApplyForce();
  }

  void ApplyForce() {
    float angX = Mathf.Cos(rotacao.arrowAngle * Mathf.Deg2Rad);
    float angY = Mathf.Sin(rotacao.arrowAngle * Mathf.Deg2Rad);

    if (Input.GetKeyUp(KeyCode.Space)) {
      ball.AddForce(new Vector2(angX, angY) * force);
    }
  }

}
