using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerMovementSettings movementSettings;
    private bool canMove = false;
    private float groundCheckRadius = 0.025f;

    // Acceleration
    private float accelerationX = 0.0f;
    private float accelerationY = 0.0f;
    private float accelerationZ = 0.0f;

    private float yRotation;
    private float xRotation;
    private Vector2 lastmPos;

    // References
    public CharacterController controller;
    public GameObject cameraHarness;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hey Luka!");

        Invoke("EnableMovement", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        // input
        int xplus = 0; 
        int zplus = 0;
        if (Input.GetKey(KeyCode.D))
            xplus = 1;
        else if (Input.GetKey(KeyCode.A))
            xplus = -1;
        if (Input.GetKey(KeyCode.W))
            zplus = 1;
        else if (Input.GetKey(KeyCode.S))
            zplus = -1;


        // calculate rotation
        Vector2 mpos = Input.mousePosition;

        Vector2 diff = mpos - lastmPos;
        yRotation += diff.x* movementSettings.yRotationSens * Time.deltaTime;
        xRotation -= diff.y* movementSettings.xRotationSens * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, movementSettings.xRotationMin, movementSettings.xRotationMax);

        lastmPos = mpos;

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
            if ((movementSettings.holdToJump) ? Input.GetKey(KeyCode.Space) : Input.GetKeyDown(KeyCode.Space))
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

    private void EnableMovement()
    {
        canMove = true;
    }

    private void PlayerJump()
    {
        accelerationY = movementSettings.jumpAcceleration; 
    }

}
