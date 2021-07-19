using DarthValidatorBlazor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarthValidatorBlazor.Shared
{
    public partial class MainLayout
    {
        bool _drawerOpen = true;
        private Page _page = Page.Validation;
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        public void ChangePage(Page page)
        {
            _page = page;
        }
    }
}
