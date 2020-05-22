using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform _transform;

    [SerializeField]
    private bool doRotate;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (doRotate) rotate();
    }
    private void rotate()
    {
        var angle = new Vector3(_transform.rotation.x, Random.Range(1, 360), _transform.rotation.z);

        _transform.Rotate(angle * Time.deltaTime / 10, Space.World);
    }
}
