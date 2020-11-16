using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GeometryObjectData", menuName = "GeometryObjectData", order = 0)]
public class GeometryObjectData : ScriptableObject 
{
    public List<ClickColorData> clicksData;
}