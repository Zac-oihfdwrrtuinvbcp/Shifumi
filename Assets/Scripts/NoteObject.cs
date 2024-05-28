using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public float time;
    public string action;

    public Renderer renderer;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        Material newMaterial = new Material(Shader.Find("Standard"));

        switch (action)
        {
            case "Rock":
                newMaterial.color = Color.magenta;
                break;
            case "Paper":
                newMaterial.color = Color.green;
                break;
            case "Scissors":
                newMaterial.color = Color.blue;
                break;
            default:
                break;
        }
 
        renderer.material = newMaterial ;

    }

    void Update()
    {
        float step = gameManager.notesBaseSpeed * gameManager.gameTimeMultiplier * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, gameManager.endPoint.position, step);   

        if (gameManager.timer > time)
        {
           renderer.material.color = Color.red;
        }

        if (Vector3.Distance(transform.position, gameManager.endPoint.position) < 0.1f)
        {
            gameManager.instanciedNotes.Remove(this);
            Destroy(gameObject);
        }
    }

    public void Hit(string playerAction)
    {
        if (playerAction == action)
        {
            Destroy(gameObject);
            gameManager.AddScore(1);
        }
    }
}
