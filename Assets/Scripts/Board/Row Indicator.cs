using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowIndicator : MonoBehaviour
{
    public void UpdatePosition (float zPos) 
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, zPos);
    }
}
