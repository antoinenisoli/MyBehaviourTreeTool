using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {
    public class Log : ActionNode
    {
        public string message;

        protected override string NodeDescription()
        {
            return "Print a message in the Unity console.";
        }

        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            Debug.Log($"{message}");
            return State.Success;
        }
    }
}
