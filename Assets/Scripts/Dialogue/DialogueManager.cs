using System.Collections;
using System.Collections.Generic;
using Ink.Parsed;
using TMPro;
using UnityEngine;
using Story = Ink.Runtime.Story;

//using Story = Ink.Runtime.Story;


public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;

    [Header("Dialogue UI")] [SerializeField]
    private GameObject _dialoguePanel;

    [SerializeField] private TextMeshProUGUI _dialogueText;

    private Story _currentStory;

    public bool isDialoguePlaying { get; private set; }

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }

        _instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }

    private void Start()
    {
        isDialoguePlaying = false;
        _dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!isDialoguePlaying)
        {
            return;
        }

        if (InputManager.GetInstance().GetSubmitPressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset iInkJson)
    {
        _currentStory = new Story(iInkJson.text);
        isDialoguePlaying = true;
        _dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        isDialoguePlaying = false;
        _dialoguePanel.SetActive(false);
        _dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            _dialogueText.text = _currentStory.Continue();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
}
