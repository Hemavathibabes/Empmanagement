﻿#pragma checksum "C:\Users\hema-pt3672\source\repos\Taskuwp\Taskuwp\Views\Team.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6FE00CB705E43EE17374F581533F6472"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Taskuwp.Views
{
    partial class Team : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\Team.xaml line 19
                {
                    this.backarrow = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // Views\Team.xaml line 31
                {
                    this.noteam = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Views\Team.xaml line 34
                {
                    this.teamview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.teamview).ItemClick += this.teamview_ItemClick;
                }
                break;
            case 5: // Views\Team.xaml line 49
                {
                    this.detailedteamview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 6: // Views\Team.xaml line 69
                {
                    this.empdetails = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 15: // Views\Team.xaml line 20
                {
                    this.Backarrow = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.Backarrow).Tapped += this.Backarrow_Tapped;
                }
                break;
            case 16: // Views\Team.xaml line 23
                {
                    this.clickedteam = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
