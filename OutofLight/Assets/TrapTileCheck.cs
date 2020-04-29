using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTileCheck : MonoBehaviour {

    public GameEvent StandingOnTrapTile;

    public void CheckUnderneath() {

        Ray ray = new Ray(transform.position, Vector3.down);

        RaycastHit hit;

        bool isValidTile = Physics.Raycast(ray, out hit);

        if(isValidTile && hit.transform.gameObject.CompareTag("Tile")) {
            if (hit.transform.gameObject.GetComponent<Tile>().trapTile) {
                StandingOnTrapTile.Raise();
            }
        }
    }

}
