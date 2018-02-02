//This script is used for an old project of a Strategy Game engine asset. I will probably never release it. 
//So I wanted to share (and save) the hard work I did with the customeditor ReorderableList I did. 
//Thank to that tutorial : http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
//I learned a lot with them :)

//In many less word as possible. It retrieve ScriptableObject, Read and write array through the editor.
//The array contain information about the cost of the building or his production. 
//It was supposed to help Gamedesigner to balance their game. And add buildings without going though code.

//I will not release all the other scripts I do in this project because that doesn't work. Maybe if i put more work in it. (that's probably not gonna happen)

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(Buildings_Main))]
public class CustomEditorBase : Editor {

	private ReorderableList List1;
	private ReorderableList List2;
	private ReorderableList List3;
	private ReorderableList List4;

	private void OnEnable(){
		List1 = new ReorderableList (serializedObject, serializedObject.FindProperty ("OnceCostList"), true, true, true, true);
		List2 = new ReorderableList (serializedObject, serializedObject.FindProperty ("OnceProductionList"), true, true, true, true);
		List3 = new ReorderableList (serializedObject, serializedObject.FindProperty ("CycleCostList"), true, true, true, true);
		List4 = new ReorderableList (serializedObject, serializedObject.FindProperty ("CycleProductionList"), true, true, true, true);


		List1.drawHeaderCallback = (Rect rect) => {EditorGUI.LabelField (rect, "Build Cost Resources");};
		List2.drawHeaderCallback = (Rect rect) => {EditorGUI.LabelField (rect, "Give on construction completed");}; 
		List3.drawHeaderCallback = (Rect rect) => {EditorGUI.LabelField (rect, "Cycle Cost Resources");};
		List4.drawHeaderCallback = (Rect rect) => {EditorGUI.LabelField (rect, "Cycle Production Resources");};

	}


	public override void OnInspectorGUI(){

		DrawDefaultInspector();
		EditorGUILayout.Space();
		EditorGUILayout.Space();

		serializedObject.Update ();

		EditorGUILayout.HelpBox("The cost in resources when the building receive the order to be build.", MessageType.Info);
		List1.DoLayoutList ();
		EditorGUILayout.HelpBox("The production in 'Variable' when the building finished to be build. Like extend the maximum units values", MessageType.Info);
		List2.DoLayoutList ();
		EditorGUILayout.HelpBox("The cost/production in resources every cycle", MessageType.Info);
		List3.DoLayoutList ();
		EditorGUILayout.HelpBox("The Production in resources every cycle", MessageType.Info);
		List4.DoLayoutList ();
		serializedObject.ApplyModifiedProperties ();


		List1.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
			var element = List1.serializedProperty.GetArrayElementAtIndex (index);
			rect.y += 2;
			EditorGUI.PropertyField (new Rect (rect.x, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Resource"), GUIContent.none);
			EditorGUI.PropertyField (new Rect (rect.x + 90, rect.y, rect.width - 60 - 120, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Amount"), GUIContent.none);
			//EditorGUI.PropertyField (new Rect (rect.x + rect.width - 50, rect.y, 50, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Amount"), GUIContent.none);
		};



		List2.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
			var element = List2.serializedProperty.GetArrayElementAtIndex (index);
			rect.y += 2;
			EditorGUI.PropertyField (new Rect (rect.x, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Resource"), GUIContent.none);
			EditorGUI.PropertyField (new Rect (rect.x + 90, rect.y, rect.width - 60 - 120, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Amount"), GUIContent.none);
		};


		List3.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
			var element = List3.serializedProperty.GetArrayElementAtIndex (index);
			rect.y += 2;
			EditorGUI.PropertyField (new Rect (rect.x, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Resource"), GUIContent.none);
			EditorGUI.PropertyField (new Rect (rect.x + 90, rect.y, rect.width - 60 - 120, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Amount"), GUIContent.none);
		};

		List4.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
			var element = List4.serializedProperty.GetArrayElementAtIndex (index);
			rect.y += 2;
			EditorGUI.PropertyField (new Rect (rect.x, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Resource"), GUIContent.none);
			EditorGUI.PropertyField (new Rect (rect.x + 90, rect.y, rect.width - 60 - 120, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Amount"), GUIContent.none);
		};
	}





}


public class EditorMiscs{

   // public static ReorderableList SetupReorderableList<T>(string headerText, List<T> elements, ref T currentElement, Action<Rect, T> drawElement, Action<T> selectElement, Action createElement, Action<T> removeElement) {
    //}
}