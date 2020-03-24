using UnityEngine;
using UnityEngine.UI;

public class BallControll : MonoBehaviour {
  //about ball rotation
  [SerializeField]
  private GameObject arrow;
  [SerializeField]
  private Image arrowImg;
  [SerializeField]
  private Transform startPosition;
  [SerializeField]
  private Transform limitLeft;
  [SerializeField]
  private Transform limitRigth;
  public float arrowAngle = 0;
  public bool allowMoveArrow = false;
  public bool shot = false;

  // About ball forces
  private Rigidbody2D ball;
  public float force = 0;

  void Awake() {
    limitLeft = GameObject.FindGameObjectWithTag("LimitLeft").transform;
    limitRigth = GameObject.FindGameObjectWithTag("LimitRight").transform;
    arrow = GameObject.FindGameObjectWithTag("ArrowGO");
    arrowImg = GameObject.FindGameObjectWithTag("ArrowGreen").GetComponent<Image>();
    startPosition = GameObject.FindGameObjectWithTag("StartPosition").GetComponent<Transform>();

    HandleArrows(false);
  }

  void Start() {
    ball = GetComponent<Rigidbody2D>();

    BallStartPosition();
  }

  void Update() {
    //about ball rotation
    ArrowRotationLimits();
    ArrowStartPosition();
    ArrowRotation();
    ArrowControlls();

    // About ball forces
    ApplyForce();
    FillArrow();

    CheckScreenLimits();
  }

  //about ball rotation
  void ArrowStartPosition() {
    arrow.transform.position = this.transform.position;
  }

  void BallStartPosition() {
    this.gameObject.transform.position = startPosition.position;
  }

  void ArrowRotation() {
    arrow.transform.eulerAngles = new Vector3(0, 0, arrowAngle);
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
    if (GameManager.gameManager.shoot == 0) {
      allowMoveArrow = true;
      HandleArrows(true);
    }
  }

  void OnMouseUp() {
    allowMoveArrow = false;
    HandleArrows(false);

    if (GameManager.gameManager.shoot == 0 & force > 0) {
      AudioManager.audioManager.PlayClipFX(2);
      shot = true;
      GameManager.gameManager.shoot = 1;
      arrowImg.fillAmount = 0;
    }
  }

  // About ball forces
  void ApplyForce() {
    float angX = Mathf.Cos(arrowAngle * Mathf.Deg2Rad);
    float angY = Mathf.Sin(arrowAngle * Mathf.Deg2Rad);

    if (shot) {
      ball.AddForce(new Vector2(angX, angY) * force);
      shot = false;
    }
  }

  void FillArrow() {
    if (allowMoveArrow) {
      float moveX = Input.GetAxis("Mouse X");

      if (moveX < 0) {
        arrowImg.fillAmount += Time.deltaTime;
        force = arrowImg.fillAmount * 1000;
      }

      if (moveX > 0) {
        arrowImg.fillAmount -= Time.deltaTime;
        force = arrowImg.fillAmount * 1000;
      }
    }
  }

  //disable/enable arrows imgs
  void HandleArrows(bool enable) {
    arrow.GetComponent<Image>().enabled = enable;
    arrowImg.enabled = enable;
  }

  void SetBallAsDynamic() {
    this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
  }

  void CheckScreenLimits() {
    if (gameObject.transform.position.x > limitRigth.position.x
          || gameObject.transform.position.x < limitLeft.position.x) {
      GameManager.gameManager.KillPlayer(this.gameObject);
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Enemy"))
      GameManager.gameManager.KillPlayer(this.gameObject);

    if (other.gameObject.CompareTag("GoalLine")) {
      GameManager.gameManager.PlayerWin();
    }

  }
}
