using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBehaviour : MonoBehaviour
{

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    public Vector2 paralaxEffectMultiplier;
    private float textureUnitSizeX;
    private float textureUnitSizeY;
    public bool infiniteHorizontal;
    public bool infiniteVertical;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        Debug.Log("git fix");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * paralaxEffectMultiplier.x, deltaMovement.y * paralaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;


        if(infiniteHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            }
        }

       
        if(infiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
            }
        }
    }
}
