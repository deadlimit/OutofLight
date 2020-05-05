using System.Collections;
using UnityEngine;

public class MovableBox : MonoBehaviour {

    [SerializeField]
    private Vector3 lockedDirection;
    [SerializeField]
    private bool lockDirection;
    [SerializeField][Header("Layernummer, tilldelas efter kollision (så spelaren inte går igenom lådan)")]
    private int newLayer;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Vector3 moveDirection = CalculatedMoveDirection(transform.position - other.gameObject.transform.position);
            //gameObject.layer = newLayer;
            StartCoroutine(Move(moveDirection));
        }
    }

    IEnumerator Move(Vector3 direction) {

        float startTime = 0;
        var endPosition = direction + transform.position;

        while (startTime < 2) {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, 1.5f * Time.deltaTime);

            startTime += Time.deltaTime;
            yield return null;
        }

    }

    private Vector3 CalculatedMoveDirection(Vector3 direction) {
        //TODO: Gör den här bättre
        if (!lockDirection) {
            if (direction.x > 0)
                return Vector3.right;
            else if (direction.x < -.9f)
                return Vector3.left;
            else if (direction.z > .9f)
                return Vector3.forward;
            else
                return Vector3.back;
        } else
            return lockedDirection;
        

        
    }

}
