using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue Cue")] [SerializeField] private GameObject _dialogueCue;
    [Header("Ink JSON")] [SerializeField] private TextAsset _inkJson;

    private bool _playerInRange;

    private void Awake()
    {
        _playerInRange = false;
        _dialogueCue.SetActive(false);
    }

    private void Update()
    {
        _dialogueCue.SetActive(_playerInRange);

        if (_playerInRange && !DialogueManager.GetInstance().isDialoguePlaying && InputManager.GetInstance().GetInteractPressed())
        {
            DialogueManager.GetInstance().EnterDialogueMode(_inkJson);
        }
    }

    private void OnTriggerEnter2D(Collider2D iCollider)
    {
        if (iCollider.gameObject.tag == "Player")
        {
            _playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D iCollider)
    {
        if (iCollider.gameObject.tag == "Player")
        {
            _playerInRange = false;
        }
    }
}
