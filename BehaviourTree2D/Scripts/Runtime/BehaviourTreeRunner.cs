using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TheKiwiCoder 
{
    public class BehaviourTreeRunner : MonoBehaviour 
    {
        public BehaviourTree tree;
        Context context;
        string currentNode;

        void Start() 
        {
            context = CreateBehaviourTreeContext();
            tree = tree.Clone();
            tree.Bind(context);
        }

        void Update() 
        {
            if (tree) 
            {
                tree.Update();
                foreach (var item in tree.nodes)
                {
                    if (item.state == Node.State.Running)
                        currentNode = item.GetType().Name;
                }
            }
        }

        Context CreateBehaviourTreeContext() 
        {
            return Context.CreateFromGameObject(gameObject);
        }

        private void OnDrawGizmos() {
            if (!tree || !Application.isPlaying) 
                return;

            BehaviourTree.Traverse(tree.rootNode, (n) => 
            {
                if (n.drawGizmos) 
                    n.OnDrawGizmos();

                if (n.debugStateGizmo)
                    n.DrawDebugGizmo();
            });

            Handles.Label(transform.position + Vector3.right * 1f, currentNode);
        }
    }
}