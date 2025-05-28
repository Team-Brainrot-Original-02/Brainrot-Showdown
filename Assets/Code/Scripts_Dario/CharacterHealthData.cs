using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterHealthData", menuName = "Character Health Data")]
public class CharacterHealthData : ScriptableObject
{
    public float maxHealth = 100f; // Maximum health for the character
}