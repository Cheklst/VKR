﻿#pragma checksum "..\..\..\Windows\Autorization.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FCF001B2D959AB175C502DC6140DB4FD84AEB42B11993204D3EF639B5F881FA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ComputerShop.Windows;
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


namespace ComputerShop.Windows {
    
    
    /// <summary>
    /// Autorization
    /// </summary>
    public partial class Autorization : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Windows\Autorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLogin;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Windows\Autorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbPassword;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\Autorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPass;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\Autorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/ComputerShop;component/windows/autorization.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\Autorization.xaml"
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
            this.tbLogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\Windows\Autorization.xaml"
            this.tbLogin.GotFocus += new System.Windows.RoutedEventHandler(this.tbLogin_GotFocus);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\Windows\Autorization.xaml"
            this.tbLogin.LostFocus += new System.Windows.RoutedEventHandler(this.tbLogin_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pbPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 25 "..\..\..\Windows\Autorization.xaml"
            this.pbPassword.LostFocus += new System.Windows.RoutedEventHandler(this.pbPassword_LostFocus);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\Windows\Autorization.xaml"
            this.pbPassword.GotFocus += new System.Windows.RoutedEventHandler(this.pbPassword_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPass = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Windows\Autorization.xaml"
            this.btnPass.Click += new System.Windows.RoutedEventHandler(this.btnPass_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Windows\Autorization.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

