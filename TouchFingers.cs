using System;
using UnityEngine;

public class TouchFinger : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0)
        {
          Touch _touch = Input.GetTouch(0);
            
            if (_touch.phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(_touch.position);
                RaycastHit _hit;
                if (Physics.Raycast(ray, out _hit))
                {
                    Debug.Log(_hit.collider.name);
                    Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y, Mathf.Abs(_hit.collider.transform.position.z - Camera.main.transform.position.z)));
                    _hit.transform.position = vec;
                }
            }
        }
    }
}
