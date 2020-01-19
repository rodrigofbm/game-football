using UnityEngine;

public class ControlCoins : MonoBehaviour {
   void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.CompareTag("Player")) {
         ScoreManager.scoreManager.AddCoins(30);
         Destroy(gameObject);
      }
   }
}
