using System.Threading;
using CodeBase.UI.AbstractWindow;
using CodeBase.UI.Controllers;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.Window
{
    public interface IWindowService
    {
        void Bind<TWindow, TController>()
            where TWindow : AbstractWindowBase
            where TController : IController<TWindow>;

        void Bind<TWindow, TController, TModel>()
            where TWindow : AbstractWindowBase
            where TModel : AbstractWindowModel
            where TController : IModelBindable;

        TWindow OpenWindow<TWindow>(bool onTop = false) where TWindow : AbstractWindowBase;
        void Close<TWindow>() where TWindow : AbstractWindowBase;
        void CloseAll();
        UniTask<TWindow> OpenWindowAsync<TWindow>(bool onTop = false, float delay = 1f, CancellationToken token = default) where TWindow : AbstractWindowBase;
    }
}