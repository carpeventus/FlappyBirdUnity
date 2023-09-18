using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    private MeshRenderer meshRenderer;

    public float bgOffset;
    // Start is called before the first frame update
    void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update() {
        meshRenderer.material.mainTextureOffset += new Vector2(bgOffset, 0);
    }
}
