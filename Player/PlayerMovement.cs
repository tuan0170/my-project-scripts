using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_jumpForce = 4;
    private float m_currentV = 0;
    private float m_currentH = 0;

    [Header("Animation")]
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;


    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    [Header("Jump")]
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_jumpInput = false;
    [SerializeField]private int m_jumpTimes =0;
    [SerializeField]private int m_maxJumpTimes = 2;

    [Header("Sound")]
    [SerializeField]private AudioSource m_jumpSound;
    [SerializeField]private AudioSource m_landSound;
    [Header("Other")]
    [SerializeField]private MobileJoystick mobileJoystick;
    [SerializeField]private ItemShop item = null;

    //

    private bool m_isGrounded;

    private List<Collider> m_collisions = new List<Collider>();

    #region properties
    public float M_moveSpeed
     {
         get{ return m_moveSpeed;}
         set{m_moveSpeed = value;}
     }
    public float M_jumpForce
     {
         get{ return m_jumpForce;}
         set{m_jumpForce = value;}
     }

    #endregion

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
        m_jumpTimes = m_maxJumpTimes;
    }
    #region event
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }
    

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }

    }

    

    public void JumpButton()//mobile input
    {
        if (!m_jumpInput)
        {
            m_jumpInput = true;
        }
    }
    #endregion

    private void Update()
    {
        if (!m_jumpInput && Input.GetKey(KeyCode.Space))
        {
            m_jumpInput = true;
        }
         
        JumpingAndLanding();
        m_jumpInput = false;
        
    }
    private void FixedUpdate()
    {
        m_animator.SetBool("Grounded", m_isGrounded);
        m_wasGrounded = m_isGrounded; 
        DirectUpdate();
        
    }
    #region method
    private void DirectUpdate()
    {


        float v = mobileJoystick.Vectical();
        float h = mobileJoystick.Horizontal();

        Transform camera = Camera.main.transform;


        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }
    }
    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver &&m_jumpInput && m_jumpTimes > 1 && m_jumpTimes <= m_maxJumpTimes )
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            m_jumpTimes -= 1;
            m_jumpSound.Play();
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
            m_landSound.Play();
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
            
        }

        if(m_isGrounded)
        {
            m_jumpTimes = m_maxJumpTimes;
        }
    }

    public void SpeedDown(float speedDown)
    {
        if(!item.EffectResistanceBuff)
        {
            m_moveSpeed -= speedDown;
        }
        
    }
    public void ReturnCurrentSpeed(float speedDown)
    {
        if(!item.EffectResistanceBuff)
        {
            m_moveSpeed += speedDown;
        }
    }


    #endregion
    
}
