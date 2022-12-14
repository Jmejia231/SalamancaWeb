using System.Collections.Generic;

namespace SalamancaWeb.Helpers {
    public class GroupHelpers {
        public string name { get; set; }

        public List<OptionHelpers> options { get; set; }

        public GroupHelpers(string name, List<OptionHelpers> options) {
            this.name = name;
            this.options = options;
        }
    }

}
