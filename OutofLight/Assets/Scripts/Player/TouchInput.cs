using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

    private Touch theTouch;
    private Vector3 touchStartPosition, touchEndPosition, direction;

    public GameEvent DoubleTap;
    public bool onCooldown;

    private void Update() {
        GetSwipeDirection();

        GetDoubleTap();

        if (!onCooldown)
            TouchRay();
    }

    private void GetDoubleTap() {
        if (theTouch.tapCount != 2) return;

        DoubleTap.Raise();
    }

    private void TouchRay() {

        if (Input.touchCount <= 0) return;

        var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        if (!Physics.Raycast(ray, out var hit)) return;

        var temp = hit.transform.gameObject.GetComponent<IInteractable>();

        if (temp == null) return;

        StartCoroutine(CooldownTimer());
        temp.Use();
    }


    private IEnumerator CooldownTimer() {
        onCooldown = true;
        yield return new WaitForSeconds(1);
        onCooldown = false;
    }

    private void GetSwipeDirection() {
        direction = Vector3.zero;

        if (Input.touchCount > 0) {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began) {
                touchStartPosition = theTouch.position;
            }  else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended) {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

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
