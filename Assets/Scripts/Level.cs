using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public float time;
    public string action;

    public NoteObject notePrefab;

    public Note(float _time, string _action, NoteObject _notePrefab)
    {
        this.time = _time;
        this.action = _action;
        this.notePrefab = _notePrefab;
    }

}
public class Level : MonoBehaviour
{
    [SerializeField]
    private NoteObject notePrefab;

    [SerializeField]
    public Note[] notes;

    [SerializeField]
    private int notesCount;

    [SerializeField]
    private float minimumTimeBetweenNotes;

    [SerializeField]
    private float maximumTimeBetweenNotes;

    private void Start()
    {
        TempRngGenerate();
    }
    private void TempRngGenerate()
    {
        notes = new Note[notesCount];
        float lastSpawnTime = 0f;
        for (int i = 0; i < notesCount; i++) 
        { 
            float timeBetweenNotes = Random.Range(minimumTimeBetweenNotes, maximumTimeBetweenNotes); 
            float spawnTime = lastSpawnTime + timeBetweenNotes; 
            string action = Random.Range(0, 3) == 0 ? "Rock" : Random.Range(0, 3) == 1 ? "Paper" : "Scissors";
            notes[i] = new Note(spawnTime, action, notePrefab); 
            lastSpawnTime = spawnTime;
        }
    }
}
