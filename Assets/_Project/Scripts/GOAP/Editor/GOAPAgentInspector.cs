using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GoapAgent))]
public class GOAPAgentInspector : Editor {
    public override void OnInspectorGUI() {
        GoapAgent agent = (GoapAgent)target;

        EditorGUILayout.Space();
        DrawDefaultInspector();

        EditorGUILayout.Space();

        if (agent.currentGoal != null) {
            EditorGUILayout.LabelField("Current Goal:", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            EditorGUILayout.LabelField(agent.currentGoal.Name);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        // Show current action
        if (agent.currentAction != null) {
            EditorGUILayout.LabelField("Current Action:", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            EditorGUILayout.LabelField(agent.currentAction.Name);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        // Show current plan
        if (agent.actionPlan != null) {
            EditorGUILayout.LabelField("Plan Stack:", EditorStyles.boldLabel);
            foreach (var a in agent.actionPlan.Actions) {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(10);
                EditorGUILayout.LabelField(a.Name);
                EditorGUILayout.EndHorizontal();
            }
        }

        EditorGUILayout.Space();

        // Show beliefs
        EditorGUILayout.LabelField("Beliefs:", EditorStyles.boldLabel);
        if (agent.beliefs != null) {
            foreach (var belief in agent.beliefs){
                if (belief.Key is "Nothing" or "Something") continue;
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(10);
                EditorGUILayout.LabelField(belief.Key + ": " + belief.Value.Evaluate());
                EditorGUILayout.EndHorizontal();
            }
        }

        EditorGUILayout.Space();
    }
}