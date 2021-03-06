using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    [Header("Visual Cue")]
    [SerializeField]
    private GameObject visualCue;


    [Header("Ink JSON")]
    [SerializeField]
    private TextAsset inkJson;

    public void Awake()
    {
        visualCue.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            CommonManager.setTriggerInfo(true, this);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            CommonManager.setTriggerInfo(false, this);
        }
    }

    public void triggerDialog()
    {
        DialogManager.getInstance().enterDialogueMode(inkJson);
    }

    public void activateVisualCue(bool activate)
    {
        visualCue.SetActive(activate);
    }
}
