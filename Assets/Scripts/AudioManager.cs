using UnityEngine;

public class AudioManager : MonoBehaviour {
   public static AudioManager audioManager;
   public AudioClip[] bgClips;
   public AudioSource bgMusics;

   public AudioClip[] fxClips;
   public AudioSource fxMusics;

   void Awake() {
      if (audioManager == null) {
         audioManager = this;
         DontDestroyOnLoad(gameObject);
      }
      else {
         Destroy(gameObject);
      }
   }

   void Update() {
      if (!bgMusics.isPlaying) {
         StartAudioClips();
      }
   }

   public void StartAudioClips() {
      bgMusics.clip = GetClip();
      bgMusics.Play();
   }

   AudioClip GetClip() {
      int index = Random.Range(0, bgClips.Length);

      return bgClips[index];
   }

   public void PlayClipFX(int index) {
      fxMusics.clip = fxClips[index];
      fxMusics.Play();
   }
}
