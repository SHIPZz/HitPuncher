using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        T LoadAssetAsync<T>(string path) where T : Object;
    }
}