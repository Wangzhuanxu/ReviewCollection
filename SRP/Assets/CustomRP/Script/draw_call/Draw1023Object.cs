using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Draw1023Object : MonoBehaviour
{
    [Range(0, 1023)] public int number;
    private MaterialPropertyBlock _block;
    private static int _baseColorId = Shader.PropertyToID("_BaseColor");
    private static int _cutOffId = Shader.PropertyToID("_CutOff");
    private Vector4[] colors;
    private Matrix4x4[] matrixs;
    private float[] cutOffs;
    public GameObject prefab;
    private Mesh _mesh;
    private Material _material;
    void Start()
    {
        colors = new Vector4[number];
        matrixs = new Matrix4x4[number];
        cutOffs = new float[number];
        for (int i = 0; i < number; i++)
        {
            matrixs[i] = Matrix4x4.TRS(
                Random.insideUnitSphere * 10f, Quaternion.identity, Vector3.one
            );
            colors[i] =
                new Vector4(Random.value, Random.value, Random.value, Random.value);

            cutOffs[i] = Random.value;
        }

        _material = prefab.GetComponent<MeshRenderer>().sharedMaterial;
        _mesh = prefab.GetComponent<MeshFilter>().sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (_block == null)
        {
            _block = new MaterialPropertyBlock();
            _block.SetVectorArray(_baseColorId,colors);
            _block.SetFloatArray(_cutOffId,cutOffs);
        }
        Graphics.DrawMeshInstanced(_mesh,0,_material,matrixs,number,_block);
    }
}
