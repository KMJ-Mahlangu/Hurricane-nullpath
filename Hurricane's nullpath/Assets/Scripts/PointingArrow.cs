using UnityEngine;

public class PointingArrow : MonoBehaviour
{
    public Transform[] targets;         
    private int currentTargetIndex = 0;
    public Vector3 offset = new Vector3(0, 2, 0); 

    void Update()
    {
        if (targets.Length > 0 && targets[currentTargetIndex] != null)
        {
          
            transform.position = targets[currentTargetIndex].position + offset;
        }
    }

    
    public void PointToNext()
    {
        currentTargetIndex++;
        if (currentTargetIndex >= targets.Length)
        {
            currentTargetIndex = 0; 
        }
    }

    
}
