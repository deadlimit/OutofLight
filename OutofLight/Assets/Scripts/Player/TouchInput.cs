using System.Collections;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    private Touch theTouch;
    private Vector3 touchStartPosition, touchEndPoisition, direction;

    public GameEvent DoubleTap;

    public bool onCooldown;

    void Update() {
        GetSwipeDirection();

        GetDoubleTap();

        if (!onCooldown)
            TouchRay();
    }

    private IEnumerator CooldownTimer() {
        onCooldown = true;
        yield return new WaitForSeconds(2);
        onCooldown = false;
    } 


    private void GetDoubleTap() {
        if(Input.touchCount > 0) {
            if (theTouch.tapCount == 2) {
                DoubleTap.Raise();
            }
        }
        
    }

    private void TouchRay() {
        if(Input.touchCount > 0) {

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit)) {
                IInteractable temp = hit.transform.gameObject.GetComponent<IInteractable>();
                Debug.Log(temp);
                if (temp == null) return;

                temp.Use();
                StartCoroutine(CooldownTimer());
                
            }
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
