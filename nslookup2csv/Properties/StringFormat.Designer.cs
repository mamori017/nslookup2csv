﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace nslookup2csv.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
    public sealed partial class StringFormat : global::System.Configuration.ApplicationSettingsBase {
        
        private static StringFormat defaultInstance = ((StringFormat)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new StringFormat())));
        
        public static StringFormat Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("==============================\r\n         nslookup2csv\r\n Copyright (C) 2018 mamori" +
            "017\r\n==============================")]
        public string Title {
            get {
                return ((string)(this["Title"]));
            }
            set {
                this["Title"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Parameter error")]
        public string ParameterError {
            get {
                return ((string)(this["ParameterError"]));
            }
            set {
                this["ParameterError"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Target : {0}")]
        public string Target {
            get {
                return ((string)(this["Target"]));
            }
            set {
                this["Target"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Finish")]
        public string Finish {
            get {
                return ((string)(this["Finish"]));
            }
            set {
                this["Finish"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Output : {0}")]
        public string Output {
            get {
                return ((string)(this["Output"]));
            }
            set {
                this["Output"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\{0}.csv\"")]
        public string FileName {
            get {
                return ((string)(this["FileName"]));
            }
            set {
                this["FileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Target\\tServer\\tAddress\\tName\\tAddress")]
        public string OutputHeader {
            get {
                return ((string)(this["OutputHeader"]));
            }
            set {
                this["OutputHeader"] = value;
            }
        }
    }
}
