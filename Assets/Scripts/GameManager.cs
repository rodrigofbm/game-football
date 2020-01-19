using UnityEngine;

public class GameManager : MonoBehaviour {
   public static GameManager gameManager;

   void Awake() {
      if (gameManager == null) {
         gameManager = this;
         DontDestroyOnLoad(gameObject);
      }
      else {
         Destroy(gameObject);
      }
   }

   void Start() {
      ScoreManager.scoreManager.GameStartScore();
   }

   private void Update() {
      ScoreManager.scoreManager.UpdateScore();
      UIManager.uIManager.UpdateUI();
   }

}
