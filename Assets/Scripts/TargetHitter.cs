using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetHitter : MonoBehaviour
{
   private Rigidbody _rigidbody;
   public float xForce;
   public float yForce;
   private BallController controller; 
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<BallController>();
    }

    void OnCollisionEnter(Collision collision) {
      if (collision.gameObject.CompareTag("Target")) {
        controller.IncrementScore();
        _rigidbody.AddForce(new Vector3(xForce, -yForce, 0));
        collision.gameObject.GetComponent<TargetController>().Respawn();
      }
    }
}
