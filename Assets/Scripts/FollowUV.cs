using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour {

	public float parralax = 2f;

	void Update () {

		MeshRenderer mr = GetComponent<MeshRenderer>();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		//offset.x = transform.position.x / transform.localScale.x / parralax;
		offset.y += Time.deltaTime / 10f;

		mat.mainTextureOffset = offset;

	}

}
