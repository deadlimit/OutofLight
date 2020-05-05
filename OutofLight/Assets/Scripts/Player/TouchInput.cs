using UnityEngine;

public class TouchInput : MonoBehaviour {

    private Touch theTouch;
    private Vector3 touchStartPosition, touchEndPoisition, direction;

    public GameEvent DoubleTap;

    void Update() {
        GetSwipeDirection();

        GetDoubleTap();
    }

    private void GetDoubleTap() {
        if (theTouch.tapCount == 2) {
            DoubleTap.Raise();
        }
    }

    private void GetSwipeDirection() {
        direction = Vector3.zero;

        if (Input.touchCount > 0) {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began) {
                touchStartPosition = theTouch.position;
            }  else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended) {
                touchEndPoisition = theTouch.position;

                float x = touchEndPoisition.x - touchStartPosition.x;
                float y = touchEndPoisition.y - touchStartPosition.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                    direction = Vector3.zero;

                else if (Mathf.Abs(x) > Mathf.Abs(y))
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
