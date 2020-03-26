using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour {
  [SerializeField]
  Transform ball, minLimit;
  Vector3 posCam, stageDimensions;
  float maxX, t = 1;

  void Update() {
    StartFollowing();
  }

  void StartFollowing() {
    stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    maxX = stageDimensions.x - (stageDimensions.x / 3);

    if (GameManager.gameManager.gameStarted) {
      if (ball == null && GameManager.gameManager.ballsInScene > 0) {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      } else if (GameManager.gameManager.ballsInScene > 0) {
        posCam = transform.position;

        posCam.x = ball.position.x;
        //if the given value is no within the min and max, then return the min;
        posCam.x = Mathf.Clamp(posCam.x, minLimit.position.x, maxX);

        transform.position = posCam;
      }
    }
  }
}
