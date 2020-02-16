using UnityEngine;

public class PlayerManager : MonoBehaviour {
   public static PlayerManager playerManager;

   private void Awake () {
      if (playerManager == null) {
         playerManager = this;
         DontDestroyOnLoad (gameObject);
      } else {
         Destroy (gameObject);
      }
   }

   void OnCollisionEnter2D (Collision2D other) {
      if (other.gameObject.CompareTag ("Obstacle")) {
         AudioManager.audioManager.PlayClipFX (0);
      }
   }
}