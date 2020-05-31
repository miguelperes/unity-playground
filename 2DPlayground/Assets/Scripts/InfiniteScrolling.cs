using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{

  public float speed = 0.2f;
  public bool changeScaleAfterReset = false;
  public bool changeColorAfterReset = false;
  public GameObject referenceObject;
  public Transform spawnPoint;
  public Transform restartPoint;
  SpriteRenderer sRenderer;

  public bool recalculateNow = false;

  void Start()
  {
    sRenderer = GetComponentInChildren<SpriteRenderer>();
  }

  void Update()
  {

    if(recalculateNow) {
      recalculatePosition();
      recalculateNow = false;
    }

    move(speed);

    if (isAfterRestartPoint())
    {
      recalculatePosition();
      if (changeScaleAfterReset) changeScale();
      if (changeColorAfterReset) changeColor();
    }
  }

  void move(float speed)
  {
    Vector3 position = this.transform.position;
    position.x = position.x - (1 * speed);
    this.transform.position = position;
  }

  void recalculatePosition()
  {
    // Vector3 newPosition = new Vector3(
    //   spawnPoint.position.x,
    //   this.transform.position.y,
    //   this.transform.position.z
    // );
    float referencePosition = referenceObject.transform.position.x;
    float referenceObjectWidth = referenceObject.GetComponent<Renderer>().bounds.size.x; //referenceObject.GetComponent<BoxCollider2D>().size.x;
    float thisWidth = GetComponent<Renderer>().bounds.size.x;
    Vector3 newPosition = new Vector3(
      referencePosition + (referenceObjectWidth),
      this.transform.position.y,
      this.transform.position.z
    );

    this.transform.position = newPosition;
  }

  void changeScale()
  {
    Vector3 scale = this.transform.localScale;
    this.transform.localScale = new Vector3(scale.x, Random.Range(0.1f, 2.0f), scale.z);


    /* Fix scaled building into camera ground */
    // float lowPosition = this.transform.position.y - (sRenderer.bounds.size.y / 2);
    // Plane downPlane = GeometryUtility.CalculateFrustumPlanes(Camera.main)[3];
    // float cameraGroundHeight = downPlane.distance;
    // float distanceFromCameraGround = Mathf.Abs(lowPosition - cameraGroundHeight);
    // Debug.Log("distanceFromCameraGround: " + distanceFromCameraGround);

  }

  void changeColor()
  {
    sRenderer.color = Random.ColorHSV();
  }

  bool isAfterRestartPoint()
  {
    float centerPosition = transform.position.x + (sRenderer.bounds.size.x / 2);

    if (centerPosition < restartPoint.position.x)
      return true;
    else
      return false;
  }
}
