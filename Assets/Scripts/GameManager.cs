using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameManager");
                    instance = singleton.AddComponent<GameManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }


    [SerializeField]
    public float gameTimeMultiplier = 1;

    [SerializeField]
    public float earlyNoteSpawnTime = 2f;

    [SerializeField]
    private Level currentLevel;

    [SerializeField]
    public Transform spawnPoint;

    [SerializeField]
    public Transform endPoint;

    [SerializeField]
    public Transform hitPoint;

    public float timer = 0;

    public float notesBaseSpeed;

    private int currentNoteIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

         float distance = Vector3.Distance(spawnPoint.position, hitPoint.position);

        notesBaseSpeed = distance / earlyNoteSpawnTime;
    }

    private void Update()
    {
        if (currentLevel != null)
        {
            timer += Time.deltaTime * gameTimeMultiplier;

            float delay = notesBaseSpeed * gameTimeMultiplier;
            Debug.Log("Delay: " + delay);
            if(currentNoteIndex < currentLevel.notes.Length && timer >= currentLevel.notes[currentNoteIndex].time - delay)
            {
                NoteObject newNote = Instantiate(currentLevel.notes[currentNoteIndex].notePrefab, spawnPoint.position, Quaternion.identity);
                newNote.time = currentLevel.notes[currentNoteIndex].time;
                newNote.action = currentLevel.notes[currentNoteIndex].action;

                currentNoteIndex++;
            }
        }
    }

    public void ExecutePlayerAction(string action)
    {
        if (currentLevel != null)
        {
            //currentLevel.ExecutePlayerAction(action);
        }
    }


}
