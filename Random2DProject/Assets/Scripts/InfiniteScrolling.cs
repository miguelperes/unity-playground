using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{

  public float speed = 0.2f;
  public Transform spawnPoint;
  public Transform restartPoint;
  bool shouldRespawn = false;
	SpriteRenderer renderer; 

void Start() {
	renderer = GetComponentInChildren<SpriteRenderer>();
}

  void Update() {
    move(speed);

    if(isAfterRestartPoint()) {
      recalculatePosition();
      shouldRespawn = false;
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

  bool isAfterRestartPoint() {
    float centerPosition = transform.position.x + (renderer.bounds.size.x / 2);
    
    if(centerPosition < restartPoint.position.x)
      return true;
    else
      return false;
  }
}
