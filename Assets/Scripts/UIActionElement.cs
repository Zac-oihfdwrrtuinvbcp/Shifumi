using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionElement : MonoBehaviour
{
    [SerializeField]
    private float animationDuration = 0.7f;

    private Image image;

    private Color color;

    private void Awake()
    {
        image = GetComponent<Image>();
        color = image.color;
    }

    public void Activate()
    {
        image.color = Color.white;

        Invoke("Deactivate", animationDuration);
    }

    public void Deactivate()
    {
        image.color = color;
    }
}
