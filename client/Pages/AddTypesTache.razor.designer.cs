﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Crm.Models.Crmdata;
using Microsoft.AspNetCore.Identity;
using Crm.Models;
using Crm.Client.Pages;

namespace Crm.Pages
{
    public partial class AddTypesTacheComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected CrmdataService Crmdata { get; set; }

        Crm.Models.Crmdata.TypesTache _typestache;
        protected Crm.Models.Crmdata.TypesTache typestache
        {
            get
            {
                return _typestache;
            }
            set
            {
                if (!object.Equals(_typestache, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "typestache", NewValue = value, OldValue = _typestache };
                    _typestache = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            typestache = new Crm.Models.Crmdata.TypesTache(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Crm.Models.Crmdata.TypesTache args)
        {
            try
            {
                var crmdataCreateTypesTacheResult = await Crmdata.CreateTypesTache(typesTache:typestache);
                DialogService.Close(typestache);
            }
            catch (System.Exception crmdataCreateTypesTacheException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new TypesTache!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
