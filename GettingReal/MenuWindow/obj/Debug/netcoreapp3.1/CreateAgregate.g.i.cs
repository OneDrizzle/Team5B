﻿#pragma checksum "..\..\..\CreateAgregate.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13F2FABADB2EDD7DE75C5D6218E2A836C2A52BAA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MenuWindow;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MenuWindow {
    
    
    /// <summary>
    /// CreateAgregatWindow
    /// </summary>
    public partial class CreateAgregatWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GetCustomer;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GetBuilding;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GetOrderNumber;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GetInfoSheet;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AddCustomer;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AddBuilding;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_FindAgregateInfoFile;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_saveNewAgregat;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\CreateAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_Error;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MenuWindow;component/createagregate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateAgregate.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GetCustomer = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.GetBuilding = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.GetOrderNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\CreateAgregate.xaml"
            this.GetOrderNumber.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.GetOrderNumber_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GetInfoSheet = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btn_AddCustomer = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.btn_AddBuilding = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btn_FindAgregateInfoFile = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\CreateAgregate.xaml"
            this.btn_FindAgregateInfoFile.Click += new System.Windows.RoutedEventHandler(this.btn_FindAgregateInfoFile_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\CreateAgregate.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.Button_back_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_saveNewAgregat = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\CreateAgregate.xaml"
            this.btn_saveNewAgregat.Click += new System.Windows.RoutedEventHandler(this.btn_saveNewAgregat_Click_);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lbl_Error = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

