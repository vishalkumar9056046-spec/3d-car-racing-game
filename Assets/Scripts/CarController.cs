using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float maxSpeed = 150f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float brakePower = 100f;
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float maxTurnAngle = 30f;
    
    [Header("Nitro Boost")]
    [SerializeField] private float nitroBoostMultiplier = 1.5f;
    [SerializeField] private float nitroDuration = 5f;
    [SerializeField] private float nitroRechargeTime = 10f;
    
    [Header("Physics")]
    [SerializeField] private Rigidbody carRigidbody;
    [SerializeField] private float dragOnBrake = 5f;
    [SerializeField] private float normalDrag = 1f;
    
    private float currentSpeed = 0f;
    private float currentTurnAngle = 0f;
    private float nitroEnergy = 1f;
    private bool nitroActive = false;
    private float nitroTimer = 0f;
    private int selectedCarType = 0;
    
    private void Start()
    {
        if (carRigidbody == null)
            carRigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        HandleInput();
        UpdateNitro();
    }
    
    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
    }
    
    private void HandleInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Accelerate/Brake
        if (verticalInput > 0)
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
            carRigidbody.drag = normalDrag;
        }
        else if (verticalInput < 0)
        {
            currentSpeed = Mathf.Max(currentSpeed - brakePower * Time.deltaTime, 0f);
            carRigidbody.drag = dragOnBrake;
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * 2f);
            carRigidbody.drag = normalDrag;
        }
        
        // Turn
        currentTurnAngle = horizontalInput * maxTurnAngle;
        
        // Nitro Boost
        if (Input.GetKeyDown(KeyCode.Space) && nitroEnergy > 0f && !nitroActive)
        {
            ActivateNitro();
        }
    }
    
    private void ApplyMovement()
    {
        float speedMultiplier = nitroActive ? nitroBoostMultiplier : 1f;
        Vector3 forwardForce = transform.forward * currentSpeed * speedMultiplier;
        carRigidbody.velocity = new Vector3(forwardForce.x, carRigidbody.velocity.y, forwardForce.z);
    }
    
    private void ApplyRotation()
    {
        if (currentSpeed > 0.1f)
        {
            float turnAmount = currentTurnAngle * turnSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, turnAmount, 0);
        }
    }
    
    private void ActivateNitro()
    {
        nitroActive = true;
        nitroTimer = nitroDuration;
        nitroEnergy = 0f;
    }
    
    private void UpdateNitro()
    {
        if (nitroActive)
        {
            nitroTimer -= Time.deltaTime;
            if (nitroTimer <= 0)
            {
                nitroActive = false;
            }
        }
        else
        {
            nitroEnergy = Mathf.Min(nitroEnergy + Time.deltaTime / nitroRechargeTime, 1f);
        }
    }
    
    public float GetSpeed()
    {
        return currentSpeed / maxSpeed;
    }
    
    public float GetNitroEnergy()
    {
        return nitroEnergy;
    }
    
    public bool IsNitroActive()
    {
        return nitroActive;
    }
    
    public void SetCarType(int carType)
    {
        selectedCarType = carType;
        // Adjust car stats based on type
        switch (carType)
        {
            case 0: // Sports Car
                maxSpeed = 180f;
                acceleration = 80f;
                break;
            case 1: // Truck
                maxSpeed = 120f;
                acceleration = 40f;
                break;
            case 2: // Formula
                maxSpeed = 200f;
                acceleration = 100f;
                break;
            case 3: // SUV
                maxSpeed = 140f;
                acceleration = 60f;
                break;
            case 4: // Hypercar
                maxSpeed = 250f;
                acceleration = 120f;
                break;
        }
    }
}