﻿#pragma checksum "C:\Users\hema-pt3672\source\repos\Taskuwp\Taskuwp\Views\AllEmployees.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E9382CDC5AB698A59E15D001A2414B68"
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
            case 2: // Views\AllEmployees.xaml line 14
                {
                    this.Allemployeeadaptive = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 3: // Views\AllEmployees.xaml line 16
                {
                    this.minwindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4: // Views\AllEmployees.xaml line 29
                {
                    this.maxwindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5: // Views\AllEmployees.xaml line 99
                {
                    this.allemplist = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.allemplist).ItemClick += this.favemplist_ItemClick;
                }
                break;
            case 6: // Views\AllEmployees.xaml line 126
                {
                    this.adaptivearrow = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.adaptivearrow).Tapped += this.adaptivearrow_Tapped;
                }
                break;
            case 7: // Views\AllEmployees.xaml line 127
                {
                    this.detailedemplist = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 11: // Views\AllEmployees.xaml line 140
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element11 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element11).Tapped += this.starbtn_Tapped;
                }
                break;
            case 14: // Views\AllEmployees.xaml line 106
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element14 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element14).PointerEntered += this.empname_PointerEntered;
                }
                break;
            case 16: // Views\AllEmployees.xaml line 115
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element16 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element16).Tapped += this.starbtn_Tapped;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element16).PointerEntered += this.starbtn_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element16).PointerExited += this.starbtn_PointerExited;
                }
                break;
            case 17: // Views\AllEmployees.xaml line 58
                {
                    this.headtext = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // Views\AllEmployees.xaml line 60
                {
                    this.searchbar = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.searchbar).SuggestionChosen += this.searchbar_SuggestionChosen;
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.searchbar).TextChanged += this.searchbar_TextChanged;
                }
                break;
            case 19: // Views\AllEmployees.xaml line 79
                {
                    this.filter = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 20: // Views\AllEmployees.xaml line 83
                {
                    this.filterfavemp = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.filterfavemp).Click += this.filterfavemp_Click;
                }
                break;
            case 21: // Views\AllEmployees.xaml line 84
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

