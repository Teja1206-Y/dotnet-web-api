using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Officeworkflows.Maui.Components.Pages
{
    public partial class LoadingPage
    {
        [Parameter] public string Message { get; set; } = "Loading...";
    }
}
