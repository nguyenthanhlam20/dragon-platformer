using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float speed;
    float offset;
    Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = speed * Time.time;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}