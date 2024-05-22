using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionElement : MonoBehaviour
{
    [SerializeField]
    private float animationDuration = 0.7f;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Activate()
    {
        image.color = Color.green;

        Invoke("Deactivate", animationDuration);
    }

    public void Deactivate()
    {
        image.color = Color.white;
    }
}
