using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorRoom3To4 : MonoBehaviour
{
    public BoolVariable leverPulled;
    public int newSceneIndex;
    public Image paper;
    public Text room3Locked;

    [SerializeField] private bool closeToDoor;

    private void Start()
    {
        paper.enabled = false;
        room3Locked.enabled = false;
    }

    public void Use()
    {
        if (!leverPulled)
            SceneManager.LoadScene(newSceneIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && leverPulled)
        {
            paper.enabled = true;
            room3Locked.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            paper.enabled = false;
            room3Locked.enabled = false;
        }
    }

    public void UnlockDoor()
    {
        gameObject.AddComponent<Door>();
        GetComponent<Door>().newSceneIndex = 5;
    }
}
