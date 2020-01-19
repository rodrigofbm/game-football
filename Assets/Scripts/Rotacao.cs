using UnityEngine;
using UnityEngine.UI;

public class Rotacao : MonoBehaviour {
   [SerializeField] private GameObject arrow;
   [SerializeField] private Image arrowImg;
   [SerializeField] private Transform startPosition;
   public float arrowAngle = 0;
   public bool allowMoveArrow = false;
   public bool shot = false;

   void Start() {
      BallStartPosition();
   }

   void Update() {
      ArrowRotationLimits();
      ArrowStartPosition();
      ArrowRotation();
      ArrowControlls();
   }

   void ArrowStartPosition() {
      arrowImg.rectTransform.position = this.transform.position;
   }

   void BallStartPosition() {
      this.gameObject.transform.position = startPosition.position;
   }

   void ArrowRotation() {
      arrowImg.rectTransform.eulerAngles = new Vector3(0, 0, arrowAngle);
   }

   void ArrowControlls() {
      if (allowMoveArrow) {
         float moveY = Input.GetAxis("Mouse Y");

         if (moveY < 0) {
            arrowAngle += 2.5f;
         }

         if (moveY > 0) {
            arrowAngle -= 2.5f;
         }
      }
   }

   void ArrowRotationLimits() {
      if (arrowAngle <= 0) arrowAngle = 0;
      if (arrowAngle > 90) arrowAngle = 90;
   }

   void OnMouseDown() {
      allowMoveArrow = true;
      arrow.SetActive(true);
   }

   void OnMouseUp() {
      allowMoveArrow = false;
      arrow.SetActive(false);
      shot = true;
   }
}
