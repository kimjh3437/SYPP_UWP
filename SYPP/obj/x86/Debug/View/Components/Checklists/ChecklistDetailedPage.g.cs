﻿#pragma checksum "C:\Users\kimjh\Desktop\SYPP\SYPP\SYPP\View\Components\Checklists\ChecklistDetailedPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "76023741A42C86017C55E478F7ADFEBB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SYPP.View.Components.Checklists
{
    partial class ChecklistDetailedPage : 
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
            case 2: // View\Components\Checklists\ChecklistDetailedPage.xaml line 125
                {
                    this.UserControl = (global::Windows.UI.Xaml.Controls.UserControl)(target);
                }
                break;
            case 3: // View\Components\Checklists\ChecklistDetailedPage.xaml line 141
                {
                    this.Delete_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Delete_Button).Click += this.Delete_Button_Click;
                }
                break;
            case 4: // View\Components\Checklists\ChecklistDetailedPage.xaml line 159
                {
                    this.Save_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Save_Button).Click += this.Save_Button_Click;
                }
                break;
            case 5: // View\Components\Checklists\ChecklistDetailedPage.xaml line 177
                {
                    this.Cancel_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Cancel_Button).Click += this.Cancel_Button_Click;
                }
                break;
            case 7: // View\Components\Checklists\ChecklistDetailedPage.xaml line 71
                {
                    global::Windows.UI.Xaml.Controls.Frame element7 = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)element7).Tapped += this.Checklist_Option_Tapped;
                }
                break;
            case 8: // View\Components\Checklists\ChecklistDetailedPage.xaml line 84
                {
                    global::Windows.UI.Xaml.Controls.TextBox element8 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element8).KeyDown += this.Checklist_Content_TextBox_KeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)element8).TextChanged += this.Checklist_Content_TextBox_TextChanged;
                }
                break;
            case 9: // View\Components\Checklists\ChecklistDetailedPage.xaml line 31
                {
                    this.Title_TextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.Title_TextBox).TextChanged += this.Title_TextBox_TextChanged;
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

