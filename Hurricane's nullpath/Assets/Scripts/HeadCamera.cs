using UnityEngine;

public class HeadCamera : MonoBehaviour
{
    public Transform headbone;
    public Vector3 offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(headbone != null)
        {
            transform.position = headbone.position + headbone.TransformDirection(offset);
            transform.rotation = headbone.rotation;
        }
    }
}
