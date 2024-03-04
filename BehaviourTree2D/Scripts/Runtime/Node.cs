using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TheKiwiCoder {
    public abstract class Node : ScriptableObject {
        public enum State {
            Running,
            Failure,
            Success
        }

        [HideInInspector] public State state = State.Running;
        [HideInInspector] public bool started = false;
        [HideInInspector] public string guid;
        [HideInInspector] public Vector2 position;
        [HideInInspector] public Context context;
        [HideInInspector] public Blackboard blackboard;
        [HideInInspector] public string nodeDescription;
        [TextArea] public string description;
        public bool drawGizmos = false;
        public bool debugStateGizmo = false;
        [SerializeField] protected Color gizmoColor = Color.white;

        public Node()
        {
            nodeDescription = NodeDescription();
        }

        public State Update() {

            if (!started) {
                OnStart();
                started = true;
            }

            state = OnUpdate();

            if (state != State.Running) {
                OnStop();
                started = false;
            }

            return state;
        }

        protected virtual string NodeDescription() => GetType().Name;

        public virtual Node Clone() {
            return Instantiate(this);
        }

        public void Abort() {
            BehaviourTree.Traverse(this, (node) => {
                node.started = false;
                node.state = State.Running;
                node.OnStop();
            });
        }

        public virtual void OnDrawGizmos() 
        { 
            
        }

        public void DrawDebugGizmo()
        {
            if (debugStateGizmo && state == State.Running)
            {
                Color c = gizmoColor;
                c.a = 0.35f;
                Gizmos.color = c;
                Gizmos.DrawCube(context.transform.position, Vector2.one * 2f);
            }
        }

        protected abstract void OnStart();
        protected abstract void OnStop();
        protected abstract State OnUpdate();
    }
}