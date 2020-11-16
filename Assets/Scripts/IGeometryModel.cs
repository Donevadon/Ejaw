using UnityEngine;

public interface IGeometryModel
{
    string Type{get;}
    int AddClick();
    void ChangeColor(Color color);
}
