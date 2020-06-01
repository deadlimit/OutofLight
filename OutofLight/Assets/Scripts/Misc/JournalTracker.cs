using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JournalTracker : MonoBehaviour
{
    public List<GameObject> journalsInScene = new List<GameObject>();
    public Journal playerJournal;

    [SerializeField]
    private Scene currentScene;
    private Vector3 respawnPosition;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    private void Start()
    {
        foreach (GameObject journal in GameObject.FindGameObjectsWithTag("Journal"))
        {
            if (journal.tag == "Journal")
            {
                journalsInScene.Add(journal);
                respawnPosition = journal.transform.position;
            }
        }
    }

    public void RespawnJournals()
    {
        foreach (GameObject journal in journalsInScene)
        {
            Instantiate(journal);
        }
    }

}
