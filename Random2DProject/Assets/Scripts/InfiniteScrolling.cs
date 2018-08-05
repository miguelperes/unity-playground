using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{

  public float speed = 0.2f;
	public bool changeScaleAfterReset = false;
	public bool changeColorAfterReset = false;
  public Transform spawnPoint;
  public Transform restartPoint;
	SpriteRenderer sRenderer; 

void Start() {
	sRenderer = GetComponentInChildren<SpriteRenderer>();
}

  void Update() {
    move(speed);

    if(isAfterRestartPoint()) {
      recalculatePosition();
			if(changeScaleAfterReset) changeScale();
			if(changeColorAfterReset) changeColor();
    }
  }
  
  void move(float speed) {
    Vector3 position = this.transform.position;
    position.x = position.x - (1 * speed);
    this.transform.position = position;
  }

  void recalculatePosition() {
    Vector3 newPosition = new Vector3(
      spawnPoint.position.x,
      this.transform.position.y,
      this.transform.position.z
    );

    this.transform.position = newPosition;
  }

	void changeScale() {
		Vector3 scale = this.transform.localScale;
		this.transform.localScale = new Vector3(scale.x, Random.Range(0.5f, 1.5f), scale.z);

		
		/* Fix scaled building into camera ground */
		// float lowPosition = this.transform.position.y - (sRenderer.bounds.size.y / 2);
		// Plane downPlane = GeometryUtility.CalculateFrustumPlanes(Camera.main)[3];
		// float cameraGroundHeight = downPlane.distance;
		// float distanceFromCameraGround = Mathf.Abs(lowPosition - cameraGroundHeight);
		// Debug.Log("distanceFromCameraGround: " + distanceFromCameraGround);
		
	}

	void changeColor() {
		sRenderer.color = Random.ColorHSV();
	}

  bool isAfterRestartPoint() {
    float centerPosition = transform.position.x + (sRenderer.bounds.size.x / 2);
    
    if(centerPosition < restartPoint.position.x)
      return true;
    else
      return false;
  }
}
