using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float noteHitWindow = 0.2f;

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

    [SerializeField]
    private Text scoreText;

    public float timer = 0;

    public float notesBaseSpeed;

    private int currentNoteIndex = 0;

    public List<NoteObject> instanciedNotes = new List<NoteObject>();

    public int score = 0;

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

            float delay = notesBaseSpeed * earlyNoteSpawnTime / gameTimeMultiplier;
            if (currentNoteIndex < currentLevel.notes.Length && timer >= currentLevel.notes[currentNoteIndex].time - earlyNoteSpawnTime)
            {
                NoteObject newNote = Instantiate(currentLevel.notes[currentNoteIndex].notePrefab, spawnPoint.position, Quaternion.identity);
                newNote.time = currentLevel.notes[currentNoteIndex].time;
                newNote.action = currentLevel.notes[currentNoteIndex].action;

                instanciedNotes.Add(newNote);
                currentNoteIndex++;
            }
        }
    }

    public void ExecutePlayerAction(string action)
    {
        if (currentLevel != null)
        {
            int index = 0;
            foreach (NoteObject note in instanciedNotes)
            {
                if (Mathf.Abs(note.time - timer) < noteHitWindow )
                {
                    instanciedNotes[index].Hit(action);
                    break;
                }
                index++;
            }
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }


}
