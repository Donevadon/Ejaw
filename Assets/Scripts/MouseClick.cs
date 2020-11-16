using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using UnityEngine;

public abstract class MouseClick : MonoBehaviour
{
    private Camera _mainCamera;
    protected IName nameManager;
    public GeometryObjectData clicksData;


    protected virtual void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Raycast();
        }
    }

    private void Raycast()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            InteractObject(hit.transform.GetComponent<IGeometryModel>());
        }else
        {
            CreateObject(ray.origin + ray.direction);
        }
    }

    private void InteractObject(IGeometryModel model)
    {
        var clicks = model.AddClick();
        var selectData = clicksData.clicksData
            .Where(x => x.objectType == model.Type && (clicks >= x.minClicksCount && clicks <= x.maxClicksCount));
        foreach(var data in selectData)
        {
            model.ChangeColor(data.color);
            break;
        }
    }

    protected abstract GameObject CreateObject(Vector3 position);
}
