using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public Grid grid;
    public float lerpTime;

    public Vector3Int CurrentCoords{ get{ return currentCoords; } }

    Vector3Int currentCoords;
    Vector3 targetPosition;

    public void MoveTo(Vector3Int newCoords)
    {
        currentCoords = newCoords;
        targetPosition = grid.CellToWorld(newCoords);
        StartCoroutine("LerpPosition");
    }
    private void Start()
    {
        currentCoords = grid.WorldToCell(transform.position);
        transform.position = grid.CellToWorld(currentCoords);
        targetPosition = transform.position;
    }
    private Vector3 SnapToGrid(Vector3 position)
    {
        return grid.CellToWorld(grid.WorldToCell(position));
    }
    // void Update()
    // {
    //     if(Input.GetKeyDown("d"))
    //     {
    //         Vector3Int newcoord = currentCoords;
    //         newcoord.x++;
    //         MoveTo(newcoord);
    //     }
    //     if(Input.GetKeyDown("a"))
    //     {
    //         Vector3Int newcoord = currentCoords;
    //         newcoord.x--;
            
    //         MoveTo(newcoord);
    //     }
    // }
    IEnumerator LerpPosition()
    {
        float startTime = Time.time;
        while(Time.time - startTime <= lerpTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, (Time.time - startTime) / lerpTime);
            yield return null;
        }
        transform.position = targetPosition;
    }
}
