using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShadowSettings
{
    [Range(0,100)]
    public float maxDistance;
    
    public Directional directional = new Directional()
    {
        _size = TextureSize._256
    };
}

//shadowmap大小
public enum TextureSize
{
    _256 = 256, _512 = 512, _1024 = 1024,
    _2048 = 2048, _4096 = 4096, _8192 = 8192
}

[Serializable]
public struct Directional
{
    public TextureSize _size;
}