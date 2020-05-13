using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    [SerializeField] private float maxDistance;
    private RaycastHit hit;
    private bool hitObject;
    private Transform _transform;

    public GameEvent ActivateInteract;
    
    public InteractParameter interactableObject;
    
    private void Awake() {
        _transform = GetComponent<Transform>();
    }
    public void LookAround() {
        CastRays(Vector3.right);
        CastRays(Vector3.forward);
        CastRays(Vector3.left);
        CastRays(Vector3.back);
    }

    private void CastRays(Vector3 direction) {
        hitObject = Physics.BoxCast(_transform.position, _transform.localScale / 2, direction, out hit, Quaternion.identity, maxDistance, LayerMask.GetMask("Interactable"));

        if (hitObject) {
            Debug.Log(hit.transform.gameObject);
            interactableObject.thisObject = hit.transform.gameObject.GetComponent<IInteractable>();
            ActivateInteract.Raise(); 
        }
            
    }
    
}

