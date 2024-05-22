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
            Destroy(gameObject);
        }
    }
}
