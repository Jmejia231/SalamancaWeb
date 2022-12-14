using System.Collections.Generic;

namespace SalamancaWeb.Helpers {
    public class OptionHelpers {
        public string controller { get; set; }

        public string route { get; set; }

        public string icon { get; set; }

        public string option { get; set; }

        public bool showOption { get; set; }

        public List<int> accessLevel { get; set; }


        public OptionHelpers(string controller, string route, string icon, string option, bool showOption, List<int> accessLevel) {
            this.controller = controller;
            this.route = route;
            this.icon = icon;
            this.option = option;
            this.showOption = showOption;
            this.accessLevel = accessLevel;
        }

        public OptionHelpers(string controller, string route, string icon, string option, bool showOption) {
            this.controller = controller;
            this.route = route;
            this.icon = icon;
            this.option = option;
            this.showOption = showOption;
        }

        public OptionHelpers(string route, string icon, string option, bool showOption) {
            this.route = route;
            this.icon = icon;
            this.option = option;
            this.showOption = showOption;
        }

        public OptionHelpers(string route, string icon, string option, bool showOption, List<int> accessLevel) : this(route, icon, option, showOption) {
            this.accessLevel = accessLevel;
        }
    }
}