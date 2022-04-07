using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        //offset = material.mainTextureOffset;
        //material.SetTextureOffset(material.shader.GetPropertyNameId(0), offset + Time.deltaTime * moveSpeed);

        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
