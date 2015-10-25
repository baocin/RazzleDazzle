using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterController), typeof(AudioSource))]
public class FirstPersonController : MonoBehaviour 
{
    // Other Public Shit
    [System.NonSerialized]
    public bool noteOpen;

    public bool bypassErrorCheck = false; 
    public Camera playerCamera;
    public GameObject pauseMenu;
    public GameObject Flashlight;
    public Light FlashlightLight;
    public bool useFullPlayerPrefs = false;
    public bool useUserPlayerPrefs = false;
    public float walkSpeed = 10.0f;
    public float sprintSpeed = 15.0f;
    public float sprintTime = 6.5f;
    public float exhaustTime = 5.0f;
    public float jumpHeight = 20.0f;
    public float mouseSensitivity = 5.0f;
    public float cameraRange = 60.0f;
    public string mousePrefName = "Mouse Sensitivity Pref Name";
    public string walkSpeedPrefName = "Walk Speed Pref Name";
    public string sprintSpeedPrefName = "Sprint Speed Pref Name";
    public string sprintTimePrefName = "Sprnt Time Pref Name";
    public string exhaustTimePrefName = "Exhaust Time Pref Name";
    public string jumpHeightPrefName = "Jump Height Pref Name";
    public AudioSource walkingSound;
    public AudioSource sprintingSound;
    public AudioClip exhaustionSound;
    AudioSource audio;

    float yRotation = 0;
    float verticalVelocity = 0;
    CharacterController cController;
    bool isPaused = false;
    bool isSprinting = false;

	void Start () 
    {
        if (!bypassErrorCheck)
        {
            errorCheck();
        }
        else
        {
            Debug.LogWarning("Error checking is disabled.");
        }

        // Do not remove these, it's required for the script to function correctly.
        cController = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
        Time.timeScale = 1;

        // This is optional, but suggested.
        // Press "Escape" when in play mode to release the cursor.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	

	void Update () 
    {
        // Camera monitor.
        watchCamera();

        // Movement monitor.
        watchMovement();

        // Jump monitor.
        watchJump();

        // Keybinds monitor.
        watchKeybinds();

        // Pause menu monitor.
        watchPause();
	}

    void watchCamera()
    {
        if (isPaused || noteOpen)
        {
            transform.Rotate(0, 0, 0);
            playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(0, rotX, 0);
            yRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            yRotation = Mathf.Clamp(yRotation, -cameraRange, cameraRange);
            playerCamera.transform.localRotation = Quaternion.Euler(yRotation, 0, 0);
        }
    }

    void watchMovement()
    {
        if (!noteOpen)
        {
            float movementSpeed = 0, sideSpeed = 0;
            if (cController.isGrounded && Input.GetButton("Sprint") && !isSprinting)
            {
                Debug.Log("If (!isSprinting) = check");
                movementSpeed = Input.GetAxis("Vertical") * sprintSpeed;
                sideSpeed = Input.GetAxis("Horizontal") * sprintSpeed;
                Debug.Log("isSprinting: " + isSprinting);
                Debug.Log("Starting Coroutine");
                StartCoroutine("sprintTimer");

            }
            else
            {
                movementSpeed = Input.GetAxis("Vertical") * walkSpeed;
                sideSpeed = Input.GetAxis("Horizontal") * walkSpeed;
            }

            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            Vector3 speed = new Vector3(sideSpeed, verticalVelocity, movementSpeed);
            speed = transform.rotation * speed;
            cController.Move(speed * Time.deltaTime);
        }
    }

    IEnumerator sprintTimer()
    {
        Debug.Log("Starting timer.");
        yield return new WaitForSeconds(sprintTime);
        isSprinting = true;
        Debug.Log("Waited " + sprintTime + " seconds.");
        Debug.Log("isSprinting: " + isSprinting);
        StartCoroutine("exhaustionTimer");
    }

    IEnumerator exhaustionTimer()
    {
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(exhaustionSound, 1f);
        }
        //AudioSource.PlayClipAtPoint(exhaustionSound, transform.position);
        yield return new WaitForSeconds(exhaustTime);
        isSprinting = false;
    }

    void watchJump()
    {
        if (cController.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpHeight;
        }
    }

    void watchKeybinds()
    {
		if (Input.GetButtonUp("Toggle Flashlight") && GameObject.FindGameObjectWithTag("Flashlight"))
        {
            if (FlashlightLight.enabled)
            {
                FlashlightLight.enabled = false;
            }
            else
            {
                FlashlightLight.enabled = true;
            }

        }

        if (Input.GetKeyUp(KeyCode.Escape) && !noteOpen)
        {
            isPaused = togglePause();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    void watchPause()
    {
        if (!noteOpen)
        {
            if (isPaused)
            {
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public bool togglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return (false);
        }
        else
        {
            Time.timeScale = 0;
            return (true);
        }
    }

    void errorCheck()
    {
        if (playerCamera == null)
        {
            Debug.LogError("There's no camera available, are you sure the player camera is added?");
        }
        if (exhaustionSound == null)
        {
            Debug.LogError("There's no exhaustion sound! Please add one before you continue!");
        }
        if (sprintingSound == null)
        {
            Debug.LogError("There's no sprinting sound! Please add one before you continue!");
        }
        if (walkingSound == null)
        {
            Debug.LogError("There's no walking sound! Please add one before you continue!");
        }


    }
}
