using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragNDrop : MonoBehaviour
{
    public Camera MainCamera;
    [SerializeField]
    public UnityEvent OnStartDrag;
    [SerializeField]
    public UnityEvent OnStopDrag;

    float ZPos;
    Vector3 offset;
    bool Dragging;


    void Start()
    {
        ZPos = MainCamera.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        if (Dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,ZPos);
            transform.position = MainCamera.ScreenToWorldPoint(position + new Vector3(offset.x, offset.y));
        }
    }

    void OnMouseDown()
    {
        if (!Dragging)
        {
            StartDrag();
        }
    }

    void OnMouseUp()
    {
        EndDrag();
    }

    public void StartDrag()
    {
        OnStartDrag.Invoke();
        Dragging = true;
        offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;      
    }
    public void EndDrag()
    {
        OnStopDrag.Invoke();
        Dragging = false;
    }
}