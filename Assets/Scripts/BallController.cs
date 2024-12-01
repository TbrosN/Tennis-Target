using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
   private Rigidbody _rigidbody;
   public float xForce;
   public float yForce;

   public float gravity;
   public int score;
   public TextMesh text;

   // Resets the ball's position and velocity
   void resetBall() {
      score = 0;
      text.text = score.ToString();
      Physics.gravity = new Vector3(0, -gravity, 0);
      _rigidbody.velocity = Vector3.zero;
      _rigidbody.angularVelocity = Vector3.zero;
      _rigidbody.transform.position = new Vector3(0f,0f,0f);
      var forceTowardWall = new Vector3(-xForce, 0f, 0f);
      var forceUp = new Vector3(0,yForce,0);
      var forceRight = new Vector3(0,0,10.0f);
      _rigidbody.AddForce(forceTowardWall + forceUp + forceRight);
   }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        resetBall();
    }
    void Update() {
      // If the ball falls off the map
      // NOTE: Pressing B is just for testing purposes
      // if (Input.GetKeyDown(KeyCode.B)) {
      //   resetBall();
      // }
    }
    public void IncrementScore() {
      score += 1;
      text.text = score.ToString();
    }
}
