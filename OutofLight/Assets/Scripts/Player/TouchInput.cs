using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class TouchInput : MonoBehaviour {

    private Touch theTouch;
    private Vector3 touchStartPosition, touchEndPosition, direction;
    private float noSwipeZoneHeight;
    private float noSwipeZoneWidth;

    private void Awake() {
        noSwipeZoneHeight = Screen.height * .3f;
        noSwipeZoneWidth = Screen.width - (Screen.width * .3f);
    }
    
    private void Update() {
        GetSwipeDirection();
    }
    private void GetSwipeDirection() {
        direction = Vector3.zero;
        if (Input.touchCount <= 0) return;
        theTouch = Input.GetTouch(0);

        if (theTouch.phase != TouchPhase.Began) {
            if (theTouch.phase != TouchPhase.Moved) return;
            touchEndPosition = theTouch.position;
            if (touchStartPosition.x > noSwipeZoneWidth && touchStartPosition.y <= noSwipeZoneHeight)
                return;

            var x = touchEndPosition.x - touchStartPosition.x;
            var y = touchEndPosition.y - touchStartPosition.y;
            
            
            if (Mathf.Abs(x) > Mathf.Abs(y))
                direction = x > 0 ? Vector3.right : Vector3.left;

            else
                direction = y > 0 ? Vector3.forward : Vector3.back;
        }
        else {
            touchStartPosition = theTouch.position;
        }
    }

    public Vector3 GetDirection() {
        return direction.normalized;
    }
    
    
}
