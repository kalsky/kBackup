﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kBackup.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Normal")]
        public global::System.Windows.Forms.FormWindowState windowState {
            get {
                return ((global::System.Windows.Forms.FormWindowState)(this["windowState"]));
            }
            set {
                this["windowState"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Windows.Forms.PictureBox pbAvatar {
            get {
                return ((global::System.Windows.Forms.PictureBox)(this["pbAvatar"]));
            }
            set {
                this["pbAvatar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string dataFolder {
            get {
                return ((string)(this["dataFolder"]));
            }
            set {
                this["dataFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string userFolder {
            get {
                return ((string)(this["userFolder"]));
            }
            set {
                this["userFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://{0}.zendesk.com/api/v2/users/me.json")]
        public string userApi {
            get {
                return ((string)(this["userApi"]));
            }
            set {
                this["userApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://{0}.zendesk.com/api/v2/help_center/categories.json")]
        public string categoryApi {
            get {
                return ((string)(this["categoryApi"]));
            }
            set {
                this["categoryApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://{0}.zendesk.com/api/v2/help_center/sections.json")]
        public string sectionApi {
            get {
                return ((string)(this["sectionApi"]));
            }
            set {
                this["sectionApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://{0}.zendesk.com/api/v2/help_center/sections/{1}/articles.json")]
        public string articleApi {
            get {
                return ((string)(this["articleApi"]));
            }
            set {
                this["articleApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://{0}.zendesk.com/api/v2/help_center/articles/{1}/comments.json")]
        public string articleCommentApi {
            get {
                return ((string)(this["articleCommentApi"]));
            }
            set {
                this["articleCommentApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://{0}.zendesk.com/api/v2/community/topics.json")]
        public string topicApi {
            get {
                return ((string)(this["topicApi"]));
            }
            set {
                this["topicApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://{0}.zendesk.com/api/v2/community/topics/{1}/posts.json")]
        public string postApi {
            get {
                return ((string)(this["postApi"]));
            }
            set {
                this["postApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://{0}.zendesk.com/api/v2/community/posts/{1}/comments.json")]
        public string postCommentApi {
            get {
                return ((string)(this["postCommentApi"]));
            }
            set {
                this["postCommentApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string domain {
            get {
                return ((string)(this["domain"]));
            }
            set {
                this["domain"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string email {
            get {
                return ((string)(this["email"]));
            }
            set {
                this["email"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string password {
            get {
                return ((string)(this["password"]));
            }
            set {
                this["password"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool rememberMe {
            get {
                return ((bool)(this["rememberMe"]));
            }
            set {
                this["rememberMe"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("pheK6CfevU84UCYa36erqBY68MeRTtnyVXg7mjhZvRXnWK7yQTp6xMTnF2nGbzpKVvk4gN74")]
        public string encryptPassword {
            get {
                return ((string)(this["encryptPassword"]));
            }
        }
    }
}
