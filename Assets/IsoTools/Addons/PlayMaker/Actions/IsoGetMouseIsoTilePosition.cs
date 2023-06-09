﻿#if PLAYMAKER
using UnityEngine;
using HutongGames.PlayMaker;
using IsoTools.PlayMaker.Internal;

namespace IsoTools.PlayMaker.Actions {
	[ActionCategory("IsoTools")]
	[HutongGames.PlayMaker.Tooltip(
		"Gets a mouse isometric tile position.")]
	public class IsoGetMouseIsoTilePosition : IsoComponentAction<IsoWorld> {
		[RequiredField]
		[CheckForComponent(typeof(IsoWorld))]
		[HutongGames.PlayMaker.Title("IsoWorld (In)")]
		public FsmOwnerDefault gameObject;

		[CheckForComponent(typeof(Camera))]
		[HutongGames.PlayMaker.Title("Camera (In)")]
		[HutongGames.PlayMaker.Tooltip("Specific camera or main camera for 'None'.")]
		public FsmGameObject camera;

		[HutongGames.PlayMaker.Title("Specific Isometric Z (In)")]
		[HutongGames.PlayMaker.Tooltip("Specific Isometric Z or 0.0f for 'None'")]
		public FsmFloat specificIsometricZ;

		[UIHint(UIHint.Variable)]
		[HutongGames.PlayMaker.Title("Store Tile Position (Out)")]
		public FsmVector3 storeVector;

		[UIHint(UIHint.Variable)]
		[HutongGames.PlayMaker.Title("Store Tile Position X (Out)")]
		public FsmFloat storeX;

		[UIHint(UIHint.Variable)]
		[HutongGames.PlayMaker.Title("Store Tile Position Y (Out)")]
		public FsmFloat storeY;

		[UIHint(UIHint.Variable)]
		[HutongGames.PlayMaker.Title("Store Tile Position Z (Out)")]
		public FsmFloat storeZ;

		[HutongGames.PlayMaker.Tooltip("Repeat every frame.")]
		public bool everyFrame;

		public override void Reset() {
			gameObject         = null;
			camera             = null;
			specificIsometricZ = null;
			storeVector        = null;
			storeX             = null;
			storeY             = null;
			storeZ             = null;
			everyFrame         = false;
		}

		public override void OnEnter() {
			DoAction();
			if ( !everyFrame ) {
				Finish();
			}
		}

		public override void OnUpdate() {
			DoAction();
		}

		void DoAction() {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if ( UpdateCache(go) ) {
				var value = isoWorld.MouseIsoTilePosition(
					camera.IsNone ? Camera.main : camera.Value.GetComponent<Camera>(),
					specificIsometricZ.IsNone ? 0.0f : specificIsometricZ.Value);
				storeVector.Value = value;
				storeX.Value      = value.x;
				storeY.Value      = value.y;
				storeZ.Value      = value.z;
			}
		}
	}
}
#endif