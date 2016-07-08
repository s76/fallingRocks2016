using UnityEngine;
using System.Collections;
using Core.Managers;

namespace Core.Model
{
    public class CharacterFactory : Singleton<CharacterFactory>
    {
        public Character Create(string characterCodeName)
        {
            var data = InitDataManager.Instance.characters.Find(x => x.codeName == characterCodeName);
            if (data != null)
            {
                var path = PathManager.Characters + data.codeName;
                var character = Instantiate(Resources.Load<Character>(path));
                character.Initialize(data);
                return character;
            }
            else
            {
                Debug.LogError("InitData not found for " + characterCodeName);
            }
            return null;
        }
    }

}
