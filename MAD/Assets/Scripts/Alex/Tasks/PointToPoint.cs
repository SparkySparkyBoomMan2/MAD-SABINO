using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPoint : MonoBehaviour
{
    // These will all be positions, relative to their original locations
    // - i.e., if we have a table, then the goal will start in the middle of the table, and changes to the vector3 will move it accordingly from that starting position
    public Vector3 goalPosition;
    public Vector3 homePosition;
    public Vector3 startPosition;
}
