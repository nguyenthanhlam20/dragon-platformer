using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private Canvas canvas;
    // Start is called before the first frame update
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    void Start()
    {
        canvas.worldCamera = Camera.main;
    }


}
