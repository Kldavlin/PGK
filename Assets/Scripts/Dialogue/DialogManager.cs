using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [Header("Dialog UI")]
    [SerializeField]
    private GameObject dialogPanel;

    [Header("Choices UI")]
    [SerializeField]
    private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [SerializeField]
    private TextMeshProUGUI dialogText;

    private Story currentStory;
    private bool dialogIsPlaying;

    private static DialogManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("There is more than one DialogManager instance in the scene");
        }
        instance = this;
    }

    public static DialogManager getInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    public void enterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        CommonManager.setInDialog(true);
        dialogPanel.SetActive(true);
        CommonManager.setCanMove(false);
        continueStory();
    }

    private void exitDialogMode()
    {
        CommonManager.setInDialog(false);
        dialogPanel.SetActive(false);
        dialogText.text = "";
        CommonManager.setCanMove(true);
    }

    public void continueStory()
    {
        if (currentStory.canContinue)
        {
            dialogText.text = currentStory.Continue();
            displayChoices();
        }
        else
        {
            exitDialogMode();
        }
    }

    private void displayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize choices
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        continueStory();
    }
}
