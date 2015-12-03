using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;

namespace UnityEditor
{
	public class AnimationTool
	{
		[MenuItem ("Designer Tools/Extract Animation")]
		public static void RenameMotion ()
		{	
			foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets)) {
				AnimationClip orgClip = (AnimationClip)AssetDatabase.LoadAssetAtPath (AssetDatabase.GetAssetPath (obj), typeof(AnimationClip));
				if (orgClip == null)
					continue;
				AnimationClip placeClip = new AnimationClip ();
				EditorUtility.CopySerialized (orgClip, placeClip);
				AssetDatabase.CreateAsset (placeClip, AssetDatabase.GetAssetPath (obj).Replace (".fbx", ".anim"));
				AssetDatabase.Refresh ();
			}
		}

		[MenuItem ("Designer Tools/Extract Animation(delete fbx file)")]
		public static void RenameMotionDelFbx ()
		{	
			foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets)) {
				AnimationClip orgClip = (AnimationClip)AssetDatabase.LoadAssetAtPath (AssetDatabase.GetAssetPath (obj), typeof(AnimationClip));
				if (orgClip == null)
					continue;
				AnimationClip placeClip = new AnimationClip ();
				EditorUtility.CopySerialized (orgClip, placeClip);
				AssetDatabase.CreateAsset (placeClip, AssetDatabase.GetAssetPath (obj).Replace (".fbx", ".anim"));
				AssetDatabase.DeleteAsset (AssetDatabase.GetAssetPath (obj));
				AssetDatabase.Refresh ();
			}
		}
	}
}
