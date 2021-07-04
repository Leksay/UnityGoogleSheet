using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GoogleSheetLoader _loader;

    private void Awake()
    {
        _loader.OnProcessData += InstantiateCubes;
    }

    private void InstantiateCubes(CubesData data)
    {
        foreach (var cubeData in data.CubeOptionsList)
        {
            var newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.transform.position = cubeData.Position;
            newCube.transform.localScale = cubeData.LocalScale;
            newCube.GetComponent<MeshRenderer>().material.color = cubeData.Color;

        }
    }
}
