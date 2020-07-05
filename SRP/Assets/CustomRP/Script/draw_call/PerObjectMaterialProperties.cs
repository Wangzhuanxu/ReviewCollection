using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerObjectMaterialProperties : MonoBehaviour
{
    public Color BaseColor;
    private static MaterialPropertyBlock _block;
    private static int _baseColorId = Shader.PropertyToID("_BaseColor");
    private void OnValidate()
    {
        if (_block == null)
        {
            _block = new MaterialPropertyBlock();
        }
        _block.SetColor(_baseColorId,BaseColor);
        GetComponent<MeshRenderer>().SetPropertyBlock(_block);
    }
}
