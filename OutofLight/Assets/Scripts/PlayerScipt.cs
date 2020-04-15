using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScipt : MonoBehaviour
{
    private Transform _transform;
    private Vector3 newPosition;
    private Rigidbody _rb2D;
    private bool moving;
    void Awake() {
        _transform = GetComponent<Transform>();
        _rb2D = GetComponent<Rigidbody>();
        
    }

    void Start() {
        moving = false;
    }

    void Update() {
        if (Input.GetMouseButton(0) && !moving) {
            GetClickedTile();
        }
    }
    private void GetClickedTile() {

         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         if (Physics.Raycast(ray, out hit, 100)) {
            Vector3 newDest = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
            SetMoving(true);
            print("I am now at " + hit.transform.gameObject.ToString());
            StartCoroutine(Move(newDest));        
        }            
    }

    private IEnumerator Move(Vector3 endPosition) {
        float startTime = Time.time;
        float distance = Vector3.Distance(transform.position, endPosition);
        
        while(transform.position != endPosition) {
            float distanceCovered = (Time.time - startTime);
            float fractionOfJourney = distanceCovered / distance;
            transform.position = Vector3.Lerp(transform.position, endPosition, fractionOfJourney);
            yield return null;
        }

        SetMoving(false);

    }

    private void SetMoving(bool value) {
        moving = value;
    }


}


