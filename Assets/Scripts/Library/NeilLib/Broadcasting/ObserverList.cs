using System.Collections.Generic;

/*
 * Holds the associated actions associated with the event name
 * Created By: NeilDG
 */
public class ObserverList
{
    private List<System.Action<Parameters>> eventListeners; //by default, event listeners with params
    private List<System.Action> eventListenersNoParams; //event listeners that does not have params;

    public ObserverList()
    {
        eventListeners = new List<System.Action<Parameters>>();
        eventListenersNoParams = new List<System.Action>();
    }

    public void AddObserver(System.Action<Parameters> action)
    {
        eventListeners.Add(action);
    }

    public void AddObserver(System.Action action)
    {
        eventListenersNoParams.Add(action);
    }

    public void RemoveObserver(System.Action<Parameters> action)
    {
        if (eventListeners.Contains(action))
        {
            eventListeners.Remove(action);
        }
    }

    public void RemoveObserver(System.Action action)
    {
        if (eventListenersNoParams.Contains(action))
        {
            eventListenersNoParams.Remove(action);
        }
    }

    public void RemoveAllObservers()
    {
        eventListeners.Clear();
        eventListenersNoParams.Clear();
    }

    public void NotifyObservers(Parameters parameters)
    {
        for (int i = 0; i < eventListeners.Count; i++)
        {
            System.Action<Parameters> action = eventListeners[i];

            action(parameters);
        }
    }

    public void NotifyObservers()
    {
        for (int i = 0; i < eventListenersNoParams.Count; i++)
        {
            System.Action action = eventListenersNoParams[i];

            action();
        }
    }

    public int GetListenerLength()
    {
        return (eventListeners.Count + eventListenersNoParams.Count);
    }
}
