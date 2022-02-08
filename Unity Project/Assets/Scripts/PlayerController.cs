using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementSettings movementSettings;
    private float groundCheckRadius = 0.2f;

    // Acceleration
    private float accelerationX = 0.0f;
    private float accelerationY = 0.0f;
    private float accelerationZ = 0.0f;

    private float yRotation;
    private float xRotation;

    // References
    public CharacterController controller;
    public GameObject cameraHarness;
    private Camera mainCamera;
    private Vector2 screenCenter;
    private Vector2 viewCenter;
    private PlayerControls controls;

    // Temp
    private bool _lockCursor = false;
    private bool LockCursor { 
        get { return _lockCursor; } 
        set {
            _lockCursor = value;
            Cursor.visible = !_lockCursor;
        } 
    }
    private bool _jumpPending = false;

    public bool IsGrounded { 
        get {
            Vector3 v = gameObject.transform.position;
            v.y += groundCheckRadius/2.0f;
            Collider[] colliders = Physics.OverlapSphere(v, groundCheckRadius, movementSettings.groundLayer);
            return colliders.Length > 0; 
        } 
    }

    private void Awake()
    {
        accelerationX = accelerationY = accelerationZ = 0;

        yRotation = transform.localEulerAngles.y;
        xRotation = cameraHarness.transform.localEulerAngles.x;

        mainCamera = Camera.main;
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        viewCenter = mainCamera.ScreenToViewportPoint(screenCenter);
        Debug.Log(string.Format("Center is {0}", screenCenter));

        controls = new PlayerControls();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !LockCursor && Utils.CheckPointInScreen(Mouse.current.position.ReadValue()))
            LockCursor = true;
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            LockCursor = false;

        if (LockCursor)
            PlayerLook();

        PlayerRotate(xRotation, yRotation);
        ApplyGravity();

        PlayerMove();
    }

    #region Update Methods
    private void PlayerLook()
    {
        Vector2 diff = controls.player_controls.Look.ReadValue<Vector2>();
        yRotation += diff.x* movementSettings.yRotationSens * Time.deltaTime;
        yRotation += diff.x* movementSettings.yRotationSens * Time.deltaTime;
        xRotation -= diff.y* movementSettings.xRotationSens * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, movementSettings.xRotationMin, movementSettings.xRotationMax);
        Mouse.current.WarpCursorPosition(screenCenter);
    }

    private void PlayerRotate(float xRotation, float yRotation)
    {
        Vector2 v = this.gameObject.transform.localEulerAngles;
        v.y = yRotation;
        this.gameObject.transform.localEulerAngles = v;

        v = cameraHarness.transform.localEulerAngles;
        v.x = xRotation;
        cameraHarness.transform.localEulerAngles = v;
    }

    private void ApplyGravity()
    {
        if (IsGrounded)
        {
            accelerationY = 0;
        }
        else
        {
            accelerationY -= movementSettings.gravity * Time.deltaTime;
            if (accelerationY < -movementSettings.maxFallSpeed)
                accelerationY = -movementSettings.maxFallSpeed;
        }
    }

    private void PlayerMove()
    {
        // input
        Vector2 move_input = controls.player_controls.Move.ReadValue<Vector2>();
        if (Mathf.Abs(move_input.x) > 0)
            move_input.x = Mathf.Sign(move_input.x);
        if (Mathf.Abs(move_input.y) > 0)
            move_input.y = Mathf.Sign(move_input.y);

        // acceleration
        if (Mathf.Abs(move_input.x) > 0)
            accelerationX += Mathf.Sign(move_input.x) * Time.deltaTime * movementSettings.accelerationModifier;
        else
            Utils.ReduceBy(ref accelerationX, Time.deltaTime * movementSettings.decelerationModifier);
        if (Mathf.Abs(move_input.y) > 0)
            accelerationZ += Mathf.Sign(move_input.y) * Time.deltaTime * movementSettings.accelerationModifier;
        else
            Utils.ReduceBy(ref accelerationZ, Time.deltaTime * movementSettings.decelerationModifier);

        accelerationX = Utils.AbsClamp(accelerationX, 0.0f, 1.0f);
        if (_jumpPending)
        {
            accelerationY = movementSettings.jumpAcceleration;
            _jumpPending = false;
        }
        accelerationZ = Utils.AbsClamp(accelerationZ, 0.0f, 1.0f);

        // movement
        Vector3 moveVector = Vector3.up * accelerationY;
        moveVector += this.transform.forward * accelerationZ;
        moveVector += this.transform.right * accelerationX;
        controller.Move(moveVector * Time.deltaTime * movementSettings.speed);
    }
    #endregion

    #region Input manager

    private void OnEnable()
    {
        controls.Enable();
        controls.player_controls.Jump.performed += Jump_performed;
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.player_controls.Jump.performed -= Jump_performed;
    }
    
    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (IsGrounded)
        {
            PlayerJump();
        }
    }

    private void PlayerJump()
    {
        _jumpPending = true;
    }


    #endregion

}
