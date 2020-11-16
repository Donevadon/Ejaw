using UnityEngine;

public class InteractionMouseClickWithObject : MouseClick
{
    protected override void Awake()
    {
        base.Awake();
        nameManager = new RandomNameWithJson();
        clicksData = Resources.Load<GeometryObjectData>("GeometryObjectData");
    }

    protected override GameObject CreateObject(Vector3 position)
    {
        return Instantiate(Resources.Load<GameObject>($"Prefabs/{nameManager.GetName(Random.Range(0,nameManager.Count))}"),position,Quaternion.identity);
    }
}