using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotateCube))]
public class DetectMouseInput : MonoBehaviour
{
    Vector3 downPosition;
    RotateCube cube;

    void Start()
    {
        cube = GetComponent<RotateCube>();
    }

    void OnMouseDown()
    {
        downPosition = Input.mousePosition;
    }
    void OnMouseUp()
    {
        Vector3 move = Input.mousePosition - downPosition;
        if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
        {
            if (move.x > 0)
            {
                cube.MoveRight();
            }
            else
            {
                cube.MoveLeft();
            }
        }
        else
        {
            if (move.y > 0)
            {
                cube.MoveUp();
            }
            else
            {
                cube.MoveDown();
            }
        }
    }
}
