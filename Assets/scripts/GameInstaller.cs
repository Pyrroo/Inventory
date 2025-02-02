using UnityEngine;
using Zenject;
public class GameInstaller : MonoInstaller
{
    public PopUpMenu popUpMenuPrefab;

    public override void InstallBindings()
    {
        Container.Bind<InventoryCreator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PopUpMenu>().FromInstance(popUpMenuPrefab).AsSingle();
        Container.Bind<PopUpMenuOpener>().FromComponentInHierarchy().AsSingle();
    }
}
