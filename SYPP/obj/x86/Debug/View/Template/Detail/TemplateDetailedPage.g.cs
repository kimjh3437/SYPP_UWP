﻿#pragma checksum "C:\Users\kimjh\Desktop\SYPP\SYPP\SYPP\View\Template\Detail\TemplateDetailedPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B69B2A1BB7582CCBE0EC2B18986E50D2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SYPP.View.Template
{
    partial class TemplateDetailedPage : 
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
            case 2: // View\Template\Detail\TemplateDetailedPage.xaml line 21
                {
                    this.Title_TextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.Title_TextBox).TextChanged += this.Title_TextBox_TextChanged;
                }
                break;
            case 3: // View\Template\Detail\TemplateDetailedPage.xaml line 37
                {
                    this.Plus_Customizable_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 4: // View\Template\Detail\TemplateDetailedPage.xaml line 65
                {
                    this.Template_TextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.Template_TextBox).TextChanged += this.Template_TextBox_TextChanged;
                }
                break;
            case 5: // View\Template\Detail\TemplateDetailedPage.xaml line 79
                {
                    this.SaveOrCopy_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SaveOrCopy_Button).Click += this.SaveOrCopy_Button_Click;
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

