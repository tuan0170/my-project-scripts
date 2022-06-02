using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField]private Transform m_target;
    [SerializeField] private float m_smoothSpeed = 0.125f;
    [SerializeField]private Vector3 m_offset;
    private void FixedUpdate() {
        CameraFollowPlayer();
    }
    #region method
    private void CameraFollowPlayer()
    {
        Vector3 _desiredPosition = m_target.position + m_offset;
		Vector3 _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, m_smoothSpeed);
		transform.position = _smoothedPosition;

		transform.LookAt(m_target);
    }
    #endregion
    
}
