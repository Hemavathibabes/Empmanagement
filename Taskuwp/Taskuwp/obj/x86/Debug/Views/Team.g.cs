﻿#pragma checksum "C:\Users\hema-pt3672\source\repos\Taskuwp\Taskuwp\Views\Team.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ABE5B1CCADB50A5C17C9CF41BE9FBFF3"
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
            case 2: // Views\Team.xaml line 33
                {
                    this.Mainteamview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.Mainteamview).ItemClick += this.Mainteamview_ItemClick;
                }
                break;
            case 3: // Views\Team.xaml line 174
                {
                    this.empdetailslist = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 4: // Views\Team.xaml line 224
                {
                    this.detailedemplist = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 7: // Views\Team.xaml line 237
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element7 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element7).Tapped += this.starbtn_Tapped;
                }
                break;
            case 10: // Views\Team.xaml line 217
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.viewprofile_Click;
                }
                break;
            case 11: // Views\Team.xaml line 186
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element11 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element11).Tapped += this.starbtn_Tapped;
                }
                break;
            case 12: // Views\Team.xaml line 89
                {
                    this.splitline = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 13: // Views\Team.xaml line 92
                {
                    this.teamdetailssp = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 14: // Views\Team.xaml line 94
                {
                    this.subteamview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.subteamview).ItemClick += this.Mainteamview_ItemClick;
                }
                break;
            case 15: // Views\Team.xaml line 108
                {
                    this.noteam = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Views\Team.xaml line 113
                {
                    this.tmemeberssearch = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.tmemeberssearch).TextChanged += this.tmemeberssearch_TextChanged;
                }
                break;
            case 17: // Views\Team.xaml line 114
                {
                    this.teamheadview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.teamheadview).ItemClick += this.teamheadview_ItemClick;
                }
                break;
            case 18: // Views\Team.xaml line 144
                {
                    this.detailedteamview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.detailedteamview).ItemClick += this.detailedteamview_ItemClick;
                }
                break;
            case 22: // Views\Team.xaml line 158
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element22 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element22).Tapped += this.starbtn_Tapped;
                }
                break;
            case 26: // Views\Team.xaml line 131
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element26 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element26).Tapped += this.starbtn_Tapped;
                }
                break;
            case 29: // Views\Team.xaml line 53
                {
                    this.Backarrow = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.Backarrow).Tapped += this.Backarrow_Tapped;
                }
                break;
            case 30: // Views\Team.xaml line 58
                {
                    this.parentteamdetails = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 35: // Views\Team.xaml line 19
                {
                    this.tnamesearch = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.tnamesearch).TextChanged += this.tnamesearch_TextChanged;
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

