using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonManager
{
    private static bool canMove = true;
    private static bool inTrigger = false;
    private static DialogueTrigger dialogTrigger;
    private static bool inDialog = false;
    private DialogManager dialogManager;

    public static float walkingSpeed = 7.5f;
    public static float runningSpeed = 11.5f;
    public static float jumpSpeed = 8.0f;
    public static float gravity = 20.0f;
    public static Camera playerCamera;
    public static float lookSpeed = 2.0f;
    public static float lookXLimit = 45.0f;

    public static void setTriggerInfo(bool inTriggerBool, DialogueTrigger dialogueTrigger)
    {
        inTrigger = inTriggerBool;
        dialogTrigger = dialogueTrigger;
        dialogTrigger.activateVisualCue(inTrigger);
    }
    public static void setTriggerInfo(bool inTriggerBool)
    {
        inTrigger = inTriggerBool;
    }
    public static bool getInTrigger()
    {
        return inTrigger;
    }
    public static void setInDialog(bool inDialogBool)
    {
        inDialog = inDialogBool;
    }
    public static bool getInDialog()
    {
        return inDialog;
    }
    public static DialogueTrigger getDialog()
    {
        return dialogTrigger;
    }
    public static void setCanMove(bool canMoveBool)
    {
        canMove = canMoveBool;
        if (canMoveBool)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public static bool getCanMove()
    {
        return canMove;
    }

    private void Start()
    {
        dialogManager = DialogManager.getInstance();
    }
}
