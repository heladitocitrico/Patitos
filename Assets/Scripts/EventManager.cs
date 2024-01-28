using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction<int> ActionTaken;
    public static void OnActionTaken(int score) => ActionTaken?.Invoke(score);
}
