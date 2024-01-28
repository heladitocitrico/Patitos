using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction<Pueblo, int> ActionTaken;
    public static void OnActionTaken(Pueblo pueblo, int score) => ActionTaken?.Invoke(pueblo, score);
    public static event UnityAction CharacterFinishedWalking;
    public static void OnCharacterFinishedWalking() => CharacterFinishedWalking?.Invoke();
    public static event UnityAction CharacterFinishedExiting;
    public static void OnCharacterFinishedExiting() => CharacterFinishedExiting?.Invoke();
}
