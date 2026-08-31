#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;

public static class EditorETLRBuilder {
    [MenuItem("ETLR/Build Prototype Scenes")]
    public static void Build(){
        Directory.CreateDirectory("Assets/Scenes");

        var boot=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
        new GameObject("BOOTSTRAP").AddComponent<ETLRBootstrap>();
        EditorSceneManager.SaveScene(boot,"Assets/Scenes/Boot.unity");

        var game=EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects,NewSceneMode.Single);
        new GameObject("GAME_STATE").AddComponent<GameState>();

        var p=new GameObject("PLAYER");
        p.AddComponent<CharacterController>();
        p.AddComponent<ThirdPersonController>();

        var cam=new GameObject("CAMERA");
        cam.AddComponent<Camera>();
        cam.transform.position=new Vector3(0,2.5f,-4);
        p.GetComponent<ThirdPersonController>().cameraTransform=cam.transform;

        var l=new GameObject("KEY_LIGHT");
        var light=l.AddComponent<Light>();
        light.type=LightType.Directional;
        light.intensity=1.1f;

        EditorSceneManager.SaveScene(game,"Assets/Scenes/Game.unity");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
#endif
