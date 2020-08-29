using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouse : MonoBehaviour
{
    private Vector3 mouse;

    private void OnMouseDrag()
    {
        mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = 0;
        transform.position = mouse;
        transform.position = new Vector2(Mathf.RoundToInt(mouse.x), Mathf.RoundToInt(mouse.y));
    }
}
