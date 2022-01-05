using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class InputCheck : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField]
    private GameObject inventory;
    private Vector2 rotation = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    CharacterController characterController;

    private static InputCheck instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one InputCheck in the Scene");
        }
        instance = this;

        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public static InputCheck getInstance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Controls.INVENTORY_TOGGLE))
        {
            inventory.SetActive(!inventory.activeSelf);
            if (inventory.activeSelf){
                CommonManager.setCanMove(false);
            }
            else
            {
                CommonManager.setCanMove(true);
            }
        }

        if (CommonManager.getCanMove()) {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            // Press Left Shift to run
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = isRunning ? CommonManager.runningSpeed : CommonManager.walkingSpeed * Input.GetAxis("Vertical");
            float curSpeedY = isRunning ? CommonManager.runningSpeed : CommonManager.walkingSpeed * Input.GetAxis("Horizontal");
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && characterController.isGrounded)
            {
                moveDirection.y = CommonManager.jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            if (!characterController.isGrounded)
            {
                moveDirection.y -= CommonManager.gravity * Time.deltaTime;
            }

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);

            // Player and Camera rotation
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
            transform.eulerAngles = new Vector2(0, rotation.y) * CommonManager.lookSpeed;
            Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * CommonManager.lookSpeed, 0, 0);
        }

        if (CommonManager.getInTrigger() && !CommonManager.getInDialog())
        {
            if (Input.GetKeyDown(Controls.INTERACT_BUTTON))
            {
                if(CommonManager.getDialog() != null)
                {
                    CommonManager.getDialog().triggerDialog();
                }
            }
        }
    }
}
