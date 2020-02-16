using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewersMovement : MonoBehaviour {
  [SerializeField] SliderJoint2D skewers;
  [SerializeField] JointMotor2D motorAux;

  void Start () {
    skewers = GetComponent<SliderJoint2D> ();
    motorAux = skewers.motor;
  }

  void Update () {
    changeSkewersMov ();
  }

  void changeSkewersMov () {
    if (skewers.limitState == JointLimitState2D.UpperLimit) {
      motorAux.motorSpeed = Random.Range (-3f, -6f);
    }
    if (skewers.limitState == JointLimitState2D.LowerLimit) {
      motorAux.motorSpeed = Random.Range (3f, 6f);;
    }

    skewers.motor = motorAux;
  }
}