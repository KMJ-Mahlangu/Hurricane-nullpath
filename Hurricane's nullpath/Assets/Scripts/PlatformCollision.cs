using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] Transform platform;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag.Equals(playerTag))
        {
            collision.gameObject.transform.parent = platform;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag.Equals(playerTag))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
