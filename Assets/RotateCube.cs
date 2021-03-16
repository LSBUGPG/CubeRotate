using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float speed = 1.0f;
    float time = 0.0f;
    Quaternion start;
    Quaternion end;
    Queue<Quaternion> moves = new Queue<Quaternion>();

    void Move(Quaternion direction)
    {
        moves.Enqueue(direction);
    }

    public void MoveRight()
    {
        Move(Quaternion.Euler(0.0f, -90.0f, 0.0f));
    }

    public void MoveLeft()
    {
        Move(Quaternion.Euler(0.0f, 90.0f, 0.0f));
    }

    public void MoveUp()
    {
        Move(Quaternion.Euler(90.0f, 0.0f, 0.0f));
    }

    public void MoveDown()
    {
        Move(Quaternion.Euler(-90.0f, 0.0f, 0.0f));
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        if (time > 1.0f)
        {
            time = 1.0f;
            transform.rotation = end;

            if (moves.Count > 0)
            {
                Quaternion direction = moves.Dequeue();
                start = transform.rotation;
                end = direction * start;
                time = 0.0f;
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(start, end, time);
        }
    }
}
