﻿#pragma checksum "C:\Users\hema-pt3672\source\repos\Taskuwp\Taskuwp\Views\AllEmployees.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "29C6F3D1B88291BFFB2AB68F8B771B5B"
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
    partial class FavEmployees : 
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
            case 2: // Views\AllEmployees.xaml line 59
                {
                    this.allemplist = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.allemplist).ItemClick += this.favemplist_ItemClick;
                }
                break;
            case 3: // Views\AllEmployees.xaml line 86
                {
                    this.detailedemplist = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 6: // Views\AllEmployees.xaml line 99
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element6 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element6).Tapped += this.starbtn_Tapped;
                }
                break;
            case 9: // Views\AllEmployees.xaml line 66
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element9 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element9).PointerEntered += this.empname_PointerEntered;
                }
                break;
            case 11: // Views\AllEmployees.xaml line 75
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element11 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element11).Tapped += this.starbtn_Tapped;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element11).PointerEntered += this.starbtn_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element11).PointerExited += this.starbtn_PointerExited;
                }
                break;
            case 12: // Views\AllEmployees.xaml line 18
                {
                    this.headtext = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // Views\AllEmployees.xaml line 20
                {
                    this.searchbar = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.searchbar).SuggestionChosen += this.searchbar_SuggestionChosen;
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.searchbar).TextChanged += this.searchbar_TextChanged;
                }
                break;
            case 14: // Views\AllEmployees.xaml line 39
                {
                    this.filter = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 15: // Views\AllEmployees.xaml line 43
                {
                    this.filterfavemp = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.filterfavemp).Click += this.filterfavemp_Click;
                }
                break;
            case 16: // Views\AllEmployees.xaml line 44
                {
                    this.filtertname = (global::Windows.UI.Xaml.Controls.MenuFlyoutSubItem)(target);
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
