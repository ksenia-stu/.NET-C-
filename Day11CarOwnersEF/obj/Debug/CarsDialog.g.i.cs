﻿#pragma checksum "..\..\CarsDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CC7229F15977C6897838BCA9AEBAF3447E084ABD027D93D3E99D3EF76F548FED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Day11CarOwnersEF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Day11CarOwnersEF {
    
    
    /// <summary>
    /// CarsDialog
    /// </summary>
    public partial class CarsDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\CarsDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstCars;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CarsDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblOwnerName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CarsDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCarId;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\CarsDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMakeModel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\CarsDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddCar;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\CarsDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btUpdateCar;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\CarsDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDeleteCar;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\CarsDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDone;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Day11CarOwnersEF;component/carsdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CarsDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lstCars = ((System.Windows.Controls.ListView)(target));
            
            #line 10 "..\..\CarsDialog.xaml"
            this.lstCars.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lstCars_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblOwnerName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblCarId = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.tbMakeModel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btAddCar = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\CarsDialog.xaml"
            this.btAddCar.Click += new System.Windows.RoutedEventHandler(this.btAddCar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btUpdateCar = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\CarsDialog.xaml"
            this.btUpdateCar.Click += new System.Windows.RoutedEventHandler(this.btUpdateCar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btDeleteCar = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\CarsDialog.xaml"
            this.btDeleteCar.Click += new System.Windows.RoutedEventHandler(this.btDeleteCar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btDone = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\CarsDialog.xaml"
            this.btDone.Click += new System.Windows.RoutedEventHandler(this.btDone_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

