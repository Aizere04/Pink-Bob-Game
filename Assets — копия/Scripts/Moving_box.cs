using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_box : MonoBehaviour
{
    [SerializeField] private GameObject[] _points;
    private int current_points = 0;
    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(_points[current_points].transform.position, transform.position) < .1f)
        {
            current_points++;
            if (current_points >= _points.Length)
            {
                current_points = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, _points[current_points].transform.position, Time.deltaTime * speed);
    }
}
