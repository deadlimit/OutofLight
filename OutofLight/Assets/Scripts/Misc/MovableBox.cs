using System.Collections;
using UnityEngine;

public class MovableBox : MonoBehaviour, IInteractable {

    [Header("Ange vilket håll lådan ska gå röra sig åt")]
    [SerializeField] public Vector3 lockedDirection;

    [Header("Ange antal tiles lådan rör sig åt hållet angivet ovan")]
    [SerializeField] private int tileMoves;

    private bool canBeMoved;

    public GameEvent UpdateTiles;

    public void Use() {
        if (canBeMoved && tileMoves > 0)
            StartCoroutine(Move(lockedDirection));
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            canBeMoved = true;
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            canBeMoved = false;
    }

    IEnumerator Move(Vector3 direction) {

        float startTime = 0;
        var endPosition = direction + transform.position;

        while (startTime < 2) {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, 1.5f * Time.deltaTime);

            startTime += Time.deltaTime;
            yield return null;
        }
        tileMoves--;
        UpdateTiles.Raise();

    }


}
