using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{

    public static UnityEvent OnDamageTaken = new UnityEvent();
    public static UnityEvent OnDestroyEnemy = new UnityEvent();

}
