using UnityEngine;

public class EntryPointGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabCharacter;
    [SerializeField]
    private CameraMove _camera;

    private void Start()
    {
        GameObject character = Instantiate(_prefabCharacter, Vector3.zero, Quaternion.identity);
        character.GetComponent<CharacterMove>().Init();

        _camera.Init(character.transform);
    }
}
