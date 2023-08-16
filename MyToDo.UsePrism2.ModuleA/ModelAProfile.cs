using MyToDo.UsePrism2.ModuleA.ViewModels;
using MyToDo.UsePrism2.ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.UsePrism2.ModuleA
{
    public class ModelAProfile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AView, AViewModel>();
        }
    }
}
