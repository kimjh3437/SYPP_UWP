﻿#pragma checksum "C:\Users\kimjh\Desktop\SYPP\SYPP\SYPP\View\Application\ApplicationsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "90D60B36996880952D57B5CA04BA32CA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SYPP.View.Application
{
    partial class ApplicationsPage : 
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
            case 2: // View\Application\ApplicationsPage.xaml line 19
                {
                    this.New_Application_Popup = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                    ((global::Windows.UI.Xaml.Controls.Primitives.Popup)this.New_Application_Popup).Closed += this.New_Application_Popup_Closed;
                }
                break;
            case 3: // View\Application\ApplicationsPage.xaml line 39
                {
                    this.New_Task_Popup = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                    ((global::Windows.UI.Xaml.Controls.Primitives.Popup)this.New_Task_Popup).Closed += this.New_Application_Popup_Closed;
                }
                break;
            case 4: // View\Application\ApplicationsPage.xaml line 67
                {
                    this.Hide_Weekly_Schedule_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Hide_Weekly_Schedule_Button).Click += this.Hide_Weekly_Schedule_Button_Click;
                }
                break;
            case 5: // View\Application\ApplicationsPage.xaml line 104
                {
                    this.Weekly_Schedule_Calendar_GridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 6: // View\Application\ApplicationsPage.xaml line 282
                {
                    this.Display_Weekly_Schedule_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Display_Weekly_Schedule_Button).Click += this.Display_Weekly_Schedule_Button_Click;
                }
                break;
            case 7: // View\Application\ApplicationsPage.xaml line 775
                {
                    this.Application_Detail_Frame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 8: // View\Application\ApplicationsPage.xaml line 347
                {
                    this.NewApplication_Button_PopUp = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 9: // View\Application\ApplicationsPage.xaml line 547
                {
                    this.Applications_GridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 10: // View\Application\ApplicationsPage.xaml line 555
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.Application_Button_Click;
                }
                break;
            case 11: // View\Application\ApplicationsPage.xaml line 573
                {
                    global::Windows.UI.Xaml.Controls.Image element11 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)element11).Tapped += this.IsFavorite_Star_Image_Tapped;
                }
                break;
            case 12: // View\Application\ApplicationsPage.xaml line 731
                {
                    global::Windows.UI.Xaml.Controls.Image element12 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)element12).Tapped += this.Application_Result_Add_Image_Tapped;
                }
                break;
            case 13: // View\Application\ApplicationsPage.xaml line 714
                {
                    global::Windows.UI.Xaml.Controls.Frame element13 = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)element13).Tapped += this.Result_Status_Frame_Tapped;
                }
                break;
            case 14: // View\Application\ApplicationsPage.xaml line 692
                {
                    global::Windows.UI.Xaml.Controls.Button element14 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element14).Click += this.Application_MidTask_Add_Button_Click;
                }
                break;
            case 16: // View\Application\ApplicationsPage.xaml line 660
                {
                    global::Windows.UI.Xaml.Controls.Frame element16 = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)element16).Tapped += this.Application_MidTask_Status_Frame_Tapped;
                }
                break;
            case 17: // View\Application\ApplicationsPage.xaml line 624
                {
                    global::Windows.UI.Xaml.Controls.Frame element17 = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)element17).Tapped += this.HasApplied_Status_Frame_Tapped;
                }
                break;
            case 19: // View\Application\ApplicationsPage.xaml line 406
                {
                    global::Windows.UI.Xaml.Controls.Button element19 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element19).Click += this.Category_Type_Button_Click;
                }
                break;
            case 20: // View\Application\ApplicationsPage.xaml line 429
                {
                    global::Windows.UI.Xaml.Controls.Primitives.Popup element20 = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                    ((global::Windows.UI.Xaml.Controls.Primitives.Popup)element20).Closed += this.Category_Filter_Type_List_PopUp_Closed;
                }
                break;
            case 21: // View\Application\ApplicationsPage.xaml line 440
                {
                    global::Windows.UI.Xaml.Controls.Button element21 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element21).Click += this.Category_Specific_Button_Click;
                }
                break;
            case 22: // View\Application\ApplicationsPage.xaml line 353
                {
                    this.New_Application_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.New_Application_Button).Click += this.New_Application_Button_Click;
                }
                break;
            case 23: // View\Application\ApplicationsPage.xaml line 304
                {
                    this.Display_Hide_Button = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24: // View\Application\ApplicationsPage.xaml line 238
                {
                    this.Active_Applications_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Active_Applications_Button).Click += this.Active_Applications_Button_Click;
                }
                break;
            case 25: // View\Application\ApplicationsPage.xaml line 258
                {
                    this.Archived_Applications_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Archived_Applications_Button).Click += this.Archived_Applications_Button_Click;
                }
                break;
            case 28: // View\Application\ApplicationsPage.xaml line 145
                {
                    global::Windows.UI.Xaml.Controls.Grid element28 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)element28).Tapped += this.Each_Calendar_Event_Tapped;
                }
                break;
            case 29: // View\Application\ApplicationsPage.xaml line 159
                {
                    global::Windows.UI.Xaml.Controls.Image element29 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)element29).Tapped += this.Icon_Favorite_Tapped;
                }
                break;
            case 30: // View\Application\ApplicationsPage.xaml line 88
                {
                    this.Hide_Button_TextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 31: // View\Application\ApplicationsPage.xaml line 49
                {
                    this.New_Task_Frame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 32: // View\Application\ApplicationsPage.xaml line 29
                {
                    this.New_Application_Frame = (global::Windows.UI.Xaml.Controls.Frame)(target);
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

