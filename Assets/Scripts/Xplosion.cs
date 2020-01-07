using UnityEngine;

public class Xplosion : MonoBehaviour {

  [SerializeField] GameObject xplosionFx;
  void Start() {

  }

  void Update() {

  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Player")) {
      Instantiate(xplosionFx, this.transform.position, Quaternion.identity);
    }
  }
}
