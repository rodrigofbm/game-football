using UnityEngine;

public class AudioManager : MonoBehaviour {
   public static AudioManager audioManager;
   public AudioClip[] clips;
   public AudioSource bgMusics;

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
      return clips[Random.Range(0, clips.Length)];
   }
}
