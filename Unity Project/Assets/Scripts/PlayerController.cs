using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementSettings movementSettings;
    private float groundCheckRadius = 0.025f;

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

    // Temp
    private bool _lockCursor = false;
    private bool LockCursor { 
        get { return _lockCursor; } 
        set {
            _lockCursor = value;
            Cursor.visible = !_lockCursor;
        } 
    }

    private PlayerControls controls;

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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hey Luka!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            int a = 1;
            // fake method
        }

        // input
        int xplus = 0; 
        int zplus = 0;
        if (Keyboard.current.dKey.isPressed)
            xplus = 1;
        else if (Keyboard.current.aKey.isPressed)
            xplus = -1;
        if (Keyboard.current.wKey.isPressed)
            zplus = 1;
        else if (Keyboard.current.sKey.isPressed)
            zplus = -1;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 view = mainCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue()); // lock cursor if we click in the window
        bool true_case = view.x > 0 && view.y > 0 && view.x < 1 && view.y < 1 && Mouse.current.leftButton.wasPressedThisFrame && !LockCursor;
        bool false_case = Keyboard.current.escapeKey.wasPressedThisFrame;

        if (true_case)
            LockCursor = true;
        if (false_case)
            LockCursor = false;

        // calculate rotation
        if (LockCursor)
        {
            /*Vector2 diff = view - viewCenter;
            yRotation += diff.x* movementSettings.yRotationSens * Time.deltaTime * 500f;
            xRotation -= diff.y* movementSettings.xRotationSens * Time.deltaTime * 500f;
            xRotation = Mathf.Clamp(xRotation, movementSettings.xRotationMin, movementSettings.xRotationMax);
            Mouse.current.WarpCursorPosition(screenCenter);*/

            //Vector2 diff = mousePosition - screenCenter;
            Vector2 diff = controls.player_controls.Look.ReadValue<Vector2>();
            yRotation += diff.x* movementSettings.yRotationSens * Time.deltaTime;
            xRotation -= diff.y* movementSettings.xRotationSens * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, movementSettings.xRotationMin, movementSettings.xRotationMax);
            Mouse.current.WarpCursorPosition(screenCenter);

            //Vector2 diff = 
        }

        // apply rotation
        Vector3 v = this.gameObject.transform.localEulerAngles;
        v.y = yRotation;
        this.gameObject.transform.localEulerAngles = v;

        v = cameraHarness.transform.localEulerAngles;
        v.x = xRotation;
        cameraHarness.transform.localEulerAngles = v;

        // grounded check
        if (IsGrounded)
        {
            accelerationY = 0;
            if ((movementSettings.holdToJump) ? Keyboard.current.spaceKey.isPressed : Keyboard.current.spaceKey.wasPressedThisFrame)
                PlayerJump();
        }
        else
        {
            accelerationY -= movementSettings.gravity * Time.deltaTime;
            if (accelerationY < -movementSettings.maxFallSpeed)
                accelerationY = -movementSettings.maxFallSpeed;
        }


        // acceleration
        if (Mathf.Abs(xplus) > 0)
            accelerationX += Mathf.Sign(xplus) * Time.deltaTime * movementSettings.accelerationModifier;
        else
            Utils.ReduceBy(ref accelerationX, Time.deltaTime * movementSettings.decelerationModifier);
        if (Mathf.Abs(zplus) > 0)
            accelerationZ += Mathf.Sign(zplus) * Time.deltaTime * movementSettings.accelerationModifier;
        else
            Utils.ReduceBy(ref accelerationZ, Time.deltaTime * movementSettings.decelerationModifier);

        accelerationX = Utils.AbsClamp(accelerationX, 0.0f, 1.0f);
        accelerationZ = Utils.AbsClamp(accelerationZ, 0.0f, 1.0f);

        // movement
        Vector3 moveVector = Vector3.up * accelerationY;
        moveVector += this.transform.forward * accelerationZ;
        moveVector += this.transform.right * accelerationX;
        controller.Move(moveVector * Time.deltaTime * movementSettings.speed);

    }

    private void PlayerJump()
    {
        accelerationY = movementSettings.jumpAcceleration; 
    }

    #region input manager

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    #endregion

}
