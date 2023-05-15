using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float raycastDistance = 3f;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float runSpeed = 9f;
    [SerializeField] private float jumpHeight = 0.3f;
    [SerializeField] private int enemyDie = 0;
    private Rigidbody rigidbody;
    private bool isJumping, isRunning;
    private AudioManager audioManager;
    public Text showEnemyDie;
    public int EnemyDie { get => enemyDie; set => enemyDie = value; }

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        showEnemyDie.text = "Enemy Kill: "+EnemyDie;

    }
    void FixedUpdate()
    {
        ChangeSate();

    }
    private bool GroundCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Ki?m tra n?u tia Raycast ch?m vào ??i t??ng có layer "Ground"
        if (Physics.Raycast(ray, out hit, raycastDistance, groundLayerMask)) {
            return true;
        }
           

        return false;

    }
    private void OnRunning()
    {
        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        if (!audioManager.IsPlaying("run")){
            audioManager.Play("run");
        }
    }
    private void OnJumping()
    {
        rigidbody.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
        if (!audioManager.IsPlaying("jump"))
        {
            audioManager.Play("jump");
        }
    }
    private void ChangeSate()
    {
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {
            OnRunning();
        }
        else
        {
            audioManager.Stop("run");
        }
        if(Input.GetAxis("Jump") != 0 && GroundCheck())
        {
            OnJumping();
        }
        else if(GroundCheck())
        {
            audioManager.Stop("jump");
        }
    }
}
