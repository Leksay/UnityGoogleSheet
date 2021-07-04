using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubesData
{
    public List<CubeOptions> CubeOptionsList;

    public override string ToString()
    {
        string result = "";
        CubeOptionsList.ForEach(o =>
        {
            result += o.ToString();
        });
        return result;
    }
}
[System.Serializable]
public class CubeOptions
{
    public int Id;
    public Vector3 Position;
    public Vector3 LocalScale;
    public Color Color;

    public override string ToString()
    {
        return $"Id {Id} \nPosition {Position} \nLocalScale {LocalScale} \nColor {Color}";
    }
}