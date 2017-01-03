using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    [System.NonSerialized]
    public Task[] AvailableTasks;

    void Start()
    {
        AvailableTasks = GetComponents<Task>();
    }

    public T ChangeTask<T>() where T :Task
    {
        CencelAllTasks();
        for (int i = 0; i < AvailableTasks.Length; i++)
        {
            Task task = AvailableTasks[i];
            if (AvailableTasks[i] is T && !task.GetType().IsSubclassOf(typeof(T)))
            {
                task.enabled = true;
                return task as T;
            }
        }
        new System.Exception("Command not available for this unit");
        return null;
    }

    public void CencelAllTasks()
    {
        for (int i = 0; i < AvailableTasks.Length; i++)
        {
            if (AvailableTasks[i].enabled)
            {
                AvailableTasks[i].enabled = false;
            }
        }
    }


}
