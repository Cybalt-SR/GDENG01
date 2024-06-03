using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Controller.Extensions
{
#if UNITY_EDITOR

    [CustomEditor(typeof(EventDebugger))]
    internal class Editor_EventReceiver : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EventDebugger mTarget = (EventDebugger)target;

            if (mTarget.Receiver_dictionary == null)
                return;

            foreach (var eventName in mTarget.Receiver_dictionary)
            {
                if (GUILayout.Button(eventName))
                    EventBroadcaster.Instance.PostEvent(eventName);
            }
        }
    }

#endif


    public class EventDebugger : MonoBehaviour
    {
        public List<string> Receiver_dictionary { get; private set; }

        private void Awake()
        {
            Receiver_dictionary = new List<string>();
        }

        public void RegisterNoParams(string tag)
        {
            if (Receiver_dictionary.Contains(tag))
            {
                return;
            }

            Receiver_dictionary.Add(tag);
            
            void DebugObserver()
            {
                Debug.Log("Event Debug: Received \"" + tag + "\"");
            }

            EventBroadcaster.Instance.AddObserver(tag, DebugObserver);
        }
        public void RegisterHasParams(string tag)
        {
            if (Receiver_dictionary.Contains(tag))
            {
                return;
            }

            Receiver_dictionary.Add(tag);

            void DebugObserver(Parameters _params)
            {
                string debug = "Event Debug: Received \"" + tag + "\"";

                foreach (var param in _params.GetAll())
                {
                    debug += "\n" + param.ToString() + "\n";
                }

                Debug.Log(debug);
            }

            EventBroadcaster.Instance.AddObserver(tag, DebugObserver);
        }
    }
}
