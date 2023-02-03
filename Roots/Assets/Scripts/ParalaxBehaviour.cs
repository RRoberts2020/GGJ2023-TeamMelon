using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBehaviour : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField]
    private float paralax_speed = 1f;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(paralax_speed * Time.deltaTime, 0);
    }
}
