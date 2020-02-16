using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XplosionTimer : MonoBehaviour {
  [SerializeField] GameObject tnt;
  // Start is called before the first frame update
  void Start () {
    tnt = GameObject.Find ("TNT");
    StartCoroutine ("Timer");
  }

  // Update is called once per frame
  void Update () {

  }

  IEnumerator Timer () {
    yield return new WaitForSeconds (0.5f);
    Destroy (tnt);
    Destroy (this.gameObject);
  }
}