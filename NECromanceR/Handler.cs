using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public abstract class Handler {
        protected IList<object> items;
        public IList<object> Items {
            get { return items; }
            set { items = value; }
        }

        protected Handler () {
            items = new List<object>();
        }

        protected Handler ( IList<object> items ) {
            this.items = new List<object>( items );
        }
        
    }
}
