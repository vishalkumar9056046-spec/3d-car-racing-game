using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -8);
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float lookAheadDistance = 10f;
    
    private void LateUpdate()
    {
        if (target == null)
            return;
        
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        transform.position = smoothedPosition;
        
        Vector3 lookTarget = target.position + target.forward * lookAheadDistance;
        transform.LookAt(lookTarget, Vector3.up);
    }
}
