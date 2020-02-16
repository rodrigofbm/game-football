using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
   public static UIManager uIManager;
   public Text numberCoinsUI;

   void Awake () {
      if (uIManager == null) {
         uIManager = this;
         DontDestroyOnLoad (gameObject);
      } else {
         Destroy (gameObject);
      }

      SceneManager.sceneLoaded += LoadUIManager;
   }

   void LoadUIManager (Scene scene, LoadSceneMode mode) {
      numberCoinsUI = GameObject.Find ("NumberCoins").GetComponent<Text> ();
   }

   public void UpdateUI () {
      numberCoinsUI.text = ScoreManager.scoreManager.playerCois.ToString ();
   }
}