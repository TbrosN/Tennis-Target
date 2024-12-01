using UnityEngine;

public class TargetController : MonoBehaviour
{
  public GameObject wall;
  public float startX;
  void Start() {
    startX = transform.position.x;
  }
  public void Respawn() {
    float wallXPosition = wall.transform.position.x;
    var mainCamera = Camera.main;
    var maxZ = GetRightmostVisiblePoint().z;
    var minZ = GetLeftmostVisiblePoint().z;
    // Debug.Log($"Leftmost: {GetLeftmostVisiblePoint()}");
    // Random position within these boundaries
    var zOffset = transform.localScale.z;
    float randomZ = Random.Range(minZ + zOffset, maxZ - zOffset);
    // int randChoice = Random.Range(0, 2);
    // randomZ = randChoice == 1 ? minZ + zOffset : maxZ - zOffset;
    transform.position = new Vector3(startX, transform.position.y, randomZ);
  }

   Vector3 GetRightmostVisiblePoint()
  {
      // Wall's X position (constant because wall is parallel to Y-Z plane)
      float wallX = wall.transform.position.x;

      // Calculate the camera's right frustum ray
      Ray rightFrustumRay = Camera.main.ViewportPointToRay(new Vector3(1, 0.5f, 0));

      // Calculate intersection of the ray with the wall's plane at x = -50
      float t = (wallX - rightFrustumRay.origin.x) / rightFrustumRay.direction.x;
      Vector3 intersectionPoint = rightFrustumRay.origin + t * rightFrustumRay.direction;

      return intersectionPoint;
  }
   Vector3 GetLeftmostVisiblePoint()
    {
        // Wall's X position (constant because wall is parallel to Y-Z plane)
        float wallX = wall.transform.position.x;

        // Calculate the camera's left frustum ray
        Ray leftFrustumRay = Camera.main.ViewportPointToRay(new Vector3(0, 0.5f, 0));

        // Calculate intersection of the ray with the wall's plane at x = -50
        float t = (wallX - leftFrustumRay.origin.x) / leftFrustumRay.direction.x;
        Vector3 intersectionPoint = leftFrustumRay.origin + t * leftFrustumRay.direction;

        return intersectionPoint;
    }
}
