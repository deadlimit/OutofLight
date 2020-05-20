using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

    private Touch theTouch;
    private Vector3 touchStartPosition, touchEndPosition, direction;
    private void Update() {
        GetSwipeDirection();
    }
    
    
    private void GetSwipeDirection() {
        direction = Vector3.zero;
        if (Input.touchCount > 0) {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began) {
                touchStartPosition = theTouch.position;
            }  else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended) {
                touchEndPosition = theTouch.position;

                var x = touchEndPosition.x - touchStartPosition.x;
                var y = touchEndPosition.y - touchStartPosition.y;
                
                if (Mathf.Abs(x) > Mathf.Abs(y))
                    direction = x > 0 ? Vector3.right : Vector3.left;

                else
                    direction = y > 0 ? Vector3.forward : Vector3.back;

            }
            
        }
    }

    public Vector3 GetDirection() {
        return direction.normalized;
    }

    
}
